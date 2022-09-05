// <copyright file="DevelopmentScrumServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using AutoMapper;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Models.Contracts;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace Garuda.Modules.ProjectManagement.Services.Repositories
{
    public class DevelopmentScrumServices : IDevelopmentScrumServices
    {
        private readonly IStorage _iStorage;
        private readonly ILogger _iLogger;
        private readonly IMapper _iMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="DevelopmentScrumServices"/> class.
        /// </summary>
        /// <param name="iLogger"></param>
        /// <param name="iMapper"></param>
        /// <param name="iStorage"></param>
        public DevelopmentScrumServices(
           IStorage iStorage,
           ILogger<DevelopmentScrumServices> iLogger,
           IMapper iMapper)
        {
            _iStorage = iStorage;
            _iLogger = iLogger;
            _iMapper = iMapper;
        }

        public async Task<MessageDto> GetAllData()
        {
            try
            {
                _iLogger.LogInformation("Trying to fetching development scrum data..");

                var datas = await _iStorage.GetRepository<IDevelopmentScrumRepository>().GetList();
                _iLogger.LogInformation($"Data has been fetch. with length {datas.Count} data");

                return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_DEVELOPMENT_SCRUMS, datas);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching development scrum, err : {ex}");
                throw new BadRequestException();
            }
        }
    }
}
