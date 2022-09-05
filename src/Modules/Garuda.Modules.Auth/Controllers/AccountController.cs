// <copyright file="AccountController.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Dtos.Responses;
using Garuda.Infrastructure.Exceptions;
using Garuda.Infrastructure.Helpers;
using Garuda.Modules.Auth.Services.Contracts;
using Garuda.Modules.Common.Dtos.Requests;
using Garuda.Modules.Common.Dtos.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Garuda.Modules.Auth.Controllers
{
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly IAccountServices _accountServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="accountServices"></param>
        public AccountController(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }

        /// <summary>
        /// API to request password reset
        /// </summary>
        /// <param name="model">
        /// {
        /// "email" : "email",
        /// }
        /// </param>
        [HttpPost]
        [Route("req-reset-password")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(LoginResponses))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.INACTIVE, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.UNAUTHORIZED, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.WRONG_CREDENTIAL, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST)]
        public async Task<IActionResult> RequestReset([FromBody] ReqResetPasswordRequests model)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException();
            }

            var result = await _accountServices.RequestResetPassword(model);
            return Ok(result);
        }


        /// <summary>
        /// API to reset password
        /// </summary>
        [HttpPost]
        [Route("reset-password")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(LoginResponses))]
        [ProducesResponseType(Codes.INACTIVE, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.UNAUTHORIZED, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.WRONG_CREDENTIAL, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST)]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequests model)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException();
            }

            var result = await _accountServices.ResetPassword(model);
            return Ok(result);
        }
    }
}
