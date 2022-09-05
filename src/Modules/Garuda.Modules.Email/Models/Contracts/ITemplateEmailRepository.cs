// <copyright file="ITemplateEmailRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Garuda.Database.Abstract.Contracts;
using Garuda.Modules.Email.Models.Datas;

namespace Garuda.Modules.Email.Models.Contracts
{
    /// <summary>
    /// Entity Group Contract Repository
    /// </summary>
    public interface ITemplateEmailRepository : IRepository
    {
        /// <summary>
        /// Add or Update data to Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task AddOrUpdate(TemplateEmail model);

        /// <summary>
        /// Delete data from Table
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Delete(Guid id);

        /// <summary>
        /// Get Data by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="TemplateEmail"/> representing the asynchronous operation.</returns>
        Task<TemplateEmail> GetData(Guid id);

        /// <summary>
        /// Get List Data Menu
        /// </summary>
        /// <returns>A <see cref="List{TemplateEmail}"/> representing the asynchronous operation.</returns>
        Task<List<TemplateEmail>> GetData();

        /// <summary>
        /// Get Data By Technology Name
        /// </summary>
        /// <param name="subject"></param>
        /// <returns>A <see cref="TemplateEmail"/> representing the asynchronous operation.</returns>
        Task<TemplateEmail> GetData(string subject);
    }
}
