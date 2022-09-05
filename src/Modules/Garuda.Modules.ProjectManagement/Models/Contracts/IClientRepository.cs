// <copyright file="IClientRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using Garuda.Database.Abstract.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;

namespace Garuda.Modules.ProjectManagement.Models.Contracts
{
    /// <summary>
    /// Entity IClientRepository Contract Repository
    /// </summary>
    public interface IClientRepository : IRepository
    {
        /// <summary>
        /// Add or Update data to Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Client"/> representing the asynchronous operation.</returns>
        Task<Client> AddData(Client model);

        /// <summary>
        /// Get data by Username or Email
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>A <see cref="Client"/> representing the asynchronous operation.</returns>
        Task<Client> GetbyCode(string parameter);

        /// <summary>
        /// Get List Client Data.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>A <see cref="List{Client}"/> representing the asynchronous operation.</returns>
        Task<List<Client>> GetData(bool isActive);

        /// <summary>
        /// Get List Client Data by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Client"/> representing the asynchronous operation.</returns>
        Task<Client> GetDataById(int id);

        /// <summary>
        /// Get Project List Client by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Client"/> representing the asynchronous operation.</returns>
        Task<Client> GetProjectListById(int id);

        /// <summary>
        /// Soft Delete Client
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Client"/> representing the asynchronous operation.</returns>
        Task<bool> SoftDeleteData(int id);

        /// <summary>
        /// Update data to Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Client"/> representing the asynchronous operation.</returns>
        Task<bool> UpdateData(int id, Client model);
    }
}
