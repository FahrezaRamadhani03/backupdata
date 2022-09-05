// <copyright file="IClientServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;
using Garuda.Modules.Common.Dtos.Responses;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Client;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Client;
using Sieve.Models;

namespace Garuda.Modules.ProjectManagement.Services.Contracts
{
    /// <summary>
    /// Client services contract
    /// </summary>
    public interface IClientServices
    {
        /// <summary>
        /// Create Client Data
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="CreateClientRequest"/> representing the asynchronous operation.</returns>
        Task<MessageDto> CreateData(CreateClientRequest model);

        /// <summary>
        /// Get Client Data
        /// </summary>
        /// /// <param name="sieveModel"></param>
        /// <returns>A <see cref="ClientResponses"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetData();

        /// <summary>
        /// Get paged list of active users
        /// </summary>
        /// <param name="sieveModel"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<PaginatedResponses<ClientResponses>> GetPagedListClient(SieveModel sieveModel);

        /// <summary>
        /// Get Client Data by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetDataById(int id);

        /// <summary>
        /// Get Client Project List by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetProjectListById(int id);

        /// <summary>
        /// Soft Delete Client
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> SoftDeleteClient(int id);

        /// <summary>
        /// Update Client Data
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> UpdateClient(int id, CreateClientRequest model);
    }
}
