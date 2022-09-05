// <copyright file="IProjectDetailRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garuda.Database.Abstract.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;

namespace Garuda.Modules.ProjectManagement.Models.Contracts
{
    /// <summary>
    /// Entity IDevelopmentRoleRepository Contract Repository
    /// </summary>
    public interface IProjectDetailRepository : IRepository
    {
        /// <summary>
        /// Get List Project Data.
        /// </summary>
        /// <returns>A <see cref="List{ProjectDetail}"/> representing the asynchronous operation.</returns>
        Task<List<ProjectDetail>> GetData(bool isActive);

        /// <summary>
        /// Get Project Short Info.
        /// </summary>
        /// /// <param name="id"></param>
        /// <returns>A <see cref="ProjectDetail"/> representing the asynchronous operation.</returns>
        Task<ProjectDetail> GetById(Guid id);

        /// <summary>
        /// Add Or Update Table
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="DevelopmentRole"/> representing the asynchronous operation.</returns>
        Task AddOrUpdate(ProjectDetail model);

        /// <summary>
        /// Check Project has been Registered by Key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>A <see cref="bool"/> representing the asynchronous operation.</returns>
        Task<bool> IsRegisteredByProjectKey(string key);

        /// <summary>
        /// Add Or Update Table
        /// </summary>
        /// <returns>A <see/> representing the asynchronous operation.</returns>
        Task<string> GetCodeAtLastData();

        /// <summary>
        /// Check Project has been Registered by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="bool"/> representing the asynchronous operation.</returns>
        Task<bool> IsRegisteredById(Guid id);

        /// <summary>
        /// Find Project By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="bool"/> representing the asynchronous operation.</returns>
        Task<ProjectDetail> FindById(Guid id);

        /// <summary>
        /// Get List Data Menu
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>A <see cref="ProjectDetail"/> representing the asynchronous operation.</returns>
        Task<ProjectDetail> GetPaymentTermbyProjectId(Guid projectId);

        /// <summary>
        /// Get Project Development Info
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>A <see cref="ProjectDetail"/> representing the asynchronous operation.</returns>
        Task<ProjectDetail> GetDevelopmentInfoByProjectId(Guid projectId);

        /// <summary>
        /// Get List Data Menu
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>A <see cref="ProjectDetail"/> representing the asynchronous operation.</returns>
        Task<ProjectDetail> GetDevelopmentTeambyProjectId(Guid projectId);

        /// <summary>
        /// Get List Project Data.
        /// </summary>
        /// <returns>A <see cref="List{ProjectDetail}"/> representing the asynchronous operation.</returns>
        Task<List<ProjectDetail>> GetDataTimeline();

        /// <summary>
        /// Get List Project Data.
        /// </summary>
        /// <returns>A <see cref="List{ProjectDetail}"/> representing the asynchronous operation.</returns>
        IQueryable<ProjectDetail> GetDataTimelineAsQueryable();

        /// <summary>
        /// Get List Project Data Last Update.
        /// </summary>
        /// <returns>A <see cref="List{ProjectDetail}"/> representing the asynchronous operation.</returns>
        Task<List<ProjectDetail>> GetDatabyLastUpdate();

        /// <summary>
        /// Get List Project Data Last Created.
        /// </summary>
        /// <returns>A <see cref="List{ProjectDetail}"/> representing the asynchronous operation.</returns>
        Task<List<ProjectDetail>> GetDatabyCreated();

        /// <summary>
        /// Get Changed Status Data
        /// </summary>
        /// <returns>A <see cref="ProjectDetail"/> representing the asynchronous operation.</returns>
        Task<List<ProjectDetail>> GetChangedStatusData();

        /// <summary>
        /// Get Invoices Data
        /// </summary>
        /// <returns>A <see cref="ProjectDetail"/> representing the asynchronous operation.</returns>
        Task<List<ProjectDetail>> GetInvoices();

        /// <summary>
        /// Get Invoices Data
        /// </summary>
        /// <returns>A <see cref="ProjectDetail"/> representing the asynchronous operation.</returns>
        Task<List<ProjectDetail>> GetAllInvoices();

        /// <summary>
        /// Get Invoices Data
        /// </summary>
        /// <param name="year"></param>
        /// <returns>A <see cref="ProjectDetail"/> representing the asynchronous operation.</returns>
        Task<List<ProjectDetail>> GetProfitProject(int year);

        /// <summary>
        /// Update Status
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="ProjectDetail"/> representing the asynchronous operation.</returns>
        Task UpdateStatus(Guid id, string status);

        /// <summary>
        /// Get last invoice no
        /// </summary>
        /// <returns>A <see cref="int"/> representing the asynchronous operation.</returns>
        Task<int> GetLastInvoicesNo(Guid projectId);
    }
}
