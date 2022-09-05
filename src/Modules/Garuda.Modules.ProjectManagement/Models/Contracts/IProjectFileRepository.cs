// <copyright file="IProjectFileRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    /// Entity IProjectFileRepository Contract Repository
    /// </summary>
    public interface IProjectFileRepository : IRepository
    {
        /// <summary>
        /// Add Or Update Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="ProjectFile"/> representing the asynchronous operation.</returns>
        Task AddOrUpdate(ProjectFile model, string projectCode);

        /// <summary>
        /// Get data by DocumentNo
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>A <see cref="ProjectFile"/> representing the asynchronous operation.</returns>
        Task<List<ProjectFile>> GetbyProject(Guid parameter);

        /// <summary>
        /// Get all Id by Project
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>A <see cref="ProjectFile"/> representing the asynchronous operation.</returns>
        Task<List<int>> GetAllIdbyProject(Guid parameter);

        /// <summary>
        /// Delete project file data
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Delete(int id, string projectCode);

        /// <summary>
        /// Get Original File Name
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<(string, string)> GetOriginalFileName(string fileName);
    }
}
