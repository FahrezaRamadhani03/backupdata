// <copyright file="EmployeeController.cs" company="CV Garuda Infinity Kreasindo">
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
using Garuda.Modules.ProjectManagement.Dtos.Responses;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Garuda.Modules.Common.Controllers
{
    [Authorize]
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices _employeeServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        /// <param name="userServices"></param>
        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        /// <summary>
        /// Get list of employee.
        /// <paramref name="model"/>
        /// </summary>
        /// <returns>A <see cref="EmployeeResponses"/> representing the asynchronous operation.</returns>
        [HttpGet("developers")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(List<EmployeeResponses>))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetListEmployeeWithDevelopmentRole(SieveModel model)
        {
            var result = await _employeeServices.GetListEmployeeWithDevelopmentRole(model);
            return Ok(result);
        }

        /// <summary>
        /// Get list of employee.
        /// <paramref name="model"/>
        /// <paramref name="clientId"/>
        /// </summary>
        /// <returns>A <see cref="EmployeeResponses"/> representing the asynchronous operation.</returns>
        [HttpGet("scrum-teams")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(List<EmployeeResponses>))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetListEmployeeForScrumTeam(SieveModel model, int? clientId)
        {
            var result = await _employeeServices.GetListEmployeeForScrumTeam(model, clientId);
            return Ok(result);
        }
    }
}
