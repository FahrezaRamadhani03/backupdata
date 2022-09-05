// <copyright file="ITechnologyServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Technology;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Technology;

namespace Garuda.Modules.ProjectManagement.Services.Contracts
{
    /// <summary>
    /// Technologies contract services
    /// </summary>
    public interface ITechnologyServices
    {
        /// <summary>
        /// Get Technology
        /// </summary>
        /// <param></param>
        /// <returns>A <see cref="TechnologyResponses"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetListTechnology();

        /// <summary>
        /// Create new Technology
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<MessageDto> CreateTechnology(CreateTechnologyRequests model);
    }
}
