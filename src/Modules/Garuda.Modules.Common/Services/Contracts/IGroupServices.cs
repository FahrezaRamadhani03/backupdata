// <copyright file="IGroupServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using Garuda.Modules.Common.Dtos.Responses;

namespace Garuda.Modules.Common.Services.Contracts
{
    /// <summary>
    /// Group services contract
    /// </summary>
    public interface IGroupServices
    {
        /// <summary>
        /// Get All Group Data
        /// </summary>
        /// <param name="isActive"></param>
        /// <returns>A <see cref="List{GroupDto}"/> representing the asynchronous operation.</returns>
        Task<List<GroupResponses>> GetData(bool isActive);
    }
}
