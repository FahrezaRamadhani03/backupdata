// <copyright file="IEmployeeRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Garuda.Database.Abstract.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;

namespace Garuda.Modules.ProjectManagement.Models.Contracts
{
    /// <summary>
    /// Entity Group Contract Repository
    /// </summary>
    public interface IEmployeeRepository : IRepository
    {
        /// <summary>
        /// Add or Update User to Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task AddOrUpdate(Employee model);

        /// <summary>
        /// Delete Data from Table
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Delete(Guid id);

        /// <summary>
        /// Get Data by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Employee"/> representing the asynchronous operation.</returns>
        Task<Employee> GetData(Guid id);

        /// <summary>
        /// Get data by Username or Email
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>A <see cref="Employee"/> representing the asynchronous operation.</returns>
        Task<Employee> GetData(string parameter);

        /// <summary>
        /// Get List data Employee.
        /// </summary>
        /// <returns>A <see cref="List{Employee}"/> representing the asynchronous operation.</returns>
        Task<List<Employee>> GetData();

        /// <summary>
        /// Get data Employee by User Id.
        /// </summary>
        /// <returns>A <see cref="List{Employee}"/> representing the asynchronous operation.</returns>
        Task<Employee> GetDataByUserId(Guid id);
    }
}
