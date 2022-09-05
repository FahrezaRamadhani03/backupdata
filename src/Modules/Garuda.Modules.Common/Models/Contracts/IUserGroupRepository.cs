// <copyright file="IUserGroupRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public interface IUserGroupRepository : IRepository
    {
        /// <summary>
        /// Add or Update data to Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task AddOrUpdate(UserGroup model);

        /// <summary>
        /// Delete data from Table
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Delete(Guid id);

        /// <summary>
        /// Get Data by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="UserGroup"/> representing the asynchronous operation.</returns>
        Task<UserGroup> GetData(Guid id);

        /// <summary>
        /// Get List data. if isActive == true will be filtered active data only else will show all data.
        /// </summary>
        /// <param name="isActive"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<List<UserGroup>> GetData(bool isActive);

        /// <summary>
        /// Get List Data. if isUser == true will filtered by UserId, if isUser == false will filtered by GroupId
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isUser"></param>
        /// <returns>A <see cref="List{UserGroup}"/> representing the result of the asynchronous operation.</returns>
        Task<List<UserGroup>> GetData(Guid id, bool isUser);

        /// <summary>
        /// Get List QpbAdministrator
        /// </summary>
        /// <returns>A <see cref="List{UserGroup}"/> representing the asynchronous operation.</returns>
        Task<List<UserGroup>> GetQpbAdministrator();
    }
}
