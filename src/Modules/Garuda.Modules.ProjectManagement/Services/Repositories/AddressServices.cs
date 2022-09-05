// <copyright file="AddressServices.cs" company="CV Garuda Infinity Kreasindo">
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
using Garuda.Modules.ProjectManagement.Dtos.Requests.Client;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Client;
using Garuda.Modules.ProjectManagement.Models.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.Extensions.Logging;
using Sieve.Models;

namespace Garuda.Modules.ProjectManagement.Services.Repositories
{
    public class AddressServices : IAddressServices
    {
        private readonly IStorage _iStorage;
        private readonly ILogger _iLogger;
        private readonly IMapper _iMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressServices"/> class.
        /// </summary>
        /// <param name="iLogger"></param>
        /// <param name="iMapper"></param>
        /// <param name="iStorage"></param>
        public AddressServices(
            IStorage iStorage,
            ILogger<AddressServices> iLogger,
            IMapper iMapper)
        {
            _iStorage = iStorage;
            _iLogger = iLogger;
            _iMapper = iMapper;
        }

        public async Task<MessageDto> GetCities()
        {
            try
            {
                var data = await _iStorage.GetRepository<ICityRepository>().GetData();
                if (data == null)
                {
                    return new MessageDto(Codes.NOT_FOUND, "Not Found", "Cities Not Found", null, null);
                }

                var datas = _iMapper.Map<List<City>, List<AddressResponse>>(data.ToList());

                // need to integration with invoice
                return new MessageDto(Codes.SUCCESS, "Found", SuccessConstant.FOUND_CITIES, null, datas);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching Cities, err : {ex}");
                throw new BadRequestException();
            }
        }

        public async Task<MessageDto> GetContries()
        {
            try
            {
                var data = await _iStorage.GetRepository<ICountryRepository>().GetData();
                if (data == null)
                {
                    return new MessageDto(Codes.NOT_FOUND, "Not Found", "Cities Not Found", null, null);
                }

                var datas = _iMapper.Map<List<Country>, List<AddressResponse>>(data.ToList());

                // need to integration with invoice
                return new MessageDto(Codes.SUCCESS, "Found", SuccessConstant.FOUND_COUNTRIES, null, datas);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching Country, err : {ex}");
                throw new BadRequestException();
            }
        }

        public async Task<MessageDto> GetDistricts()
        {
            try
            {
                var data = await _iStorage.GetRepository<IDistrictRepository>().GetData();
                if (data == null)
                {
                    return new MessageDto(Codes.NOT_FOUND, "Not Found", "Districts Not Found", null, null);
                }

                var datas = _iMapper.Map<List<District>, List<AddressResponse>>(data.ToList());

                // need to integration with invoice
                return new MessageDto(Codes.SUCCESS, "Found", SuccessConstant.FOUND_DISTRICTS, null, datas);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching District, err : {ex}");
                throw new BadRequestException();
            }
        }

        public async Task<MessageDto> GetProvinces()
        {
            try
            {
                var data = await _iStorage.GetRepository<IProvinceRepository>().GetData();
                if (data == null)
                {
                    return new MessageDto(Codes.NOT_FOUND, "Not Found", "Proviences Not Found", null, null);
                }

                var datas = _iMapper.Map<List<Province>, List<AddressResponse>>(data.ToList());

                // need to integration with invoice
                return new MessageDto(Codes.SUCCESS, "Found", SuccessConstant.FOUND_PROVINCES, null, datas);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching Provinces, err : {ex}");
                throw new BadRequestException();
            }
        }

        public async Task<MessageDto> CreateCity(AddressRequest model)
        {
            try
            {
                if (model == null)
                {
                    throw new BadRequestException();
                }
                if (await _iStorage.GetRepository<ICityRepository>().IsRegisteredName(model.Name.Trim()))
                {
                    throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.CONFLICT_ADDRESS_NAME;
                }
                else
                {
                    _iLogger.LogInformation("Saving new city to database..");
                    await _iStorage.GetRepository<ICityRepository>().AddOrUpdate(_iMapper.Map<City>(model));
                    await _iStorage.SaveAsync();

                    return new MessageDto(Codes.CREATED, "Created", "city has been added", null, model);
                }
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to save city, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> CreateContry(AddressRequest model)
        {
            try
            {
                if (model == null)
                {
                    throw new BadRequestException();
                }
                if (await _iStorage.GetRepository<ICountryRepository>().IsRegisteredName(model.Name.Trim()))
                {
                    throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.CONFLICT_ADDRESS_NAME;
                }
                else
                {
                    _iLogger.LogInformation("Saving new country to database..");
                    await _iStorage.GetRepository<ICountryRepository>().AddOrUpdate(_iMapper.Map<Country>(model));
                    await _iStorage.SaveAsync();

                    return new MessageDto(Codes.CREATED, "Created", "country has been added", null, model);
                }
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to save country, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> CreateDistrict(AddressRequest model)
        {
            try
            {
                if (model == null)
                {
                    throw new BadRequestException();
                }
                if (await _iStorage.GetRepository<IDistrictRepository>().IsRegisteredName(model.Name.Trim()))
                {
                    throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.CONFLICT_ADDRESS_NAME;
                }
                else
                {
                    _iLogger.LogInformation("Saving new District to database..");
                    await _iStorage.GetRepository<IDistrictRepository>().AddOrUpdate(_iMapper.Map<District>(model));
                    await _iStorage.SaveAsync();

                    return new MessageDto(Codes.CREATED, "Created", "District has been added", null, model);
                }
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to save District, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> CreateProvince(AddressRequest model)
        {
            try
            {
                if (model == null)
                {
                    throw new BadRequestException();
                }
                if (await _iStorage.GetRepository<IProvinceRepository>().IsRegisteredName(model.Name.Trim()))
                {
                    throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.CONFLICT_ADDRESS_NAME;
                }
                else
                {
                    _iLogger.LogInformation("Saving new Province to database..");
                    await _iStorage.GetRepository<IProvinceRepository>().AddOrUpdate(_iMapper.Map<Province>(model));
                    await _iStorage.SaveAsync();

                    return new MessageDto(Codes.CREATED, "Created", "Province has been added", null, model);
                }
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to save Province, err : {ex}");
                throw;
            }
        }
    }
}
