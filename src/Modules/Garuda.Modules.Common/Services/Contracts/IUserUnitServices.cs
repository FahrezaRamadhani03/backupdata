// <copyright file="IUserUnitServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Garuda.Modules.Common.Dtos.Responses;

namespace Garuda.Modules.Common.Services.Contracts
{
    /// <summary>
    /// User Unit Services
    /// </summary>
    public interface IUserUnitServices
    {
        /// <summary>
        /// Get User by Mine Head by selected Unit
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<UserResponses> GetUserByMineHead(Guid id);
    }
}
