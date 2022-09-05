// <copyright file="TechnologyController.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Technology;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Technology;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Garuda.Modules.ProjectManagement.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/technologies")]
    public class TechnologyController : Controller
    {
        private readonly ITechnologyServices _technologyServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="TechnologyController"/> class.
        /// </summary>
        /// <param name="technologyServices"></param>
        public TechnologyController(ITechnologyServices technologyServices)
        {
            _technologyServices = technologyServices;
        }

        /// <summary>
        /// Get list of technology.
        /// </summary>
        /// <returns>A <see cref="TechnologyResponses"/> representing the asynchronous operation.</returns>
        [HttpGet]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(List<TechnologyResponses>))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetListTechnology()
        {
            var result = await _technologyServices.GetListTechnology();
            return Ok(result);
        }

        /// <summary>
        /// Create new Technology user
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpPost]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST)]
        public async Task<IActionResult> CreateTechnology([FromBody] CreateTechnologyRequests model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _technologyServices.CreateTechnology(model);
            return Ok(result);
        }
    }
}
