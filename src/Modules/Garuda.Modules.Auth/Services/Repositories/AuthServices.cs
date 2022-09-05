// <copyright file="AuthServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Ldap.Contracts;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Contracts;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;
using Garuda.Infrastructure.Helpers;
using Garuda.Modules.Auth.Services.Contracts;
using Garuda.Modules.Common.Dtos.Requests;
using Garuda.Modules.Common.Dtos.Responses;
using Garuda.Modules.Common.Models.Contracts;
using Garuda.Modules.Common.Models.Datas;
using Garuda.Modules.Email.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Garuda.Modules.Auth.Services.Repositories
{
    public class AuthServices : IAuthServices
    {
        private readonly IStorage _iStorage;
        private readonly ILogger _logger;
        private readonly IJwtFactory _jwt;
        private readonly IEmailSender _emailSender;

        public AuthServices(
            IStorage iStorage,
            ILogger<AuthServices> logger,
            IJwtFactory jwt,
            IEmailSender emailSender)
        {
            _iStorage = iStorage;
            _logger = logger;
            _jwt = jwt;
            _emailSender = emailSender;
        }

        public async Task<LoginResponses> Login(LoginRequests model)
        {
            try
            {
                _logger.LogInformation("User logging in.");

                _logger.LogInformation("Getting user data from database..");
                var user = await _iStorage.GetRepository<IUserRepository>().GetData(model.Username);

                if (user != null)
                {
                    if (user.IsActive == false)
                    {
                        throw ErrorConstant.INACTIVE_USER;
                    }

                    if (!model.Password.VerifyPassword(user.Password))
                    {
                        throw ErrorConstant.INVALID_USERNAME;
                    }

                    // Handle Jwt
                    _logger.LogInformation("Creating user token..");

                    // Tinggal dirubah sesuai kebutuhan login
                    var token = await _jwt.CreateTokenAsync(user.Id, "Administrator", user.Username, "module");

                    return new LoginResponses()
                    {
                        RefreshToken = token.RefreshToken,
                        Token = token.Token,
                        UserId = user.Id,
                    };
                }
                else
                {
                    throw ErrorConstant.INVALID_USERNAME;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<MessageDto> LogOff(HttpContext httpContext)
        {
            _logger.LogInformation("Getting user session..");
            var session = await _jwt.GetSession(httpContext);
            var revoked = await _jwt.Revoke(session);
            if (revoked)
            {
                _logger.LogInformation("User logged out.");
                return new MessageDto("You've been logged out");
            }
            else
            {
                throw new UnauthorizedException();
            }
        }

        public async Task<SessionTokenDto> GetRefreshToken(HttpContext httpContext, RefreshTokenRequests model)
        {
            SessionTokenDto sessiontoken;
            SessionDto session;

            try
            {
                if (model.Token == null && model.RefreshToken == null)
                {
                    session = await _jwt.GetSession(httpContext);
                }
                else
                {
                    session = await _jwt.ReadSessionToken(model.Token);
                }

                _logger.LogInformation("Getting user token fron database..");
                var result = await _iStorage.GetRepository<IUserSessionRepository>().GetRefreshToken(session.UserId, session.Jti, false);
                if (model.RefreshToken != null)
                {
                    if (result.RefreshToken != model.RefreshToken)
                    {
                        throw new UnauthorizedException();
                    }
                }
                else
                {
                    if (result.RefreshToken == null)
                    {
                        throw new UnauthorizedException();
                    }
                }

                _logger.LogInformation("Creating new user token..");
                sessiontoken = await _jwt.CreateTokenAsync(session.UserId, session.UserRole, session.FullName, "module");

                return new SessionTokenDto
                {
                    Token = sessiontoken.Token,
                    RefreshToken = sessiontoken.RefreshToken,
                    Jti = sessiontoken.Jti,
                };
            }
            catch
            {
                throw new InvalidSessionExceptions();
            }
        }
    }
}