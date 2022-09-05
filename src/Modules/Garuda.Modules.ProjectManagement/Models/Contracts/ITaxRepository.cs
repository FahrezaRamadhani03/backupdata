// <copyright file="ITaxRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public interface ITaxRepository : IRepository
    {
        /// <summary>
        /// Add or Update data to Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task AddOrUpdate(Tax model);

        /// <summary>
        /// Delete data from Table
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<bool> Delete(Guid id);

        /// <summary>
        /// Get Data by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Tax"/> representing the asynchronous operation.</returns>
        Task<Tax> GetData(Guid id);

        /// <summary>
        /// Get List Data Menu
        /// </summary>
        /// <returns>A <see cref="List{Taxes}"/> representing the asynchronous operation.</returns>
        Task<List<Tax>> GetData();

        /// <summary>
        /// Get Data By Tax Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A <see cref="List{Taxes}"/> representing the asynchronous operation.</returns>
        Task<Tax> GetData(string name);

        /// <summary>
        /// Check Is Regestered Code
        /// </summary>
        /// <param name="code"></param>
        /// <returns>A <see cref="bool"/> representing the asynchronous operation.</returns>
        Task<bool> IsRegisteredCode(string code);

        /// <summary>
        /// Check Is Regestered Code
        /// </summary>
        /// <param name="code"></param>
        /// <returns>A <see cref="bool"/> representing the asynchronous operation.</returns>
        Task<bool> IsRegisteredById(Guid id);

        /// <summary>
        /// Check Is Regestered Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A <see cref="bool"/> representing the asynchronous operation.</returns>
        Task UpdateNonActiveTaxByName(string name);
    }
}
