// <copyright file="IBudgetTypeRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    /// Entity Group Contract Budget Type Repository
    /// </summary>
    public interface IBudgetTypeRepository : IRepository
    {
        /// <summary>
        /// Add or Update data to Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task AddOrUpdate(BudgetType model);

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
        /// <returns>A <see cref="BudgetType"/> representing the asynchronous operation.</returns>
        Task<BudgetType> GetData(Guid id);

        /// <summary>
        /// Get List Data
        /// </summary>
        /// <returns>A <see cref="List{BudgetType}"/> representing the asynchronous operation.</returns>
        Task<List<BudgetType>> GetData();

        /// <summary>
        /// Get List Data
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="List{BudgetType}"/> representing the asynchronous operation.</returns>
        Task<List<BudgetType>> GetDataByBudgetId(Guid id);
        
        /// <summary>
        /// Check registered data
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A <see cref="bool"/> representing the asynchronous operation.</returns>
        Task<bool> IsRegistered(string name, Guid? currentId);

        /// <summary>
        /// Check registered data
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A <see cref="bool"/> representing the asynchronous operation.</returns>
        Task<bool> IsRegistered(Guid id);
    }
}
