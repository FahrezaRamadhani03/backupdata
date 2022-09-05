// <copyright file="IProjectResourceRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public interface IProjectResourceRepository : IRepository
    {
        /// <summary>
        /// Add Or Update Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="DevelopmentRole"/> representing the asynchronous operation.</returns>
        Task AddOrUpdate(ProjectResources model);

        /// <summary>
        /// Delete data by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="DevelopmentRole"/> representing the asynchronous operation.</returns>
        Task<bool> DeleteById(Guid id);

        /// <summary>
        /// Get data by Project Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="ProjectResources"/> representing the asynchronous operation.</returns>
        Task<List<ProjectResources>> GetDataByProjectId(Guid id);

        /// <summary>
        /// Get data by Role Name
        /// </summary>
        /// <param name="level"></param>
        /// <returns>A <see cref="ProjectResources"/> representing the asynchronous operation.</returns>
        Task<ProjectResources> GetByName(Guid projectId, string roleName, string level);
    }
}
