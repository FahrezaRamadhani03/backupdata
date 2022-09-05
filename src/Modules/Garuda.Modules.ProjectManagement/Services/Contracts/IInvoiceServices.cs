// <copyright file="IInvoiceServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Invoice;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Invoice;
using Sieve.Models;

namespace Garuda.Modules.ProjectManagement.Services.Contracts
{
    /// <summary>
    /// Technologies contract services
    /// </summary>
    public interface IInvoiceServices
    {
        /// <summary>
        /// Get Invoice
        /// </summary>
        /// <param name="sieveModel"></param>
        /// <returns>A <see cref="Task{InvoiceResponses}"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetAllList(SieveModel sieveModel);

        /// <summary>
        /// Create new Invoice
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<MessageDto> Create(CreateInvoiceRequest model);

        /// <summary>
        /// Create new Invoice
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{InvoiceResponses}"/> representing the result of the asynchronous operation.</returns>
        Task<MessageDto> GetData(Guid id);

        /// <summary>
        /// Create new Invoice
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{InvoiceResponses}"/> representing the result of the asynchronous operation.</returns>
        Task<MessageDto> Delete(Guid id);

        /// <summary>
        /// Delete Invoice
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task{SendInvoiceRequest}"/> representing the result of the asynchronous operation.</returns>
        Task<MessageDto> SendInvoice(SendInvoiceRequest model);

        /// <summary>
        /// Delete Invoice
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task{InvoicePaymentRequest}"/> representing the result of the asynchronous operation.</returns>
        Task<MessageDto> SetPaid(InvoicePaymentRequest model);

        /// <summary>
        /// Get All Status Data
        /// </summary>
        /// <returns>A <see cref="string"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetStatusInvoice();

        /// <summary>
        /// Get All Status Data
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="string"/> representing the asynchronous operation.</returns>
        Task<(string path, string contextType, string fileName)> DownloadInvoiceAsync(Guid id);

        /// <summary>
        /// Update Status Project in Background
        /// </summary>
        /// <returns>A <see cref="Invoice"/> representing the asynchronous operation.</returns>
        Task CronJobSendEmailInvoiceNotSend();

        /// <summary>
        /// Update Status Project in Background
        /// </summary>
        /// <returns>A <see cref="Invoice"/> representing the asynchronous operation.</returns>
        Task CronJobSendEmailInvoiceNotPaid();

        /// <summary>
        /// Update Status Project in Background
        /// </summary>
        /// <returns>A <see cref="Invoice"/> representing the asynchronous operation.</returns>
        Task CronJobGenerateInvoice();
    }
}
