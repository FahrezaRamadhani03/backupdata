// <copyright file="TechnologyServices.cs" company="CV Garuda Infinity Kreasindo">
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
using Garuda.Modules.ProjectManagement.Dtos.Requests.Technology;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Technology;
using Garuda.Modules.ProjectManagement.Models.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.Extensions.Logging;
using Sieve.Services;

namespace Garuda.Modules.ProjectManagement.Services.Repositories
{
    public class TechnologyServices : ITechnologyServices
    {
        private readonly IStorage _iStorage;
        private readonly ILogger _iLogger;
        private readonly IMapper _iMapper;
        private readonly SieveProcessor _sieve;

        /// <summary>
        /// Initializes a new instance of the <see cref="TechnologyServices"/> class.
        /// </summary>
        /// <param name="iStorage"></param>
        /// <param name="iLogger"></param>
        /// <param name="iMapper"></param>
        /// <param name="sieve"></param>
        public TechnologyServices(
            IStorage iStorage,
            ILogger<TechnologyServices> iLogger,
            IMapper iMapper,
            SieveProcessor sieve)
        {
            _iStorage = iStorage;
            _iLogger = iLogger;
            _iMapper = iMapper;
            _sieve = sieve;
        }

        public async Task<MessageDto> GetListTechnology()
        {
            try
            {
                _iLogger.LogInformation("Trying to get menu data..");
                var technologies = await _iStorage.GetRepository<ITechnologyRepository>().GetData();
                if (technologies.Count() > 0)
                {
                    var datas = _iMapper.Map<List<Technology>, List<TechnologyResponses>>(technologies.ToList());
                    return new MessageDto(Codes.SUCCESS, "Found", SuccessConstant.FOUND_TECHNOLOGIES, null, datas.ToList());
                }
                else
                {
                    return new MessageDto(Codes.SUCCESS, "Not Found", SuccessConstant.FOUND_TECHNOLOGIES, null, new List<TechnologyResponses>());
                }
            }
            catch (Exception ex)
            {
                throw new BadRequestException();
            }
        }

        public async Task<MessageDto> CreateTechnology(CreateTechnologyRequests model)
        {
            try
            {
                _iLogger.LogInformation("Getting user data from database..");
                var technology = await _iStorage.GetRepository<ITechnologyRepository>().GetData(model.Name);
                if (technology != null)
                {
                    throw Infrastructure.Constants.ErrorConstant.TRANSACT_DUPLICATE;
                }
                else
                {
                    technology = new Technology()
                    {
                        Name = model.Name,
                    };

                    _iLogger.LogInformation("Saving new technology to database..");
                    await _iStorage.GetRepository<ITechnologyRepository>().AddOrUpdate(technology);
                    await _iStorage.SaveAsync();

                    return new MessageDto(Codes.CREATED, "Created", "New technology has been created", null, technology);
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
