// <copyright file="ICityRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    /// Entity Group Contract City Repository
    /// </summary>
    public interface ICityRepository : IRepository
    {
        /// <summary>
        /// Add or Update data to Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task AddOrUpdate(City model);

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
        /// <returns>A <see cref="City"/> representing the asynchronous operation.</returns>
        Task<City> GetData(Guid id);

        /// <summary>
        /// Get Data by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A <see cref="City"/> representing the asynchronous operation.</returns>
        Task<City> GetData(string name);

        /// <summary>
        /// Get List Data
        /// </summary>
        /// <returns>A <see cref="List{City}"/> representing the asynchronous operation.</returns>
        Task<List<City>> GetData();

        /// <summary>
        /// Check duplicate data by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A <see cref="bool"/> representing the asynchronous operation.</returns>
        Task<bool> IsRegisteredName(string name);
    }
}
