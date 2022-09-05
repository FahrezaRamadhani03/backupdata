// <copyright file="IDevelopmentScrumSprintRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    /// Entity IDevelopmentRoleRepository Contract Repository
    /// </summary>
    public interface IDevelopmentScrumSprintRepository : IRepository
    {
        /// <summary>
        /// Add Or Update Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="DevelopmentScrumSprint"/> representing the asynchronous operation.</returns>
        Task<DevelopmentScrumSprint> AddOrUpdate(DevelopmentScrumSprint model);

        /// <summary>
        /// Get List Data without Filter
        /// </summary>
        /// <returns>A <see cref="List{DevelopmentScrumSprint}"/> representing the asynchronous operation.</returns>
        Task<List<DevelopmentScrumSprint>> GetList();

        /// <summary>
        /// Delete Data
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="DevelopmentScrumSprint"/> representing the asynchronous operation.</returns>
        Task<bool> DeleteById(Guid id);

        /// <summary>
        /// Get List Data by Development Scrum Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="List{DevelopmentScrumSprint}"/> representing the asynchronous operation.</returns>
        Task<List<DevelopmentScrumSprint>> GetListByDevScrumId(Guid id);

        /// <summary>
        /// Get Last Sprint Date
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="DateTime"/> representing the asynchronous operation.</returns>
        Task<DateTime> GetLastSprintDate(Guid id);
    }
}
