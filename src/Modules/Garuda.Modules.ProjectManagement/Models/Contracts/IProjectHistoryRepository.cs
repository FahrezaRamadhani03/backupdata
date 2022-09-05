// <copyright file="IProjectHistoryRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    /// Entity IProjectHistoryRepository Contract Repository
    /// </summary>
    public interface IProjectHistoryRepository : IRepository
    {
        /// <summary>
        /// Get data by ProjectId
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>A <see cref="ProjectHistory"/> representing the asynchronous operation.</returns>
        Task<List<ProjectHistory>> GetbyProject(Guid parameter);

        /// <summary>
        /// Add data to Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="ProjectHistory"/> representing the asynchronous operation.</returns>
        Task<ProjectHistory> AddData(ProjectHistory model);
    }
}
