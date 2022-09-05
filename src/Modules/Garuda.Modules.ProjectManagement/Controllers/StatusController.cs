// <copyright file="StatusController.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Garuda.Modules.ProjectManagement.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/status")]
    public class StatusController : Controller
    {
        private readonly IStatusServices _iService;

        public StatusController(IStatusServices iService)
        {
            _iService = iService;
        }

        /// <summary>
        /// Get all Status Data.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(List<string>))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetDatas()
        {
            var success = await _iService.GetAllData();

            return Ok(success);
        }
    }
}
