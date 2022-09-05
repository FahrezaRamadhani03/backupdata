// <copyright file="IEmployeeServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Sieve.Models;

namespace Garuda.Modules.ProjectManagement.Services.Contracts
{
    /// <summary>
    /// User Service Contracts
    /// </summary>
    public interface IEmployeeServices
    {
        /// <summary>
        /// Get list of active employee
        /// </summary>
        /// <param name="sieveModel"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<MessageDto> GetListEmployeeWithDevelopmentRole(SieveModel sieveModel);

        /// <summary>
        /// Get list of active employee
        /// </summary>
        /// <param name="sieveModel"></param>
        /// <param name="clientId"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<MessageDto> GetListEmployeeForScrumTeam(SieveModel sieveModel, int? clientId);
    }
}
