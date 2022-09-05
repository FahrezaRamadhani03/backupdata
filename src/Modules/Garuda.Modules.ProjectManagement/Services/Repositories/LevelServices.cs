// <copyright file="LevelServices.cs" company="CV Garuda Infinity Kreasindo">
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
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Level;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Level;
using Garuda.Modules.ProjectManagement.Models.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.Extensions.Logging;
using Sieve.Services;

namespace Garuda.Modules.ProjectManagement.Services.Repositories
{
    public class LevelServices : ILevelServices
    {
        private readonly IStorage _iStorage;
        private readonly ILogger _iLogger;
        private readonly IMapper _iMapper;
        private readonly SieveProcessor _sieve;

        /// <summary>
        /// Initializes a new instance of the <see cref="LevelServices"/> class.
        /// </summary>
        /// <param name="iStorage"></param>
        /// <param name="iLogger"></param>
        /// <param name="iMapper"></param>
        /// <param name="sieve"></param>
        public LevelServices(
            IStorage iStorage,
            ILogger<LevelServices> iLogger,
            IMapper iMapper,
            SieveProcessor sieve)
        {
            _iStorage = iStorage;
            _iLogger = iLogger;
            _iMapper = iMapper;
            _sieve = sieve;
        }

        public async Task<MessageDto> GetListLevel()
        {
            try
            {
                _iLogger.LogInformation("Trying to get menu data..");
                var technologies = await _iStorage.GetRepository<ILevelRepository>().GetData();
                if (technologies.Count() > 0)
                {
                    var datas = _iMapper.Map<List<Level>, List<LevelResponses>>(technologies.ToList());
                    return new MessageDto(Codes.SUCCESS, "Found", SuccessConstant.FOUND_LEVELS, null, datas.ToList());
                }
                else
                {
                    return new MessageDto(Codes.SUCCESS, "Not Found", SuccessConstant.FOUND_LEVELS, null, new List<LevelResponses>());
                }
            }
            catch (Exception ex)
            {
                throw new BadRequestException();
            }
        }

        public async Task<MessageDto> CreateLevel(CreateLevelRequests model)
        {
            try
            {
                _iLogger.LogInformation("Getting user data from database..");
                var level = await _iStorage.GetRepository<ILevelRepository>().GetData(model.Name);
                if (level != null)
                {
                    throw Infrastructure.Constants.ErrorConstant.TRANSACT_DUPLICATE;
                }
                else
                {
                    level = new Level()
                    {
                        Name = model.Name,
                    };

                    _iLogger.LogInformation("Saving new Level to database..");
                    await _iStorage.GetRepository<ILevelRepository>().AddOrUpdate(level);
                    await _iStorage.SaveAsync();

                    return new MessageDto(Codes.CREATED, "Created", "New Level has been created", null, level);
                }
            }
            catch (DataNotFoundExceptions ex)
            {
                throw new DataNotFoundExceptions();
            }
            catch (Exception ex)
            {
                throw new BadRequestException();
            }
        }
    }
}
