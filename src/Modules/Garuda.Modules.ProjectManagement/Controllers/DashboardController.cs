using System;
using System.Threading.Tasks;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentInfo;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Garuda.Modules.ProjectManagement.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/dashboard")]
    public class DashboardController : Controller
    {
        private readonly IDashboardServices _iService;

        public DashboardController(IDashboardServices iService)
        {
            _iService = iService;
        }

        /// <summary>
        /// Get Project Summary Data.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet("project")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetProjectSummary()
        {
            var success = await _iService.GetProjectSummary();

            return Ok(success);
        }

        /// <summary>
        /// Get Recent Project Summary Data.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet("recent-project")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetRecentProject()
        {
            var success = await _iService.GetRecentProject();

            return Ok(success);
        }

        /// <summary>
        /// Get Recent Project by Invoice Data.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet("recent-invoice")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetRecentProjectInvoice()
        {
            var success = await _iService.GetRecentProjectInvoice();

            return Ok(success);
        }
    }
}
