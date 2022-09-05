// <copyright file="ProjectExpensesController.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Client;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Expenses;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Client;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Garuda.Modules.ProjectManagement.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/project-expenses")]
    public class ProjectExpensesController : Controller
    {
        private readonly IProjectExpensesServices _service;

        public ProjectExpensesController(IProjectExpensesServices service)
        {
            _service = service;
        }

        /// <summary>
        /// Created New Expense.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpPost]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> CreateExpense([FromForm] ExpenseRequest model)
        {
            var result = await _service.CreateExpense(model);
            return Ok(result);
        }

        /// <summary>
        /// Get Project Expense Data.
        /// </summary>
        /// <remarks>
        /// Filter : BudgetActivity, BudgetType, ProjectId, CreatedDate
        ///
        /// Sort : BudgetActivity, BudgetType, ProjectId, CreatedDate
        ///
        /// Sample with filter :
        /// 
        ///     Get /api/project-expenses?Filters=BudgetActivity%3D%3DBuku
        ///
        /// </remarks>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetDataProject(SieveModel model)
        {
            var result = await _service.GetDataProject(model);
            return Ok(result);
        }

        /// <summary>
        /// Get Expense Data.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet("expense")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetData(Guid id)
        {
            var result = await _service.GetData(id);
            return Ok(result);
        }

        /// <summary>
        /// Delete Project Expense Data.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpDelete]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> DeleteExpense(Guid id)
        {
            var result = await _service.DeleteExpense(id);
            return Ok(result);
        }

        /// <summary>
        /// Edit New Expense.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> EditExpense([FromRoute] Guid id, [FromForm] ExpenseRequest model)
        {
            var result = await _service.EditExpense(id, model);
            return Ok(result);
        }

        /// <summary>
        /// Download Bill.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet("file-bill/{id}")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<ActionResult> GetFileBill(Guid id)
        {
            var result = await _service.GetFileBill(id);
            return File(System.IO.File.ReadAllBytes(result.PathFile), result.ContentType, result.NameFile);
        }

        /// <summary>
        /// Get Project Cost Summary.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet("summary")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<ActionResult> GetSummary(Guid id)
        {
            var result = await _service.GetSummary(id);
            return Ok(result);
        }
    }
}
