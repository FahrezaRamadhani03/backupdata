// <copyright file="IProjectDevelopmentTeamServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentTeam;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Technology;

namespace Garuda.Modules.ProjectManagement.Services.Contracts
{
    /// <summary>
    /// Technologies contract services
    /// </summary>
    public interface IProjectDevelopmentTeamServices
    {
        /// <summary>
        /// Get ProjectDevelopmentTeam by Project Id
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<MessageDto> GetProjectDevelopmentTeamProjectId(Guid projectId);

        /// <summary>
        /// Create new Project Development Team
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<MessageDto> CreateProjectDevelopmentTeam(CreateProjectDevelopmentTeamRequest model);
    }
}
