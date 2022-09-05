// <copyright file="IBankServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Bank;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Bank;

namespace Garuda.Modules.ProjectManagement.Services.Contracts
{
    /// <summary>
    /// Technologies contract services
    /// </summary>
    public interface IBankServices
    {
        /// <summary>
        /// Get Technology
        /// </summary>
        /// <returns>A <see cref="BankResponses"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetListBank();

        /// <summary>
        /// Create new Technology
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<MessageDto> CreateBank(CreateBankRequests model);
    }
}
