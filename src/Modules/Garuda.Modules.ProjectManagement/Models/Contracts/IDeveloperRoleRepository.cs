// <copyright file="IDeveloperRoleRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public interface IDeveloperRoleRepository : IRepository
    {
        /// <summary>
        /// Add Or Update Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="DeveloperRole"/> representing the asynchronous operation.</returns>
        Task AddOrUpdate(DeveloperRole model);

        /// <summary>
        /// Get List Data without Filter
        /// </summary>
        /// <returns>A <see cref="List{DevelopmentRole}"/> representing the asynchronous operation.</returns>
        Task<List<DeveloperRole>> GetList();

        /// <summary>
        /// Get List Data without Filter
        /// </summary>
        /// <param name="developerRole"></param>
        /// <returns>A <see cref="model"/> representing the asynchronous operation.</returns>
        Task<DeveloperRole> FindById(DeveloperRole developerRole);
    }
}
