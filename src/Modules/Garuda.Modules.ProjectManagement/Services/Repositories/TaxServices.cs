// <copyright file="TaxServices.cs" company="CV Garuda Infinity Kreasindo">
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
using Garuda.Modules.ProjectManagement.Dtos.Requests.Tax;
using Garuda.Modules.ProjectManagement.Dtos.Responses;
using Garuda.Modules.ProjectManagement.Models.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.Extensions.Logging;
using Sieve.Models;
using Sieve.Services;

namespace Garuda.Modules.ProjectManagement.Services.Repositories
{
    public class TaxServices : ITaxServices
    {
        private readonly IStorage _iStorage;
        private readonly ILogger _iLogger;
        private readonly IMapper _iMapper;
        private readonly SieveProcessor _sieve;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxServices"/> class.
        /// </summary>
        /// <param name="iStorage"></param>
        /// <param name="iLogger"></param>
        /// <param name="iMapper"></param>
        /// <param name="sieve"></param>
        public TaxServices(
            IStorage iStorage,
            ILogger<TaxServices> iLogger,
            IMapper iMapper,
            SieveProcessor sieve)
        {
            _iStorage = iStorage;
            _iLogger = iLogger;
            _iMapper = iMapper;
            _sieve = sieve;
        }

        public async Task<MessageDto> CreateData(TaxRequest model)
        {
            try
            {
                if (model == null)
                {
                    throw new BadRequestException();
                }

                if (await _iStorage.GetRepository<ITaxRepository>().IsRegisteredCode(model.Code))
                {
                    throw ErrorConstant.CONFLICT_TAX_CODES;
                }

                var data = _iMapper.Map<TaxRequest, Tax>(model);
                _iLogger.LogInformation("update other tax with same name to database..");
                await _iStorage.GetRepository<ITaxRepository>().UpdateNonActiveTaxByName(model.Name);
                await _iStorage.SaveAsync();

                await _iStorage.GetRepository<ITaxRepository>().AddOrUpdate(data);
                _iLogger.LogInformation("Saving tax to database..");
                await _iStorage.SaveAsync();
                return new MessageDto(Infrastructure.Constants.Codes.CREATED, "Created", null, SuccessConstant.CREATED_TAX, data);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation("Failed to fetch taxes, err: ", ex);
                throw;
            }
        }

        public async Task<MessageDto> DeleteData(Guid id)
        {
            try
            {
                if (id == null)
                {
                    throw new BadRequestException();
                }

                if (!await _iStorage.GetRepository<ITaxRepository>().Delete(id))
                {
                    throw ErrorConstant.TAX_FAILED_TO_DELETE;
                }

                _iLogger.LogInformation("Saving tax to database..");
                await _iStorage.SaveAsync();
                return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Deleted", null, SuccessConstant.REMOVE_TAX, null);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation("Failed to delete taxes, err: ", ex);
                throw;
            }
        }

        public async Task<MessageDto> EditData(Guid id, TaxRequest model)
        {
            try
            {
                if (id == null || model == null)
                {
                    throw new BadRequestException();
                }

                if (!await _iStorage.GetRepository<ITaxRepository>().IsRegisteredById(id))
                {
                    throw ErrorConstant.TAXES_NOT_FOUND;
                }

                var tax = await _iStorage.GetRepository<ITaxRepository>().GetData(id);

                if (await _iStorage.GetRepository<ITaxRepository>().IsRegisteredCode(model.Code) && model.Code != tax.Code)
                {
                    throw ErrorConstant.CONFLICT_TAX_CODES;
                }

                _iLogger.LogInformation("update other tax with same name to database..");
                await _iStorage.GetRepository<ITaxRepository>().UpdateNonActiveTaxByName(model.Name);
                await _iStorage.SaveAsync();

                await _iStorage.GetRepository<ITaxRepository>().AddOrUpdate(new Tax
                {
                    Id = id,
                    Code = model.Code,
                    Name = model.Name,
                    Rate = model.Rate,
                    IsActive = model.IsActive,
                });
                _iLogger.LogInformation("Saving tax to database..");
                await _iStorage.SaveAsync();
                return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Updated", null, SuccessConstant.UPDATED_TAX, null);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation("Failed to update taxes, err: ", ex);
                throw;
            }
        }

        public async Task<MessageDto> GetListTax(SieveModel model)
        {
            try
            {
                _iLogger.LogInformation("Trying to get taxes data..");
                var taxes = await _iStorage.GetRepository<ITaxRepository>().GetData();
                if (taxes.Count() > 0)
                {
                    var datas = _iMapper.Map<List<Tax>, List<TaxResponses>>(taxes.ToList());
                    var result = _sieve.Apply(model, datas.AsQueryable(), applyPagination: false);
                    if (model.PageSize != null && model.Page != null)
                    {
                        result = _sieve.Apply(model, datas.AsQueryable());
                        return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", SuccessConstant.FOUND_TAXES, null, result.ToList());
                    }

                    return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", SuccessConstant.FOUND_TAXES, null, result.ToList());
                }
                else
                {
                    throw ErrorConstant.TAXES_NOT_FOUND;
                }
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation("Failed to fetch taxes, err: ", ex);
                throw;
            }
        }
    }
}
