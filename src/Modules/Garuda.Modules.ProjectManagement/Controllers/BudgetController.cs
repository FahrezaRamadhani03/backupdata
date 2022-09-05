// <copyright file="BudgetController.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Budget;
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
    [Route("api/budgets")]
    public class BudgetController : Controller
    {
        private readonly IBudgetServices _service;

        public BudgetController(IBudgetServices service)
        {
            _service = service;
        }

        /// <summary>
        /// Get Budget Types.
        /// </summary>
        /// <remarks>
        /// Filter : TypeName, Id
        ///
        /// Sort : TypeName, Id
        ///
        /// Sample with filter :
        /// 
        ///     Get /api/budgets/budget-types?Filters=TypeName%3D%3DApex
        ///
        /// </remarks>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet("budget-types")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetBudgetTypes(SieveModel model)
        {
            var result = await _service.GetBudgetTypes(model);
            return Ok(result);
        }

        /// <summary>
        /// Get Budget Types.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet("budget-types/{id}")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetBudgetTypes(Guid id)
        {
            var result = await _service.GetBudgetTypes(id);
            return Ok(result);
        }

        /// <summary>
        /// Post Budget Types.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpPost("budget-types")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> CreateBudgetTypes([FromBody] BudgetTypeRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.CreateBudgetTypes(model);
            return Ok(result);
        }

        /// <summary>
        /// Edit Budget Types.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpPut("budget-types/{id}")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> EditBudgetTypes([FromBody] BudgetTypeRequest model, [FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.EditBudgetTypes(model, id);
            return Ok(result);
        }

        /// <summary>
        /// Delete Budget Types.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpDelete("budget-types")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> DeleteBudgetTypes(Guid id)
        {
            var result = await _service.DeleteBudgetTypes(id);
            return Ok(result);
        }

        /// <summary>
        /// Get Budget Activities.
        /// </summary>
        /// <remarks>
        /// Filter : Name, Id, BudgetType
        ///
        /// Sort : Name, Id, BudgetType
        ///
        /// Sample with filter :
        /// 
        ///     Get /api/budgets/budget-activities?Filters=Name%3D%3DApex
        ///
        /// </remarks>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet("budget-activities")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetBudgetActivities(SieveModel model)
        {
            var result = await _service.GetBudgetActivities(model);
            return Ok(result);
        }

        /// <summary>
        /// Get Budget Activities.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet("budget-activities/{id}")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetBudgetActivities(Guid id)
        {
            var result = await _service.GetBudgetActivities(id);
            return Ok(result);
        }

        /// <summary>
        /// Get Budget.
        /// </summary>
        /// <param name="sieveModel"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetBudgets(SieveModel sieveModel)
        {
            var result = await _service.GetDatas(sieveModel);
            return Ok(result);
        }

        /// <summary>
        /// Get Budget.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetBudget(Guid id)
        {
            var result = await _service.GetData(id);
            return Ok(result);
        }

        /// <summary>
        /// Create or Update Budget.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpPost]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> CreateBudget([FromBody] BudgetRequest model)
        {
            var result = await _service.CreateBudget(model);
            return Ok(result);
        }

        /// <summary>
        /// Post Budget Activity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpPost("budget-activities")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> CreateBudgetActivities([FromBody] BudgetActivyRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.CreateBudgetActivities(model);
            return Ok(result);
        }

        /// <summary>
        /// Create or Update Budget.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpPost("budget-details")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> CreateBudgetDetail([FromBody] BudgetDetailRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.CreateBudgetDetail(model);
            return Ok(result);
        }

        /// <summary>
        /// Edit Budget Types.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpPut("budget-activities/{id}")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> EditBudgetActivities([FromBody] BudgetActivyRequest model, [FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.EditBudgetActivities(model, id);
            return Ok(result);
        }

        /// <summary>
        /// Generate budget report to excel.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet("download-excel")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> DownloadBudgetExcel(Guid id)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var (path, contextType, savedFileName) = await _service.ReportBudgetToExcel(id, userId);
            return PhysicalFile(path, contextType, savedFileName);
        }

        /// <summary>
        /// Generate budget report to pdf.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet("download-pdf")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> DownloadBudgetPdf(Guid id)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var (path, contextType, savedFileName) = await _service.ReportBudgetToPdf(id, userId);
            return PhysicalFile(path, contextType, savedFileName);
        }

        /// <summary>
        /// Delete Budget Types.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpDelete("budget-activities")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> DeleteBudgetActivities(Guid id)
        {
            var result = await _service.DeleteBudgetActivities(id);
            return Ok(result);
        }

        /// <summary>
        /// Get Default Budget.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet("default")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetDefaultBudget()
        {
            var result = await _service.GetDefaultBudget();
            return Ok(result);
        }
    }
}
