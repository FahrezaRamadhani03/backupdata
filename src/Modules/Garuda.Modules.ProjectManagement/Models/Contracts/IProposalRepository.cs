// <copyright file="IProposalRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    /// Entity IProposalRepository Contract Repository
    /// </summary>
    public interface IProposalRepository : IRepository
    {
        /// <summary>
        /// Add Or Update Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Proposal"/> representing the asynchronous operation.</returns>
        Task AddOrUpdate(Proposal model);

        /// <summary>
        /// Get data by DocumentNo
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>A <see cref="Proposal"/> representing the asynchronous operation.</returns>
        Task<Proposal> GetbyProject(Guid parameter);

        /// <summary>
        /// Delete data by ProjectId
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>A <see cref="Proposal"/> representing the asynchronous operation.</returns>
        Task DeleteByProject(Guid parameter);

        /// <summary>
        /// Get proposal amount by Id
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>A <see cref="decimal"/> representing the asynchronous operation.</returns>
        Task<decimal> GetProposalAmount(Guid parameter);

        /// <summary>
        /// Check Document No
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>A <see cref="bool"/> representing the asynchronous operation.</returns>
        Task<bool> IsRegisteredDocumentNo(string parameter, Guid projectId);
    }
}
