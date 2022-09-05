// <copyright file="IGroupMenuPermissionsRepository.cs" company="CV Garuda Infinity Kreasindo">
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
    public interface IGroupMenuPermissionsRepository : IRepository
    {
        /// <summary>
        /// Add Or Update Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task AddOrUpdate(GroupMenuPermission model);

        /// <summary>
        /// Delete Table
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Delete(Guid id);

        /// <summary>
        /// Get 1 Data By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="GroupMenuPermission"/> representing the asynchronous operation.</returns>
        Task<GroupMenuPermission> GetById(Guid id);

        /// <summary>
        /// Get List Data without Filter
        /// </summary>
        /// <returns>A <see cref="List{GroupMenuPermission}"/> representing the asynchronous operation.</returns>
        Task<List<GroupMenuPermission>> GetList();

        /// <summary>
        /// Get List Data. if byMenu == true will filtered by menuId, if byMenu == false will filtered by group id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="byMenu"></param>
        /// <returns>A <see cref="List{GroupMenuPermission}"/> representing the asynchronous operation.</returns>
        Task<List<GroupMenuPermission>> GetList(Guid id, bool byMenu);

        /// <summary>
        /// Get List data by Menu Id and Group Id
        /// </summary>
        /// <param name="menuId"></param>
        /// <param name="groupId"></param>
        /// <returns>A <see cref="List{GroupMenuPermission}"/> representing the asynchronous operation.</returns>
        Task<List<GroupMenuPermission>> GetList(Guid menuId, Guid groupId);
    }
}
