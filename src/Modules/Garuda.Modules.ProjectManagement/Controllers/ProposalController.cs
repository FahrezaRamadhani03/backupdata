// <copyright file="ProposalController.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Proposal;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Garuda.Modules.ProjectManagement.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/proposals")]
    public class ProposalController : Controller
    {
        private readonly IProposalServices _proposalService;

        public ProposalController(IProposalServices proposalService)
        {
            _proposalService = proposalService;
        }

        /// <summary>
        /// Get Proposal Data.
        /// </summary>
        /// <returns>A <see cref="ProposalResponses"/> representing the asynchronous operation.</returns>
        [HttpGet]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(ProposalResponses))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetData(Guid projectId)
        {
            var result = await _proposalService.GetData(projectId);

            return Ok(result);
        }

        /// <summary>
        /// Created New Expense.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpPost]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.UNAUTHORIZED, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST)]
        public async Task<IActionResult> CreateProposal([FromForm] CreateProposalRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var result = await _proposalService.CreateData(model, userId);
            return Ok(result);
        }

        /// <summary>
        /// Get Proposal History Data.
        /// </summary>
        /// <returns>A <see cref="ProposalHistory"/> representing the asynchronous operation.</returns>
        [HttpGet]
        [Route("histories")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(ProposalResponses))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetHistory(Guid projectId)
        {
            var result = await _proposalService.GetHistory(projectId);

            return Ok(result);
        }

        [HttpGet]
        [Route("download")]
        public ActionResult Download(string fileName)
        {
            var (path, contextType, savedFileName) = _proposalService.Download(fileName);

            return PhysicalFile(path, contextType, savedFileName);
        }
    }
}
