// <copyright file="IProposalServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Proposal;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Microsoft.AspNetCore.Http;

namespace Garuda.Modules.ProjectManagement.Services.Contracts
{
    /// <summary>
    /// Proposal services contract
    /// </summary>
    public interface IProposalServices
    {
        /// <summary>
        /// Get Proposal Data
        /// </summary>
        /// /// <param name="projectId"></param>
        /// <returns>A <see cref="ProposalResponses"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetData(Guid projectId);

        /// <summary>
        /// Create Proposal Data
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="CreateProposalRequest"/> representing the asynchronous operation.</returns>
        Task<MessageDto> CreateData(CreateProposalRequest model, Guid userId);

        /// <summary>
        /// Get Proposal History Data
        /// </summary>
        /// /// <param name="projectId"></param>
        /// <returns>A <see cref="ProposalHistory"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetHistory(Guid projectId);

        /// <summary>
        /// Download Proposal File
        /// </summary>
        /// /// <param name="fileName"></param>
        /// <returns>A <see cref="Proposal"/> representing the asynchronous operation.</returns>
        (string path, string contextType, string fileName) Download(string fileName);
    }
}
