// <copyright file="IUserSessionRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Garuda.Database.Abstract.Contracts;
using Garuda.Modules.Common.Models.Datas;

namespace Garuda.Modules.Common.Models.Contracts
{
    /// <summary>
    /// Entity Group Contract Repository
    /// </summary>
    public interface IUserSessionRepository : IRepository
    {
        /// <summary>
        /// Add or Update data to Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task AddOrUpdate(UserSession model);

        /// <summary>
        /// Delete data from Table
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Delete(Guid id);

        /// <summary>
        /// Get Refresh Token by userId, jti
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="jti"></param>
        /// <param name="revoked"></param>
        /// <returns>A <see cref="UserSession"/> representing the asynchronous operation.</returns>
        Task<UserSession> GetRefreshToken(Guid userId, string jti, bool revoked);

        /// <summary>
        /// Get Refresh token by Jti and Expired
        /// </summary>
        /// <param name="jti"></param>
        /// <param name="revoked"></param>
        /// <param name="expired"></param>
        /// <returns>A <see cref="UserSession"/> representing the asynchronous operation.</returns>
        Task<UserSession> GetRefreshToken(string jti, bool revoked, DateTime expired);

        /// <summary>
        /// Get Refresh Token by UserId and Expired
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="revoked"></param>
        /// <param name="expired"></param>
        /// <returns>A <see cref="UserSession"/> representing the asynchronous operation.</returns>
        Task<List<UserSession>> GetRefreshToken(Guid userId, bool revoked, DateTime expired);
    }
}
