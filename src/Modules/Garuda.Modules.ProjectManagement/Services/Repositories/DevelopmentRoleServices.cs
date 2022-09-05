// <copyright file="DevelopmentRoleServices.cs" company="CV Garuda Infinity Kreasindo">
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
using Garuda.Modules.ProjectManagement.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentRole;
using Garuda.Modules.ProjectManagement.Dtos.Responses.DevelopmentRole;
using Garuda.Modules.ProjectManagement.Models.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace Garuda.Modules.ProjectManagement.Services.Repositories
{
    public class DevelopmentRoleServices : IDevelopmentRoleService
    {
        private readonly IStorage _iStorage;
        private readonly ILogger _iLogger;
        private readonly IMapper _iMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="DevelopmentRoleServices"/> class.
        /// </summary>
        /// <param name="iLogger"></param>
        /// <param name="iMapper"></param>
        /// <param name="iStorage"></param>
        public DevelopmentRoleServices(
           IStorage iStorage,
           ILogger<DevelopmentRoleServices> iLogger,
           IMapper iMapper)
        {
            _iStorage = iStorage;
            _iLogger = iLogger;
            _iMapper = iMapper;
        }

        public async Task<MessageDto> CreateData(CreateDevelopmentRoleRequest model)
        {
            try
            {
                if (model == null)
                {
                    throw new BadRequestException();
                }

                var levels = await _iStorage.GetRepository<ILevelRepository>().GetData();
                if (levels != null)
                {
                    var levelList = levels.Select(x => x.Name).OfType<string>().ToList();
                    model.Level = levelList;
                }

                var map = _iMapper.Map<CreateDevelopmentRoleRequest, DevelopmentRole>(model);
                var registeredData = await _iStorage.GetRepository<IDevelopmentRoleRepository>().FindByCodeAndName(map);
                if (registeredData != null)
                {
                    throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.CONFLICT_DEVELOPMENT_ROLES;
                }

                _iLogger.LogInformation("Trying to created a development role data..");

                await _iStorage.GetRepository<IDevelopmentRoleRepository>().AddOrUpdate(map);
                await _iStorage.SaveAsync();

                return new MessageDto(Infrastructure.Constants.Codes.CREATED, "Created", null, SuccessConstant.CREATED_DEVELOPMENT_ROLES, model);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to create a development role, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> GetAllData()
        {
            try
            {
                _iLogger.LogInformation("Trying to fetching development roles data..");

                var datas = await _iStorage.GetRepository<IDevelopmentRoleRepository>().GetListMapLevel();
                _iLogger.LogInformation($"Data has been fetch. with length {datas.Count} data");

                return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_DEVELOPMENT_ROLES, new GetDevelopmentRolesResponses { DevelopmentRoles = datas.OrderBy(u => u).ToList() });
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching development roles, err : {ex}");
                throw new BadRequestException();
            }
        }

        public async Task<MessageDto> GetData()
        {
            try
            {
                _iLogger.LogInformation("Trying to fetching development roles data..");

                var datas = await _iStorage.GetRepository<IDevelopmentRoleRepository>().GetList();
                _iLogger.LogInformation($"Data has been fetch. with length {datas.Count} data");

                var map = _iMapper.Map<List<DevelopmentRole>, List<DevelopmentRoleDto>>(datas);

                return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_DEVELOPMENT_ROLES, map);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching development roles, err : {ex}");
                throw new BadRequestException();
            }
        }

        public async Task<MessageDto> UpdateData(Guid id, CreateDevelopmentRoleRequest model)
        {
            try
            {
                if (model == null)
                {
                    throw new BadRequestException();
                }

                var levels = await _iStorage.GetRepository<ILevelRepository>().GetData();
                if (levels != null)
                {
                    var levelList = levels.Select(x => x.Name).OfType<string>().ToList();
                    model.Level = levelList;
                }

                var data = await _iStorage.GetRepository<IDevelopmentRoleRepository>().FindById(id);

                if (data == null)
                {
                    return new MessageDto("Development role data not found");
                }
                else
                {
                    var map = _iMapper.Map<CreateDevelopmentRoleRequest, DevelopmentRole>(model);
                    map.Id = id;
                    _iLogger.LogInformation("Trying to update development role data..");

                    await _iStorage.GetRepository<IDevelopmentRoleRepository>().UpdateData(map);
                    await _iStorage.SaveAsync();
                    return new MessageDto(Codes.SUCCESS, "Updated", null, SuccessConstant.UPDATED_DEVELOPMENT_ROLE, model);
                }
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to update development role, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> Delete(Guid id)
        {
            try
            {
                _iLogger.LogInformation("Trying to delete development role data..");
                var (isDeleted, devRoleName) = _iStorage.GetRepository<IDevelopmentRoleRepository>().Delete(id);

                if (!isDeleted)
                {
                    var message = new MessageLangDto(null, "Data can't be deleted! " + devRoleName + " has relation with another data.");
                    throw new BadRequestException(Codes.ERROR_TRANSACT, "Not Deleted", message);
                }
                await _iStorage.SaveAsync();

                return new MessageDto("Data has been deleted.");
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to delete development role, err : {ex}");
                throw;
            }
        }
    }
}
