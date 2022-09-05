// <copyright file="IUnitRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Garuda.Database.Abstract.Contracts;
using Garuda.Modules.Common.Models.Datas;

namespace Garuda.Modules.Common.Models.Contracts
{
    /// <summary>
    /// Entity Group Contract Repository
    /// </summary>
    public interface IUnitRepository : IRepository
    {
        /// <summary>
        /// Add or Update data To Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task AddOrUpdate(Unit model);

        /// <summary>
        /// Delete Data by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Delete(Guid id);

        /// <summary>
        /// Get Data By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Unit"/> representing the asynchronous operation.</returns>
        Task<Unit> GetData(Guid id);

        /// <summary>
        /// Get Data. if parameter set to true then only show active data, else show all data
        /// </summary>
        /// <param name="isActive"></param>
        /// <returns>A <see cref="List{Unit}"/> representing the asynchronous operation.</returns>
        Task<List<Unit>> GetData(bool isActive);
    }
}
