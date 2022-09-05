// <copyright file="IProfitProjectServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Sieve.Models;

namespace Garuda.Modules.ProjectManagement.Services.Contracts
{
    /// <summary>
    /// Status services contract
    /// </summary>
    public interface IProfitProjectServices
    {
        /// <summary>
        /// Get All Status Data
        /// </summary>
        /// /// <param name="sieveModel"></param>
        /// /// <param name="year"></param>
        /// <returns>A <see cref="string"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetDatas(SieveModel sieveModel, int year);

        /// <summary>
        /// Get All Status Data
        /// </summary>
        /// <returns>A <see cref="string"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetYear();
    }
}
