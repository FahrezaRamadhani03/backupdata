// <copyright file="IContractRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    /// Entity IContractRepository Contract Repository
    /// </summary>
    public interface IContractInfoRepository : IRepository
    {
        /// <summary>
        /// Add Or Update Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="ContractInfo"/> representing the asynchronous operation.</returns>
        Task AddOrUpdate(ContractInfo model);

        /// <summary>
        /// Get data by DocumentNo
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>A <see cref="ContractInfo"/> representing the asynchronous operation.</returns>
        Task<ContractInfo> GetbyProject(Guid parameter);

        /// <summary>
        /// Delete data by ProjectId
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>A <see cref="ContractInfo"/> representing the asynchronous operation.</returns>
        Task DeleteByProject(Guid parameter);

        /// <summary>
        /// Check Garuda Contract No
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>A <see cref="bool"/> representing the asynchronous operation.</returns>
        Task<bool> IsRegisteredGarudaContractNo(string parameter, Guid projectId);

        /// <summary>
        /// Check Client Contract No
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>A <see cref="bool"/> representing the asynchronous operation.</returns>
        Task<bool> IsRegisteredClientContractNo(string parameter, Guid projectId);
    }
}
