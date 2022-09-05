// <copyright file="ITechnologyRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public interface ITechnologyRepository : IRepository
    {
        /// <summary>
        /// Add or Update data to Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task AddOrUpdate(Technology model);

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
        /// <returns>A <see cref="Technology"/> representing the asynchronous operation.</returns>
        Task<Technology> GetData(Guid id);

        /// <summary>
        /// Get List Data Menu
        /// </summary>
        /// <returns>A <see cref="List{Technologies}"/> representing the asynchronous operation.</returns>
        Task<List<Technology>> GetData();

        /// <summary>
        /// Get Data By Technology Name
        /// </summary>
        /// <param name="techName"></param>
        /// <returns>A <see cref="List{Technologies}"/> representing the asynchronous operation.</returns>
        Task<Technology> GetData(string techName);
    }
}
