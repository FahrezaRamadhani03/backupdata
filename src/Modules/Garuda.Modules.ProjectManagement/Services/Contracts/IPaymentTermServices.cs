// <copyright file="IPaymentTermServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.PaymentTerm;

namespace Garuda.Modules.ProjectManagement.Services.Contracts
{
    /// <summary>
    /// Technologies contract services
    /// </summary>
    public interface IPaymentTermServices
    {
        /// <summary>
        /// Get Payment Term by Project Id
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<MessageDto> GetPaymentTermByProjectId(Guid projectId);

        /// <summary>
        /// Get Payment Term by Project Id
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<MessageDto> GetPaymentTermByUnpaid(Guid projectId);

        /// <summary>
        /// Create new Payment Term
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<MessageDto> CreatePaymentTerms(CreatePaymentTermRequest model);
    }
}
