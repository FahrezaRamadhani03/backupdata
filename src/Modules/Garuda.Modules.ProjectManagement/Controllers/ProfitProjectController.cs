// <copyright file="ProfitProjectController.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Responses.ProfitProject;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Garuda.Modules.ProjectManagement.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/profit-projects")]
    public class ProfitProjectController : Controller
    {
        private readonly IProfitProjectServices _iService;

        public ProfitProjectController(IProfitProjectServices iService)
        {
            _iService = iService;
        }

        /// <summary>
        /// Get Profit Project.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(ProfitProjectResponses))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetDatas(SieveModel model, int year)
        {
            var success = await _iService.GetDatas(model, year);

            return Ok(success);
        }

        /// <summary>
        /// Get years.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet("years")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(List<int>))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetDatas()
        {
            var success = await _iService.GetYear();

            return Ok(success);
        }
    }
}
