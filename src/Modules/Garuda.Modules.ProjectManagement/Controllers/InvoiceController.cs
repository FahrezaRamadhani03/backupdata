// <copyright file="InvoiceController.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Invoice;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Invoice;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Garuda.Modules.ProjectManagement.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/invoices")]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceServices _invoiceServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceController"/> class.
        /// </summary>
        /// <param name="invoiceServices"></param>
        public InvoiceController(IInvoiceServices invoiceServices)
        {
            _invoiceServices = invoiceServices;
        }

        /// <summary>
        /// Get list of Invoice.
        /// </summary>
        /// <param name="sieveModel"></param>
        /// <returns>A <see cref="ProjectInvoiceResponses"/> representing the asynchronous operation.</returns>
        [HttpGet]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetAllList(SieveModel sieveModel)
        {
            var result = await _invoiceServices.GetAllList(sieveModel);
            return Ok(result);
        }

        /// <summary>
        /// Create or update Invoice
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpPost]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST)]
        public async Task<IActionResult> Create([FromBody] CreateInvoiceRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _invoiceServices.Create(model);
            return Ok(result);
        }

        /// <summary>
        /// Create or update Invoice
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet("detail")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST)]
        public async Task<IActionResult> GetData(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _invoiceServices.GetData(id);
            return Ok(result);
        }

        /// <summary>
        /// Delete Invoice
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpDelete]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST)]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _invoiceServices.Delete(id);
            return Ok(result);
        }

        /// <summary>
        /// update Invoice send invoice
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpPut("send-invoice")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST)]
        public async Task<IActionResult> SendInvoice([FromBody] SendInvoiceRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _invoiceServices.SendInvoice(model);
            return Ok(result);
        }

        /// <summary>
        /// update Invoice send invoice
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpPut("set-paid")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST)]
        public async Task<IActionResult> SetPaid([FromBody] InvoicePaymentRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _invoiceServices.SetPaid(model);
            return Ok(result);
        }

        /// <summary>
        /// Get all Status Invoice Data.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet("status-invoices")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(List<string>))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetStatusInvoice()
        {
            var result = await _invoiceServices.GetStatusInvoice();

            return Ok(result);
        }

        /// <summary>
        /// Get all Status Invoice Data.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet("download")]
        public async Task<IActionResult> GetPdfInvoice(Guid id)
        {
            var (path, contextType, savedFileName) = await _invoiceServices.DownloadInvoiceAsync(id);

            return PhysicalFile(path, contextType, savedFileName);
        }
    }
}
