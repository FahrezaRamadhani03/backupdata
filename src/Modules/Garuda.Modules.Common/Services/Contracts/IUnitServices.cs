// <copyright file="IUnitServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using Garuda.Modules.Common.Dtos.Responses;

namespace Garuda.Modules.Common.Services.Contracts
{
    /// <summary>
    /// Unit services contract
    /// </summary>
    public interface IUnitServices
    {
        /// <summary>
        /// Get All Unit Data => if isActive == true only fetch active data only else fetch all data
        /// </summary>
        /// <param name="isActive"></param>
        /// <returns>A <see cref="List{UnitDto}"/> representing the asynchronous operation.</returns>
        Task<List<UnitResponses>> GetData(bool isActive);
    }
}
