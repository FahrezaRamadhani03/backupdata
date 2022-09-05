// <copyright file="UnitServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Exceptions;
using Garuda.Modules.Common.Dtos.Responses;
using Garuda.Modules.Common.Models.Contracts;
using Garuda.Modules.Common.Models.Datas;
using Garuda.Modules.Common.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace Garuda.Modules.Common.Services.Repositories
{
    public class UnitServices : IUnitServices
    {
        private readonly IStorage _iStorage;
        private readonly ILogger _iLogger;
        private readonly IMapper _iMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitServices"/> class.
        /// </summary>
        /// <param name="iStorage"></param>
        /// <param name="iLogger"></param>
        /// <param name="iMapper"></param>
        public UnitServices(
            IStorage iStorage,
            ILogger<UnitServices> iLogger,
            IMapper iMapper)
        {
            _iStorage = iStorage;
            _iLogger = iLogger;
            _iMapper = iMapper;
        }

        public async Task<List<UnitResponses>> GetData(bool isActive)
        {
            try
            {
                _iLogger.LogInformation("Trying to get Unit data..");
                var datas = await _iStorage.GetRepository<IUnitRepository>().GetData(true);
                if (datas == null)
                {
                    datas = new List<Unit>();
                }

                _iLogger.LogInformation($"Data has been fetched. with {datas.Count} data");
                var map = _iMapper.Map<List<Unit>, List<UnitResponses>>(datas);
                return map;
            }
            catch (BadRequestException ex)
            {
                throw new BadRequestException();
            }
        }
    }
}
