// <copyright file="BankServices.cs" company="CV Garuda Infinity Kreasindo">
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
using Garuda.Modules.ProjectManagement.Dtos.Requests.Bank;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Bank;
using Garuda.Modules.ProjectManagement.Models.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.Extensions.Logging;
using Sieve.Services;

namespace Garuda.Modules.ProjectManagement.Services.Repositories
{
    public class BankServices : IBankServices
    {
        private readonly IStorage _iStorage;
        private readonly ILogger _iLogger;
        private readonly IMapper _iMapper;
        private readonly SieveProcessor _sieve;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankServices"/> class.
        /// </summary>
        /// <param name="iStorage"></param>
        /// <param name="iLogger"></param>
        /// <param name="iMapper"></param>
        /// <param name="sieve"></param>
        public BankServices(
            IStorage iStorage,
            ILogger<BankServices> iLogger,
            IMapper iMapper,
            SieveProcessor sieve)
        {
            _iStorage = iStorage;
            _iLogger = iLogger;
            _iMapper = iMapper;
            _sieve = sieve;
        }

        public async Task<MessageDto> GetListBank()
        {
            try
            {
                _iLogger.LogInformation("Trying to get menu data..");
                var banks = await _iStorage.GetRepository<IBankRepository>().GetData();
                if (banks.Count() > 0)
                {
                    var datas = _iMapper.Map<List<Bank>, List<BankResponses>>(banks.ToList());
                    return new MessageDto(Codes.SUCCESS, "Found", SuccessConstant.FOUND_BANKS, null, datas.ToList());
                }
                else
                {
                    return new MessageDto(Codes.SUCCESS, "Not Found", SuccessConstant.FOUND_BANKS, null, new List<BankResponses>());
                }
            }
            catch (Exception ex)
            {
                throw new BadRequestException();
            }
        }

        public async Task<MessageDto> CreateBank(CreateBankRequests model)
        {
            try
            {
                _iLogger.LogInformation("Getting user data from database..");
                var bank = await _iStorage.GetRepository<IBankRepository>().GetData(model.Name);
                if (bank != null)
                {
                    throw Infrastructure.Constants.ErrorConstant.TRANSACT_DUPLICATE;
                }
                else
                {
                    bank = new Bank()
                    {
                        Code = model.Code,
                        Name = model.Name,
                    };

                    _iLogger.LogInformation("Saving new bank to database..");
                    await _iStorage.GetRepository<IBankRepository>().AddOrUpdate(bank);
                    await _iStorage.SaveAsync();

                    return new MessageDto(Codes.CREATED, "Created", "New bank has been created", null, bank);
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
