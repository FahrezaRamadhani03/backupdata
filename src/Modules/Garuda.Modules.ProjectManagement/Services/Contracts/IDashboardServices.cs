// <copyright file="IDashboardServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;

namespace Garuda.Modules.ProjectManagement.Services.Contracts
{
    /// <summary>
    /// Dashboard Services services contract
    /// </summary>
    public interface IDashboardServices
    {
        /// <summary>
        /// Get All Project Summary Data
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetProjectSummary();

        /// <summary>
        /// Get All Recent Project Summary Data
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetRecentProject();

        /// <summary>
        /// Get All Recent Project Summary by Invoice Data
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetRecentProjectInvoice();
    }
}
