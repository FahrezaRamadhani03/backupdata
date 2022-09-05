// <copyright file="PaymentTermController.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.PaymentTerm;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Garuda.Modules.ProjectManagement.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/payment-terms")]
    public class PaymentTermController : Controller
    {
        private readonly IPaymentTermServices _paymentTermServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentTermController"/> class.
        /// </summary>
        /// <param name="paymentTermServices"></param>
        public PaymentTermController(IPaymentTermServices paymentTermServices)
        {
            _paymentTermServices = paymentTermServices;
        }

        /// <summary>
        /// Get Payment Term
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST)]
        public async Task<IActionResult> GetPaymentTerms(Guid projectId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _paymentTermServices.GetPaymentTermByProjectId(projectId);
            return Ok(result);
        }

        /// <summary>
        /// Get Payment Term
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet("unpaid")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST)]
        public async Task<IActionResult> GetPaymentTermsUnpaid(Guid projectId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _paymentTermServices.GetPaymentTermByUnpaid(projectId);
            return Ok(result);
        }

        /// <summary>
        /// Create or Update Payment Term
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpPost]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST)]
        public async Task<IActionResult> CreatePaymentTerms([FromBody] CreatePaymentTermRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _paymentTermServices.CreatePaymentTerms(model);
            return Ok(result);
        }
    }
}
