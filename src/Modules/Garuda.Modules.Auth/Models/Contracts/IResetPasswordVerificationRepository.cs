// <copyright file="IResetPasswordVerificationRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Garuda.Database.Abstract.Contracts;
using Garuda.Modules.Auth.Models.Datas;

namespace Garuda.Modules.Auth.Models.Contracts
{
    /// <summary>
    /// Entity Reset Password Verification Repository
    /// </summary>
    public interface IResetPasswordVerificationRepository : IRepository
    {
        /// <summary>
        /// Add or Update ResetPasswordVerification to Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task AddOrUpdate(ResetPasswordVerification model);

        /// <summary>
        /// Get data by Code
        /// </summary>
        /// <param name="code"></param>
        /// <returns>A <see cref="ResetPasswordVerification"/> representing the asynchronous operation.</returns>
        Task<ResetPasswordVerification> GetData(string code);

        /// <summary>
        /// Get all data
        /// </summary>
        /// <returns>A <see cref="ResetPasswordVerification"/> representing the asynchronous operation.</returns>
        Task<List<ResetPasswordVerification>> GetAllData();
    }
}
