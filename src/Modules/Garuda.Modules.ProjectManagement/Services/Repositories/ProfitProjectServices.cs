// <copyright file="ProfitProjectServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;
using Garuda.Modules.Common.Dtos.Responses;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Responses.ProfitProject;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Status;
using Garuda.Modules.ProjectManagement.Models.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sieve.Models;
using Sieve.Services;

namespace Garuda.Modules.ProjectManagement.Services.Repositories
{
    public class ProfitProjectServices : IProfitProjectServices
    {
        private readonly IStorage _iStorage;
        private readonly ILogger _iLogger;
        private readonly IMapper _iMapper;
        private readonly IConfiguration _configuration;
        private readonly SieveProcessor _sieve;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfitProjectServices"/> class.
        /// </summary>
        /// <param name="iStorage"></param>
        /// <param name="iLogger"></param>
        /// <param name="iMapper"></param>
        /// <param name="iconfiguration"></param>
        /// <param name="sieve"></param>
        public ProfitProjectServices(
           IConfiguration iconfiguration,
           IStorage iStorage,
           ILogger<ProfitProjectServices> iLogger,
           IMapper iMapper,
           SieveProcessor sieve)
        {
            _configuration = iconfiguration;
            _iStorage = iStorage;
            _iLogger = iLogger;
            _iMapper = iMapper;
            _sieve = sieve;
        }

        public async Task<MessageDto> GetYear()
        {
            try
            {
                _iLogger.LogInformation("Trying to fetching status data..");
                var start = _configuration.GetSection("YearStart").Value;
                var years = new List<int>();
                var end = DateTime.Now.AddYears(5).Year;
                for (int i = Convert.ToInt32(start); i <= end; i++)
                {
                    years.Add(i);
                }

                _iLogger.LogInformation($"Data has been fetch.");
                return new MessageDto(
                    Infrastructure.Constants.Codes.SUCCESS,
                    "Found",
                    null,
                    SuccessConstant.FOUND_YEAR,
                    years);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching status data, err : {ex}");
                throw new BadRequestException();
            }
        }

        public async Task<MessageDto> GetDatas(SieveModel sieveModel, int year)
        {
            try
            {
                _iLogger.LogInformation("Tryiing to get project data...");
                var projects = await _iStorage.GetRepository<IProjectDetailRepository>().GetProfitProject(year);
                if (projects != null)
                {
                    var datas = _iMapper.Map<List<ProjectDetail>, List<ProfitProjectDetail>>(projects.ToList());
                    foreach (var data in datas)
                    {
                        var projectCost = await _iStorage.GetRepository<IProjectDevelopmentTeamRepository>().GetManDaysAmountByProject(data.Id)
                            + data.ProjectCost;
                        var index = datas.FindIndex(u => u.Id == data.Id);
                        datas[index].ProjectCost = projectCost;
                    }

                    var detail = _sieve.Apply(sieveModel, datas.AsQueryable());
                    var profitProject = new ProfitProjectResponses();
                    foreach (var profit in datas)
                    {
                        profitProject.TotalAmount += profit.ProjectAmount;
                        profitProject.TotalCost += profit.ProjectCost;
                        profitProject.TotalProfit += profit.ProjectProfit;
                    }

                    var result = new PaginatedResponses<ProfitProjectDetail>()
                    {
                        Data = detail.ToList(),
                        TotalData = datas.Count(),
                        TotalPage = (int)Math.Ceiling((double)datas.Count() / sieveModel.PageSize.Value),
                        CurrentPage = sieveModel.Page.Value,
                        PageSize = sieveModel.PageSize.Value,
                    };
                    profitProject.ProfitProjectDetail = result;
                    _iLogger.LogInformation($"Data has been fetched.");
                    return new MessageDto(Codes.SUCCESS, "Found", SuccessConstant.FOUND_PROFIT, null, profitProject);
                }
                else
                {
                    return new MessageDto(Codes.NOT_FOUND, "Not Found", SuccessConstant.FOUND_PROFIT, null, new ProfitProjectResponses());
                }
            }
            catch (Infrastructure.Exceptions.BadRequestException ex)
            {
                _iLogger.LogInformation($"Failed to fetching project, err : {ex}");
                throw new Infrastructure.Exceptions.BadRequestException();
            }
        }
    }
}
