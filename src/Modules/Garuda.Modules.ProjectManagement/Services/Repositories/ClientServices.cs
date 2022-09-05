// <copyright file="ClientServices.cs" company="CV Garuda Infinity Kreasindo">
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
using Sieve.Services;

namespace Garuda.Modules.ProjectManagement.Services.Repositories
{
    public class ClientServices : IClientServices
    {
        private readonly IStorage _iStorage;
        private readonly ILogger _iLogger;
        private readonly IMapper _iMapper;
        private readonly SieveProcessor _sieve;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientServices"/> class.
        /// </summary>
        /// <param name="iLogger"></param>
        /// <param name="iMapper"></param>
        /// <param name="iStorage"></param>
        public ClientServices(
            IStorage iStorage,
            ILogger<ClientServices> iLogger,
            IMapper iMapper,
            SieveProcessor sieve)
        {
            _iStorage = iStorage;
            _iLogger = iLogger;
            _iMapper = iMapper;
            _sieve = sieve;
        }

        public async Task<MessageDto> GetData()
        {
            try
            {
                _iLogger.LogInformation("Trying to get client data..");
                var clients = await _iStorage.GetRepository<IClientRepository>().GetData(true);

                if (clients.Count() > 0)
                {
                    var datas = _iMapper.Map<List<Client>, List<ClientResponses>>(clients.ToList());

                    _iLogger.LogInformation($"Data has been fetched. with {datas.Count} data");
                    return new MessageDto(Codes.SUCCESS, "Found", SuccessConstant.FOUND_CLIENT, null, datas);
                }
                else
                {
                    return new MessageDto(Codes.SUCCESS, "Not Found", SuccessConstant.FOUND_CLIENT, null, new List<ClientResponses>());
                }
            }
            catch (BadRequestException ex)
            {
                _iLogger.LogInformation($"Failed to fetching client, err : {ex}");
                throw new BadRequestException();
            }
        }

        public async Task<PaginatedResponses<ClientResponses>> GetPagedListClient(SieveModel sieveModel)
        {
            try
            {
                _iLogger.LogInformation("Getting data list client..");
                var clients = await _iStorage.GetRepository<IClientRepository>().GetData(true);
                if (clients.Count() > 0)
                {
                    var datas = _iMapper.Map<List<Client>, List<ClientResponses>>(clients.ToList());
                    var sieveData = _sieve.Apply(sieveModel, datas.AsQueryable());
                    int count = datas.Count();
                    _iLogger.LogInformation($"Data has been fetched. with {datas.Count} data");

                    var result = new PaginatedResponses<ClientResponses>()
                    {
                        Data = sieveData.ToList(),
                        TotalData = count,
                        TotalPage = (int)Math.Ceiling((double)count / sieveModel.PageSize.Value),
                        CurrentPage = sieveModel.Page.Value,
                        PageSize = sieveModel.PageSize.Value,
                    };

                    return result;
                }
                else
                {
                    return new PaginatedResponses<ClientResponses>();
                }
            }
            catch (Exception ex)
            {
                throw new BadRequestException();
            }
        }

        public async Task<MessageDto> CreateData(CreateClientRequest model)
        {
            try
            {
                var clientLocal = await _iStorage.GetRepository<IClientRepository>().GetbyCode(model.Code);
                if (clientLocal != null)
                {
                    throw Infrastructure.Constants.ErrorConstant.TRANSACT_DUPLICATE;
                }
                else
                {
                    _iLogger.LogInformation("Trying to fetching Country data..");
                    var country = await _iStorage.GetRepository<ICountryRepository>().GetData(model.Country);
                    if (country == null)
                    {
                        country = new Country()
                        {
                            Name = model.Country,
                            Code = model.Country,
                        };

                        await _iStorage.GetRepository<ICountryRepository>().AddOrUpdate(country);
                    }

                    _iLogger.LogInformation("Trying to fetching State data..");
                    var province = await _iStorage.GetRepository<IProvinceRepository>().GetData(model.State);
                    if (province == null)
                    {
                        province = new Province()
                        {
                            Name = model.State,
                            Code = model.State,
                            CountryId = country.Id,
                        };

                        await _iStorage.GetRepository<IProvinceRepository>().AddOrUpdate(province);
                    }

                    _iLogger.LogInformation("Trying to fetching City data..");
                    var city = await _iStorage.GetRepository<ICityRepository>().GetData(model.City);
                    if (city == null)
                    {
                        city = new City()
                        {
                            Name = model.City,
                            Code = model.City,
                            ProvinceId = province.Id,
                        };

                        await _iStorage.GetRepository<ICityRepository>().AddOrUpdate(city);
                    }

                    _iLogger.LogInformation("Trying to fetching District data..");
                    var district = await _iStorage.GetRepository<IDistrictRepository>().GetData(model.District);
                    if (district == null)
                    {
                        district = new District()
                        {
                            Name = model.District,
                            Code = model.District,
                            CityId = city.Id,
                        };

                        await _iStorage.GetRepository<IDistrictRepository>().AddOrUpdate(district);
                    }

                    clientLocal = _iMapper.Map<CreateClientRequest, Client>(model);
                    _iLogger.LogInformation("Saving new client to database..");
                    await _iStorage.GetRepository<IClientRepository>().AddData(clientLocal);
                    await _iStorage.SaveAsync();

                    return new MessageDto(Codes.CREATED, "Created", "Client has been added", null, clientLocal);
                }
            }
            catch (ErrorTransactExceptions ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to save client, err : {ex}");
                throw new BadRequestException();
            }
        }

        public async Task<MessageDto> GetDataById(int id)
        {
            try
            {
                var client = await _iStorage.GetRepository<IClientRepository>().GetDataById(id);
                if (client == null)
                {
                    return new MessageDto(Codes.NOT_FOUND, "Not Found", "Client Not Found", null, null);
                }

                var datas = _iMapper.Map<Client, ClientDetailResponse>(client);

                // need to integration with invoice
                return new MessageDto(Codes.SUCCESS, "Found", SuccessConstant.FOUND_CLIENT, null, datas);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching client, err : {ex}");
                throw new BadRequestException();
            }
        }

        public async Task<MessageDto> GetProjectListById(int id)
        {
            try
            {
                var client = await _iStorage.GetRepository<IClientRepository>().GetProjectListById(id);
                if (client == null)
                {
                    return new MessageDto(Codes.NOT_FOUND, "Not Found", "Client Not Found", null, null);
                }

                var datas = _iMapper.Map<List<ProjectDetail>, List<ClientProjectResponse>>(client.ProjectDetails.ToList());

                // need to integration with invoice
                return new MessageDto(Codes.SUCCESS, "Found", SuccessConstant.FOUND_CLIENT, null, datas);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching client, err : {ex}");
                throw new BadRequestException();
            }
        }

        public async Task<MessageDto> SoftDeleteClient(int id)
        {
            try
            {
                if (id == null)
                {
                    throw new BadRequestException();
                }

                if (await _iStorage.GetRepository<IClientRepository>().SoftDeleteData(id))
                {
                    await _iStorage.SaveAsync();
                    return new MessageDto(Codes.SUCCESS, "Deleted", "Client has been removed", null, null);
                }
                else
                {
                    throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.CLIENT_FAILED_TO_DELETE;
                }
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to save Province, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> UpdateClient(int id, CreateClientRequest model)
        {
            try
            {
                if (id == null || model == null)
                {
                    throw new BadRequestException();
                }

                var clientLocal = await _iStorage.GetRepository<IClientRepository>().GetDataById(id);
                if (clientLocal == null)
                {
                    throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.NOT_FOUND_CLIENT;
                }
                else
                {
                    if (await _iStorage.GetRepository<IClientRepository>().UpdateData(id, _iMapper.Map<CreateClientRequest, Client>(model)))
                    {
                        _iLogger.LogInformation("update client data to database..");
                        await _iStorage.SaveAsync();
                    }
                    else
                    {
                        throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.CLIENT_FAILED_TO_UPDATE;
                    }

                    return new MessageDto(Codes.SUCCESS, "Updated", "Client has been updated", null, model);
                }
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to save client, err : {ex}");
                throw;
            }
        }
    }
}
