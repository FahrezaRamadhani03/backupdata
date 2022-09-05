// <copyright file="BudgetServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DinkToPdf;
using DinkToPdf.Contracts;
using DocumentFormat.OpenXml.Spreadsheet;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;
using Garuda.Infrastructure.Helpers;
using Garuda.Modules.Common.Dtos.Responses;
using Garuda.Modules.Common.Models.Contracts;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Budget;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Client;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Budget;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Client;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Expense;
using Garuda.Modules.ProjectManagement.Helper;
using Garuda.Modules.ProjectManagement.Models.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sieve.Models;
using Sieve.Services;
using Spire.Xls;
using SpreadsheetLight;

namespace Garuda.Modules.ProjectManagement.Services.Repositories
{
    public class BudgetServices : IBudgetServices
    {
        private readonly IStorage _iStorage;
        private readonly ILogger _iLogger;
        private readonly IMapper _iMapper;
        private readonly SieveProcessor _sieve;
        private readonly IConverter _iconverter;
        private readonly IHostEnvironment _hostingEnvironment;

        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetServices"/> class.
        /// </summary>
        /// <param name="iLogger"></param>
        /// <param name="iMapper"></param>
        /// <param name="iStorage"></param>
        public BudgetServices(
            IStorage iStorage,
            ILogger<BudgetServices> iLogger,
            IMapper iMapper,
            SieveProcessor sieve,
            IConverter iconverter,
            IHostEnvironment hostingEnvironment)
        {
            _iStorage = iStorage;
            _iLogger = iLogger;
            _iMapper = iMapper;
            _sieve = sieve;
            _iconverter = iconverter;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<MessageDto> CreateBudgetActivities(BudgetActivyRequest model)
        {
            try
            {
                if (model == null)
                {
                    throw new BadRequestException();
                }

                _iLogger.LogInformation("Try to check registered Budget Activities from database..");
                if (!await _iStorage.GetRepository<IBudgetActivityRepository>().IsRegistered(model.Name, null))
                {
                    if (model.BudgetTypeId != null && !await _iStorage.GetRepository<IBudgetTypeRepository>().IsRegistered(model.BudgetTypeId))
                    {
                        throw Constants.ErrorConstant.BUDGET_TYPES_NOT_FOUND;
                    }

                    await _iStorage.GetRepository<IBudgetActivityRepository>().AddOrUpdate(new BudgetActivity
                    {
                        Name = model.Name.Trim(),
                        BudgetTypeId = model.BudgetTypeId,
                        IsShowInProjectExpense = model.IsShowInProjectExpense,
                    });

                    await _iStorage.SaveAsync();
                }
                else
                {
                    throw Constants.ErrorConstant.CONFLICT_BUDGET_ACTIVITIES;
                }

                return new MessageDto(Infrastructure.Constants.Codes.CREATED, "Created", null, SuccessConstant.CREATED_BUDGET_ACTIVITIES, model);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching Budget Types, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> CreateBudgetTypes(BudgetTypeRequest model)
        {
            try
            {
                if (model == null)
                {
                    throw new BadRequestException();
                }

                _iLogger.LogInformation("Try to check registered Budget Types from database..");
                if (!await _iStorage.GetRepository<IBudgetTypeRepository>().IsRegistered(model.Name, null))
                {
                    await _iStorage.GetRepository<IBudgetTypeRepository>().AddOrUpdate(new BudgetType
                    {
                        TypeName = model.Name.Trim(),
                    });
                    await _iStorage.SaveAsync();
                }
                else
                {
                    throw Constants.ErrorConstant.CONFLICT_BUDGET_TYPES;
                }

                return new MessageDto(Infrastructure.Constants.Codes.CREATED, "Created", null, SuccessConstant.CREATED_BUDGET_TYPES, model);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching Budget Activities, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> DeleteBudgetActivities(Guid id)
        {
            try
            {
                _iLogger.LogInformation("Try to deleted Budget Activities from database..");
                if (!await _iStorage.GetRepository<IBudgetActivityRepository>().IsRegistered(id))
                {
                    throw Constants.ErrorConstant.BUDGET_ACTIVITY_NOT_FOUND;
                }

                await _iStorage.GetRepository<IBudgetActivityRepository>().Delete(id);
                await _iStorage.SaveAsync();

                return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Deleted", null, SuccessConstant.REMOVED_BUDGET_ACTIVITIES, null);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching Budget Activities, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> DeleteBudgetTypes(Guid id)
        {
            try
            {
                _iLogger.LogInformation("Try to deleted Budget Types from database..");
                if (!await _iStorage.GetRepository<IBudgetTypeRepository>().IsRegistered(id))
                {
                    throw Constants.ErrorConstant.BUDGET_TYPES_NOT_FOUND;
                }

                await _iStorage.GetRepository<IBudgetTypeRepository>().Delete(id);
                await _iStorage.SaveAsync();

                _iLogger.LogInformation("Try to deleted Budget Activity relation from database..");
                await _iStorage.GetRepository<IBudgetActivityRepository>().DeleteByTypeId(id);
                await _iStorage.SaveAsync();

                return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Deleted", null, SuccessConstant.REMOVED_BUDGET_TYPES, null);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching Budget Types, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> EditBudgetActivities(BudgetActivyRequest model, Guid id)
        {
            try
            {
                if (model == null)
                {
                    throw new BadRequestException();
                }

                _iLogger.LogInformation("Try to check registered Budget Activities from database..");
                if (!await _iStorage.GetRepository<IBudgetActivityRepository>().IsRegistered(id))
                {
                    throw Constants.ErrorConstant.BUDGET_ACTIVITY_NOT_FOUND;
                }

                if (!await _iStorage.GetRepository<IBudgetActivityRepository>().IsRegistered(model.Name, id))
                {
                    if (model.BudgetTypeId != null && !await _iStorage.GetRepository<IBudgetTypeRepository>().IsRegistered(model.BudgetTypeId))
                    {
                        throw Constants.ErrorConstant.BUDGET_TYPES_NOT_FOUND;
                    }

                    await _iStorage.GetRepository<IBudgetActivityRepository>().AddOrUpdate(new BudgetActivity
                    {
                        Name = model.Name.Trim(),
                        BudgetTypeId = model.BudgetTypeId,
                        IsShowInProjectExpense = model.IsShowInProjectExpense,
                        Id = id,
                    });
                    await _iStorage.SaveAsync();
                }
                else
                {
                    throw Constants.ErrorConstant.CONFLICT_BUDGET_ACTIVITIES;
                }

                return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Updated", null, SuccessConstant.UPDATED_BUDGET_ACTIVITIES, model);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching Budget Activities, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> EditBudgetTypes(BudgetTypeRequest model, Guid id)
        {
            try
            {
                if (model == null)
                {
                    throw new BadRequestException();
                }

                if (id != null && !await _iStorage.GetRepository<IBudgetTypeRepository>().IsRegistered(id))
                {
                    throw Constants.ErrorConstant.BUDGET_TYPES_NOT_FOUND;
                }

                _iLogger.LogInformation("Try to check registered Budget Types from database..");
                if (!await _iStorage.GetRepository<IBudgetTypeRepository>().IsRegistered(model.Name, id))
                {
                    await _iStorage.GetRepository<IBudgetTypeRepository>().AddOrUpdate(new BudgetType
                    {
                        TypeName = model.Name.Trim(),
                        Id = id,
                    });
                    await _iStorage.SaveAsync();
                }
                else
                {
                    throw Constants.ErrorConstant.CONFLICT_BUDGET_TYPES;
                }

                return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Updated", null, SuccessConstant.UPDATED_BUDGET_TYPES, model);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching Budget Types, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> GetBudgetActivities(SieveModel model)
        {
            try
            {
                _iLogger.LogInformation("Try to fetching Budget Activities from database..");
                var budgets = await _iStorage.GetRepository<IBudgetActivityRepository>().GetData();
                var mapper = _iMapper.Map<List<BudgetActivityDto>>(budgets);
                var finalResult = _sieve.Apply(model, mapper.AsQueryable(), applyPagination: false);
                var pagination = _sieve.Apply(model, mapper.AsQueryable());
                if (budgets.Count() > 0 && model.Page != null && model.PageSize != null)
                {
                    var rolebackMap = _iMapper.Map<List<BudgetActivityResponse>>(pagination);
                    _iLogger.LogInformation("Trying to map pagination..");
                    var count = rolebackMap.Count();
                    var response = new PaginatedResponses<BudgetActivityResponse>()
                    {
                        Data = rolebackMap.ToList(),
                        TotalData = count,
                        TotalPage = (int)Math.Ceiling((double)count / model.PageSize.Value),
                        CurrentPage = model.Page.Value,
                        PageSize = model.PageSize.Value,
                    };
                    return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_BUDGET_ACTIVITIES, response);
                }
                else
                {
                    return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_BUDGET_ACTIVITIES, _iMapper.Map<List<BudgetActivityResponse>>(finalResult));
                }
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching Budget Activities, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> GetBudgetActivities(Guid id)
        {
            try
            {
                _iLogger.LogInformation("Try to fetching Budget Activity from database..");
                var budgets = await _iStorage.GetRepository<IBudgetActivityRepository>().GetData(id);
                if (budgets == null)
                {
                    throw Constants.ErrorConstant.BUDGET_ACTIVITY_NOT_FOUND;
                }

                return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_BUDGET_ACTIVITIES, _iMapper.Map<BudgetActivityDto>(budgets));
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching Budget Activity, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> GetBudgetTypes(SieveModel model)
        {
            try
            {
                _iLogger.LogInformation("Try to fetching Budget Types from database..");
                var budgets = await _iStorage.GetRepository<IBudgetTypeRepository>().GetData();
                var mapper = _iMapper.Map<List<BudgetTypesResponse>>(budgets);
                var finalResult = _sieve.Apply(model, mapper.AsQueryable());
                var finalResultAll = _sieve.Apply(model, mapper.AsQueryable(), applyPagination: false);
                if (budgets.Count() > 0 && model.Page != null && model.PageSize != null)
                {
                    _iLogger.LogInformation("Trying to map pagination..");
                    var count = finalResultAll.Count();
                    var response = new PaginatedResponses<BudgetTypesResponse>()
                    {
                        Data = finalResult.ToList(),
                        TotalData = count,
                        TotalPage = (int)Math.Ceiling((double)count / model.PageSize.Value),
                        CurrentPage = model.Page.Value,
                        PageSize = model.PageSize.Value,
                    };
                    return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_BUDGET_TYPES, response);
                }
                else
                {
                    return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_BUDGET_TYPES, finalResult);
                }
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching Budget Types, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> GetBudgetTypes(Guid id)
        {
            try
            {
                _iLogger.LogInformation("Try to fetching Budget Types from database..");
                var budgets = await _iStorage.GetRepository<IBudgetTypeRepository>().GetData(id);
                if (budgets == null)
                {
                    throw Constants.ErrorConstant.BUDGET_TYPES_NOT_FOUND;
                }

                return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_BUDGET_TYPES, _iMapper.Map<BudgetTypesResponse>(budgets));
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching Budget Types, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> GetDatas(SieveModel sieveModel)
        {
            try
            {
                _iLogger.LogInformation("Try to fetching Budget Types from database..");
                var budgets = await _iStorage.GetRepository<IBudgetRepository>().GetData();
                if (budgets != null && budgets.Count() != 0)
                {
                    var datas = _iMapper.Map<List<BudgetResponses>>(budgets);
                    var sieveData = _sieve.Apply(sieveModel, datas.AsQueryable());
                    var result = new PaginatedResponses<BudgetResponses>()
                    {
                        Data = sieveData.ToList(),
                        TotalData = datas.Count(),
                        TotalPage = (int)Math.Ceiling((double)datas.Count() / sieveModel.PageSize.Value),
                        CurrentPage = sieveModel.Page.Value,
                        PageSize = sieveModel.PageSize.Value,
                    };

                    return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_BUDGET, result);
                }
                else
                {
                    return new MessageDto(Infrastructure.Constants.Codes.NOT_FOUND, "Not Found", null, SuccessConstant.NOT_FOUND, new List<BudgetResponses>());
                }
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching Budget Types, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> GetData(Guid id)
        {
            try
            {
                _iLogger.LogInformation("Try to fetching Budget Types from database..");
                var budget = await _iStorage.GetRepository<IBudgetRepository>().GetData(id);
                var budgetDetails = await _iStorage.GetRepository<IBudgetTypeRepository>().GetDataByBudgetId(id);
                var result = _iMapper.Map<BudgetResponse>(budget);
                result.BudgetTypes = _iMapper.Map<List<BudgetTypeDetailResponses>>(budgetDetails);

                if (result != null)
                {
                    return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_BUDGET, _iMapper.Map<BudgetResponse>(result));
                }
                else
                {
                    return new MessageDto(Infrastructure.Constants.Codes.NOT_FOUND, "Not Found", null, SuccessConstant.NOT_FOUND, new BudgetResponse());
                }
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching Budget, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> CreateBudget(BudgetRequest model)
        {
            try
            {
                // validate for existing data that's mean update data
                if (model.Id != null)
                {
                    var data = await _iStorage.GetRepository<IBudgetRepository>().GetData((Guid)model.Id);
                    if (data.Year != model.Year)
                    {
                        if (await _iStorage.GetRepository<IBudgetRepository>().IsExisBaseOnYear(model.Year))
                        {
                            throw Constants.ErrorConstant.CONFLICT_BUDGET_YEAR;
                        }
                    }
                }
                else
                {
                    if (await _iStorage.GetRepository<IBudgetRepository>().IsExisBaseOnYear(model.Year))
                    {
                        throw Constants.ErrorConstant.CONFLICT_BUDGET_YEAR;
                    }
                }

                _iLogger.LogInformation("Saving new Budget to database...");
                var budget = _iMapper.Map<Budget>(model);
                await _iStorage.GetRepository<IBudgetRepository>().AddOrUpdate(budget);

                await _iStorage.SaveAsync();
                return new MessageDto(Infrastructure.Constants.Codes.CREATED, "Success", null, SuccessConstant.CREATE_BUDGET, budget);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation("save new budget failed, with err: ", ex);
                throw;
            }
        }

        public async Task<MessageDto> CreateBudgetDetail(BudgetDetailRequest model)
        {
            try
            {
                // validate for existing data that's mean update data
                if (model.Id != null)
                {
                    var data = await _iStorage.GetRepository<IBudgetRepository>().GetData((Guid)model.Id);
                    if (data.Year != model.Year)
                    {
                        if (await _iStorage.GetRepository<IBudgetRepository>().IsExisBaseOnYear(model.Year))
                        {
                            throw Constants.ErrorConstant.CONFLICT_BUDGET_YEAR;
                        }
                    }
                }
                else
                {
                    if (await _iStorage.GetRepository<IBudgetRepository>().IsExisBaseOnYear(model.Year))
                    {
                        throw Constants.ErrorConstant.CONFLICT_BUDGET_YEAR;
                    }
                }

                _iLogger.LogInformation("Saving new Budget to database...");
                var budget = _iMapper.Map<Budget>(model);
                await _iStorage.GetRepository<IBudgetRepository>().AddOrUpdate(budget);
                await _iStorage.SaveAsync();

                foreach (var type in model.BudgetTypes)
                {
                    foreach (var activity in type.BudgetActivities)
                    {
                        var newActivity = _iMapper.Map<BudgetDetail>(activity);
                        newActivity.BudgetId = budget.Id;
                        newActivity.BudgetTypeId = type.TypeId;
                        await _iStorage.GetRepository<IBudgetDetailRepository>().AddOrUpdate(newActivity);
                    }
                }

                await _iStorage.SaveAsync();
                return new MessageDto(Infrastructure.Constants.Codes.CREATED, "Success", null, SuccessConstant.CREATE_BUDGET, model);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation("Failed to create, with err: ", ex);
                throw;
            }
        }

        public async Task<(string path, string contextType, string fileName)> ReportBudgetToExcel(Guid id, Guid userId)
        {
            try
            {
                _iLogger.LogInformation("Try to fetching Budget Types from database..");
                var budget = await _iStorage.GetRepository<IBudgetRepository>().GetData(id);
                var budgetDetails = await _iStorage.GetRepository<IBudgetTypeRepository>().GetDataByBudgetId(id);
                var result = _iMapper.Map<BudgetResponse>(budget);
                result.BudgetTypes = _iMapper.Map<List<BudgetTypeDetailResponses>>(budgetDetails);
                string fileName = string.Empty;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (SLDocument sl = new SLDocument())
                    {
                        Monitoring(sl, result);

                        SLPageSettings ps = new SLPageSettings();
                        ps.ShowGridLines = false;
                        sl.SetPageSettings(ps);
                        sl.SaveAs(ms);
                    }

                    ms.Position = 0;

                    var newDirectory = Path.Combine(_hostingEnvironment.ContentRootPath, "media", "budget");
                    if (!Directory.Exists(newDirectory))
                    {
                        Directory.CreateDirectory(newDirectory);
                    }

                    var workbook = new Spire.Xls.Workbook();
                    workbook.LoadFromStream(ms);

                    foreach (var sheet in workbook.Worksheets)
                    {
                        sheet.PageSetup.PaperSize = PaperSizeType.PaperA4;
                        sheet.PageSetup.FitToPagesWide = 1;
                        sheet.PageSetup.FitToPagesTall = 1;
                    }

                    var user = await _iStorage.GetRepository<IUserRepository>().GetData(userId);

                    var fileNameFormat = string.Format(
                        "Budget{0}_{1}_By_{2}",
                        result.Year.ToString(),
                        DateTime.Now.ToString("dd-MM-yyyy HH.mm.ss"),
                        user.Fullname);

                    fileName = fileNameFormat + ".xlsx";
                    FileStream fileExcel = new FileStream(newDirectory + Path.DirectorySeparatorChar + fileName, FileMode.Create, FileAccess.Write);
                    ms.WriteTo(fileExcel);
                    fileExcel.Close();
                    ms.Close();
                }

                string path = Path.Combine(_hostingEnvironment.ContentRootPath, "media", "budget", fileName);
                FileInfo fileInfo = new FileInfo(path);
                var fileExt = fileInfo.Extension;

                string contextType = FileHelper.GetFileContextType(fileExt);
                string savedFileName = fileName.Substring(fileName.IndexOf('-') + 1);

                return (path, contextType, savedFileName);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to generate budget report to excel, err : {ex}");
                throw;
            }
        }

        public async Task<(string path, string contextType, string fileName)> ReportBudgetToPdf(Guid id, Guid userId)
        {
            try
            {
                _iLogger.LogInformation("Try to fetching Budget Types from database..");
                var budget = await _iStorage.GetRepository<IBudgetRepository>().GetData(id);
                var budgetDetails = await _iStorage.GetRepository<IBudgetTypeRepository>().GetDataByBudgetId(id);
                var result = _iMapper.Map<BudgetResponse>(budget);
                result.BudgetTypes = _iMapper.Map<List<BudgetTypeDetailResponses>>(budgetDetails);
                string pdfFileName = string.Empty;

                // create file pdf byte
                byte[] pdfFile = TemplateBudget(result);

                // check if directory already created or not
                var newDirectory = Path.Combine(_hostingEnvironment.ContentRootPath, "media", "budget");
                if (!Directory.Exists(newDirectory))
                {
                    Directory.CreateDirectory(newDirectory);
                }

                // create file pdf in selected directory
                var user = await _iStorage.GetRepository<IUserRepository>().GetData(userId);

                var fileNameFormat = string.Format(
                    "Budget{0}_{1}_By_{2}",
                    result.Year.ToString(),
                    DateTime.Now.ToString("dd-MM-yyyy HH.mm.ss"),
                    user.Fullname);

                pdfFileName = fileNameFormat + ".pdf";
                FileStream filePdf = new FileStream(newDirectory + Path.DirectorySeparatorChar + pdfFileName, FileMode.Create, FileAccess.Write);
                filePdf.Write(pdfFile);
                filePdf.Close();

                // get path of current file pdf
                string path = Path.Combine(_hostingEnvironment.ContentRootPath, "media", "budget", pdfFileName);
                FileInfo fileInfo = new FileInfo(path);
                var fileExt = fileInfo.Extension;
                string contextType = FileHelper.GetFileContextType(fileExt);
                string savedFileName = pdfFileName.Substring(pdfFileName.IndexOf('-') + 1);

                return (path, contextType, savedFileName);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to generate budget report to pdf, err : {ex}");
                throw new BadRequestException(Codes.BAD_REQUEST,
                                              "ERROR GENERATE PDF",
                                              new MessageLangDto($"Failed to generate" +
                                                                 $" budget report to pdf," +
                                                                 $"err : {ex.Message}", string.Empty));
            }
        }


        public byte[] TemplateBudget(BudgetResponse results)
        {
            // create style tag
            StringBuilder headString = new StringBuilder();
            headString.Append(@"<style>
                                table, th, td {
                                border: 1px solid black;
                                border-collapse: collapse;
                                }
                                th {
                                padding: 5px;
                                }
                                #center{
                                text-align: center;
                                }
                                #right{
                                text-align: right; 
                                padding-right:5px;
                                }
                                </style>");

            // create year and projection
            StringBuilder paragrafString = new StringBuilder();
            paragrafString.Append($"<tr>" +
                                $"<th>Year</th>" +
                                $"<th>&emsp;{results.Year}</th>" +
                             $"</tr><br>");
            paragrafString.Append($"<tr>" +
                                $"<th>Projection</th>" +
                                $"<th>&emsp;{results.Projection}</th>" +
                             $"</tr>");

            // create table budget report
            StringBuilder boxString = new StringBuilder();
            boxString.Append(@"<table>
                                    <tr>
                                    <th>No</th>
                                    <th>Activities</th>
                                    <th>Budget(%)</th>
                                    <th>Budget(Rp)</th>
                                    <th>Utilized(Rp)</th>
                                    <th>Remaining(Rp)</th>
                                    <th>Januari(Rp)</th>
                                    <th>February(Rp)</th>
                                    <th>March(Rp)</th>
                                    <th>April(Rp)</th>
                                    <th>May(Rp)</th>
                                    <th>June(Rp)</th>
                                    <th>July(Rp)</th>
                                    <th>August(Rp)</th>
                                    <th>September(Rp)</th>
                                    <th>October(Rp)</th>
                                    <th>November(Rp)</th>
                                    <th>December(Rp)</th>
                                    </tr>");

            decimal totalPercentage = 0;
            decimal totalAmount = 0;
            foreach (var budgetType in results.BudgetTypes)
            {
                boxString.Append($"<tr>" +
                                    $"<td colspan='18'>{budgetType.TypeName}</td>" +
                                 $"</tr>");

                int countNumber = 1;
                foreach (var budget in budgetType.BudgetActivities)
                {
                    boxString.Append("<tr>");
                    boxString.Append($"<td>{countNumber}</td>" +
                                     $"<td>{budget.BudgetActivityName}</td>" +
                                     $"<td id='center'>{String.Format("{0:N}", budget.BudgetPercentage)}</td>" +
                                     $"<td id='right'>{String.Format("{0:N}", budget.BudgetAmount)}</td>" +
                                     $"<td id='right'>{String.Format("{0:N}", budget.Utilized)}</td>" +
                                     $"<td id='right'>{String.Format("{0:N}", budget.Remaining)}</td>" +
                                     $"<td id='right'>{String.Format("{0:N}", budget.January)}</td>" +
                                     $"<td id='right'>{String.Format("{0:N}", budget.February)}</td>" +
                                     $"<td id='right'>{String.Format("{0:N}", budget.March)}</td>" +
                                     $"<td id='right'>{String.Format("{0:N}", budget.April)}</td>" +
                                     $"<td id='right'>{String.Format("{0:N}", budget.May)}</td>" +
                                     $"<td id='right'>{String.Format("{0:N}", budget.June)}</td>" +
                                     $"<td id='right'>{String.Format("{0:N}", budget.July)}</td>" +
                                     $"<td id='right'>{String.Format("{0:N}", budget.August)}</td>" +
                                     $"<td id='right'>{String.Format("{0:N}", budget.September)}</td>" +
                                     $"<td id='right'>{String.Format("{0:N}", budget.October)}</td>" +
                                     $"<td id='right'>{String.Format("{0:N}", budget.November)}</td>" +
                                     $"<td id='right'>{String.Format("{0:N}", budget.December)}</td>");
                    boxString.Append("</tr>");

                    totalPercentage += budget.BudgetPercentage;
                    totalAmount += budget.BudgetAmount;
                    countNumber += 1;
                }
            }

            // Total
            boxString.Append($"<tr>");
            boxString.Append($"<th colspan='2'>Total</th>");
            boxString.Append($"<th id='center'>{String.Format("{0:N}", results.BudgetTypes.AsEnumerable().Sum(x => x.BudgetActivities.AsEnumerable().Sum(x => x.BudgetPercentage)))}</th>");
            boxString.Append($"<th id='right'>{String.Format("{0:N}", results.BudgetTypes.AsEnumerable().Sum(x => x.BudgetActivities.AsEnumerable().Sum(x => x.BudgetAmount)))}</th>");
            boxString.Append($"<th id='right'>{String.Format("{0:N}", results.BudgetTypes.AsEnumerable().Sum(x => x.BudgetActivities.AsEnumerable().Sum(x => x.Utilized)))}</th>");
            boxString.Append($"<th id='right'>{String.Format("{0:N}", results.BudgetTypes.AsEnumerable().Sum(x => x.BudgetActivities.AsEnumerable().Sum(x => x.Remaining)))}</th>");
            boxString.Append($"<th id='right'>{String.Format("{0:N}", results.BudgetTypes.AsEnumerable().Sum(x => x.BudgetActivities.AsEnumerable().Sum(x => x.January)))}</th>");
            boxString.Append($"<th id='right'>{String.Format("{0:N}", results.BudgetTypes.AsEnumerable().Sum(x => x.BudgetActivities.AsEnumerable().Sum(x => x.February)))}</th>");
            boxString.Append($"<th id='right'>{String.Format("{0:N}", results.BudgetTypes.AsEnumerable().Sum(x => x.BudgetActivities.AsEnumerable().Sum(x => x.March)))}</th>");
            boxString.Append($"<th id='right'>{String.Format("{0:N}", results.BudgetTypes.AsEnumerable().Sum(x => x.BudgetActivities.AsEnumerable().Sum(x => x.April)))}</th>");
            boxString.Append($"<th id='right'>{String.Format("{0:N}", results.BudgetTypes.AsEnumerable().Sum(x => x.BudgetActivities.AsEnumerable().Sum(x => x.May)))}</th>");
            boxString.Append($"<th id='right'>{String.Format("{0:N}", results.BudgetTypes.AsEnumerable().Sum(x => x.BudgetActivities.AsEnumerable().Sum(x => x.June)))}</th>");
            boxString.Append($"<th id='right'>{String.Format("{0:N}", results.BudgetTypes.AsEnumerable().Sum(x => x.BudgetActivities.AsEnumerable().Sum(x => x.July)))}</th>");
            boxString.Append($"<th id='right'>{String.Format("{0:N}", results.BudgetTypes.AsEnumerable().Sum(x => x.BudgetActivities.AsEnumerable().Sum(x => x.August)))}</th>");
            boxString.Append($"<th id='right'>{String.Format("{0:N}", results.BudgetTypes.AsEnumerable().Sum(x => x.BudgetActivities.AsEnumerable().Sum(x => x.September)))}</th>");
            boxString.Append($"<th id='right'>{String.Format("{0:N}", results.BudgetTypes.AsEnumerable().Sum(x => x.BudgetActivities.AsEnumerable().Sum(x => x.October)))}</th>");
            boxString.Append($"<th id='right'>{String.Format("{0:N}", results.BudgetTypes.AsEnumerable().Sum(x => x.BudgetActivities.AsEnumerable().Sum(x => x.November)))}</th>");
            boxString.Append($"<th id='right'>{String.Format("{0:N}", results.BudgetTypes.AsEnumerable().Sum(x => x.BudgetActivities.AsEnumerable().Sum(x => x.December)))}</th>");
            boxString.Append($"</tr>");

            // Remaining
            boxString.Append($"<tr>");
            boxString.Append($"<th colspan='2'>Remaining</td>" +
                             $"<th id='center'>{String.Format("{0:N}", 100 - totalPercentage)}</td>" +
                             $"<th id='right'>{String.Format("{0:N}", results.Projection - totalAmount)}</td>" +
                             $"<th colspan='16'></td>");
            boxString.Append($"</tr>");

            boxString.Append("</table>");

            // combine string to single html string
            var budgetReport = "";
            try
            {
                /*
                var htmlPath = Path.Combine(_hostingEnvironment.ContentRootPath, "Template", "TemplateBudgetPdf.html");
                // check if the template is exist or the path is correct
                if (htmlPath == null)
                {
                    throw Constants.ErrorConstant.TEMPLATE_HTML_NOT_FOUND;
                }
                Encoding encode = Encoding.GetEncoding("utf-8");
                StreamReader html = new StreamReader(htmlPath, encode, true);
                */
                StreamReader html = new StreamReader(Path.Combine(_hostingEnvironment.ContentRootPath, "Template", "TemplateBudgetPdf.html"));
                budgetReport = html.ReadToEnd();
                budgetReport = budgetReport.Replace("[Style]", headString.ToString());
                budgetReport = budgetReport.Replace("[ParagrafBody]", paragrafString.ToString());
                budgetReport = budgetReport.Replace("[TableBody]", boxString.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }

            // instance pdf document
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Landscape,
                    PaperSize = DinkToPdf.PaperKind.A3,
                },
                Objects = {
                    new ObjectSettings() {
                        HtmlContent = budgetReport,
                        WebSettings = { DefaultEncoding = "utf-8" },
                    }
                }
            };

            // convert html string to pdf byte
            byte[] pdfFile = _iconverter.Convert(doc);

            return pdfFile;
        }

        public SLDocument Monitoring(SLDocument sl, BudgetResponse budget)
        {
            sl.RenameWorksheet(SLDocument.DefaultFirstSheetName, "Budget");

            SLStyle header = sl.CreateStyle();
            header.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            header.Font.Bold = true;
            header.Border.SetTopBorder(BorderStyleValues.Medium, System.Drawing.Color.Black);
            header.Border.SetBottomBorder(BorderStyleValues.Medium, System.Drawing.Color.Black);
            header.Border.SetLeftBorder(BorderStyleValues.Medium, System.Drawing.Color.Black);
            header.Border.SetRightBorder(BorderStyleValues.Medium, System.Drawing.Color.Black);

            SLStyle borderFull = sl.CreateStyle();
            borderFull.Border.SetTopBorder(BorderStyleValues.Medium, System.Drawing.Color.Black);
            borderFull.Border.SetBottomBorder(BorderStyleValues.Medium, System.Drawing.Color.Black);
            borderFull.Border.SetLeftBorder(BorderStyleValues.Medium, System.Drawing.Color.Black);
            borderFull.Border.SetRightBorder(BorderStyleValues.Medium, System.Drawing.Color.Black);

            SLStyle textCenter = sl.CreateStyle();
            textCenter.Alignment.Horizontal = HorizontalAlignmentValues.Center;

            SLStyle textNumber = sl.CreateStyle();
            textNumber.Alignment.Horizontal = HorizontalAlignmentValues.Right;
            textNumber.FormatCode = "#,##0.00";

            sl.SetCellValue(1, 1, "Year");
            sl.SetCellValue(2, 1, "Projection");

            sl.SetCellValue(1, 2, budget.Year);
            sl.SetCellValue(2, 2, budget.Projection);
            sl.SetCellStyle(2, 2, textNumber);

            sl.SetCellValue(4, 1, "No");
            sl.SetCellValue(4, 2, "Activities");
            sl.SetCellValue(4, 3, "Budget(%)");
            sl.SetCellValue(4, 4, "Budget(Rp)");
            sl.SetCellValue(4, 5, "Utillized(Rp)");
            sl.SetCellValue(4, 6, "Remaining(Rp)");
            sl.SetCellValue(4, 7, "January(Rp)");
            sl.SetCellValue(4, 8, "February(Rp)");
            sl.SetCellValue(4, 9, "March(Rp)");
            sl.SetCellValue(4, 10, "April(Rp)");
            sl.SetCellValue(4, 11, "May(Rp)");
            sl.SetCellValue(4, 12, "June(Rp)");
            sl.SetCellValue(4, 13, "July(Rp)");
            sl.SetCellValue(4, 14, "August(Rp)");
            sl.SetCellValue(4, 15, "September(Rp)");
            sl.SetCellValue(4, 16, "October(Rp)");
            sl.SetCellValue(4, 17, "November(Rp)");
            sl.SetCellValue(4, 18, "December(Rp)");
            sl.SetCellStyle(4, 1, 4, 18, header);

            int countType = 5;
            decimal totalPercentage = 0;
            decimal totalAmount = 0;
            foreach (var type in budget.BudgetTypes)
            {
                sl.SetCellValue(countType, 1, type.TypeName);
                sl.MergeWorksheetCells(countType, 1, countType, 2);
                countType += 1;
                int countNumber = 1;
                foreach (var activity in type.BudgetActivities)
                {
                    sl.SetCellValue(countType, 1, countNumber);
                    sl.SetCellStyle(countType, 1, textCenter);
                    sl.SetColumnWidth(1, 10);

                    sl.SetCellValue(countType, 2, activity.BudgetActivityName);
                    sl.SetCellStyle(countType, 2, textCenter);
                    sl.SetColumnWidth(2, 30);

                    sl.SetCellValue(countType, 3, activity.BudgetPercentage);
                    sl.SetCellStyle(countType, 3, textCenter);
                    sl.SetColumnWidth(3, 15);

                    sl.SetCellValue(countType, 4, activity.BudgetAmount);
                    sl.SetCellStyle(countType, 4, textNumber);
                    sl.SetColumnWidth(4, 30);

                    sl.SetCellValue(countType, 5, activity.Utilized);
                    sl.SetCellStyle(countType, 5, textNumber);
                    sl.SetColumnWidth(5, 25);

                    sl.SetCellValue(countType, 6, activity.Remaining);
                    sl.SetCellStyle(countType, 6, textNumber);
                    sl.SetColumnWidth(6, 25);

                    sl.SetCellValue(countType, 7, activity.January);
                    sl.SetCellStyle(countType, 7, textNumber);
                    sl.SetColumnWidth(7, 25);

                    sl.SetCellValue(countType, 8, activity.February);
                    sl.SetCellStyle(countType, 8, textNumber);
                    sl.SetColumnWidth(8, 25);

                    sl.SetCellValue(countType, 9, activity.March);
                    sl.SetCellStyle(countType, 9, textNumber);
                    sl.SetColumnWidth(9, 25);

                    sl.SetCellValue(countType, 10, activity.April);
                    sl.SetCellStyle(countType, 10, textNumber);
                    sl.SetColumnWidth(10, 25);

                    sl.SetCellValue(countType, 11, activity.May);
                    sl.SetCellStyle(countType, 11, textNumber);
                    sl.SetColumnWidth(11, 25);

                    sl.SetCellValue(countType, 12, activity.June);
                    sl.SetCellStyle(countType, 12, textNumber);
                    sl.SetColumnWidth(12, 25);

                    sl.SetCellValue(countType, 13, activity.July);
                    sl.SetCellStyle(countType, 13, textNumber);
                    sl.SetColumnWidth(13, 25);

                    sl.SetCellValue(countType, 14, activity.August);
                    sl.SetCellStyle(countType, 14, textNumber);
                    sl.SetColumnWidth(14, 25);

                    sl.SetCellValue(countType, 15, activity.September);
                    sl.SetCellStyle(countType, 15, textNumber);
                    sl.SetColumnWidth(15, 25);

                    sl.SetCellValue(countType, 16, activity.October);
                    sl.SetCellStyle(countType, 16, textNumber);
                    sl.SetColumnWidth(16, 25);

                    sl.SetCellValue(countType, 17, activity.November);
                    sl.SetCellStyle(countType, 17, textNumber);
                    sl.SetColumnWidth(17, 25);

                    sl.SetCellValue(countType, 18, activity.December);
                    sl.SetCellStyle(countType, 18, textNumber);
                    sl.SetColumnWidth(18, 25);

                    totalPercentage += activity.BudgetPercentage;
                    totalAmount += activity.BudgetAmount;
                    countType += 1;
                    countNumber += 1;
                }
            }

            for (int i = 4; i < 19; i++)
            {
                sl.SetCellValue(countType, i, string.Format("=SUM({0}6:{0}{1})", NumberToAlphabet.GetCode(i), countType - 2));
                sl.SetCellStyle(countType, i, textNumber);
            }

            sl.SetCellValue(countType, 1, "Total");
            sl.SetCellValue(countType, 3, totalPercentage);
            sl.SetCellStyle(countType, 3, textCenter);
            sl.MergeWorksheetCells(countType, 1, countType, 2);

            sl.SetCellValue(countType + 1, 1, "Remaining");
            sl.SetCellValue(countType + 1, 3, 100 - totalPercentage);
            sl.SetCellStyle(countType + 1, 3, textCenter);
            sl.SetCellValue(countType + 1, 4, budget.Projection - totalAmount);
            sl.SetCellStyle(countType + 1, 4, textNumber);
            sl.MergeWorksheetCells(countType + 1, 1, countType + 1, 2);
            sl.SetCellStyle(5, 1, countType + 1, 18, borderFull);

            return sl;
        }

        public async Task<MessageDto> GetDefaultBudget()
        {
            try
            {
                _iLogger.LogInformation("Try to fetching Budget Types from database..");
                var budget = new Budget { };
                var budgetDetails = await _iStorage.GetRepository<IBudgetTypeRepository>().GetData();
                var result = _iMapper.Map<BudgetResponse>(budget);
                result.BudgetTypes = _iMapper.Map<List<BudgetTypeDetailResponses>>(budgetDetails);

                if (result != null)
                {
                    return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_BUDGET, _iMapper.Map<BudgetResponse>(result));
                }
                else
                {
                    return new MessageDto(Infrastructure.Constants.Codes.NOT_FOUND, "Not Found", null, SuccessConstant.NOT_FOUND, new BudgetResponse());
                }
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching Budget, err : {ex}");
                throw;
            }
        }
    }
}
