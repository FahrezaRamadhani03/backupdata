// <copyright file="IDevelopmentScrumServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;

namespace Garuda.Modules.ProjectManagement.Services.Contracts
{
    /// <summary>
    /// Development Scrum services contract
    /// </summary>
    public interface IDevelopmentScrumServices
    {
        /// <summary>
        /// Get All Development Roles Data
        /// </summary>
        /// <returns>A <see cref="DevelopmentScrum"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetAllData();
    }
}
