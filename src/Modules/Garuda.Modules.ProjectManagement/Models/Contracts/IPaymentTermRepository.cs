// <copyright file="IPaymentTermRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public interface IPaymentTermRepository : IRepository
    {
        /// <summary>
        /// Add or Update data to Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task AddOrUpdate(PaymentTerm model);

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
        /// <returns>A <see cref="PaymentTerm"/> representing the asynchronous operation.</returns>
        Task<PaymentTerm> GetData(Guid id);

        /// <summary>
        /// Get List Data Menu
        /// </summary>
        /// <returns>A <see cref="List{PaymentTerms}"/> representing the asynchronous operation.</returns>
        Task<List<PaymentTerm>> GetData();

        /// <summary>
        /// Get List Data Menu
        /// </summary>
        /// <returns>A <see cref="List{PaymentTerms}"/> representing the asynchronous operation.</returns>
        Task<List<PaymentTerm>> GetDataByUnpaid(Guid projectId);

        /// <summary>
        /// Get List Data Menu
        /// </summary>
        /// <returns>A <see cref="List{PaymentTerms}"/> representing the asynchronous operation.</returns>
        Task<List<PaymentTerm>> GetDataByUnpaid();

        /// <summary>
        /// Check paymentTerm invoice
        /// </summary>
        /// <returns>A <see cref="bool"/> representing the asynchronous operation.</returns>
        Task<bool> IsPaymentTermHasInvoice(Guid id);
    }
}
