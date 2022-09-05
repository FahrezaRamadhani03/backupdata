// <copyright file="IUserUnitRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public interface IUserUnitRepository : IRepository
    {
        /// <summary>
        /// Add or Update data to Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task AddOrUpdate(UserUnit model);

        /// <summary>
        /// Delete data from table
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Delete(Guid id);

        /// <summary>
        /// Get data by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="UserUnit"/> representing the asynchronous operation.</returns>
        Task<UserUnit> GetData(Guid id);

        /// <summary>
        /// Get Data list user unit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isUser"></param>
        /// <returns>A <see cref="List{UserUnit}"/> representing the asynchronous operation.</returns>
        Task<List<UserUnit>> GetData(Guid id, bool isUser);

        /// <summary>
        /// Get Mine Head by UnitId
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<UserUnit> GetUserByMineHead(Guid id);
    }
}
