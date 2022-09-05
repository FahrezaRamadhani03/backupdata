// <copyright file="UnitController.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Collections.Generic;
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
    [Route("api/units")]
    public class UnitController : Controller
    {
        private readonly IUnitServices _iServices;

        public UnitController(IUnitServices iServices)
        {
            _iServices = iServices;
        }

        /// <summary>
        /// Get List Unit Data
        /// </summary>
        /// <returns>A <see cref="List{UnitDto}"/> representing the asynchronous operation.</returns>
        [HttpGet]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(List<UnitResponses>))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.UNAUTHORIZED, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetUnits()
        {
            var datas = await _iServices.GetData(true);
            return Ok(datas);
        }
    }
}
