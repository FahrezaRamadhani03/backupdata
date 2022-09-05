// <copyright file="ILevelServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Level;

namespace Garuda.Modules.ProjectManagement.Services.Contracts
{
    /// <summary>
    /// Technologies contract services
    /// </summary>
    public interface ILevelServices
    {
        /// <summary>
        /// Get Level
        /// </summary>
        /// <returns>A <see cref="LevelResponses"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetListLevel();

        /// <summary>
        /// Create new Level
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<MessageDto> CreateLevel(CreateLevelRequests model);
    }
}
