// <copyright file="IDevelopmentRoleService.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentRole;
using Microsoft.AspNetCore.Mvc;

namespace Garuda.Modules.ProjectManagement.Services.Contracts
{
    /// <summary>
    /// DevelopmentRole services contract
    /// </summary>
    public interface IDevelopmentRoleService
    {
        /// <summary>
        /// Create Development Roles Data
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="CreateDevelopmentRoleRequest"/> representing the asynchronous operation.</returns>
        Task<MessageDto> CreateData(CreateDevelopmentRoleRequest model);

        /// <summary>
        /// Get All Development Roles Data with level
        /// </summary>
        /// <returns>A <see cref="DevelopmentRoleResponses"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetAllData();

        /// <summary>
        /// Get All Development Roles Data
        /// </summary>
        /// <returns>A <see cref="DevelopmentRoleResponses"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetData();

        /// <summary>
        /// Update Development Role Data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns>A <see cref="CreateDevelopmentRoleRequest"/> representing the asynchronous operation.</returns>
        Task<MessageDto> UpdateData(Guid id, CreateDevelopmentRoleRequest model);

        /// <summary>
        /// Delete Development Role Data
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>A <see cref="Task{DevelopmentRoleResponses}"/> representing the asynchronous operation.</returns>
        Task<MessageDto> Delete(Guid parameter);
    }
}
