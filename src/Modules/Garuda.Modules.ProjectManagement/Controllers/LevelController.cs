// <copyright file="LevelController.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Level;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Level;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Garuda.Modules.ProjectManagement.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/levels")]
    public class LevelController : Controller
    {
        private readonly ILevelServices _levelServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="LevelController"/> class.
        /// </summary>
        /// <param name="technologyServices"></param>
        public LevelController(ILevelServices levelServices)
        {
            _levelServices = levelServices;
        }

        /// <summary>
        /// Get list of level.
        /// </summary>
        /// <returns>A <see cref="LevelResponses"/> representing the asynchronous operation.</returns>
        [HttpGet]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(List<LevelResponses>))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetListLevel()
        {
            var result = await _levelServices.GetListLevel();
            return Ok(result);
        }

        /// <summary>
        /// Create new level user
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpPost]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST)]
        public async Task<IActionResult> CreateLevel([FromBody] CreateLevelRequests model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _levelServices.CreateLevel(model);
            return Ok(result);
        }
    }
}
