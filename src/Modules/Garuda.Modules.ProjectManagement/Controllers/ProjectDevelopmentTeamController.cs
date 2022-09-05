// <copyright file="ProjectDevelopmentTeamController.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentTeam;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Garuda.Modules.ProjectManagement.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/project-development-teams")]
    public class ProjectDevelopmentTeamController : Controller
    {
        private readonly IProjectDevelopmentTeamServices _projectDevelopmentTeamServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectDevelopmentTeamController"/> class.
        /// </summary>
        /// <param name="projectDevelopmentTeamServices"></param>
        public ProjectDevelopmentTeamController(IProjectDevelopmentTeamServices projectDevelopmentTeamServices)
        {
            _projectDevelopmentTeamServices = projectDevelopmentTeamServices;
        }

        /// <summary>
        /// Create new Development Team
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpPost]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST)]
        public async Task<IActionResult> CreateProjectDevelopmentTeam([FromBody] CreateProjectDevelopmentTeamRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _projectDevelopmentTeamServices.CreateProjectDevelopmentTeam(model);
            return Ok(result);
        }

        /// <summary>
        /// Get Project Development Teams
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST)]
        public async Task<IActionResult> GetProjectDevelopmentTeams(Guid projectId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _projectDevelopmentTeamServices.GetProjectDevelopmentTeamProjectId(projectId);
            return Ok(result);
        }
    }
}
