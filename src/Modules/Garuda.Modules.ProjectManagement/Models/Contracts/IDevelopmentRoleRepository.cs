// <copyright file="IDevelopmentRoleRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    /// Entity IDevelopmentRoleRepository Contract Repository
    /// </summary>
    public interface IDevelopmentRoleRepository : IRepository
    {
        /// <summary>
        /// Add Or Update Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="DevelopmentRole"/> representing the asynchronous operation.</returns>
        Task AddOrUpdate(DevelopmentRole model);

        /// <summary>
        /// Update Data
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="DevelopmentRole"/> representing the asynchronous operation.</returns>
        Task UpdateData(DevelopmentRole model);

        /// <summary>
        /// Get List Data without Filter
        /// </summary>
        /// <returns>A <see cref="List{DevelopmentRole}"/> representing the asynchronous operation.</returns>
        Task<List<DevelopmentRole>> GetList();

        /// <summary>
        /// Get List Data without Filter
        /// </summary>
        /// <returns>A <see cref="model"/> representing the asynchronous operation.</returns>
        Task<DevelopmentRole> FindByCodeAndName(DevelopmentRole model);

        /// <summary>
        /// Get Data by Id
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>A <see cref="DevelopmentRole"/> representing the asynchronous operation.</returns>
        Task<DevelopmentRole> FindById(Guid parameter);

        /// <summary>
        /// Get List Data each data mapper with Level 
        /// </summary>
        /// <returns>A <see cref="string"/> representing the asynchronous operation.</returns>
        Task<List<string>> GetListMapLevel();


        /// <summary>
        /// Get List Data without Filter
        /// </summary>
        /// <returns>A <see cref="model"/> representing the asynchronous operation.</returns>
        Task<DevelopmentRole> FindByName(string name);

        /// <summary>
        /// Delete data by Id
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>A <see cref="DevelopmentRole"/> representing the asynchronous operation.</returns>
        (bool, string) Delete(Guid parameter);
    }
}
