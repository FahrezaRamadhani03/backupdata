// <copyright file="IJwtFactory.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Microsoft.AspNetCore.Http;

namespace Garuda.Infrastructure.Contracts
{
    /// <summary>
    /// Interface JWT Factory Contracts
    /// </summary>
    public interface IJwtFactory : IServiceRepository
    {
        /// <summary>
        /// Get Session
        /// </summary>
        /// <param name="context"></param>
        /// <returns>A <see cref="SessionDto"/> representing the asynchronous operation.</returns>
        Task<SessionDto> GetSession(HttpContext context);

        /// <summary>
        /// Create Token Async
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userType"></param>
        /// <param name="fullName"></param>
        /// <param name="appName"></param>
        /// <returns>A <see cref="SessionTokenDto"/> representing the asynchronous operation.</returns>
        Task<SessionTokenDto> CreateTokenAsync(Guid userId, string userType, string fullName, string appName);

        /// <summary>
        /// Read Session token.
        /// </summary>
        /// <param name="sessionToken"></param>
        /// <returns>A <see cref="SessionDto"/> representing the asynchronous operation.</returns>
        Task<SessionDto> ReadSessionToken(string sessionToken);

        /// <summary>
        /// Revoke Session
        /// </summary>
        /// <param name="session"></param>
        /// <returns><see cref="bool"/> true/false</returns>
        Task<bool> Revoke(SessionDto session);

        /// <summary>
        /// Refresh Sesssion
        /// </summary>
        /// <param name="session"></param>
        /// <param name="refreshToken"></param>
        /// <returns>A <see cref="SessionTokenDto"/> representing the asynchronous operation.</returns>
        Task<SessionTokenDto> RefreshSession(SessionDto session, string refreshToken);

        /// <summary>
        /// Generate Jti
        /// </summary>
        /// <returns>A <see cref="string"/> new Jti.</returns>
        Task<string> GenerateJti();

        /// <summary>
        /// Verify Session Token.
        /// </summary>
        /// <param name="sessionToken"></param>
        /// <returns>A <see cref="SessionDto"/> representing the asynchronous operation.</returns>
        Task<SessionDto> VerifySessionTokenWithoutExpiryCheck(string sessionToken);
    }
}
