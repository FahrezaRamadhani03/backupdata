// <copyright file="IInvoiceFileHistoryRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    /// Entity Group Contract Bil Repository
    /// </summary>
    public interface IInvoiceFileHistoryRepository : IRepository
    {
        /// <summary>
        /// Add or Update data to Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task AddOrUpdate(InvoiceFileHistory model);

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
        /// <returns>A <see cref="ExpenseBill"/> representing the asynchronous operation.</returns>
        Task<InvoiceFileHistory> GetData(Guid id);

        /// <summary>
        /// Get List Data
        /// </summary>
        /// <returns>A <see cref="List{ExpenseBill}"/> representing the asynchronous operation.</returns>
        Task<List<InvoiceFileHistory>> GetData();
    }
}
