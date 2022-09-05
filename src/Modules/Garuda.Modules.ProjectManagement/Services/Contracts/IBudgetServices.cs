// <copyright file="IBudgetServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Budget;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Client;
using Sieve.Models;

namespace Garuda.Modules.ProjectManagement.Services.Contracts
{
    /// <summary>
    /// Budget Services contract
    /// </summary>
    public interface IBudgetServices
    {
        /// <summary>
        /// Get Budget Types
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetBudgetTypes(SieveModel model);

        /// <summary>
        /// Get Budget Types
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetBudgetActivities(SieveModel model);

        /// <summary>
        /// Get Budget Types by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetBudgetTypes(Guid id);

        /// <summary>
        /// Get Budget Activity
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetBudgetActivities(Guid id);

        /// <summary>
        /// Post Budget Types
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> CreateBudgetTypes(BudgetTypeRequest model);

        /// <summary>
        /// Post Budget Types
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> EditBudgetTypes(BudgetTypeRequest model, Guid id);

        /// <summary>
        /// Post Budget Types
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> DeleteBudgetTypes(Guid id);

        /// <summary>
        /// Post Budget Activities
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> CreateBudgetActivities(BudgetActivyRequest model);

        /// <summary>
        /// Post Budget Types
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> EditBudgetActivities(BudgetActivyRequest model, Guid id);

        /// <summary>
        /// Get Budget
        /// </summary>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetDatas(SieveModel model);

        /// <summary>
        /// Get Budget
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetData(Guid id);

        /// <summary>
        /// Post Budget Activities
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> CreateBudget(BudgetRequest model);

        /// <summary>
        /// Post Budget Activities
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> CreateBudgetDetail(BudgetDetailRequest model);

        /// <summary>
        /// Report Budget to excel
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns>A <see cref="string"/></returns>
        Task<(string path, string contextType, string fileName)> ReportBudgetToExcel(Guid id, Guid userId);

        /// <summary>
        /// Report Budget to pdf
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns>A <see cref="string"/></returns>
        Task<(string path, string contextType, string fileName)> ReportBudgetToPdf(Guid id, Guid userId);

        /// <summary>
        /// Delete Budget Activities
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> DeleteBudgetActivities(Guid id);

        /// <summary>
        /// Get Default Budget
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetDefaultBudget();
    }
}
