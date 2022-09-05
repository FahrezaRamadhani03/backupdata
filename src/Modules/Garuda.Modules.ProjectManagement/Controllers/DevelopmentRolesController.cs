// <copyright file="DevelopmentRolesController.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentRole;
using Garuda.Modules.ProjectManagement.Dtos.Responses.DevelopmentRole;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Garuda.Modules.ProjectManagement.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/development-roles")]
    public class DevelopmentRolesController : Controller
    {
        private readonly IDevelopmentRoleService _iService;

        public DevelopmentRolesController(IDevelopmentRoleService iService)
        {
            _iService = iService;
        }

        /// <summary>
        /// Get all Development Roles Data.
        /// </summary>
        /// <returns>A <see cref="DevelopmentRoleResponses"/> representing the asynchronous operation.</returns>
        [HttpGet]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(GetDevelopmentRolesResponses))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetDatas()
        {
            var success = await _iService.GetAllData();

            return Ok(success);
        }

        /// <summary>
        /// Get all Development Roles Data.
        /// </summary>
        /// <returns>A <see cref="DevelopmentRoleResponses"/> representing the asynchronous operation.</returns>
        [HttpGet("roles")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(GetDevelopmentRolesResponses))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetData()
        {
            var success = await _iService.GetData();

            return Ok(success);
        }

        /// <summary>
        /// Post a Development Role Data.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="DevelopmentRoleResponses"/> representing the asynchronous operation.</returns>
        [HttpPost]
        [ProducesResponseType(Codes.CREATED, Type = typeof(DevelopmentRoleResponses))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> CreateData([FromBody] CreateDevelopmentRoleRequest model)
        {
            var success = await _iService.CreateData(model);

            return Ok(success);
        }

        /// <summary>
        /// Put Development Role Data.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns>A <see cref="DevelopmentRoleResponses"/> representing the asynchronous operation.</returns>
        [HttpPut]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(DevelopmentRoleResponses))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> UpdateData(Guid id, [FromBody] CreateDevelopmentRoleRequest model)
        {
            var success = await _iService.UpdateData(id, model);

            return Ok(success);
        }

        /// <summary>
        /// Delete Development Role
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="DevelopmentRoleResponses"/> representing the asynchronous operation.</returns>
        [HttpDelete]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _iService.Delete(id);

            return Ok(success);
        }
    }
}
