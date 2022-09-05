// <copyright file="ProjectManagementController.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.ProjectDetails;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Project;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Garuda.Modules.ProjectManagement.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/projects")]
    public class ProjectManagementController : Controller
    {
        private readonly IProjectDetailServices _iService;

        public ProjectManagementController(IProjectDetailServices iService)
        {
            _iService = iService;
        }

        /// <summary>
        /// Get Project List Data.
        /// </summary>
        /// <returns>A <see cref="ProjectListResponses"/> representing the asynchronous operation.</returns>
        [HttpGet]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(ProjectListResponses))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetData(SieveModel model)
        {
            if (model.Page.HasValue && model.PageSize.HasValue)
            {
                var result = await _iService.GetPagedListProject(model);
                return Ok(result);
            }
            else
            {
                var result = await _iService.GetData(model);
                return Ok(result);
            }
        }

        /// <summary>
        /// Get Project List Data witouth pagination.
        /// </summary>
        /// <returns>A <see cref="ProjectListResponses"/> representing the asynchronous operation.</returns>
        [HttpGet("list-projects")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(ProjectListResponses))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetDatas()
        {
            var result = await _iService.GetData();
            return Ok(result);
        }

        /// <summary>
        /// Get Project Short Info.
        /// </summary>
        /// <returns>A <see cref="ProjectShortInfoResponses"/> representing the asynchronous operation.</returns>
        [HttpGet]
        [Route("short-info")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(ProjectShortInfoResponses))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetShortInfo(Guid id)
        {
            var result = await _iService.GetShortInfo(id);

            return Ok(result);
        }

        /// <summary>
        /// Post a Project Detail Data.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="ProjectDetailResponses"/> representing the asynchronous operation.</returns>
        [HttpPost("details")]
        [ProducesResponseType(Codes.CREATED, Type = typeof(CreateProjectDetailRequest))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> CreateData([FromBody] CreateProjectDetailRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var success = await _iService.CreateData(model, userId);

            return Ok(success);
        }

        /// <summary>
        /// Get a Project Detail by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="ProjectDetailResponses"/> representing the asynchronous operation.</returns>
        [HttpGet("details")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(ProjectDetailDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetDataById(Guid id)
        {
            var success = await _iService.GetDataById(id);

            return Ok(success);
        }

        /// <summary>
        /// Edit a Project Detail.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="ProjectDetailResponses"/> representing the asynchronous operation.</returns>
        [HttpPut("details")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(ProjectDetailDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> EditData([FromBody] EditProjectDetailRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _iService.EditData(model);

            return Ok(success);
        }

        /// <summary>
        /// Post a Project Status History Data.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="ProjectDetailResponses"/> representing the asynchronous operation.</returns>
        [HttpPost("status")]
        [ProducesResponseType(Codes.CREATED, Type = typeof(UpdateStatusRequest))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> CreateStatusHistoryData([FromBody] UpdateStatusRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var success = await _iService.UpdateStatus(model, userId);

            return Ok(success);
        }
    }
}
