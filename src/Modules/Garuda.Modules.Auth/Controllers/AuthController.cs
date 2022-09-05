// <copyright file="AuthController.cs" company="CV Garuda Infinity Kreasindo">
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
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IAuthServices _authServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="authServices"></param>
        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        /// <summary>
        /// Login Apps.
        /// </summary>
        /// <param name="model">
        /// {
        /// "username" : "username",
        /// "password" : "password",
        /// }
        /// </param>
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(LoginResponses))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.INACTIVE, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.UNAUTHORIZED, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.WRONG_CREDENTIAL, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST)]
        public async Task<IActionResult> Login([FromBody] LoginRequests model)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException();
            }

            var result = await _authServices.Login(model);
            return Ok(result);
        }

        /// <summary>
        /// Logout from Apps.
        /// </summary>
        [Authorize]
        [HttpPost]
        [Route("logout")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.UNAUTHORIZED, Type = typeof(MessageDto))]
        public async Task<IActionResult> LogOffRequest()
        {
            var result = await _authServices.LogOff(HttpContext);
            return Ok(result);
        }

        /// <summary>
        /// Get refresh token from user session
        /// </summary>
        /// <param name="model">
        /// {
        /// "Token" : "token",
        /// "RefreshToken" : "refreshtoken",
        /// }
        [Authorize]
        [HttpPut]
        [Route("refresh-token")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(SessionTokenDto))]
        [ProducesResponseType(Codes.UNAUTHORIZED, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.INVALID_SESSION, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetRefreshToken([FromBody] RefreshTokenRequests model)
        {
            var result = await _authServices.GetRefreshToken(HttpContext, model);
            return Ok(result);
        }
    }
}
