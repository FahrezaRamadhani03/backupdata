// <copyright file="StatusServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Status;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Garuda.Modules.ProjectManagement.Services.Repositories
{
    public class StatusServices : IStatusServices
    {
        private readonly IStorage _iStorage;
        private readonly ILogger _iLogger;
        private readonly IMapper _iMapper;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusServices"/> class.
        /// </summary>
        /// <param name="iStorage"></param>
        /// <param name="iLogger"></param>
        /// <param name="iMapper"></param>
        /// <param name="iconfiguration"></param>
        public StatusServices(
           IConfiguration iconfiguration,
           IStorage iStorage,
           ILogger<StatusServices> iLogger,
           IMapper iMapper)
        {
            _configuration = iconfiguration;
            _iStorage = iStorage;
            _iLogger = iLogger;
            _iMapper = iMapper;
        }

        public async Task<MessageDto> GetAllData()
        {
            try
            {
                _iLogger.LogInformation("Trying to fetching status data..");
                var datas = _configuration.GetSection("StatusProject").Get<List<StatusDto>>();
                if (datas == null)
                {
                    throw ErrorConstant.STATUS_NOT_FOUND;
                }

                _iLogger.LogInformation($"Data has been fetch. with length {datas.Count} data");
                return new MessageDto(
                    Infrastructure.Constants.Codes.SUCCESS,
                    "Found",
                    null,
                    SuccessConstant.FOUND_STATUS,
                    datas);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching status data, err : {ex}");
                throw new BadRequestException();
            }
        }
    }
}
