// <copyright file="IDistrictRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    /// Entity Group Contract District Repository
    /// </summary>
    public interface IDistrictRepository : IRepository
    {
        /// <summary>
        /// Add or Update data to Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task AddOrUpdate(District model);

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
        /// <returns>A <see cref="District"/> representing the asynchronous operation.</returns>
        Task<District> GetData(Guid id);

        /// <summary>
        /// Get Data by Id
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A <see cref="District"/> representing the asynchronous operation.</returns>
        Task<District> GetData(string name);

        /// <summary>
        /// Get List Data
        /// </summary>
        /// <returns>A <see cref="List{District}"/> representing the asynchronous operation.</returns>
        Task<List<District>> GetData();

        /// <summary>
        /// Check duplicate data by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A <see cref="bool"/> representing the asynchronous operation.</returns>
        Task<bool> IsRegisteredName(string name);
    }
}
