// <copyright file="UserController.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.Common.Dtos.Requests;
using Garuda.Modules.Common.Dtos.Responses;
using Garuda.Modules.Common.Models.Datas;
using Garuda.Modules.Common.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Garuda.Modules.Common.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly IMenuServices _menuServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userServices"></param>
        /// <param name="menuServices"></param>
        public UserController(
            IUserServices userServices,
            IMenuServices menuServices)
        {
            _userServices = userServices;
            _menuServices = menuServices;
        }

        /// <summary>
        /// Get list of active users.
        /// </summary>
        /// <returns>A <see cref="UsersResponses"/> representing the asynchronous operation.</returns>
        [HttpGet]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(List<UsersResponses>))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetListUser(SieveModel model)
        {
            if (model.Page.HasValue && model.PageSize.HasValue)
            {
                var result = await _userServices.GetPagedListUser(model);
                return Ok(result);
            }
            else
            {
                var result = await _userServices.GetListUser(model);
                return Ok(result);
            }
        }

        /// <summary>
        /// Create new QPB user
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpPost]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequests model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userServices.CreateUser(model);
            return Ok(result);
        }

        /// <summary>
        /// Edit user Qpb
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST)]
        public async Task<IActionResult> EditUser([FromRoute] Guid id, [FromBody] EditUserRequests model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userServices.EditUser(id, model);
            return Ok(result);
        }

        /// <summary>
        /// Get user profile.
        /// </summary>
        /// <returns>A <see cref="UserProfileResponses"/> representing the asynchronous operation.</returns>
        [HttpGet]
        [Route("me")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(UserProfileResponses))]
        [ProducesResponseType(Codes.UNAUTHORIZED, Type = typeof(MessageDto))]
        public async Task<UserProfileResponses> GetUserProfile()
        {
            var result = await _userServices.GetUserProfile(this.HttpContext);
            return result;
        }

        /// <summary>
        /// Get AD user by username.
        /// </summary>
        /// <returns>A <see cref="UsersResponses"/> representing the asynchronous operation.</returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("{username}")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(UsersResponses))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetADUser(string username)
        {
            var result = await _userServices.GetADUser(username);
            return Ok(result);
        }

        /// <summary>
        /// Get Menu by User Login
        /// </summary>
        /// <returns>A <see cref="List{MenuResponses}"/> representing the asynchronous operation.</returns>
        [HttpGet]
        [Route("menu")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(UserResponses))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.UNAUTHORIZED, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetMenu()
        {
            var result = await _menuServices.GetMenu(this.HttpContext);
            return Ok(result);
        }
    }
}
