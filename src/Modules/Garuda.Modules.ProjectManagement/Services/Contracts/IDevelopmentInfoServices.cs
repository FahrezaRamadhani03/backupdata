// <copyright file="IDevelopmentInfoServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentInfo;
using Microsoft.AspNetCore.Http;

namespace Garuda.Modules.ProjectManagement.Services.Contracts
{
    /// <summary>
    /// DevelopmentInfo Services services contract
    /// </summary>
    public interface IDevelopmentInfoServices
    {
        /// <summary>
        /// Get All Development Roles Data
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetDayOfSprint();

        /// <summary>
        /// Get All Holidays Data
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetHolidays();

        /// <summary>
        /// Get All Holidays Data
        /// </summary>
        /// /// <param name="start"></param>
        /// /// <param name="end"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetHolidays(DateTime start, DateTime end);

        /// <summary>
        /// Create Development Info Data
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> CreateData(CreateDevelopmentInfoRequest model, Guid userId);

        /// <summary>
        /// Get All Sprint Data
        /// </summary>
        /// /// <param name="parameter"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetSprintList(Guid parameter);

        /// <summary>
        /// Edit Development Info Data
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> EditData(EditDevelopmentInfoRequest model);

        /// <summary>
        /// Edit Development Info Data
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetData(Guid id);

        /// <summary>
        /// Add Extend Days
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> AddExtendDays(AddExtendDaysRequest model);

        /// <summary>
        /// Edit Sprint
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> EditSprint(EditSprintRequest model, Guid id);
    }
}
