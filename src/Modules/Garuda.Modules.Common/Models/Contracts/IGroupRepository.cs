// <copyright file="IGroupRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public interface IGroupRepository : IRepository
    {
        /// <summary>
        /// Add or Update data to Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task AddOrUpdate(Group model);

        /// <summary>
        /// Delete data from Table
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Delete(Guid id);

        /// <summary>
        /// Get Data by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Group"/> representing the asynchronous operation.</returns>
        Task<Group> GetData(Guid id);

        /// <summary>
        /// Get List Group Data.
        /// </summary>
        /// <param name="isActive"></param>
        /// <returns>A <see cref="List{Group}"/> representing the asynchronous operation.</returns>
        Task<List<Group>> GetData(bool isActive);
    }
}
