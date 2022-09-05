// <copyright file="IProjectSPKRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    /// Entity IProjectSPKRepository Contract Repository
    /// </summary>
    public interface IProjectSPKRepository : IRepository
    {
        /// <summary>
        /// Add data to Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="ProjectSPK"/> representing the asynchronous operation.</returns>
        Task<ProjectSPK> AddData(ProjectSPK model);
    }
}
