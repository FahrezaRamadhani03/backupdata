// <copyright file="IHolidayRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    /// Entity IHolidayRepository Contract Repository
    /// </summary>
    public interface IHolidayRepository : IRepository
    {
        /// <summary>
        /// Add Or Update Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Holiday"/> representing the asynchronous operation.</returns>
        Task AddOrUpdate(Holiday model);

        /// <summary>
        /// Get List Data without Filter
        /// </summary>
        /// <returns>A <see cref="List{Holiday}"/> representing the asynchronous operation.</returns>
        Task<List<Holiday>> GetList();

        /// <summary>
        /// Get List Data with Filter
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>A <see cref="List{Holiday}"/> representing the asynchronous operation.</returns>
        Task<List<Holiday>> GetList(DateTime start, DateTime end);
    }
}
