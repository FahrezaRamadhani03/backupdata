// <copyright file="IUserRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public interface IUserRepository : IRepository
    {
        /// <summary>
        /// Add or Update User to Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task AddOrUpdate(User model);

        /// <summary>
        /// Update User Password
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task UpdatePassword(User model);

        /// <summary>
        /// Delete Data from Table
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Delete(Guid id);

        /// <summary>
        /// Get Data by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="User"/> representing the asynchronous operation.</returns>
        Task<User> GetData(Guid id);

        /// <summary>
        /// Get data by Username or Email
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>A <see cref="User"/> representing the asynchronous operation.</returns>
        Task<User> GetData(string parameter);

        /// <summary>
        /// Get List data User. if isActive is true => all active user. if isActive is false => all user whether active or inactive.
        /// </summary>
        /// <param name="isActive"></param>
        /// <returns>A <see cref="List{User}"/> representing the asynchronous operation.</returns>
        Task<List<User>> GetData(bool isActive);
    }
}
