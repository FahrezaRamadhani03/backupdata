// <copyright file="UserUnitServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
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
    public class UserUnitServices : IUserUnitServices
    {
        private readonly IStorage _iStorage;
        private readonly ILogger _iLogger;
        private readonly IMapper _iMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserUnitServices"/> class.
        /// </summary>
        /// <param name="iStorage"></param>
        /// <param name="iLogger"></param>
        /// <param name="mapper"></param>
        public UserUnitServices(
            IStorage iStorage,
            ILogger<UserUnitServices> iLogger,
            IMapper mapper)
        {
            _iStorage = iStorage;
            _iLogger = iLogger;
            _iMapper = mapper;
        }

        public async Task<UserResponses> GetUserByMineHead(Guid id)
        {
            try
            {
                _iLogger.LogInformation("Trying to get user data by mine head id..");
                var data = await _iStorage.GetRepository<IUserUnitRepository>().GetUserByMineHead(id);
                if (data == null)
                {
                    return new UserResponses();
                }

                _iLogger.LogInformation($"Data has been fetched.");
                var result = _iMapper.Map<User, UserResponses>(data.User);
                return result;
            }
            catch (BadRequestException ex)
            {
                throw new BadRequestException();
            }
        }
    }
}
