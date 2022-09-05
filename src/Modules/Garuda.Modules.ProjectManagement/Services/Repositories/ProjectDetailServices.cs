// <copyright file="ProjectDetailServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Garuda.Database.Abstract.Contracts;
using Garuda.Filestorage.Exceptions;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Contracts;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;
using Garuda.Infrastructure.Helpers;
using Garuda.Modules.Common.Dtos.Responses;
using Garuda.Modules.Common.Models.Contracts;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.ProjectDetails;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Project;
using Garuda.Modules.ProjectManagement.Hubs;
using Garuda.Modules.ProjectManagement.Hubs.Contracts;
using Garuda.Modules.ProjectManagement.Models.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sieve.Models;
using Sieve.Services;
using ErrorConstant = Garuda.Modules.ProjectManagement.Constants.ErrorConstant;

namespace Garuda.Modules.ProjectManagement.Services.Repositories
{
    public class ProjectDetailServices : IProjectDetailServices
    {
        private readonly IStorage _iStorage;
        private readonly ILogger _iLogger;
        private readonly IMapper _iMapper;
        private readonly IConfiguration _configuration;
        private readonly IDevelopmentRoleService _developmentRoleService;
        private readonly SieveProcessor _sieve;
        private readonly IHubContext<NotificationHub, INotificationHub> _notifHub;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectDetailServices"/> class.
        /// </summary>
        /// <param name="iStorage"></param>
        /// <param name="iLogger"></param>
        /// <param name="mapper"></param>
        /// <param name="configuration"></param>
        /// <param name="developmentRoleService"></param>
        /// <param name="sieve"></param>
        /// <param name="notifHub"></param>
        public ProjectDetailServices(
            IStorage iStorage,
            ILogger<ProjectDetailServices> iLogger,
            IMapper mapper,
            IConfiguration configuration,
            IDevelopmentRoleService developmentRoleService,
            SieveProcessor sieve,
            IHubContext<NotificationHub, INotificationHub> notifHub)
        {
            _iStorage = iStorage;
            _iLogger = iLogger;
            _iMapper = mapper;
            _configuration = configuration;
            _developmentRoleService = developmentRoleService;
            _sieve = sieve;
            _notifHub = notifHub;
        }

        public async Task<MessageDto> GetData(SieveModel sieveModel)
        {
            try
            {
                _iLogger.LogInformation("Trying to get project data..");
                var projects = await _iStorage.GetRepository<IProjectDetailRepository>().GetData(true);
                var clients = await _iStorage.GetRepository<IClientRepository>().GetData(true);

                if (projects.Count() > 0)
                {
                    var datas = _iMapper.Map<List<ProjectDetail>, List<ProjectListResponses>>(projects.ToList());

                    datas.ForEach(d =>
                    {
                        d.ClientName = clients.Find(x => x.Id == d.ClientId)?.Name;
                        d.Address = clients.Find(x => x.Id == d.ClientId)?.Address;
                        d.DevelopmentPeriod = d.DevelopmentStart?.ToString("dd MMM yyyy") + " - " + d.DevelopmentEnd?.ToString("dd MMM yyyy");
                    });

                    var result = _sieve.Apply(sieveModel, datas.AsQueryable());
                    _iLogger.LogInformation($"Data has been fetched. with {datas.Count} data");
                    return new MessageDto(Codes.SUCCESS, "Found", SuccessConstant.FOUND_PROJECT, null, result.ToList());
                }
                else
                {
                    return new MessageDto(Codes.SUCCESS, "Not Found", SuccessConstant.FOUND_PROJECT, null, new List<ProjectListResponses>());
                }
            }
            catch (Infrastructure.Exceptions.BadRequestException ex)
            {
                _iLogger.LogInformation($"Failed to fetching project, err : {ex}");
                throw new Infrastructure.Exceptions.BadRequestException();
            }
        }

        public async Task<MessageDto> GetData()
        {
            try
            {
                _iLogger.LogInformation("Trying to get project data..");
                var projects = await _iStorage.GetRepository<IProjectDetailRepository>().GetData(true);
                var clients = await _iStorage.GetRepository<IClientRepository>().GetData(true);

                if (projects.Count() > 0)
                {
                    var datas = _iMapper.Map<List<ProjectDetail>, List<ProjectListResponses>>(projects.ToList());

                    datas.ForEach(d =>
                    {
                        d.ClientName = clients.Find(x => x.Id == d.ClientId)?.Name;
                        d.Address = clients.Find(x => x.Id == d.ClientId)?.Address;
                        d.DevelopmentPeriod = d.DevelopmentStart?.ToString("dd MMM yyyy") + " - " + d.DevelopmentEnd?.ToString("dd MMM yyyy");
                    });

                    var result = datas.AsQueryable();
                    _iLogger.LogInformation($"Data has been fetched. with {datas.Count} data");
                    return new MessageDto(Codes.SUCCESS, "Found", SuccessConstant.FOUND_PROJECT, null, result.ToList());
                }
                else
                {
                    return new MessageDto(Codes.SUCCESS, "Not Found", SuccessConstant.FOUND_PROJECT, null, new List<ProjectListResponses>());
                }
            }
            catch (Infrastructure.Exceptions.BadRequestException ex)
            {
                _iLogger.LogInformation($"Failed to fetching project, err : {ex}");
                throw new Infrastructure.Exceptions.BadRequestException();
            }
        }

        public async Task<MessageDto> GetShortInfo(Guid id)
        {
            try
            {
                _iLogger.LogInformation("Trying to get project short info..");
                var project = await _iStorage.GetRepository<IProjectDetailRepository>().GetById(id);
                var developmentTeams = await _iStorage.GetRepository<IProjectDevelopmentTeamRepository>().GetByProject(id);
                var projectResources = await _iStorage.GetRepository<IProjectResourceRepository>().GetDataByProjectId(id);

                if (project != null)
                {
                    var datas = _iMapper.Map<ProjectDetail, ProjectShortInfoResponses>(project);
                    var devTeamsResponses = new List<ProjectDevTeamResponses>();
                    developmentTeams.ForEach(d =>
                    {
                        var developmentTeam = new ProjectDevTeamResponses()
                        {
                            Id = d.Id,
                            FullName = d.Developer?.Fullname,
                            IsLeader = d.IsLeader,
                        };

                        devTeamsResponses.Add(developmentTeam);
                    });

                    datas.DevelopmentTeams = devTeamsResponses;
                    datas.DevelopmentPeriod = datas.DevelopmentStart != null ? datas.DevelopmentStart?.ToString("dd MMM yyyy") + " - " + datas.DevelopmentEnd?.ToString("dd MMM yyyy") : string.Empty;
                    datas.MaintenancePeriod = datas.MaintenanceStart != null ? datas.MaintenanceStart?.ToString("dd MMM yyyy") + " - " + datas.MaintenanceEnd?.ToString("dd MMM yyyy") : string.Empty;

                    Regex pattern = new Regex(@"[\[\]""]");
                    datas.Technology = pattern.Replace(datas.Technology, string.Empty).Replace(",", ", ");

                    string currentSprint = string.Empty;
                    if (project.DevelopmentScrums.FirstOrDefault() != null)
                    {
                       var sprint = project.DevelopmentScrums.FirstOrDefault().DevelopmentScrumSprints.Where(u => DateTime.Now >= u.SprintStart &&  DateTime.Now <= u.SprintEnd && u.DeletedDate == null).FirstOrDefault();
                       if (sprint != null)
                       {
                            datas.CurrentSprint = sprint.Sprintname;
                            datas.PeriodeSprint = sprint.SprintStart.ToString("dd MMM yyyy") + " - " + sprint.SprintEnd.ToString("dd MMM yyyy");
                        }
                    }

                    if (projectResources != null)
                    {
                        foreach (var resource in projectResources)
                        {
                            var requiredResources = $"{resource.Qty} {resource.DevelopmentRole.Code} {resource.DevelopmentRole.ProjectResources.FirstOrDefault().Level}";
                            datas.RequiredResources += datas.RequiredResources == null ? requiredResources : ", " + requiredResources;
                        }
                    }

                    var projectHoliday = new List<string> { };
                    foreach (var holiday in project.DevelopmentHolidays)
                    {
                        projectHoliday.Add(holiday.Description + ", " + holiday.HolidayDate.ToString("dd MMM yyyy"));
                    }

                    if (projectHoliday.Count > 0)
                    {
                        datas.Holidays = projectHoliday;
                    }

                    _iLogger.LogInformation($"Data has been fetched.");
                    return new MessageDto(Codes.SUCCESS, "Found", SuccessConstant.FOUND_PROJECT, null, datas);
                }
                else
                {
                    return new MessageDto(Codes.SUCCESS, "Not Found", "Project not found.", null, new ProjectShortInfoResponses());
                }
            }
            catch (Infrastructure.Exceptions.BadRequestException ex)
            {
                _iLogger.LogInformation($"Failed to fetching project, err : {ex}");
                throw new Infrastructure.Exceptions.BadRequestException();
            }
        }

        public async Task<MessageDto> CreateData(CreateProjectDetailRequest model, Guid userId)
        {
            try
            {
                _iLogger.LogInformation("Trying to get client data by id..");
                if (model == null)
                {
                    throw new Infrastructure.Exceptions.BadRequestException();
                }

                PICRequest client = null;
                if (model.Client != null)
                {
                    var clientData = await _iStorage.GetRepository<IClientRepository>().GetDataById(model.Client.Id);

                    if (clientData == null)
                    {
                        throw ErrorConstant.NOT_FOUND_CLIENT;
                    }

                    if (!model.Client.IsRegisteredPIC)
                    {
                        if (model.Client.PIC == null)
                        {
                            throw ErrorConstant.CLIENT_PIC_REQUIRED;
                        }

                        if (model.Client.PIC.NoHandphone == null || model.Client.PIC.Name == null || model.Client.PIC.Email == null ||
                            model.Client.PIC.NoHandphone == string.Empty || model.Client.PIC.Name == string.Empty || model.Client.PIC.Email == string.Empty)
                        {
                            throw ErrorConstant.CLIENT_PIC_REQUIRED;
                        }

                        client = new PICRequest
                        {
                            Email = model.Client.PIC.Email,
                            Name = model.Client.PIC.Name,
                            NoHandphone = model.Client.PIC.NoHandphone,
                        };
                    }
                    else
                    {
                        client = new PICRequest
                        {
                            Email = clientData.PICEmail,
                            Name = clientData.PICName,
                            NoHandphone = clientData.PICPhone,
                        };
                    }
                }

                _iLogger.LogInformation("Trying to validate Project Code..");
                if (await _iStorage.GetRepository<IProjectDetailRepository>().IsRegisteredByProjectKey(model.Key))
                {
                    throw ErrorConstant.CONFLICT_PROJECT_KEY;
                }

                _iLogger.LogInformation("Trying to get InitState..");
                var initState = _configuration.GetSection("InitState").Get<List<string>>();
                _iLogger.LogInformation("Trying to validate initState..");
                if (!initState.Any(u => u == model.InitState))
                {
                    throw ErrorConstant.INIT_STATE_NOT_FOUND;
                }

                _iLogger.LogInformation("Trying to fetching Status data..");
                var status = _configuration.GetSection("StatusProject").Get<List<StatusDto>>();
                var defaultStatus = status.Where(u => u.IsDefaultInitStatus).Select(u => u.Name).FirstOrDefault();
                _iLogger.LogInformation("Trying to validate status..");

                if (model.Status != null && !status.Where(u => u.IsInitStatus == true).Select(u => u.Name).Any(u => u == model.Status))
                {
                    throw ErrorConstant.STATUS_NOT_FOUND;
                }

                // code no yet implementation becuase feature need to integration with other dev(Yuda)
                _iLogger.LogInformation("Trying to fetching Technology data..");
                var technology = await _iStorage.GetRepository<ITechnologyRepository>().GetData();
                if (model.Technologies?.Count > 0)
                {
                    foreach (var tech in model.Technologies)
                    {
                        if (!technology.Select(u => u.Name).Any(u => u == tech))
                        {
                            var newTechnology = new Technology()
                            {
                                Name = tech,
                            };

                            await _iStorage.GetRepository<ITechnologyRepository>().AddOrUpdate(newTechnology);
                        }
                    }
                }

                _iLogger.LogInformation("Trying to fetching Development data..");
                var developmentRoles = await _iStorage.GetRepository<IDevelopmentRoleRepository>().GetListMapLevel();
                _iLogger.LogInformation("Trying to validate resouces..");
                var resouces = model.Resources.Select(u => u.DevelopmentRoles).ToList();
                if (resouces != null)
                {
                    foreach (var resouce in resouces)
                    {
                        if (!developmentRoles.Any(u => u == resouce))
                        {
                            throw ErrorConstant.RESOURCE_NOT_FOUND;
                        }
                    }
                }

                _iLogger.LogInformation("Trying to get TypeOfCoorporation..");
                var typeOfCoorporation = _configuration.GetSection("TypeOfCoorporation").Get<List<string>>();
                _iLogger.LogInformation("Trying to validate TypeOfCoorporation..");
                if (!typeOfCoorporation.Any(u => u == model.TypeOfCorporation))
                {
                    throw ErrorConstant.TYPE_OF_COORPORATION_NOT_FOUND;
                }

                var codeProjectResult = string.Empty;
                var currentYear = DateTime.Now.Year;

                _iLogger.LogInformation("Trying to get last data project detail..");
                var lastData = await _iStorage.GetRepository<IProjectDetailRepository>().GetCodeAtLastData();
                if (lastData == null || lastData == string.Empty)
                {
                    codeProjectResult = String.Concat(currentYear.ToString().Substring(2, 2), "01");
                }
                else
                {
                    int noProject = Int16.Parse(lastData.Substring(2, 2)) + 1;
                    codeProjectResult = String.Concat(currentYear.ToString().Substring(2, 2), noProject.ToString("00"));
                }

                var data = new ProjectDetail
                {
                    Code = codeProjectResult,
                    ClientId = model.Client?.Id,
                    PICEmail = client?.Email,
                    PICName = client?.Name,
                    PICPhone = client?.NoHandphone,
                    Key = model.Key,
                    Name = model.Name,
                    InitState = model.InitState,
                    TypeOfCoorporation = model.TypeOfCorporation,
                    Status = model.Status != null ? model.Status : defaultStatus,
                    ShortDescription = model.ShortDescription,
                    Description = model.Description,
                    Technology = JsonConvert.SerializeObject(model.Technologies),
                };

                _iLogger.LogInformation("Trying to saved project detail...");
                await _iStorage.GetRepository<IProjectDetailRepository>().AddOrUpdate(data);
                await _iStorage.SaveAsync();

                _iLogger.LogInformation($"Project detail has been created data");
                _iLogger.LogInformation("Trying to saved project resources...");
                foreach (var resource in model.Resources)
                {
                    var resourceSplit = resource.DevelopmentRoles.Split(' ');
                    var resourceLevel = resourceSplit.Last();
                    var level = _configuration.GetSection("Level").Get<List<string>>();
                    if (level.Any(u => u == resourceLevel))
                    {
                        var resourceRole = String.Join(" ", resourceSplit.Take(resourceSplit.Count() - 1));
                        _iLogger.LogInformation("Trying to fetching Development data..");
                        var developmentRole = await _iStorage.GetRepository<IDevelopmentRoleRepository>().FindByName(resourceRole);

                        await _iStorage.GetRepository<IProjectResourceRepository>().AddOrUpdate(new ProjectResources
                        {
                            ProjectId = data.Id,
                            RoleId = developmentRole.Id,
                            Level = resourceLevel,
                            Qty = resource.Quantity,
                        });
                        await _iStorage.SaveAsync();
                        _iLogger.LogInformation("Trying to saved Project Resouces...");
                    }
                    else
                    {
                        _iLogger.LogInformation("Trying to fetching Development data..");
                        var developmentRole = await _iStorage.GetRepository<IDevelopmentRoleRepository>().FindByName(resource.DevelopmentRoles);
                        await _iStorage.GetRepository<IProjectResourceRepository>().AddOrUpdate(new ProjectResources
                        {
                            ProjectId = data.Id,
                            RoleId = developmentRole.Id,
                            Level = null,
                            Qty = resource.Quantity,
                        });
                        await _iStorage.SaveAsync();
                        _iLogger.LogInformation("Trying to saved Project Resouces...");
                    }
                }

                var projectHistory = new ProjectHistory()
                {
                    ProjectId = data.Id,
                    Status = data.Status,
                };

                await _iStorage.GetRepository<IProjectHistoryRepository>().AddData(projectHistory);
                await _iStorage.SaveAsync();

                // send notification to client
                _iLogger.LogInformation($"Create notification");

                await SendProjectNotification(data.Id, model.Name, userId, null, AppConstant.AddNewProject);

                return new MessageDto(Infrastructure.Constants.Codes.CREATED, "Created", null, SuccessConstant.CREATED_PROJECT_DETAIL, _iMapper.Map<ProjectDetailDto>(data));
            }
            catch (Infrastructure.Exceptions.BadRequestException ex)
            {
                _iLogger.LogInformation($"Failed to created project detail, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> EditData(EditProjectDetailRequest model)
        {
            try
            {
                _iLogger.LogInformation("Trying to get client data by id..");
                if (model == null)
                {
                    throw new Infrastructure.Exceptions.BadRequestException();
                }

                _iLogger.LogInformation("Trying to get Project Detail data by id..");
                var project = await _iStorage.GetRepository<IProjectDetailRepository>().FindById(model.Id);

                if (project == null)
                {
                    throw ErrorConstant.PROJECT_NOT_FOUND;
                }

                PICRequest client = null;
                if (model.Client != null)
                {
                    var clientData = await _iStorage.GetRepository<IClientRepository>().GetDataById(model.Client.Id);

                    if (clientData == null)
                    {
                        throw ErrorConstant.NOT_FOUND_CLIENT;
                    }

                    if (!model.Client.IsRegisteredPIC)
                    {
                        if (model.Client.PIC == null)
                        {
                            throw ErrorConstant.CLIENT_PIC_REQUIRED;
                        }

                        if (model.Client.PIC.NoHandphone == null || model.Client.PIC.Name == null || model.Client.PIC.Email == null ||
                            model.Client.PIC.NoHandphone == string.Empty || model.Client.PIC.Name == string.Empty || model.Client.PIC.Email == string.Empty)
                        {
                            throw ErrorConstant.CLIENT_PIC_REQUIRED;
                        }

                        client = new PICRequest
                        {
                            Email = model.Client.PIC.Email,
                            Name = model.Client.PIC.Name,
                            NoHandphone = model.Client.PIC.NoHandphone,
                        };
                    }
                    else
                    {
                        client = new PICRequest
                        {
                            Email = clientData.PICEmail,
                            Name = clientData.PICName,
                            NoHandphone = clientData.PICPhone,
                        };
                    }
                }

                _iLogger.LogInformation("Trying to validate Project Code..");
                if (project.Key != model.Key)
                {
                    if (await _iStorage.GetRepository<IProjectDetailRepository>().IsRegisteredByProjectKey(model.Key))
                    {
                        throw ErrorConstant.CONFLICT_PROJECT_KEY;
                    }
                }

                _iLogger.LogInformation("Trying to get InitState..");
                var initState = _configuration.GetSection("InitState").Get<List<string>>();
                _iLogger.LogInformation("Trying to validate initState..");
                if (!initState.Any(u => u == model.InitState))
                {
                    throw ErrorConstant.INIT_STATE_NOT_FOUND;
                }

                _iLogger.LogInformation("Trying to fetching Status data..");
                var status = _configuration.GetSection("StatusProject").Get<List<StatusDto>>();
                var defaultStatus = status.Where(u => u.IsDefaultInitStatus).Select(u => u.Name).FirstOrDefault();
                _iLogger.LogInformation("Trying to validate status..");

                if (model.Status == null)
                {
                    throw ErrorConstant.STATUS_NOT_FOUND;
                }

                // code no yet implementation becuase feature need to integration with other dev(Yuda)
                _iLogger.LogInformation("Trying to fetching Technology data..");
                var technology = await _iStorage.GetRepository<ITechnologyRepository>().GetData();
                if (model.Technologies?.Count > 0)
                {
                    foreach (var tech in model.Technologies)
                    {
                        if (!technology.Select(u => u.Name).Any(u => u == tech))
                        {
                            var newTechnology = new Technology()
                            {
                                Name = tech,
                            };

                            await _iStorage.GetRepository<ITechnologyRepository>().AddOrUpdate(newTechnology);
                        }
                    }
                }

                _iLogger.LogInformation("Trying to fetching Development data..");
                var developmentRoles = await _iStorage.GetRepository<IDevelopmentRoleRepository>().GetListMapLevel();
                _iLogger.LogInformation("Trying to validate resouces..");
                var resouces = model.Resources.Select(u => u.DevelopmentRoles).ToList();
                if (resouces != null)
                {
                    foreach (var resouce in resouces)
                    {
                        if (!developmentRoles.Any(u => u == resouce))
                        {
                            throw ErrorConstant.RESOURCE_NOT_FOUND;
                        }
                    }
                }

                _iLogger.LogInformation("Trying to get TypeOfCoorporation..");
                var typeOfCoorporation = _configuration.GetSection("TypeOfCoorporation").Get<List<string>>();
                _iLogger.LogInformation("Trying to validate TypeOfCoorporation..");
                if (!typeOfCoorporation.Any(u => u == model.TypeOfCorporation))
                {
                    throw ErrorConstant.TYPE_OF_COORPORATION_NOT_FOUND;
                }

                var codeProjectResult = string.Empty;
                var currentYear = DateTime.Now.Year;

                project.ClientId = model.Client?.Id;
                project.PICEmail = client?.Email;
                project.PICName = client?.Name;
                project.PICPhone = client?.NoHandphone;
                project.Key = model.Key;
                project.Name = model.Name;
                project.InitState = model.InitState;
                project.TypeOfCoorporation = model.TypeOfCorporation;
                project.Status = model.Status != null ? model.Status : defaultStatus;
                project.ShortDescription = model.ShortDescription;
                project.Description = model.Description;
                project.Technology = JsonConvert.SerializeObject(model.Technologies);

                _iLogger.LogInformation("Trying to update project detail...");
                await _iStorage.GetRepository<IProjectDetailRepository>().AddOrUpdate(project);
                await _iStorage.SaveAsync();

                _iLogger.LogInformation($"Project detail has been updated data");
                _iLogger.LogInformation("Trying to update project resources...");
                foreach (var resource in model.Resources)
                {
                    var resourceSplit = resource.DevelopmentRoles.Split(' ');
                    var resourceLevel = resourceSplit.Last();
                    var level = _configuration.GetSection("Level").Get<List<string>>();
                    if (level.Any(u => u == resourceLevel))
                    {
                        var resourceRole = String.Join(" ", resourceSplit.Take(resourceSplit.Count() - 1));
                        _iLogger.LogInformation("Trying to fetching Development data..");
                        var developmentRole = await _iStorage.GetRepository<IDevelopmentRoleRepository>().FindByName(resourceRole);
                        var registeredProjectResource = await _iStorage.GetRepository<IProjectResourceRepository>().GetByName(project.Id, developmentRole.Name, resourceLevel);
                        if (registeredProjectResource != null)
                        {
                            await _iStorage.GetRepository<IProjectResourceRepository>().AddOrUpdate(new ProjectResources
                            {
                                Id = registeredProjectResource.Id,
                                ProjectId = project.Id,
                                RoleId = developmentRole.Id,
                                Level = resourceLevel,
                                Qty = resource.Quantity,
                            });
                            await _iStorage.SaveAsync();
                            _iLogger.LogInformation("Trying to updated or saved Project Resouces...");
                        }
                        else
                        {
                            await _iStorage.GetRepository<IProjectResourceRepository>().AddOrUpdate(new ProjectResources
                            {
                                ProjectId = project.Id,
                                RoleId = developmentRole.Id,
                                Level = resourceLevel,
                                Qty = resource.Quantity,
                            });
                            await _iStorage.SaveAsync();
                            _iLogger.LogInformation("Trying to updated or saved Project Resouces...");
                        }
                    }
                    else
                    {
                        _iLogger.LogInformation("Trying to fetching Development data..");
                        var developmentRole = await _iStorage.GetRepository<IDevelopmentRoleRepository>().FindByName(resource.DevelopmentRoles);
                        var registeredProjectResource = await _iStorage.GetRepository<IProjectResourceRepository>().GetByName(project.Id, developmentRole.Name, null);
                        if (registeredProjectResource != null)
                        {
                            await _iStorage.GetRepository<IProjectResourceRepository>().AddOrUpdate(new ProjectResources
                            {
                                Id = registeredProjectResource.Id,
                                ProjectId = project.Id,
                                RoleId = developmentRole.Id,
                                Level = null,
                                Qty = resource.Quantity,
                            });
                            await _iStorage.SaveAsync();
                            _iLogger.LogInformation("Trying to updated or saved Project Resouces...");
                        }
                        else
                        {
                            await _iStorage.GetRepository<IProjectResourceRepository>().AddOrUpdate(new ProjectResources
                            {
                                ProjectId = project.Id,
                                RoleId = developmentRole.Id,
                                Level = null,
                                Qty = resource.Quantity,
                            });
                            await _iStorage.SaveAsync();
                            _iLogger.LogInformation("Trying to updated or saved Project Resouces...");
                        }
                    }
                }

                _iLogger.LogInformation("Trying to validate project resources between db and current...");
                var registeredResources = await _iStorage.GetRepository<IProjectResourceRepository>().GetDataByProjectId(project.Id);
                foreach (var resourced in registeredResources)
                {
                    var developmentRole = String.Concat(resourced.DevelopmentRole.Name, " ", resourced.Level);
                    if (model.Resources.Where(u => u.DevelopmentRoles == developmentRole.Trim()).FirstOrDefault() == null)
                    {
                        _iLogger.LogInformation("Trying to delete project resources...");
                        if (!await _iStorage.GetRepository<IProjectResourceRepository>().DeleteById(resourced.Id))
                        {
                            throw ErrorConstant.PROJECT_RESOURCE_FAILED_TO_REMOVE;
                        }
                        else
                        {
                            await _iStorage.SaveAsync();
                            _iLogger.LogInformation("Trying to saved Project Resouces after deleted some data...");
                        }
                    }
                }

                return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Updated", null, SuccessConstant.UPDATE_PROJECT_DETAIL, _iMapper.Map<ProjectDetailDto>(project));
            }
            catch (Infrastructure.Exceptions.BadRequestException ex)
            {
                _iLogger.LogInformation($"Failed to update project detail, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> GetDataById(Guid id)
        {
            try
            {
                _iLogger.LogInformation("Trying to get Project Detail data by id..");
                var project = await _iStorage.GetRepository<IProjectDetailRepository>().FindById(id);

                if (project == null)
                {
                    throw ErrorConstant.PROJECT_NOT_FOUND;
                }

                var mapper = _iMapper.Map<ProjectDetailDto>(project);
                if (mapper.PICEmail == mapper.Client?.PICEmail &&
                    mapper.PICName == mapper.Client?.PICName &&
                    mapper.PICPhone == mapper.Client?.PICPhone)
                {
                    mapper.IsRegisteredPIC = true;
                }
                else
                {
                    mapper.IsRegisteredPIC = false;
                }

                return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_PROJECT_DETAIL, mapper);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to get project detail, err : {ex}");
                throw;
            }
        }

        public async Task<PaginatedResponses<ProjectListResponses>> GetPagedListProject(SieveModel sieveModel)
        {
            try
            {
                _iLogger.LogInformation("Getting data list client..");
                var projects = await _iStorage.GetRepository<IProjectDetailRepository>().GetData(true);
                var clients = await _iStorage.GetRepository<IClientRepository>().GetData(true);
                if (projects.Count() > 0)
                {
                    var datas = _iMapper.Map<List<ProjectDetail>, List<ProjectListResponses>>(projects.ToList());

                    datas.ForEach(d =>
                    {
                        d.ClientName = clients.Find(x => x.Id == d.ClientId)?.Name;
                        d.Address = clients.Find(x => x.Id == d.ClientId)?.Address;
                        d.DevelopmentPeriod = d.DevelopmentStart?.ToString("dd MMM yyyy") + " - " + d.DevelopmentEnd?.ToString("dd MMM yyyy");
                    });

                    var sieveData = _sieve.Apply(sieveModel, datas.AsQueryable());
                    var sieveAllData = _sieve.Apply(sieveModel, datas.AsQueryable(), applyPagination: false);
                    int count = sieveAllData.Count();

                    _iLogger.LogInformation($"Data has been fetched. with {count} data");

                    var result = new PaginatedResponses<ProjectListResponses>()
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
                    return new PaginatedResponses<ProjectListResponses>();
                }
            }
            catch (Exception ex)
            {
                throw new Infrastructure.Exceptions.BadRequestException();
            }
        }

        public async Task<MessageDto> UpdateStatus(UpdateStatusRequest model, Guid userId)
        {
            try
            {
                if (model == null)
                {
                    throw new Infrastructure.Exceptions.BadRequestException();
                }

                var actions = new List<string> { AppConstant.ActDeal, AppConstant.ActHold, AppConstant.ActClose, AppConstant.ActCancel,
                                                 AppConstant.ActReopen, AppConstant.ActContinue, AppConstant.ActDone };
                if (!actions.Any(u => u == model.Action))
                {
                    throw ErrorConstant.ACTION_NOT_REGISTERED;
                }

                _iLogger.LogInformation("Trying to get Project Detail data by id..");
                var project = await _iStorage.GetRepository<IProjectDetailRepository>().FindById(model.ProjectId);
                var projectHistories = await _iStorage.GetRepository<IProjectHistoryRepository>().GetbyProject(model.ProjectId);

                if (project == null)
                {
                    throw ErrorConstant.PROJECT_NOT_FOUND;
                }

                if (model.SPKUploads != null)
                {
                    if (model.SPKUploads.FileName != null)
                    {
                        var (data, type) = FileHelper.GetFileDetail(model.SPKUploads.Base64);
                        var fileSize = data.Length;
                        type = type == string.Empty ? "." + model.SPKUploads.FileExtension : type;

                        if (!Constants.FileConstant.ALLOWED_EXTENSION_SPK.Contains(type))
                        {
                            string msg = model.SPKUploads.FileName + type + " has invalid exception. Only " + Constants.FileConstant.ALLOWED_EXTENSION_SPK + " are allowed.";
                            var message = new MessageLangDto(null, msg);
                            throw new Infrastructure.Exceptions.BadRequestException(Codes.ERROR_TRANSACT, "Not Created", message);
                        }

                        if (fileSize > Constants.FileConstant.MAX_FILE_SIZE_SPK)
                        {
                            string msg = "Size of a request exceeds the file size limit.";
                            var message = new MessageLangDto(null, msg);
                            throw new PayloadTooLargeException(message);
                        }

                        model.SPKUploads.Data = data;
                        model.SPKUploads.FileExtension = type;
                    }
                }

                if (

                    // current status -> onchange status
                    // Prospect -> Cancelled, On Hold, Preparation
                    // Proposal Submitted -> Cancelled, Preparation, On Hold
                    // Maintenance -> Done
                    // Cancelled -> "Continue" Status back to last status before cancelled.
                    // On Hold -> "Reopen" Status back to last status before On Hold.
                    // Done -> Closed
                    (model.Action == AppConstant.ActDeal && (project.Status != AppConstant.ProposalSubmitted && project.Status != AppConstant.Prospect)) ||
                    (model.Action == AppConstant.ActHold && (project.Status != AppConstant.Prospect && project.Status != AppConstant.ProposalSubmitted && project.Status != AppConstant.Preparation && project.Status != AppConstant.InProgress)) ||
                    (model.Action == AppConstant.ActClose && (project.Status != AppConstant.Done && project.Status != AppConstant.Maintenance)) ||
                    (model.Action == AppConstant.ActCancel && (project.Status != AppConstant.Prospect && project.Status != AppConstant.ProposalSubmitted && project.Status != AppConstant.Preparation && project.Status != AppConstant.InProgress && project.Status != AppConstant.OnHold)) ||
                    (model.Action == AppConstant.ActReopen && (project.Status != AppConstant.OnHold)) ||
                    (model.Action == AppConstant.ActContinue && (project.Status != AppConstant.Canceled)) ||
                    (model.Action == AppConstant.ActDone && (project.Status != AppConstant.Maintenance && project.Status != AppConstant.InProgress)))
                {
                    throw ErrorConstant.ACTION_STATUS_FAILED_TO_CHANGE;
                }

                var newStatus = string.Empty;
                switch (model.Action)
                {
                    case AppConstant.ActDeal:
                        newStatus = project.DevelopmentStart <= DateTime.Now.Date ? AppConstant.InProgress : AppConstant.Preparation;
                        break;

                    case AppConstant.ActHold:
                        newStatus = AppConstant.OnHold;
                        break;

                    case AppConstant.ActContinue:
                        newStatus = projectHistories[projectHistories.Count - 2].Status;
                        break;

                    case AppConstant.ActClose:
                        newStatus = AppConstant.Closed;
                        break;

                    case AppConstant.ActCancel:
                        newStatus = AppConstant.Canceled;
                        break;

                    case AppConstant.ActReopen:
                        newStatus = projectHistories[projectHistories.Count - 2].Status;
                        break;

                    case AppConstant.ActDone:
                        newStatus = AppConstant.Done;
                        break;
                }

                var projectHistory = new ProjectHistory()
                {
                    ProjectId = model.ProjectId,
                    Status = newStatus,
                    Remark = model.Remark,
                };

                project.Status = newStatus;
                await _iStorage.GetRepository<IProjectDetailRepository>().AddOrUpdate(project);
                await _iStorage.GetRepository<IProjectHistoryRepository>().AddData(projectHistory);

                if (model.SPKNo != null)
                {
                    var newDirectory = Path.Combine(Directory.GetCurrentDirectory(), "media" + Path.DirectorySeparatorChar +"SPK");
                    if (!Directory.Exists(newDirectory))
                    {
                        Directory.CreateDirectory(newDirectory);
                    }

                    var fileName = DateTime.Now.ToString("yyyyMMddhhmmss") + "-" + model.SPKUploads.FileName;

                    var projectSPKData = _iMapper.Map<UpdateStatusRequest, ProjectSPK>(model);
                    if (projectSPKData != null)
                    {
                        projectSPKData.ProjectHistoryId = projectHistory.Id;
                        projectSPKData.FileNameOri = model.SPKUploads.FileName + model.SPKUploads.FileExtension;
                        projectSPKData.FileName = fileName + model.SPKUploads.FileExtension;
                        await _iStorage.GetRepository<IProjectSPKRepository>().AddData(projectSPKData);

                        File.WriteAllBytes(newDirectory + Path.DirectorySeparatorChar + fileName + model.SPKUploads.FileExtension, model.SPKUploads.Data);
                    }
                }

                await _iStorage.SaveAsync();

                // send notification to client
                var action = AppConstant.ChangeStatusProject.Replace("ProjectStatus", newStatus);
                await SendProjectNotification(model.ProjectId, project.Name, userId, null, action);

                return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Updated", null, SuccessConstant.UPDATE_PROJECT_DETAIL, model);
            }
            catch (Infrastructure.Exceptions.BadRequestException ex)
            {
                _iLogger.LogInformation($"Failed to update project status, err : {ex}");
                throw;
            }
        }

        public async Task CronJobUpdateStatus()
        {
            var updatedProject = await _iStorage.GetRepository<IProjectDetailRepository>().GetChangedStatusData();
            bool isStatusUpdated = false;
            if (updatedProject != null)
            {
                updatedProject.ToList().ForEach(async d =>
                {
                    if (DateTime.Now.Date >= d.DevelopmentEnd && DateTime.Now.Date <= d.MaintenanceEnd && d.Status != AppConstant.Maintenance)
                    {
                        if (d.Status != AppConstant.Maintenance)
                        {
                            d.Status = AppConstant.Maintenance;
                            var projectHistory = new ProjectHistory()
                            {
                                ProjectId = d.Id,
                                Status = d.Status,
                            };
                            d.ProjectHistories.Add(projectHistory);
                            isStatusUpdated = true;
                            await SendProjectNotification(d.Id, d.Name, null, d.Status, AppConstant.UpdateStatusProject);
                        }
                    }
                    else if (DateTime.Now.Date >= d.KickoffDate && DateTime.Now.Date <= d.DevelopmentEnd && d.Status != AppConstant.InProgress)
                    {
                            d.Status = AppConstant.InProgress;
                            var projectHistory = new ProjectHistory()
                            {
                                ProjectId = d.Id,
                                Status = d.Status,
                            };
                            d.ProjectHistories.Add(projectHistory);
                            isStatusUpdated = true;
                            await SendProjectNotification(d.Id, d.Name, null, d.Status, AppConstant.UpdateStatusProject);
                    }
                    else if (DateTime.Now.Date >= d.MaintenanceEnd && d.Status != AppConstant.Closed)
                    {
                        d.Status = AppConstant.Closed;
                        var projectHistory = new ProjectHistory()
                        {
                            ProjectId = d.Id,
                            Status = d.Status,
                        };
                        d.ProjectHistories.Add(projectHistory);
                        isStatusUpdated = true;
                        await SendProjectNotification(d.Id, d.Name, null, d.Status, AppConstant.UpdateStatusProject);
                    }

                    await _iStorage.GetRepository<IProjectDetailRepository>().AddOrUpdate(d);

                    d.ProjectHistories.ToList().ForEach(async ph =>
                    {
                        await _iStorage.GetRepository<IProjectHistoryRepository>().AddData(ph);
                    });
                });

                if (isStatusUpdated) await _iStorage.SaveAsync();
            }
        }

        private async Task SendProjectNotification(Guid projectId,string projectName, Guid? userId, string projectStatus, string action)
        {
            try
            {
                // send notification to client
                _iLogger.LogInformation($"Create notification");
                var message = string.Empty;
                var employe = new Employee { };
                if (userId != null)
                {
                    employe = await _iStorage.GetRepository<IEmployeeRepository>().GetDataByUserId((Guid)userId);
                    message = employe?.Fullname + action + projectName;
                }
                else
                {
                    message = projectName + action + projectStatus;
                }

                var notif = new Notification
                {
                    Message = message,
                    ProjectId = projectId,
                    EmployeeId = employe?.Id,
                };
                await _iStorage.GetRepository<INotificationRepository>().AddOrUpdate(notif);
                await _iStorage.SaveAsync();

                _iLogger.LogInformation($"Send notification to all client");
                await _notifHub.Clients.All.ReceiveMessage(new Notification
                {
                    Id = notif.Id,
                    Message = notif.Message,
                    ProjectId = notif.ProjectId,
                    EmployeeId = notif?.EmployeeId,
                });
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Send notification to all client failed with err: ", ex);
            }
        }
    }
}
