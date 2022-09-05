// <copyright file="IProjectDetailServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos;
using Garuda.Modules.Common.Dtos.Responses;
using Garuda.Modules.ProjectManagement.Dtos.Requests.ProjectDetails;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Project;
using Sieve.Models;
using Microsoft.AspNetCore.Http;

namespace Garuda.Modules.ProjectManagement.Services.Contracts
{
    /// <summary>
    /// Project Detail Services contract
    /// </summary>
    public interface IProjectDetailServices
    {
        /// <summary>
        /// Create Project Detail Data
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="CreateProjectDetailRequest"/> representing the asynchronous operation.</returns>
        Task<MessageDto> CreateData(CreateProjectDetailRequest model, Guid userId);

        /// <summary>
        /// Get Project Detail Data by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="ProjectDetailDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetDataById(Guid id);

        /// <summary>
        /// Edit Project Detail Data
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="EditProjectDetailRequest"/> representing the asynchronous operation.</returns>
        Task<MessageDto> EditData(EditProjectDetailRequest model);

        /// <summary>
        /// Get Project Data
        /// </summary>
        /// /// <param name="sieveModel"></param>
        /// <returns>A <see cref="ProjectListResponses"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetData(SieveModel sieveModel);

        /// <summary>
        /// Get Project Data
        /// </summary>
        /// <returns>A <see cref="ProjectListResponses"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetData();

        /// <summary>
        /// Get Project Short Info
        /// </summary>
        /// /// <param name="id"></param>
        /// <returns>A <see cref="ProjectShortInfoResponses"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetShortInfo(Guid id);

        /// <summary>
        /// Get paged list of active project
        /// </summary>
        /// <param name="sieveModel"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<PaginatedResponses<ProjectListResponses>> GetPagedListProject(SieveModel sieveModel);

        /// <summary>
        /// Update Project Status Data
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="UpdateStatusRequest"/> representing the asynchronous operation.</returns>
        Task<MessageDto> UpdateStatus(UpdateStatusRequest model, Guid userId);

        /// <summary>
        /// Update Status Project in Background
        /// </summary>
        /// <returns>A <see cref="ProjectDetail"/> representing the asynchronous operation.</returns>
        Task CronJobUpdateStatus();
    }
}
