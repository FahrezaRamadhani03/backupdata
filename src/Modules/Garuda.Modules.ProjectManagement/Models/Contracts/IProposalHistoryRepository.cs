// <copyright file="IProposalHistoryRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    /// Entity IProposalHistoryRepository Contract Repository
    /// </summary>
    public interface IProposalHistoryRepository : IRepository
    {
        /// <summary>
        /// Add data to Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="ProposalHistory"/> representing the asynchronous operation.</returns>
        Task<ProposalHistory> AddData(ProposalHistory model);

        /// <summary>
        /// Get data by ProjectId
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>A <see cref="ProposalHistory"/> representing the asynchronous operation.</returns>
        Task<List<ProposalHistory>> GetbyProject(Guid parameter);
    }
}
