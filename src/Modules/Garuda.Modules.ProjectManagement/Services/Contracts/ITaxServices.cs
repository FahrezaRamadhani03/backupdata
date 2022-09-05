// <copyright file="ITaxServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Tax;
using Garuda.Modules.ProjectManagement.Dtos.Responses;
using Sieve.Models;

namespace Garuda.Modules.ProjectManagement.Services.Contracts
{
    /// <summary>
    /// Technologies contract services
    /// </summary>
    public interface ITaxServices
    {
        /// <summary>
        /// Get Taxes
        /// </summary>
        /// <returns>A <see cref="TaxResponses"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetListTax(SieveModel model);

        /// <summary>
        /// Post Taxes
        /// </summary>
        /// <returns>A <see cref="TaxResponses"/> representing the asynchronous operation.</returns>
        Task<MessageDto> CreateData(TaxRequest model);

        /// <summary>
        /// Edit Taxes
        /// </summary>
        /// <returns>A <see cref="TaxResponses"/> representing the asynchronous operation.</returns>
        Task<MessageDto> EditData(Guid id, TaxRequest model);

        /// <summary>
        /// Delete Taxes
        /// </summary>
        /// <returns>A <see cref="TaxResponses"/> representing the asynchronous operation.</returns>
        Task<MessageDto> DeleteData(Guid id);
    }
}
