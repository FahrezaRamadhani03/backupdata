﻿// <copyright file="IInvoiceRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Garuda.Database.Abstract.Contracts;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Invoice;
using Garuda.Modules.ProjectManagement.Models.Datas;

namespace Garuda.Modules.ProjectManagement.Models.Contracts
{
    /// <summary>
    /// Entity Group Contract Repository
    /// </summary>
    public interface IInvoiceRepository : IRepository
    {
        /// <summary>
        /// Add or Update data to Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task AddOrUpdate(Invoice model);

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
        /// <returns>A <see cref="Invoice"/> representing the asynchronous operation.</returns>
        Task<Invoice> GetData(Guid id);

        /// <summary>
        /// Get List Data Menu
        /// </summary>
        /// <returns>A <see cref="List{Invoices}"/> representing the asynchronous operation.</returns>
        Task<List<Invoice>> GetData();

        /// <summary>
        /// Get List Data Menu
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task SendInvoice(SendInvoiceRequest model);

        /// <summary>
        /// Get List Data Menu
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task SetPaid(Guid id);

        /// <summary>
        /// Get Total UnPaid Invoice by Client.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="decimal"/> representing the asynchronous operation.</returns>
        Task<decimal> GetUnpaidInvoiceByProjectId(Guid id);

        /// <summary>
        /// Get Total Overdue date And Unpaid Invoice by Client.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="decimal"/> representing the asynchronous operation.</returns>
        Task<decimal> GetUnpaidOverdueInvoiceByProjectId(Guid id);

        /// <summary>
        /// Get Total paid Invoice  by Client.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="decimal"/> representing the asynchronous operation.</returns>
        Task<decimal> GetPaidInvoiceByProjectId(Guid id);

        /// <summary>
        /// Get ProjectData By Invoice Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<(Guid, string)> GetProjectDataByInvoiceId(Guid id);
    }
}