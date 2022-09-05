// <copyright file="EmployeeServices.cs" company="CV Garuda Infinity Kreasindo">
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
using Garuda.Modules.ProjectManagement.Dtos.Responses;
using Garuda.Modules.ProjectManagement.Models.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.Extensions.Logging;
using Sieve.Models;
using Sieve.Services;

namespace Garuda.Modules.Common.Services.Repositories
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IStorage _iStorage;
        private readonly IMapper _iMapper;
        private readonly SieveProcessor _sieve;
        private readonly ILogger _iLogger;

        public EmployeeServices(
            IStorage iStorage,
            IMapper iMapper,
            SieveProcessor sieve,
            ILogger<EmployeeServices> iLogger)
        {
            _iStorage = iStorage;
            _iMapper = iMapper;
            _sieve = sieve;
            _iLogger = iLogger;
        }

        public async Task<MessageDto> GetListEmployeeForScrumTeam(SieveModel sieveModel, int? clientId)
        {
            try
            {
                _iLogger.LogInformation("Getting data list employee..");
                var developers = await _iStorage.GetRepository<IDeveloperRepository>().GetDataByClientId(clientId);
                if (developers.Count() > 0)
                {
                    var employeeScrums = _iMapper.Map<List<EmployeeScrumResponses>>(developers.ToList());
                    var result = _sieve.Apply(sieveModel, employeeScrums.AsQueryable());
                    return new MessageDto(Codes.SUCCESS, "Found", SuccessConstant.FOUND_EMPLOYEES, null, result.ToList());
                }
                else
                {
                    return new MessageDto(Codes.NOT_FOUND, "Not Found", "Not Found", null, new List<EmployeeResponses>());
                }
            }
            catch (Exception ex)
            {
                throw new BadRequestException();
            }
        }

        public async Task<MessageDto> GetListEmployeeWithDevelopmentRole(SieveModel sieveModel)
        {
            try
            {
                _iLogger.LogInformation("Getting data list employee..");
                var employees = await _iStorage.GetRepository<IEmployeeRepository>().GetData();
                if (employees.Count() > 0)
                {
                    var datas = _iMapper.Map<List<Employee>, List<EmployeeResponses>>(employees.ToList());
                    var sieve = _sieve.Apply(sieveModel, datas.AsQueryable());
                    var result = new PaginatedResponses<EmployeeResponses>()
                    {
                        Data = sieve.ToList(),
                        TotalData = datas.Count(),
                        TotalPage = (int)Math.Ceiling((double)datas.Count() / sieveModel.PageSize.Value),
                        CurrentPage = sieveModel.Page.Value,
                        PageSize = sieveModel.PageSize.Value,
                    };

                    _iLogger.LogInformation($"Data has been fetched. with {datas.Count} data");
                    return new MessageDto(Codes.SUCCESS, "Found", SuccessConstant.FOUND_EMPLOYEES, null, result);
                }
                else
                {
                    return new MessageDto(Codes.NOT_FOUND, "Not Found", "Not Found", null, new List<EmployeeResponses>());
                }
            }
            catch (Exception ex)
            {
                throw new BadRequestException();
            }
        }
    }
}
