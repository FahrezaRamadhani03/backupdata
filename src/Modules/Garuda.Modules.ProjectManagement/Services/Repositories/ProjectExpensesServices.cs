// <copyright file="ProjectExpensesServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;
using Garuda.Modules.Common.Dtos.Responses;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Client;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Expenses;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Client;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Expense;
using Garuda.Modules.ProjectManagement.Helper;
using Garuda.Modules.ProjectManagement.Helper.Interfaces;
using Garuda.Modules.ProjectManagement.Models.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sieve.Models;
using Sieve.Services;

namespace Garuda.Modules.ProjectManagement.Services.Repositories
{
    public class ProjectExpensesServices : IProjectExpensesServices
    {
        private readonly IStorage _iStorage;
        private readonly ILogger _iLogger;
        private readonly IMapper _iMapper;
        private readonly SieveProcessor _sieve;
        private readonly IHostEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        private readonly IFileChecker _fileChecker;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectExpensesServices"/> class.
        /// </summary>
        /// <param name="iLogger"></param>
        /// <param name="iMapper"></param>
        /// <param name="iStorage"></param>
        /// <param name="iSieve"></param>
        /// <param name="iHostingEnvironment"></param>
        /// <param name="iConfiguration"></param>
        /// <param name="iFileCheker"></param>
        public ProjectExpensesServices(
            IStorage iStorage,
            ILogger<ProjectExpensesServices> iLogger,
            IMapper iMapper,
            SieveProcessor iSieve,
            IHostEnvironment iHostingEnvironment,
            IConfiguration iConfiguration,
            IFileChecker iFileCheker)
        {
            _iStorage = iStorage;
            _iLogger = iLogger;
            _iMapper = iMapper;
            _sieve = iSieve;
            _hostingEnvironment = iHostingEnvironment;
            _configuration = iConfiguration;
            _fileChecker = iFileCheker;
        }

        public async Task<MessageDto> CreateExpense(ExpenseRequest model)
        {
            try
            {
                if (model == null)
                {
                    throw new BadRequestException();
                }

                if (model.ProjectId != null)
                {
                    var project = await _iStorage.GetRepository<IProjectDetailRepository>().GetById((Guid)model.ProjectId);
                    if (project == null)
                    {
                        throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.PROJECT_NOT_FOUND;
                    }
                }

                if (model.ActivityId != null)
                {
                    var activity = await _iStorage.GetRepository<IBudgetActivityRepository>().GetData((Guid)model.ActivityId);
                    if (activity == null)
                    {
                        throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.BUDGET_ACTIVITY_NOT_FOUND;
                    }
                }

                var expense = await _iStorage.GetRepository<IExpenseRepository>().AddOrUpdate(new Expense
                {
                    ActivityId = model.ActivityId,
                    ProjectId = model.ProjectId,
                    BillAmount = model.BillAmount,
                    Description = model.Description,
                    TransactionDate = model.TransactionDate,
                });
                await _iStorage.SaveAsync();

                if (model.Bills != null && model.Bills.Count > 0)
                {
                    var (fileNames, err) = await SaveFiles(model.Bills, expense.Id);
                    if (err != null)
                    {
                        throw err;
                    }
                }

                return new MessageDto(Codes.CREATED, "Created", SuccessConstant.CREATED_PROJECT_EXPENSES, null, expense.Id);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to save Expenses, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> DeleteExpense(Guid id)
        {
            try
            {
                if (id == null)
                {
                    throw new BadRequestException();
                }

                var expense = await _iStorage.GetRepository<IExpenseRepository>().GetData(id);
                _iLogger.LogInformation($"Try to delete project expense data, id : {id}");
                if (!await _iStorage.GetRepository<IExpenseRepository>().Delete(id))
                {
                    throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.EXPENSE_FAILED_TO_DELETE;
                }

                await _iStorage.SaveAsync();
                _iLogger.LogInformation("Try to delete expense bills");
                foreach (var bill in expense.ExpenseBills)
                {
                    if (!DeleteFile(bill.Filename))
                    {
                        throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.FILE_FAILED_TO_DELETE;
                    }
                }

                return new MessageDto(Codes.SUCCESS, "Deleted", "Expenses has been deleted", null, null);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to delete Expenses, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> EditExpense(Guid id, ExpenseRequest model)
        {
            try
            {
                if (id == null || model == null)
                {
                    throw new BadRequestException();
                }

                if (model.ProjectId != null)
                {
                    var project = await _iStorage.GetRepository<IProjectDetailRepository>().GetById((Guid)model.ProjectId);
                    if (project == null)
                    {
                        throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.PROJECT_NOT_FOUND;
                    }
                }

                if (model.ActivityId != null)
                {
                    var activity = await _iStorage.GetRepository<IBudgetActivityRepository>().GetData((Guid)model.ActivityId);
                    if (activity == null)
                    {
                        throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.BUDGET_ACTIVITY_NOT_FOUND;
                    }
                }

                var expense = await _iStorage.GetRepository<IExpenseRepository>().AddOrUpdate(new Expense
                {
                    Id = id,
                    ActivityId = model.ActivityId,
                    ProjectId = model.ProjectId,
                    BillAmount = model.BillAmount,
                    Description = model.Description,
                    TransactionDate = model.TransactionDate,
                });
                await _iStorage.SaveAsync();

                if (model.Bills != null && model.Bills.Count > 0)
                {
                    foreach (var fileBill in model.Bills)
                    {
                        if (expense.ExpenseBills.Any(u => u.Filename == fileBill.FileName))
                        {
                            model.Bills.Remove(fileBill);
                        }
                    }

                    var (fileNames, err) = await SaveFiles(model.Bills, expense.Id);
                    if (err != null)
                    {
                        throw err;
                    }
                }

                var bill = await _iStorage.GetRepository<IExpenseRepository>().GetData(expense.Id);
                foreach (var file in bill.ExpenseBills)
                {
                    if (model.Bills == null)
                    {
                        if (!DeleteFile(file.Filename))
                        {
                            throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.FILE_FAILED_TO_DELETE;
                        }

                        if (!await _iStorage.GetRepository<IExpenseBillRepository>().Delete(file.Id))
                        {
                            throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.BILL_FAILED_TO_DELETE;
                        }
                        else
                        {
                            await _iStorage.SaveAsync();
                        }
                    }
                    else if (!model.Bills.Any(u => u.FileName == file.OriginalFilename))
                    {
                        if (!DeleteFile(file.Filename))
                        {
                            throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.FILE_FAILED_TO_DELETE;
                        }

                        if (!await _iStorage.GetRepository<IExpenseBillRepository>().Delete(file.Id))
                        {
                            throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.BILL_FAILED_TO_DELETE;
                        }
                        else
                        {
                            await _iStorage.SaveAsync();
                        }
                    }
                }

                return new MessageDto(Codes.SUCCESS, "Updated", "Expenses has been updated", null, expense.Id);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to save Expenses, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> GetData(Guid id)
        {
            try
            {
                if (id == null)
                {
                    throw new BadRequestException();
                }

                _iLogger.LogInformation($"Try to get expense data, id : {id}");
                var expense = await _iStorage.GetRepository<IExpenseRepository>().GetData(id);
                if (expense == null)
                {
                    throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.EXPENSE_NOT_FOUND;
                }

                return new MessageDto(Codes.SUCCESS, "Found", SuccessConstant.FOUND_EXPENSES, null, _iMapper.Map<Expense, ExpenseDto>(expense));
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching Project Expenses, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> GetDataProject(SieveModel model)
        {
            try
            {
                _iLogger.LogInformation($"Try to get expense data");
                var projectExpense = await _iStorage.GetRepository<IExpenseRepository>().GetData();
                if (projectExpense == null)
                {
                    throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.PROJECT_NOT_FOUND;
                }

                var data = _iMapper.Map<List<Expense>, List<ExpenseDto>>(projectExpense.ToList());
                var result = _sieve.Apply(model, data.AsQueryable(), applyPagination: false);
                var responsePagination = _sieve.Apply(model, result.AsQueryable());

                if (responsePagination.ToList().Count() > 0 && model.Page != null && model.PageSize != null)
                {
                    _iLogger.LogInformation("Trying to map pagination..");
                    var count = result.Count();
                    var response = new PaginatedResponses<ExpenseDto>()
                    {
                        Data = responsePagination.ToList(),
                        TotalData = count,
                        TotalPage = (int)Math.Ceiling((double)count / model.PageSize.Value),
                        CurrentPage = model.Page.Value,
                        PageSize = model.PageSize.Value,
                    };
                    return new MessageDto(Codes.SUCCESS, "Found", SuccessConstant.FOUND_PROJECT_EXPENSES, null, response);
                }
                else
                {
                    return new MessageDto(Codes.NOT_FOUND, "Not Found", null, SuccessConstant.FOUND_PROJECT_EXPENSES, responsePagination);
                }
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching Project Expense, err : {ex}");
                throw;
            }
        }

        public async Task<FileBillDto> GetFileBill(Guid id)
        {
            try
            {
                var bill = await _iStorage.GetRepository<IExpenseBillRepository>().GetData(id);
                if (bill == null)
                {
                    throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.EXPENSE_NOT_FOUND;
                }

                var mediaPath = Path.Combine(_hostingEnvironment.ContentRootPath, "media" + Path.DirectorySeparatorChar + "expenses", bill.Filename);

                if (mediaPath == null)
                {
                    throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.EXPENSE_NOT_FOUND;
                }

                FileInfo file = new FileInfo(mediaPath);
                return new FileBillDto
                {
                    NameFile = bill.OriginalFilename,
                    ContentType = _fileChecker.GetContentType(file.Extension.TrimStart(new Char[] { '.' })),
                    PathFile = mediaPath,
                };
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching Expense bill, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> GetSummary(Guid id)
        {
            try
            {
                var labour = await _iStorage.GetRepository<IProjectDevelopmentTeamRepository>().GetManDaysAmountByProject(id);

                var expenses = await _iStorage.GetRepository<IExpenseRepository>().GetTotalExpenseAmountByProjectId(id);

                var projectCost = expenses + labour;

                var projectAmount = await _iStorage.GetRepository<IProposalRepository>().GetProposalAmount(id);

                var unpaidAmount = await _iStorage.GetRepository<IInvoiceRepository>().GetUnpaidInvoiceByProjectId(id);

                var unvoicedAmount = projectAmount - unpaidAmount;

                var overdueAmount = await _iStorage.GetRepository<IInvoiceRepository>().GetUnpaidOverdueInvoiceByProjectId(id);

                var paidAmount = await _iStorage.GetRepository<IInvoiceRepository>().GetPaidInvoiceByProjectId(id);

                var profitEstimation = projectAmount - projectCost;

                return new MessageDto(Codes.SUCCESS, "Found", SuccessConstant.FOUND_EXPENSES_SUMMARY, null, new ProjectCostSummaryResponse
                {
                    Expenses = expenses,
                    Labour = labour,
                    ProjectCost = projectCost,
                    ProjectAmount = projectAmount,
                    UnpaidAmount = unpaidAmount,
                    UninvoicedAmount = unvoicedAmount,
                    OverdueAmount = overdueAmount,
                    PaidAmount = paidAmount,
                    ProfitEstimation = profitEstimation,
                });
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to delete file, err : {ex}");
                throw;
            }
        }

        private async Task<(List<string>, HttpResponseLibraryException)> SaveFiles(List<IFormFile> fileList, Guid projectId)
        {
            List<string> fileRespon = new List<string> { };
            foreach (var file in fileList)
            {
                var fileTypes = _configuration.GetSection("UploadFileTypes").Get<List<string>>();

                if (!_fileChecker.IsValidType(file))
                {
                    _iLogger.LogInformation($"Failed to save File");
                    throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.FILE_UPLOAD_TYPE;
                }

                if (!_fileChecker.IsValidSize(file))
                {
                    _iLogger.LogInformation($"Failed to save File");
                    throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.FILE_UPLOAD_SIZE;
                }

                var (resultFileName, error) = await UploadFile(file, projectId.ToString() + _fileChecker.GenerateUniqFileName(file), projectId);
                if (error != null)
                {
                    return (null, error);
                }

                fileRespon.Add(resultFileName);
            }

            return (fileRespon, null);
        }

        private async Task<(string, HttpResponseLibraryException)> UploadFile(IFormFile file, string nameFile, Guid expenseId)
        {
            var mediaPath = Path.Combine(_hostingEnvironment.ContentRootPath, "media" + Path.DirectorySeparatorChar + "expenses");
            if (Directory.Exists(mediaPath) == false)
            {
                try
                {
                    Directory.CreateDirectory(mediaPath);
                }
                catch (Exception ex)
                {
                    _iLogger.LogInformation($"Failed to save file to server, err : {ex}");
                    throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.FORBIDEN_ACCESS_TO_FILE_SERVER;
                }
            }

            var itemPath = Path.Combine(mediaPath, nameFile.Trim('/'));
            var itemFile = System.IO.File.Create(itemPath);
            await file.CopyToAsync(itemFile);
            itemFile.Close();
            try
            {
                await _iStorage.GetRepository<IExpenseBillRepository>().AddOrUpdate(new ExpenseBill
                {
                    ExpenseId = expenseId,
                    Filename = nameFile,
                    OriginalFilename = file.FileName,
                });
                await _iStorage.SaveAsync();
                return (nameFile, null);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to save expense bills, err : {ex}");
                throw new BadRequestException();
            }
        }

        private bool DeleteFile(string fileName)
        {
            try
            {
                var mediaPath = Path.Combine(_hostingEnvironment.ContentRootPath, "media" + Path.DirectorySeparatorChar + "expenses", fileName);
                FileInfo file = new FileInfo(mediaPath);
                if (file.Exists)
                {
                    file.Delete();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to delete file, err : {ex}");
                return false;
            }
        }
    }
}
