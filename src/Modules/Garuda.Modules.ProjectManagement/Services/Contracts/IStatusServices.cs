// <copyright file="IStatusServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;

namespace Garuda.Modules.ProjectManagement.Services.Contracts
{
    /// <summary>
    /// Status services contract
    /// </summary>
    public interface IStatusServices
    {
        /// <summary>
        /// Get All Status Data
        /// </summary>
        /// <returns>A <see cref="string"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetAllData();
    }
}
