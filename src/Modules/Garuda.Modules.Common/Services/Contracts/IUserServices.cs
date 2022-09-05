// <copyright file="IUserServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.Common.Dtos.Requests;
using Garuda.Modules.Common.Dtos.Responses;
using Microsoft.AspNetCore.Http;
using Sieve.Models;

namespace Garuda.Modules.Common.Services.Contracts
{
    /// <summary>
    /// User Service Contracts
    /// </summary>
    public interface IUserServices
    {
        /// <summary>
        /// Get user profile by user id
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<UserProfileResponses> GetUserProfile(HttpContext httpContext);

        /// <summary>
        /// Get paged list of active users
        /// </summary>
        /// <param name="sieveModel"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<PaginatedResponses<UsersResponses>> GetPagedListUser(SieveModel sieveModel);

        /// <summary>
        /// Get list of active users
        /// </summary>
        /// <param name="sieveModel"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<List<UsersResponses>> GetListUser(SieveModel sieveModel);

        /// <summary>
        /// Get AD user by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<UsersResponses> GetADUser(string username);

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<MessageDto> CreateUser(CreateUserRequests model);

        /// <summary>
        /// Edit user by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<MessageDto> EditUser(Guid id, EditUserRequests model);
    }
}
