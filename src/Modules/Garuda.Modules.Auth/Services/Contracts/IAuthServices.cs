// <copyright file="IAuthServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.Common.Dtos.Requests;
using Garuda.Modules.Common.Dtos.Responses;
using Microsoft.AspNetCore.Http;

namespace Garuda.Modules.Auth.Services.Contracts
{
    /// <summary>
    /// Auth Services Contract
    /// </summary>
    public interface IAuthServices
    {
        /// <summary>
        /// Login Login by Ldap Configurations.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<LoginResponses> Login(LoginRequests model);

        /// <summary>
        /// Log off user login.
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns>A <see cref="Task{GlobalResponses}"/> representing the result of the asynchronous operation.</returns>
        Task<MessageDto> LogOff(HttpContext httpContext);

        /// <summary>
        /// Get user refresh token from session
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<SessionTokenDto> GetRefreshToken(HttpContext httpContext, RefreshTokenRequests model);
    }
}
