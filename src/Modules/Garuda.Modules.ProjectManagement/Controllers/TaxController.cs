// <copyright file="TaxController.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Tax;
using Garuda.Modules.ProjectManagement.Dtos.Responses;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Garuda.Modules.ProjectManagement.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/taxes")]
    public class TaxController : Controller
    {
        private readonly ITaxServices _taxServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxController"/> class.
        /// </summary>
        /// <param name="technologyServices"></param>
        public TaxController(ITaxServices taxServices)
        {
            _taxServices = taxServices;
        }

        /// <summary>
        /// Get list of Taxes.
        /// </summary>
        /// <returns>A <see cref="TaxResponses"/> representing the asynchronous operation.</returns>
        [HttpGet]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(List<TaxResponses>))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetListTax(SieveModel model)
        {
            var result = await _taxServices.GetListTax(model);
            return Ok(result);
        }

        /// <summary>
        /// Post new Tax.
        /// </summary>
        /// <returns>A <see cref="TaxResponses"/> representing the asynchronous operation.</returns>
        [HttpPost]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(List<TaxResponses>))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        public async Task<IActionResult> CreateData([FromBody] TaxRequest model)
        {
            var result = await _taxServices.CreateData(model);
            return Ok(result);
        }

        /// <summary>
        /// Edit Tax.
        /// </summary>
        /// <returns>A <see cref="TaxResponses"/> representing the asynchronous operation.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(List<TaxResponses>))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        public async Task<IActionResult> EditData([FromRoute]Guid id, [FromBody] TaxRequest model)
        {
            var result = await _taxServices.EditData(id, model);
            return Ok(result);
        }

        /// <summary>
        /// Delete Tax.
        /// </summary>
        /// <returns>A <see cref="TaxResponses"/> representing the asynchronous operation.</returns>
        [HttpDelete]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(List<TaxResponses>))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        public async Task<IActionResult> DeleteData(Guid id)
        {
            var result = await _taxServices.DeleteData(id);
            return Ok(result);
        }
    }
}
