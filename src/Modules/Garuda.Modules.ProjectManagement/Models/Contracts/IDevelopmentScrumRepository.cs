﻿// <copyright file="IDevelopmentScrum.cs" company="CV Garuda Infinity Kreasindo">
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
    public interface IDevelopmentScrumRepository : IRepository
    {
        /// <summary>
        /// Add Or Update Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="DevelopmentScrum"/> representing the asynchronous operation.</returns>
        Task AddOrUpdate(DevelopmentScrum model);

        /// <summary>
        /// Get List Data without Filter
        /// </summary>
        /// <returns>A <see cref="List{DevelopmentScrum}"/> representing the asynchronous operation.</returns>
        Task<List<DevelopmentScrum>> GetList();

        /// <summary>
        /// Get Data by Project Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="DevelopmentScrum"/> representing the asynchronous operation.</returns>
        Task<DevelopmentScrum> GetDataByProjectId(Guid id);

        /// <summary>
        /// Get Data include Sprint by Project Id
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>A <see cref="DevelopmentScrum"/> representing the asynchronous operation.</returns>
        Task<DevelopmentScrum> GetDataSprintByProject(Guid parameter);
    }
}
