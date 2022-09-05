// <copyright file="ClientController.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Client;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Client;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Garuda.Modules.ProjectManagement.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/clients")]
    public class ClientController : Controller
    {
        private readonly IClientServices _clientService;

        public ClientController(IClientServices clientService)
        {
            _clientService = clientService;
        }

        /// <summary>
        /// Get All Client Data.
        /// </summary>
        /// <returns>A <see cref="ClientResponses"/> representing the asynchronous operation.</returns>
        [HttpGet("list-clients")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(ClientResponses))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetDataAll()
        {
            var result = await _clientService.GetData();
            return Ok(result);
        }

        /// <summary>
        /// Get Client Data.
        /// </summary>
        /// <returns>A <see cref="ClientResponses"/> representing the asynchronous operation.</returns>
        [HttpGet("search")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(ClientResponses))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetData(SieveModel model)
        {
            var result = await _clientService.GetPagedListClient(model);
            return Ok(result);
        }

        /// <summary>
        /// Create Client Data.
        /// </summary>
        /// <returns>A <see cref="ClientResponses"/> representing the asynchronous operation.</returns>
        [HttpPost]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.UNAUTHORIZED, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.ERROR_TRANSACT_DELETE, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST)]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _clientService.CreateData(model);
            return Ok(result);
        }

        /// <summary>
        /// Get Client Data by Id.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetDataById(int id)
        {
            var result = await _clientService.GetDataById(id);
            return Ok(result);
        }

        /// <summary>
        /// Get Client Project List by Id.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet("projects")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetProjectListById(int id)
        {
            var result = await _clientService.GetProjectListById(id);
            return Ok(result);
        }

        /// <summary>
        /// Soft Delete Client.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpDelete]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> SoftDeleteClient(int id)
        {
            var result = await _clientService.SoftDeleteClient(id);
            return Ok(result);
        }

        /// <summary>
        /// Update Client Data.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> UpdateClient([FromRoute]int id, [FromBody] CreateClientRequest model)
        {
            var result = await _clientService.UpdateClient(id, model);
            return Ok(result);
        }
    }
}
