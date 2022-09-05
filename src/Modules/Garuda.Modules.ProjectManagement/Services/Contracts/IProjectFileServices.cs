// <copyright file="IProjectFileServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.ProjectFile;
using Garuda.Modules.ProjectManagement.Dtos.Responses.File;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Garuda.Modules.ProjectManagement.Services.Contracts
{
    /// <summary>
    /// ProjectFile services contract
    /// </summary>
    public interface IProjectFileServices
    {
        /// <summary>
        /// Get Project File Data
        /// </summary>
        /// /// <param name="projectId"></param>
        /// <returns>A <see cref="ProjectFileResponses"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetData(Guid projectId, string projectCode);

        /// <summary>
        /// Create ProjectFile Data
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="List<CreateProjectFileRequest></CreateProjectFileRequest>"/> representing the asynchronous operation.</returns>
        Task<MessageDto> CreateData(Guid projectId, string projectCode, List<CreateProjectFileRequest> model);
        
        /// <summary>
        /// Edit ProjectFile Data
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="List<CreateProjectFileRequest></CreateProjectFileRequest>"/> representing the asynchronous operation.</returns>
        Task<MessageDto> EditData(Guid projectId, string projectCode, List<EditProjectFileRequest> model);

        /// <summary>
        /// Download Project File
        /// </summary>
        /// /// <param name="fileName"></param>
        /// <returns>A <see cref="FileResponse"/> representing the asynchronous operation.</returns>
        Task<FileResponse> Download(string fileName);
    }
}
