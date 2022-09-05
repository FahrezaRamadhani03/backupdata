// <copyright file="DevelopmentHolidayServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Dtos.Responses.DevelopmentHolidays;
using Garuda.Modules.ProjectManagement.Models.Contracts;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace Garuda.Modules.ProjectManagement.Services.Repositories
{
    public class DevelopmentHolidayServices : IDevelopmentHolidayServices
    {
        private readonly IStorage _iStorage;
        private readonly ILogger _iLogger;
        private readonly IMapper _iMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="DevelopmentHolidayServices"/> class.
        /// </summary>
        /// <param name="iLogger"></param>
        /// <param name="iMapper"></param>
        /// <param name="iStorage"></param>
        public DevelopmentHolidayServices(
           IStorage iStorage,
           ILogger<DevelopmentHolidayServices> iLogger,
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
                _iLogger.LogInformation("Trying to fetching development holidays data..");

                var datas = await _iStorage.GetRepository<IDevelopmentHolidayRepository>().GetList();
                _iLogger.LogInformation($"Data has been fetch. with length {datas.Count} data");

                return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_DEVELOPMENT_HOLIDAYS, datas.OrderBy(u => u).Select(d => _iMapper.Map<DevelopmentHolidaysReponse>(d)).ToList());
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching development holidays, err : {ex}");
                throw new BadRequestException();
            }
        }
    }
}
