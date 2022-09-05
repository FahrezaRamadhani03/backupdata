// <copyright file="IDevelopmentHolidayServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;

namespace Garuda.Modules.ProjectManagement.Services.Contracts
{
    /// <summary>
    /// Book services contract
    /// </summary>
    public interface IDevelopmentHolidayServices
    {
        /// <summary>
        /// Get All Development Holiday Data
        /// </summary>
        /// <returns>A <see cref="DevelopmentHolidaysReponses"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetAllData();
    }
}
