// <copyright file="ProjectFileController.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.ProjectFile;
using Garuda.Modules.ProjectManagement.Dtos.Responses.ProjectFile;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Garuda.Modules.ProjectManagement.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/project-files")]
    public class ProjectFileController : Controller
    {
        private readonly IProjectFileServices _projectFileService;

        public ProjectFileController(IProjectFileServices projectFileService)
        {
            _projectFileService = projectFileService;
        }

        /// <summary>
        /// Get Project File Data.
        /// </summary>
        /// <returns>A <see cref="ProjectFileResponses"/> representing the asynchronous operation.</returns>
        [HttpGet]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(ProjectFileResponses))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetData(Guid projectId, string projectCode)
        {
            var result = await _projectFileService.GetData(projectId, projectCode);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.UNAUTHORIZED, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST)]
        public async Task<IActionResult> CreateProjectFile(Guid projectId, string projectCode, [FromForm] List<CreateProjectFileRequest> model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _projectFileService.CreateData(projectId, projectCode, model);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.UNAUTHORIZED, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST)]
        public async Task<IActionResult> EditProjectFile(Guid projectId, string projectCode, [FromForm] List<EditProjectFileRequest> model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _projectFileService.EditData(projectId, projectCode, model);
            return Ok(result);
        }

        /// <summary>
        /// Download Bill.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet("download/{fileName}")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<ActionResult> Download(string fileName)
        {
            var result = await _projectFileService.Download(fileName);
            return File(System.IO.File.ReadAllBytes(result.PathFile), result.ContentType, result.NameFile);
        }
    }
}
