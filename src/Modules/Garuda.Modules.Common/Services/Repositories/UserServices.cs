// <copyright file="UserServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Garuda.Database.Abstract.Contracts;
using Garuda.Database.Ldap.Configurations;
using Garuda.Database.Ldap.Contracts;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Contracts;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;
using Garuda.Modules.Common.Dtos.Requests;
using Garuda.Modules.Common.Dtos.Responses;
using Garuda.Modules.Common.Models.Contracts;
using Garuda.Modules.Common.Models.Datas;
using Garuda.Modules.Common.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;

namespace Garuda.Modules.Common.Services.Repositories
{
    public class UserServices : IUserServices
    {
        private readonly IAuthLibraryService _authLibrary;
        private readonly IStorage _iStorage;
        private readonly IMapper _iMapper;
        private readonly SieveProcessor _sieve;
        private readonly LdapLibraryConfig _ldapConfig;
        private readonly ILogger _iLogger;
        private readonly IJwtFactory _jwt;

        public UserServices(
            IAuthLibraryService authLibrary,
            IStorage iStorage,
            IMapper iMapper,
            SieveProcessor sieve,
            IJwtFactory jwt,
            IOptions<LdapLibraryConfig> ldapConfig,
            ILogger<UserServices> iLogger)
        {
            _authLibrary = authLibrary;
            _iStorage = iStorage;
            _iMapper = iMapper;
            _sieve = sieve;
            _jwt = jwt;
            _ldapConfig = ldapConfig.Value;
            _iLogger = iLogger;
        }

        public async Task<UserProfileResponses> GetUserProfile(HttpContext httpContext)
        {
            try
            {
                _iLogger.LogInformation("Getting user profile..");
                var session = await _jwt.GetSession(httpContext);
                var user = await _iStorage.GetRepository<IUserRepository>().GetData(session.UserId);

                if (user != null)
                {
                    var result = new UserProfileResponses()
                    {
                        Id = session.UserId,
                        Email = user.Email,
                        Username = user.Username,
                        Fullname = user.Fullname,
                        IsActive = user.IsActive,
                        LastLogin = user.LastLogin,
                        UserGroups = user.UserGroups,
                        UserUnits = user.UserUnits,
                    };

                    _iLogger.LogInformation("Getting user profile is done.");
                    return result;
                }
                else
                {
                    throw new UnauthorizedException();
                }
            }
            catch (DataNotFoundExceptions)
            {
                throw new DataNotFoundExceptions();
            }
            catch (UnauthorizedException)
            {
                throw new UnauthorizedException();
            }
            catch (Exception ex)
            {
                throw new BadRequestException();
            }
        }

        public async Task<List<UsersResponses>> GetListUser(SieveModel sieveModel)
        {
            try
            {
                _iLogger.LogInformation("Getting data list user..");
                var users = await _iStorage.GetRepository<IUserRepository>().GetData(true);
                if (users.Count() > 0)
                {
                    var datas = _iMapper.Map<List<User>, List<UsersResponses>>(users.ToList());
                    var result = _sieve.Apply(sieveModel, datas.AsQueryable());

                    _iLogger.LogInformation($"Data has been fetched. with {datas.Count} data");
                    return result.ToList();
                }
                else
                {
                    return new List<UsersResponses>();
                }
            }
            catch (Exception ex)
            {
                throw new BadRequestException();
            }
        }

        public async Task<PaginatedResponses<UsersResponses>> GetPagedListUser(SieveModel sieveModel)
        {
            try
            {
                _iLogger.LogInformation("Getting data list user..");
                var users = await _iStorage.GetRepository<IUserRepository>().GetData(true);
                if (users.Count() > 0)
                {
                    var datas = _iMapper.Map<List<User>, List<UsersResponses>>(users.ToList());
                    var sieveData = _sieve.Apply(sieveModel, datas.AsQueryable());
                    int count = datas.Count();
                    _iLogger.LogInformation($"Data has been fetched. with {datas.Count} data");

                    var result = new PaginatedResponses<UsersResponses>()
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
                    return new PaginatedResponses<UsersResponses>();
                }
            }
            catch (Exception ex)
            {
                throw new BadRequestException();
            }
        }

        public async Task<UsersResponses> GetADUser(string username)
        {
            try
            {
                var usernameAD = _ldapConfig.DefaultUser.Username;
                var passwordAD = _ldapConfig.DefaultUser.Password;

                _iLogger.LogInformation("Getting user data from AD..");
                var (ldapUserResponse, domain, error) = await _authLibrary.CheckAdUser(usernameAD, passwordAD, username);

                if (ldapUserResponse != null)
                {
                    var result = new UsersResponses()
                    {
                        Email = ldapUserResponse.GetAttribute("mail").StringValue,
                        Username = ldapUserResponse.GetAttribute("sAMAccountName").StringValue,
                        Fullname = ldapUserResponse.GetAttribute("displayName").StringValue,
                        IsActive = false,
                        LastLogin = null,
                    };

                    return result;
                }
                else
                {
                    throw new DataNotFoundExceptions();
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

        public async Task<MessageDto> CreateUser(CreateUserRequests model)
        {
            try
            {
                var usernameAD = _ldapConfig.DefaultUser.Username;
                var passwordAD = _ldapConfig.DefaultUser.Password;

                _iLogger.LogInformation("Getting user data from AD..");
                var (ldapUserResponse, domain, error) = await _authLibrary.CheckAdUser(usernameAD, passwordAD, model.Username);

                if (ldapUserResponse != null)
                {
                    _iLogger.LogInformation("Getting user data from database..");
                    var ldapUserLocal = await _iStorage.GetRepository<IUserRepository>().GetData(model.Username);
                    if (ldapUserLocal != null)
                    {
                        throw ErrorConstant.TRANSACT_DUPLICATE;
                    }
                    else
                    {
                        ldapUserLocal = new User()
                        {
                            Email = model.Email,
                            Username = model.Username,
                            Fullname = model.Fullname,
                            IsActive = model.IsActive,
                            LastLogin = model.LastLogin,
                        };

                        _iLogger.LogInformation("Saving new user to database..");
                        await _iStorage.GetRepository<IUserRepository>().AddOrUpdate(ldapUserLocal);
                        await _iStorage.SaveAsync();

                        return new MessageDto("New user has been created");
                    }
                }
                else
                {
                    throw new DataNotFoundExceptions();
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

        public async Task<MessageDto> EditUser(Guid id, EditUserRequests model)
        {
            try
            {
                var usernameAD = _ldapConfig.DefaultUser.Username;
                var passwordAD = _ldapConfig.DefaultUser.Password;

                _iLogger.LogInformation("Getting user data from AD..");
                var (ldapUserResponse, domain, error) = await _authLibrary.CheckAdUser(usernameAD, passwordAD, model.Username);
                if (ldapUserResponse != null)
                {
                    _iLogger.LogInformation("Getting user data from database..");
                    var ldapUserLocal = await _iStorage.GetRepository<IUserRepository>().GetData(model.Username);
                    if (ldapUserLocal != null && ldapUserLocal.Username != model.Username)
                    {
                        throw ErrorConstant.TRANSACT_DUPLICATE;
                    }
                    else
                    {
                        ldapUserLocal = new User()
                        {
                            Id = id,
                            Email = model.Email,
                            Username = model.Username,
                            Fullname = model.Fullname,
                            IsActive = model.IsActive,
                            LastLogin = model.LastLogin,
                        };

                        _iLogger.LogInformation("Saving updated user to database..");
                        await _iStorage.GetRepository<IUserRepository>().AddOrUpdate(ldapUserLocal);
                        await _iStorage.SaveAsync();

                        return new MessageDto("User has been updated");
                    }
                }
                else
                {
                    throw new DataNotFoundExceptions();
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
