
using System;
using System.Threading.Tasks;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentInfo;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Garuda.Modules.ProjectManagement.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/timeline")]
    public class TimelineController : Controller
    {
        private readonly ITimelineServices _iService;

        public TimelineController(ITimelineServices iService)
        {
            _iService = iService;
        }

        /// <summary>
        /// Get Timeline by Employee.
        /// </summary>
        /// <remarks>
        /// Filter : ProjectPeriode, DeveloperRole, ClientName, ProjectStatus, ProjectName, Type, DeveloperName
        ///
        /// Sort : ProjectPeriode, DeveloperRole, ClientName, ProjectStatus, ProjectName, Type, DeveloperName
        ///
        /// Sample with filter :
        /// 
        ///     Get /api/timeline/by-employees?Filters=DeveloperName%3D%3DAtthoriq%20Gerhana
        ///
        /// </remarks>
        /// <param name="model">"Sieve Model"</param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        [HttpGet("by-employees")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetByEmployees(SieveModel model)
        {
            var success = await _iService.GetByEmployees(model);

            return Ok(success);
        }

        /// <summary>
        /// Get Day of Sprint Data.
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        /// <remarks>
        /// Filter : DevelopementPeriode, ProjectName, StatusTimeline, Type, ClientName
        ///
        /// Sort : DevelopementPeriode, ProjectName, StatusTimeline, Type, ClientName
        ///
        /// Sample with filter :
        ///
        ///     Get /api/timeline/by-projects?Filters=Name%3D%3DApex
        ///
        ///     DevelopmentPeriod==2022-07-31;2022-08-06, ProjectName==mamreq
        ///
        /// </remarks>
        /// <param name="model">"Sieve Model"</param>
        [HttpGet("by-projects")]
        [ProducesResponseType(Codes.SUCCESS, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.NOT_FOUND, Type = typeof(MessageDto))]
        [ProducesResponseType(Codes.BAD_REQUEST, Type = typeof(MessageDto))]
        public async Task<IActionResult> GetByProjects(SieveModel model)
        {
            var success = await _iService.GetByProjects(model);

            return Ok(success);
        }
    }
}
