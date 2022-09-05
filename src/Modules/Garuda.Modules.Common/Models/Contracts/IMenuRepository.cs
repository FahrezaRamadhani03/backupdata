// <copyright file="IMenuRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public interface IMenuRepository : IRepository
    {
        /// <summary>
        /// Add or Update data to Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task AddOrUpdate(Menu model);

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
        /// <returns>A <see cref="Menu"/> representing the asynchronous operation.</returns>
        Task<Menu> GetData(Guid id);

        /// <summary>
        /// Get List Data Menu
        /// </summary>
        /// <returns>A <see cref="List{Menu}"/> representing the asynchronous operation.</returns>
        Task<List<Menu>> GetData();

        /// <summary>
        /// Get List Data Parent Menu
        /// </summary>
        /// <param name="isParent"></param>
        /// <param name="userId"></param>
        /// <returns>A <see cref="List{Menu}"/> representing the asynchronous operation.</returns>
        Task<List<Menu>> GetData(bool isParent, Guid userId);

        /// <summary>
        /// Get List data By Parent Id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isList"></param>
        /// <returns>A <see cref="List{Menu}"/> representing the asynchronous operation.</returns>
        Task<List<Menu>> GetData(Guid id, bool isList);
    }
}
