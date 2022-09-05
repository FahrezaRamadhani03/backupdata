// <copyright file="UserUnitController.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.Common.Dtos.Responses;
using Garuda.Modules.Common.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Garuda.Modules.Common.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/user-unit")]
    public class UserUnitController : Controller
    {
        private readonly IUserUnitServices _iServices;

        public UserUnitController(IUserUnitServices iServices)
        {
            _iServices = iServices;
        }

        /// <summary>
        /// Get User Mine Head by UnitId
        /// </summary>
        /// <param name="unitId"></param>
        /// <returns>A <see cref="UserResponses"/> representing the asynchronous operation.</returns>
        [HttpGet]
        [Route("units/{unitId}")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(UserResponses))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.UNAUTHORIZED, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetMineHead(Guid unitId)
        {
            var unit = await _iServices.GetUserByMineHead(unitId);
            return Ok(unit);
        }
    }
}
