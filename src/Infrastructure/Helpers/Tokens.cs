// <copyright file="Tokens.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Garuda.Infrastructure.Contracts;
using Garuda.Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Garuda.Infrastructure.Helpers
{
    public class Tokens
    {
        //public static async Task<string> GenerateJwtByClaims(ClaimsIdentity identity, IJwtFactory jwtFactory, string userName, JwtIssuerOptions jwtOptions, JsonSerializerSettings serializerSettings)
        //{
        //    var response = new
        //    {
        //        id = identity.Claims.Single(c => c.Type == "id").Value,
        //        auth_token = await jwtFactory.GenerateEncodedToken(userName, identity),
        //        expires_in = (int)jwtOptions.ValidFor.TotalSeconds,
        //    };

        //    return JsonConvert.SerializeObject(response, serializerSettings);
        //}

        //public static string EncryptPassword(string password)
        //{
        //    return BCrypt.Net.BCrypt.HashPassword(password);
        //}

        //public static bool VerifyPassword(string enteredPassword, string hashedPassword)
        //{
        //    return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
        //}

        //public static string GenerateJwtToken(int id, string fullname, string userRole, string module, string securityKey, double expirationDate)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var authClaims = new List<Claim>()
        //    {
        //        new Claim(ClaimTypes.Name, fullname),
        //        new Claim(ClaimTypes.Role, userRole),
        //        new Claim(ClaimTypes.NameIdentifier, id.ToString()),
        //        new Claim(ClaimTypes.GroupSid, module),
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //    };

        //    var authSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(securityKey));

        //    var token = new JwtSecurityToken(
        //        expires: DateTime.UtcNow.AddMinutes(expirationDate),
        //        claims: authClaims,
        //        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

        //    return tokenHandler.WriteToken(token);
        //}

        //public static ClaimsPrincipal GetPrincipalFromExpiredToken(string token, string securityKey)
        //{
        //    return VerifyToken(token, securityKey, false);
        //}

        //public static bool Verify(string token, string secretKey)
        //{
        //    var authSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

        //    var handler = new JwtSecurityTokenHandler();
        //    if (!handler.CanReadToken(token))
        //    {
        //        return false;
        //    }

        //    SecurityToken securityToken;
        //    var cliamsPrinciple = handler.ValidateToken(
        //        token,
        //        new TokenValidationParameters()
        //        {
        //            RequireSignedTokens = true,
        //            ValidateIssuerSigningKey = true,
        //            IssuerSigningKey = authSigningKey,
        //            AuthenticationType = SecurityAlgorithms.HmacSha256,
        //            ValidateIssuer = false,
        //            ValidateAudience = false,
        //            RequireExpirationTime = true,
        //            ValidateLifetime = false,
        //        },
        //        out securityToken);

        //    if (!handler.CanValidateToken)
        //    {
        //        return false;
        //    }

        //    string id = cliamsPrinciple.FindFirst(ClaimTypes.NameIdentifier).Value;
        //    var userType = cliamsPrinciple.FindFirst(ClaimTypes.Role).Value;
        //    var fullName = cliamsPrinciple.FindFirst(ClaimTypes.Name).Value;
        //    var appName = cliamsPrinciple.FindFirst(ClaimTypes.GroupSid).Value;
        //    var jti = cliamsPrinciple.FindFirst(JwtRegisteredClaimNames.Jti).Value;
        //    return true;
        //}

        //public static ClaimsPrincipal VerifyToken(string token, string securityKey, bool validateLifeTime = true)
        //{
        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        //    var tokenValidationParameters = new TokenValidationParameters
        //    {
        //        ValidateAudience = false,
        //        ValidateIssuer = false,
        //        ValidateIssuerSigningKey = true,
        //        IssuerSigningKey = key,
        //        ValidateLifetime = validateLifeTime,
        //    };

        //    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        //    var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

        //    if (!(securityToken as JwtSecurityToken).Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        //    {
        //        throw new SecurityTokenException("Invalid token");
        //    }

        //    return principal;
        //}
    }
}
