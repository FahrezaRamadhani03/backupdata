// <copyright file="AddressController.cs" company="CV Garuda Infinity Kreasindo">
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
    [Route("api/address")]
    public class AddressController : Controller
    {
        private readonly IAddressServices _service;

        public AddressController(IAddressServices service)
        {
            _service = service;
        }

        /// <summary>
        /// Get Client City List.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet("cities")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetCities()
        {
            var result = await _service.GetCities();
            return Ok(result);
        }

        /// <summary>
        /// Get Client Countries List.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet("countries")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetContries()
        {
            var result = await _service.GetContries();
            return Ok(result);
        }

        /// <summary>
        /// Get Client Districts.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet("districts")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetDistricts()
        {
            var result = await _service.GetDistricts();
            return Ok(result);
        }

        /// <summary>
        /// Get Client Proviences.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet("provinces")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetProvinces()
        {
            var result = await _service.GetProvinces();
            return Ok(result);
        }

        /// <summary>
        /// Get Client City List.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpPost("cities")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> CreateCity([FromBody] AddressRequest model)
        {
            var result = await _service.CreateCity(model);
            return Ok(result);
        }

        /// <summary>
        /// Add Client Countries.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpPost("countries")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> CreateContry([FromBody] AddressRequest model)
        {
            var result = await _service.CreateContry(model);
            return Ok(result);
        }

        /// <summary>
        /// Add Client Districts.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpPost("districts")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> CreateDistricts([FromBody] AddressRequest model)
        {
            var result = await _service.CreateDistrict(model);
            return Ok(result);
        }

        /// <summary>
        /// Add Client Proviences.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpPost("provinces")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> CreateProvince([FromBody] AddressRequest model)
        {
            var result = await _service.CreateProvince(model);
            return Ok(result);
        }
    }
}
