// <copyright file="IExpenseRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    /// Entity Group Contract Expense Repository
    /// </summary>
    public interface IExpenseRepository : IRepository
    {
        /// <summary>
        /// Add or Update data to Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<Expense> AddOrUpdate(Expense model);

        /// <summary>
        /// Delete data from Table
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task <bool> Delete(Guid id);

        /// <summary>
        /// Get Data by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Expense"/> representing the asynchronous operation.</returns>
        Task<Expense> GetData(Guid id);

        /// <summary>
        /// Get List Data
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="List{Expense}"/> representing the asynchronous operation.</returns>
        Task<List<Expense>> GetDataByProjectId(Guid id);

        /// <summary>
        /// Get List Data
        /// </summary>
        /// <returns>A <see cref="List{Expense}"/> representing the asynchronous operation.</returns>
        Task<List<Expense>> GetData();

        /// <summary>
        /// Get Total Expense Amount
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="decimal"/> representing the asynchronous operation.</returns>
        Task<decimal> GetTotalExpenseAmountByProjectId(Guid id);
    }
}
