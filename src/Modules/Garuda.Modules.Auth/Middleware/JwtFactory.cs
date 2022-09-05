// <copyright file="JwtFactory.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Configurations;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Contracts;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.Common.Models.Contracts;
using Garuda.Modules.Common.Models.Datas;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Garuda.Modules.Auth.Middleware
{
    public class JwtFactory : IJwtFactory
    {
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly IStorage _iStorage;

        /// <summary>
        /// Initializes a new instance of the <see cref="JwtFactory"/> class.
        /// </summary>
        /// <param name="jwtOptions"></param>
        /// <param name="iStorage"></param>
        public JwtFactory(IOptions<JwtIssuerOptions> jwtOptions, IStorage iStorage)
        {
            _jwtOptions = jwtOptions.Value;
            _iStorage = iStorage;
        }

        public async Task<SessionDto> GetSession(HttpContext context)
        {
            string id = context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userType = context.User.FindFirst(ClaimTypes.Role).Value;
            var fullName = context.User.FindFirst(ClaimTypes.Name).Value;
            var appName = context.User.FindFirst(ClaimTypes.GroupSid).Value;
            var jti = context.User.FindFirst(JwtRegisteredClaimNames.Jti).Value;

            var activeRefreshToken = await FindActiveTokenByJti(jti);
            if (activeRefreshToken == null)
            {
                throw ErrorConstant.UNAUTHORIZED;
            }

            return new SessionDto()
            {
                UserId = Guid.Parse(id),
                UserRole = userType,
                FullName = fullName,
                Jti = jti,
                AppName = appName,
            };
        }

        public async Task<SessionTokenDto> CreateTokenAsync(Guid userId, string userType, string fullName, string appName)
        {
            var session = new SessionDto()
            {
                UserId = userId,
                UserRole = userType,
                AppName = appName,
                Jti = await GenerateJti(),
                FullName = fullName,
            };
            var sessionToken = CreateSessionToken(session);
            var refreshToken = await CreateRefreshToken(session);

            return new SessionTokenDto
            {
                Token = sessionToken.Item1,
                SessionExpiredAt = sessionToken.Item2,
                RefreshToken = refreshToken,
                Jti = session.Jti,
            };
        }

        public async Task<SessionDto> ReadSessionToken(string sessionToken)
        {
            var handler = new JwtSecurityTokenHandler();
            if (!handler.CanReadToken(sessionToken))
            {
                return null;
            }

            var token = handler.ReadJwtToken(sessionToken);

            var id = token.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var fullname = token.Claims.First(c => c.Type == ClaimTypes.Name).Value;
            var jti = token.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value;
            var userType = token.Claims.First(c => c.Type == ClaimTypes.Role).Value;
            var appName = token.Claims.First(c => c.Type == ClaimTypes.GroupSid).Value;

            return new SessionDto()
            {
                UserId = Guid.Parse(id),
                FullName = fullname,
                UserRole = userType,
                Jti = jti,
                AppName = appName,
            };
        }

        public async Task<bool> Revoke(SessionDto session)
        {
            var activeToken = await _iStorage.GetRepository<IUserSessionRepository>().GetRefreshToken(session.UserId, session.Jti, true);

            if (activeToken == null)
            {
                return false;
            }

            activeToken.DateRevoked = DateTime.UtcNow;
            await _iStorage.GetRepository<IUserSessionRepository>().AddOrUpdate(activeToken);
            await _iStorage.SaveAsync();

            return true;
        }

        public async Task<SessionTokenDto> RefreshSession(SessionDto session, string refreshToken)
        {
            var activeToken = await FindActiveTokenByJti(session.Jti);
            if (activeToken == null || activeToken.RefreshToken != refreshToken)
            {
                return null;
            }

            activeToken.DateRevoked = DateTime.UtcNow;
            await _iStorage.GetRepository<IUserSessionRepository>().AddOrUpdate(activeToken);
            await _iStorage.SaveAsync();

            //var profile = await GetProfileByUserIdAndRole(session.UserId, session.UserRole);
            var newToken = await CreateTokenAsync(session.UserId, session.UserRole, session.FullName, session.AppName);
            return newToken;
        }

        public async Task<string> GenerateJti()
        {
            await Task.Delay(10);
            return Guid.NewGuid().ToString();
        }

        public async Task<SessionDto> VerifySessionTokenWithoutExpiryCheck(string sessionToken)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOptions.SecretKey));

            var handler = new JwtSecurityTokenHandler();
            if (!handler.CanReadToken(sessionToken))
            {
                return null;
            }

            SecurityToken securityToken;
            var cliamsPrinciple = handler.ValidateToken(
                sessionToken,
                new TokenValidationParameters()
                {
                    RequireSignedTokens = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = authSigningKey,
                    AuthenticationType = SecurityAlgorithms.HmacSha256,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = true,
                    ValidateLifetime = false,
                },
                out securityToken);

            if (!handler.CanValidateToken)
            {
                return null;
            }

            string id = cliamsPrinciple.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userType = cliamsPrinciple.FindFirst(ClaimTypes.Role).Value;
            var fullName = cliamsPrinciple.FindFirst(ClaimTypes.Name).Value;
            var appName = cliamsPrinciple.FindFirst(ClaimTypes.GroupSid).Value;
            var jti = cliamsPrinciple.FindFirst(JwtRegisteredClaimNames.Jti).Value;

            var session = new SessionDto()
            {
                FullName = fullName,
                UserRole = userType,
                UserId = Guid.Parse(id),
                AppName = appName,
                Jti = jti,
            };

            return session;
        }

        /// <summary>
        /// Generate Refresh Token
        /// </summary>
        /// <returns><see cref="string"/>Rng Generator for RefreshToken</returns>
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        /// <summary>
        /// Create Session Token.
        /// </summary>
        /// <param name="session"></param>
        /// <returns><see cref="string"/> SessionToken</returns>
        /// <returns><see cref="DateTime"/> ExpiredAt</returns>
        private (string SessionToken, DateTime ExpiredAt) CreateSessionToken(SessionDto session)
        {
            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, session.FullName),
                new Claim(ClaimTypes.Role, session.UserRole),
                new Claim(ClaimTypes.NameIdentifier, session.UserId.ToString()),
                new Claim(ClaimTypes.GroupSid, session.AppName),
                new Claim(JwtRegisteredClaimNames.Jti, session.Jti),
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOptions.SecretKey));

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddMinutes(_jwtOptions.ExpirationTime),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

            var sessionToken = new JwtSecurityTokenHandler().WriteToken(token);

            return (sessionToken, token.ValidTo);
        }

        /// <summary>
        /// Create Refresh Token.
        /// </summary>
        /// <param name="session"></param>
        /// <returns><see cref="string"/>Refresh Token</returns>
        private async Task<string> CreateRefreshToken(SessionDto session)
        {
            UserSession refreshToken;
            var list = await FindAllActiveTokenByUserId(session.UserId);
            foreach (var item in list)
            {
                item.DateRevoked = DateTime.UtcNow;
                await _iStorage.GetRepository<IUserSessionRepository>().AddOrUpdate(item);
            }

            if (list.Any())
            {
                await _iStorage.SaveAsync();
            }

            refreshToken = new UserSession()
            {
                UserId = session.UserId,
                Jti = session.Jti,
                DateExpired = DateTime.UtcNow.AddDays(_jwtOptions.RefreshExpirationTime),
                RefreshToken = GenerateRefreshToken(),
            };

            await _iStorage.GetRepository<IUserSessionRepository>().AddOrUpdate(refreshToken);
            await _iStorage.SaveAsync();

            return refreshToken.RefreshToken;
        }

        /// <summary>
        /// Find ACtive Token Jti
        /// </summary>
        /// <param name="jti"></param>
        /// <returns><see cref="UserSession"/></returns>
        private async Task<UserSession> FindActiveTokenByJti(string jti)
        {
            var activeToken = await _iStorage.GetRepository<IUserSessionRepository>().GetRefreshToken(jti, false, DateTime.UtcNow);
            return activeToken;
        }

        /// <summary>
        /// Find All Active Token.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns><see cref="UserSession"/></returns>
        private async Task<List<UserSession>> FindAllActiveTokenByUserId(Guid userId)
        {
            var activeTokens = await _iStorage.GetRepository<IUserSessionRepository>().GetRefreshToken(userId, true, DateTime.UtcNow);
            return activeTokens;
        }

        /// <summary>
        /// Get Profile User and Role
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userRole"></param>
        /// <returns><see cref="ProfileDto"/></returns>
        private async Task<ProfileDto> GetProfileByUserIdAndRole(Guid userId, string userRole)
        {
            // Get user role.
            var user = new ProfileDto()
            {
                Email = string.Empty,
                FullName = string.Empty,
                PhoneNumber = string.Empty,
                PictureUrl = string.Empty,
                UserRole = string.Empty,
            };
            return user;
        }
    }
}
