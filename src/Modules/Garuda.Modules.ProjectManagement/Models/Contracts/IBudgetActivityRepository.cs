// <copyright file="IBudgetActivityRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    /// Entity Group Contract BudgeActivity Repository
    /// </summary>
    public interface IBudgetActivityRepository : IRepository
    {
        /// <summary>
        /// Add or Update data to Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task AddOrUpdate(BudgetActivity model);

        /// <summary>
        /// Delete data from Table
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Delete(Guid id);

        /// <summary>
        /// Delete data from Table
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task DeleteByTypeId(Guid id);

        /// <summary>
        /// Get Data by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="BudgetActivity"/> representing the asynchronous operation.</returns>
        Task<BudgetActivity> GetData(Guid id);

        /// <summary>
        /// Get List Data
        /// </summary>
        /// <returns>A <see cref="List{BudgetActivity}"/> representing the asynchronous operation.</returns>
        Task<List<BudgetActivity>> GetData();

        /// <summary>
        /// Check registered type
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A <see cref="bool"/> representing the asynchronous operation.</returns>
        Task<bool> IsRegistered(string name, Guid? currentId);

        /// <summary>
        /// Check registered by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="bool"/> representing the asynchronous operation.</returns>
        Task<bool> IsRegistered(Guid id);
    }
}
