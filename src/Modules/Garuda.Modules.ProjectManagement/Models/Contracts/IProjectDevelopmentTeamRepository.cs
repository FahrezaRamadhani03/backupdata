// <copyright file="IProjectDevelopmentTeamRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Garuda.Database.Abstract.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;

namespace Garuda.Modules.ProjectManagement.Models.Contracts
{
    /// <summary>
    /// Entity Group Contract Repository
    /// </summary>
    public interface IProjectDevelopmentTeamRepository : IRepository
    {
        /// <summary>
        /// Add or Update data to Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task AddOrUpdate(ProjectDevelopmentTeam model);

        /// <summary>
        /// Delete data from Table
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Delete(Guid id);

        /// <summary>
        /// Get Data by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="ProjectDevelopmentTeam"/> representing the asynchronous operation.</returns>
        Task<ProjectDevelopmentTeam> GetData(Guid id);

        /// <summary>
        /// Get List Data Menu
        /// </summary>
        /// <returns>A <see cref="List{ProjectDevelopmentTeams}"/> representing the asynchronous operation.</returns>
        Task<List<ProjectDevelopmentTeam>> GetData();

        /// <summary>
        /// Get List Data by Project Id
        /// </summary>
        /// /// <param name="projectId"></param>
        /// <returns>A <see cref="List{ProjectDevelopmentTeams}"/> representing the asynchronous operation.</returns>
        Task<List<ProjectDevelopmentTeam>> GetByProject(Guid projectId);


        /// <summary>
        /// Get Total Man Days Developer Amount
        /// </summary>
        /// /// <param name="projectId"></param>
        /// <returns>A <see cref="decimal"/> representing the asynchronous operation.</returns>
        Task<decimal> GetManDaysAmountByProject(Guid projectId);
    }
}
