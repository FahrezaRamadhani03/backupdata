// <copyright file="IAccountServices.cs" company="CV Garuda Infinity Kreasindo">
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
    /// Account Services Contract
    /// </summary>
    public interface IAccountServices
    {
        /// <summary>
        /// Request Reset Password.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<MessageDto> RequestResetPassword(ReqResetPasswordRequests model);

        /// <summary>
        /// Reset Password.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<MessageDto> ResetPassword(ResetPasswordRequests model);
    }
}
