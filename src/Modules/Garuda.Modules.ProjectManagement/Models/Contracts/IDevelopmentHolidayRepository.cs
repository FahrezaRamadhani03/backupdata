// <copyright file="IDevelopmentHolidayRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Garuda.Database.Abstract.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;

namespace Garuda.Modules.ProjectManagement.Models.Contracts
{
    /// <summary>
    /// Entity IDevelopmentHolidayRepository Contract Repository
    /// </summary>
    public interface IDevelopmentHolidayRepository : IRepository
    {
        /// <summary>
        /// Add Or Update Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="DevelopmentHoliday"/> representing the asynchronous operation.</returns>
        Task AddOrUpdate(DevelopmentHoliday model);

        /// <summary>
        /// Get List Data without Filter
        /// </summary>
        /// <returns>A <see cref="List{DevelopmentRole}"/> representing the asynchronous operation.</returns>
        Task<List<DevelopmentHoliday>> GetList();

        /// <summary>
        /// Delete data by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="DevelopmentHoliday"/> representing the asynchronous operation.</returns>
        Task<bool> DeleteById(Guid id);

        /// <summary>
        /// Get List Data by DevelopmentScrumSprintId
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="List{DevelopmentRole}"/> representing the asynchronous operation.</returns>
        Task<List<DevelopmentHoliday>> GetListByDevelopmentScrumSprintId(Guid id);
    }
}
