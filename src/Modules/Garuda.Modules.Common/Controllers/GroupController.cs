// <copyright file="GroupController.cs" company="CV Garuda Infinity Kreasindo">
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
    [Route("api/groups")]
    public class GroupController : Controller
    {
        private readonly IGroupServices _iService;

        public GroupController(IGroupServices iService)
        {
            _iService = iService;
        }

        /// <summary>
        /// Get List Group Data.
        /// </summary>
        /// <returns>A <see cref="List{GroupDto}"/> representing the asynchronous operation.</returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(List<GroupResponses>))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.UNAUTHORIZED, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetData()
        {
            var datas = await _iService.GetData(true);
            return Ok(datas);
        }
    }
}
