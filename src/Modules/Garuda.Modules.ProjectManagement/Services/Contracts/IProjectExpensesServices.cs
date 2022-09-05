// <copyright file="IProjectExpensesServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Expenses;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Expense;
using Sieve.Models;

namespace Garuda.Modules.ProjectManagement.Services.Contracts
{
    /// <summary>
    /// Project Expenses Service contract
    /// </summary>
    public interface IProjectExpensesServices
    {
        /// <summary>
        /// Get expenses by project
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetDataProject(SieveModel model);

        /// <summary>
        /// Get expenses by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetData(Guid id);

        /// <summary>
        /// Create Expense
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> CreateExpense(ExpenseRequest model);

        /// <summary>
        /// Edit Expense
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> EditExpense(Guid id, ExpenseRequest model);

        /// <summary>
        /// Delete Expense
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> DeleteExpense(Guid id);

        /// <summary>
        /// Get File Expense
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<FileBillDto> GetFileBill(Guid id);

        /// <summary>
        /// Get Project Cost Summary
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
        Task<MessageDto> GetSummary(Guid id);
    }
}
