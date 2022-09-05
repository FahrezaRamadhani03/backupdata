// <copyright file="DevelopmentInfoServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Contracts;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentInfo;
using Garuda.Modules.ProjectManagement.Dtos.Responses.DevelopmentSprint;
using Garuda.Modules.ProjectManagement.Hubs;
using Garuda.Modules.ProjectManagement.Hubs.Contracts;
using Garuda.Modules.ProjectManagement.Models.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Garuda.Modules.ProjectManagement.Services.Repositories
{
    public class DevelopmentInfoServices : IDevelopmentInfoServices
    {
        private readonly IStorage _iStorage;
        private readonly ILogger _iLogger;
        private readonly IMapper _iMapper;
        private readonly IConfiguration _iconfiguration;
        private readonly IHubContext<NotificationHub, INotificationHub> _notifHub;

        /// <summary>
        /// Initializes a new instance of the <see cref="DevelopmentInfoServices"/> class.
        /// </summary>
        /// <param name="iLogger"></param>
        /// <param name="iMapper"></param>
        /// <param name="iStorage"></param>
        /// <param name="iconfiguration"></param>
        public DevelopmentInfoServices(
           IStorage iStorage,
           ILogger<DevelopmentInfoServices> iLogger,
           IMapper iMapper,
           IConfiguration iconfiguration,
           IHubContext<NotificationHub, INotificationHub> notifHub)
        {
            _iStorage = iStorage;
            _iLogger = iLogger;
            _iMapper = iMapper;
            _iconfiguration = iconfiguration;
            _notifHub = notifHub;
        }

        public async Task<MessageDto> GetDayOfSprint()
        {
            try
            {
                _iLogger.LogInformation("Trying to fetching day of sprint data..");

                var datas = _iconfiguration.GetSection("DayOfSprint").Get<List<string>>();
                _iLogger.LogInformation($"Data has been fetch. with length {datas.Count} data");

                return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_DAY_OF_SPRINT, datas);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching day of sprint, err : {ex}");
                throw new BadRequestException();
            }
        }

        public async Task<MessageDto> GetHolidays()
        {
            try
            {
                _iLogger.LogInformation("Trying to fetching holidays data..");

                var datas = await _iStorage.GetRepository<IHolidayRepository>().GetList();
                _iLogger.LogInformation($"Data has been fetch. with length {datas.Count} data");

                return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_HOLIDAYS, datas.Select(u => new
                {
                    u.Description,
                    u.Date,
                }).ToList());
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching holidays, err : {ex}");
                throw new BadRequestException();
            }
        }

        public async Task<MessageDto> GetHolidays(DateTime start, DateTime end)
        {
            try
            {
                _iLogger.LogInformation("Trying to fetching holidays data..");

                var datas = await _iStorage.GetRepository<IHolidayRepository>().GetList(start, end);
                var result = _iMapper.Map<List<HolidayDto>>(datas);
                _iLogger.LogInformation($"Data has been fetch. with length {datas.Count} data");

                return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_HOLIDAYS, result);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching holidays, err : {ex}");
                throw new BadRequestException();
            }
        }

        public async Task<MessageDto> CreateData(CreateDevelopmentInfoRequest model, Guid userId)
        {
            try
            {
                if (model == null)
                {
                    throw new BadRequestException();
                }

                if (model.MaintenanceLength != 0 || model.MaintenanceEnd != null || model.MaintenanceStart != null || model.DevelopmentUnit != null)
                {
                    if (model.DevelopmentUnit == null)
                    {
                        throw ErrorConstant.DEVELOPMENT_UNIT_NULL;
                    }

                    if (model.MaintenanceLength == 0)
                    {
                        throw ErrorConstant.MAINTENANCE_LENGTH_NULL;
                    }

                    if (model.MaintenanceStart == null)
                    {
                        throw ErrorConstant.MAINTENANCE_START_NULL;
                    }

                    if (model.MaintenanceEnd == null)
                    {
                        throw ErrorConstant.MAINTENANCE_END_NULL;
                    }
                }

                _iLogger.LogInformation("Trying to get project data..");
                var registeredData = await _iStorage.GetRepository<IProjectDetailRepository>().FindById(model.ProjectId);
                if (registeredData == null)
                {
                    throw ErrorConstant.PROJECT_NOT_FOUND;
                }

                _iLogger.LogInformation("Trying to update project..");
                registeredData.DevelopmentMethod = model.DevelopmentMethod;
                registeredData.KickoffDate = model.KickoffDate;
                registeredData.DevelopmentStart = model.DevelopmentStart;
                registeredData.DevelopmentEnd = model.DevelopmentEnd;
                registeredData.MaintenanceLength = model.MaintenanceLength;
                registeredData.MaintenanceStart = model.MaintenanceStart;
                registeredData.MaintenanceEnd = model.MaintenanceEnd;
                registeredData.MaintenanceUnit = model.DevelopmentUnit;

                if (registeredData.KickoffDate != null && DateTime.Now >= registeredData.KickoffDate &&
                    (registeredData.Status == AppConstant.Prospect || registeredData.Status == AppConstant.ProposalSubmitted
                    || registeredData.Status == AppConstant.Preparation))
                {
                    registeredData.Status = AppConstant.InProgress;
                }

                await _iStorage.GetRepository<IProjectDetailRepository>().AddOrUpdate(registeredData);
                await _iStorage.SaveAsync();

                _iLogger.LogInformation($"Data has been updated");

                _iLogger.LogInformation($"Trying to save project status history");
                var projectHistory = new ProjectHistory()
                {
                    ProjectId = model.ProjectId,
                    Status = registeredData.Status,
                };

                await _iStorage.GetRepository<IProjectHistoryRepository>().AddData(projectHistory);
                await _iStorage.SaveAsync();
                _iLogger.LogInformation($"Project status history has been saved");

                _iLogger.LogInformation("Trying to save developmentScrum..");
                var developmentScrum = new DevelopmentScrum
                {
                    ProjectId = registeredData.Id,
                    Quantity = model.Quantity,
                    DaysInSprint = model.DayOfSprint,
                };
                await _iStorage.GetRepository<IDevelopmentScrumRepository>().AddOrUpdate(developmentScrum);
                await _iStorage.SaveAsync();

                _iLogger.LogInformation($"Data has been saved developmentScrum");
                _iLogger.LogInformation("Trying to save DevelopmentScrumSprint..");
                if (model.SprintDates != null && model.SprintDates.Count > 0)
                {
                    foreach (var sprint in model?.SprintDates)
                    {
                        var developmentScrumSprint = new DevelopmentScrumSprint
                        {
                            DevelopmentScrumId = developmentScrum.Id,
                            SprintStart = sprint.SprintStart,
                            SprintEnd = sprint.SprintEnd,
                            DayLength = sprint.DayLength,
                            HolidayLength = sprint.HolidayLength,
                            Sprintname = sprint.SprintName,
                            Remark = sprint.Remark,
                        };
                        await _iStorage.GetRepository<IDevelopmentScrumSprintRepository>().AddOrUpdate(developmentScrumSprint);
                        await _iStorage.SaveAsync();
                        _iLogger.LogInformation($"Data has been saved DevelopmentScrumSprint");
                        if (sprint.Holidays != null && sprint.Holidays.Count > 0)
                        {
                            foreach (var holiday in sprint.Holidays)
                            {
                                await _iStorage.GetRepository<IDevelopmentHolidayRepository>().AddOrUpdate(new DevelopmentHoliday
                                {
                                    ProjectId = registeredData.Id,
                                    DevelopmentScrumSprintId = developmentScrumSprint.Id,
                                    Description = holiday.Description,
                                    HolidayDate = holiday.Date,
                                });
                                await _iStorage.SaveAsync();
                                _iLogger.LogInformation($"Data has been saved DevelopmentScrumSprint");
                            }
                        }
                    }
                }

                // send notification to client
                _iLogger.LogInformation($"Create notification");
                var employe = await _iStorage.GetRepository<IEmployeeRepository>().GetDataByUserId(userId);
                var project = await _iStorage.GetRepository<IProjectDetailRepository>().GetById(model.ProjectId);
                var message = AppConstant.UserUpdateStatusProject;
                message = message.Replace("ProjectName", registeredData.Name);
                message = message.Replace("ProjectStatus", AppConstant.InProgress);
                message = message.Replace("EmployeeName", employe?.Fullname);

                var notif = new Notification
                {
                    Message = message,
                    ProjectId = model.ProjectId,
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

                return new MessageDto(Infrastructure.Constants.Codes.CREATED, "Created", null, SuccessConstant.CREATED_DEVELOPMENT_INFO, model);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to create a development info, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> EditData(EditDevelopmentInfoRequest model)
        {
            try
            {
                if (model == null)
                {
                    throw new BadRequestException();
                }

                if (model.MaintenanceLength != 0 || model.MaintenanceEnd != null || model.MaintenanceStart != null || model.DevelopmentUnit != null)
                {
                    if (model.DevelopmentUnit == null)
                    {
                        throw ErrorConstant.DEVELOPMENT_UNIT_NULL;
                    }

                    if (model.MaintenanceLength == 0)
                    {
                        throw ErrorConstant.MAINTENANCE_LENGTH_NULL;
                    }

                    if (model.MaintenanceStart == null)
                    {
                        throw ErrorConstant.MAINTENANCE_START_NULL;
                    }

                    if (model.MaintenanceEnd == null)
                    {
                        throw ErrorConstant.MAINTENANCE_END_NULL;
                    }
                }

                _iLogger.LogInformation("Trying to get project data..");
                var registeredData = await _iStorage.GetRepository<IProjectDetailRepository>().FindById(model.ProjectId);
                if (registeredData == null)
                {
                    throw ErrorConstant.PROJECT_NOT_FOUND;
                }

                _iLogger.LogInformation("Trying to update project..");
                registeredData.DevelopmentMethod = model.DevelopmentMethod;
                registeredData.KickoffDate = model.KickoffDate;
                registeredData.DevelopmentStart = model.DevelopmentStart;
                registeredData.DevelopmentEnd = model.DevelopmentEnd;
                registeredData.MaintenanceLength = model.MaintenanceLength;
                registeredData.MaintenanceStart = model.MaintenanceStart;
                registeredData.MaintenanceEnd = model.MaintenanceEnd;
                registeredData.MaintenanceUnit = model.DevelopmentUnit;

                if (registeredData.KickoffDate != null && DateTime.Now >= registeredData.KickoffDate &&
                   (registeredData.Status == AppConstant.Prospect || registeredData.Status == AppConstant.ProposalSubmitted
                   || registeredData.Status == AppConstant.Preparation))
                {
                    registeredData.Status = AppConstant.InProgress;
                }

                await _iStorage.GetRepository<IProjectDetailRepository>().AddOrUpdate(registeredData);
                await _iStorage.SaveAsync();

                _iLogger.LogInformation($"Data has been updated");

                _iLogger.LogInformation("Trying to get development Scrum data..");

                var developmentScrum = await _iStorage.GetRepository<IDevelopmentScrumRepository>().GetDataByProjectId(registeredData.Id);

                _iLogger.LogInformation("Trying to update developmentScrum..");
                await _iStorage.GetRepository<IDevelopmentScrumRepository>().AddOrUpdate(new DevelopmentScrum
                {
                    Id = developmentScrum.Id,
                    ProjectId = registeredData.Id,
                    Quantity = model.Quantity,
                    DaysInSprint = model.DayOfSprint,
                });
                await _iStorage.SaveAsync();
                _iLogger.LogInformation($"Development Scrum Data has been updated ");

                var registeredDevScrumSprint = await _iStorage.GetRepository<IDevelopmentScrumSprintRepository>().GetListByDevScrumId(developmentScrum.Id);
                foreach (var devScrumSprint in registeredDevScrumSprint)
                {
                    if (model.SprintDates.Where(u => u.Id != null && u.Id == devScrumSprint.Id).FirstOrDefault() == null)
                    {
                        _iLogger.LogInformation("Trying to delete development scrum sprint...");
                        if (!await _iStorage.GetRepository<IDevelopmentScrumSprintRepository>().DeleteById(devScrumSprint.Id))
                        {
                            _iLogger.LogInformation($"Development Scrum sprint failed to remove");
                            throw ErrorConstant.DEVELOPMENT_SCRUM_SPRINT_FAILED_TO_REMOVE;
                        }
                        else
                        {
                            _iLogger.LogInformation("Trying to saved development scrum sprint after deleted some data...");
                            await _iStorage.SaveAsync();
                            _iLogger.LogInformation($"Development Scrum sprint has been deleted");
                        }
                    }
                }

                _iLogger.LogInformation("Trying to save or update Development Scrum Sprint..");
                if (model.SprintDates != null && model.SprintDates.Count > 0)
                {
                    foreach (var sprint in model?.SprintDates)
                    {
                        _iLogger.LogInformation("Trying to add or update Development Scrum sprint...");
                        var developmentScrumSprint = await _iStorage.GetRepository<IDevelopmentScrumSprintRepository>().AddOrUpdate(new DevelopmentScrumSprint
                        {
                            Id = sprint.Id ?? new Guid(),
                            DevelopmentScrumId = developmentScrum.Id,
                            SprintStart = sprint.SprintStart,
                            SprintEnd = sprint.SprintEnd,
                            DayLength = sprint.DayLength,
                            HolidayLength = sprint.HolidayLength,
                            Sprintname = sprint.SprintName,
                            Remark = sprint.Remark,
                        });
                        await _iStorage.SaveAsync();
                        _iLogger.LogInformation($"Development Scrum Sprint has been updated Development Scrum Sprint");

                        var registeredHoliday = await _iStorage.GetRepository<IDevelopmentHolidayRepository>().GetListByDevelopmentScrumSprintId(developmentScrumSprint.Id);
                        foreach (var holiday in registeredHoliday)
                        {
                            if (sprint.Holidays.Where(u => u.Id != null && u.Id == holiday.Id).FirstOrDefault() == null)
                            {
                                _iLogger.LogInformation("Trying to delete holiday scrum sprint...");
                                if (!await _iStorage.GetRepository<IDevelopmentHolidayRepository>().DeleteById(holiday.Id))
                                {
                                    _iLogger.LogInformation($"Holiday failed to remove");
                                    throw ErrorConstant.DEVELOPMENT_SCRUM_SPRINT_FAILED_TO_REMOVE;
                                }
                                else
                                {
                                    await _iStorage.SaveAsync();
                                    _iLogger.LogInformation("Trying to saved Holiday after deleted some data...");
                                }
                            }
                        }

                        if (sprint.Holidays != null && sprint.Holidays.Count > 0)
                        {
                            foreach (var holiday in sprint.Holidays)
                            {
                                _iLogger.LogInformation("Trying to save or update Holiday..");
                                await _iStorage.GetRepository<IDevelopmentHolidayRepository>().AddOrUpdate(new DevelopmentHoliday
                                {
                                    Id = holiday.Id,
                                    ProjectId = registeredData.Id,
                                    DevelopmentScrumSprintId = developmentScrumSprint.Id,
                                    Description = holiday.Description,
                                    HolidayDate = holiday.Date,
                                });
                                await _iStorage.SaveAsync();
                                _iLogger.LogInformation($"Holiday Data has been updated");
                            }
                        }
                    }
                }

                return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Updated", null, SuccessConstant.UPDATE_DEVELOPMENT_INFO, model);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to update a development info, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> GetData(Guid id)
        {
            try
            {
                if (id == null || id == default(Guid))
                {
                    throw new BadRequestException();
                }

                _iLogger.LogInformation("Trying to get project data..");
                var project = await _iStorage.GetRepository<IProjectDetailRepository>().GetDevelopmentInfoByProjectId(id);
                if (project == null)
                {
                    throw ErrorConstant.PROJECT_NOT_FOUND;
                }

                return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_DEVELOPMENT_INFO, _iMapper.Map<DevelopmentInfoDto>(project));
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to get a development info, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> GetSprintList(Guid projectId)
        {
            try
            {
                _iLogger.LogInformation("Trying to fetching sprint data..");

                var datas = await _iStorage.GetRepository<IDevelopmentScrumRepository>().GetDataSprintByProject(projectId);
                var sprintList = new List<SprintListResponses>();
                if (datas != null)
                {
                    foreach (var devScrumSprints in datas.DevelopmentScrumSprints)
                    {
                        var culture = new System.Globalization.CultureInfo("id-ID");
                        var holidays = await _iStorage.GetRepository<IDevelopmentHolidayRepository>().GetListByDevelopmentScrumSprintId(devScrumSprints.Id);
                        var holidayString = string.Empty;

                        foreach (var holiday in holidays)
                        {
                            holidayString += holidayString == string.Empty ? holiday.HolidayDate.ToString("dd MMM yyyy") : "," + holiday.HolidayDate.ToString("dd MMM yyyy");
                        }

                        var sprintData = new SprintListResponses()
                        {
                            Id = devScrumSprints.Id,
                            SprintName = devScrumSprints.IsExtendDays == false ? "Sprint " + devScrumSprints.Sprintname : devScrumSprints.Sprintname,
                            SprintStart = devScrumSprints.SprintStart.ToString("dd MMM yyyy"),
                            SprintEnd = devScrumSprints.SprintEnd.ToString("dd MMM yyyy"),
                            StartDay = culture.DateTimeFormat.GetDayName(devScrumSprints.SprintStart.DayOfWeek),
                            EndDay = culture.DateTimeFormat.GetDayName(devScrumSprints.SprintEnd.DayOfWeek),
                            Holidays = holidayString,
                            TotalWorkDay = devScrumSprints.DayLength - devScrumSprints.HolidayLength,
                            TotalHoliday = devScrumSprints.HolidayLength,
                            Duration = devScrumSprints.DayLength,
                            Remark = devScrumSprints.Remark,
                            Holiday = _iMapper.Map<List<HolidayDto>>(holidays),
                        };
                        sprintList.Add(sprintData);
                    }
                }
                else
                {
                    throw ErrorConstant.SPRINT_LIST_DATA_NOT_FOUND;
                }

                return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_SPRINT_LIST, sprintList);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to fetching sprint list, err : {ex}");
                throw new BadRequestException();
            }
        }

        public async Task<MessageDto> AddExtendDays(AddExtendDaysRequest model)
        {
            try
            {
                if (model == null)
                {
                    throw new BadRequestException();
                }

                _iLogger.LogInformation("Trying to get development Scrum data..");

                // Get development scrum from database
                var developmentScrum = await _iStorage.GetRepository<IDevelopmentScrumRepository>().GetDataByProjectId(model.ProjectId);
                if (developmentScrum == null)
                {
                    throw ErrorConstant.DEVELOPMENT_SCRUM_NOT_FOUND;
                }

                // Check project has registered
                if (!await _iStorage.GetRepository<IProjectDetailRepository>().IsRegisteredById(model.ProjectId))
                {
                    throw ErrorConstant.PROJECT_NOT_FOUND;
                }
                else
                {
                    _iLogger.LogInformation("Trying to get last sprint Scrum data..");
                    var lastSprintDate = await _iStorage.GetRepository<IDevelopmentScrumSprintRepository>().GetLastSprintDate(developmentScrum.Id);
                    double increaseDay = 0;
                    if (lastSprintDate == null)
                    {
                        throw ErrorConstant.SPRINT_LIST_DATA_NOT_FOUND;
                    }
                    else
                    {
                        // check sprint start date
                        // check next day is weekend or not
                        // if a date is on weekend increase day by day to on weekday
                        if (lastSprintDate.AddDays(1).DayOfWeek == DayOfWeek.Saturday)
                        {
                            lastSprintDate = lastSprintDate.AddDays(3);
                        }
                        else if (lastSprintDate.AddDays(1).DayOfWeek == DayOfWeek.Sunday)
                        {
                            lastSprintDate = lastSprintDate.AddDays(2);
                        }
                        else
                        {
                            lastSprintDate = lastSprintDate.AddDays(1);
                        }

                        // check sprint end
                        // get result increase day
                        for (int i = 1; i <= model.Days - 1; i++)
                        {
                            if (lastSprintDate.AddDays(i).DayOfWeek == DayOfWeek.Saturday ||
                                lastSprintDate.AddDays(i).DayOfWeek == DayOfWeek.Sunday)
                            {
                                increaseDay++;
                            }
                        }
                    }

                    var developmentScrumSprint = new DevelopmentScrumSprint
                    {
                        DevelopmentScrumId = developmentScrum.Id,
                        DayLength = model.Days,
                        Sprintname = model.Descriptions,
                        SprintStart = lastSprintDate,
                        SprintEnd = lastSprintDate.AddDays(increaseDay + model.Days - 1),
                        IsExtendDays = true,
                    };

                    _iLogger.LogInformation("Trying to save Development Scrum Sprint data..");

                    await _iStorage.GetRepository<IDevelopmentScrumSprintRepository>().AddOrUpdate(developmentScrumSprint);
                    await _iStorage.SaveAsync();

                    return new MessageDto(Infrastructure.Constants.Codes.CREATED, "Created", null, SuccessConstant.CREATE_EXTEND_DAYS, developmentScrumSprint);
                }

            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to save extend days sprint, err : {ex}");
                throw;
            }
        }

        public async Task<MessageDto> EditSprint(EditSprintRequest model, Guid id)
        {
            try
            {
                if (model == null)
                {
                    throw new BadRequestException();
                }

                _iLogger.LogInformation("Trying to get development Scrum data..");

                var developmentScrum = await _iStorage.GetRepository<IDevelopmentScrumRepository>().GetDataByProjectId(model.ProjectId);
                if (developmentScrum == null)
                {
                    throw ErrorConstant.DEVELOPMENT_SCRUM_NOT_FOUND;
                }

                if (!await _iStorage.GetRepository<IProjectDetailRepository>().IsRegisteredById(model.ProjectId))
                {
                    throw ErrorConstant.PROJECT_NOT_FOUND;
                }
                else
                {
                    _iLogger.LogInformation("Trying to get last sprint Scrum data..");
                    var lastSprintDate = await _iStorage.GetRepository<IDevelopmentScrumSprintRepository>().GetLastSprintDate(developmentScrum.Id);
                    if (lastSprintDate == null)
                    {
                        throw ErrorConstant.SPRINT_LIST_DATA_NOT_FOUND;
                    }

                    var developmentScrumSprint = new DevelopmentScrumSprint
                    {
                        Id = id,
                        DevelopmentScrumId = developmentScrum.Id,
                        SprintStart = model.SprintStart,
                        SprintEnd = model.SprintEnd,
                        Remark = model.Remarks,
                        DayLength = model.DayLength,
                        HolidayLength = model.HolidayLength,
                    };

                    _iLogger.LogInformation("Trying to save Development Scrum Sprint data..");

                    await _iStorage.GetRepository<IDevelopmentScrumSprintRepository>().AddOrUpdate(developmentScrumSprint);
                    await _iStorage.SaveAsync();

                    var registeredHoliday = await _iStorage.GetRepository<IDevelopmentHolidayRepository>().GetListByDevelopmentScrumSprintId(developmentScrumSprint.Id);
                    foreach (var holiday in registeredHoliday)
                    {
                        if (model.Holidays.Where(u => u.Id != null && u.Id == holiday.Id).FirstOrDefault() == null)
                        {
                            _iLogger.LogInformation("Trying to delete holiday scrum sprint...");
                            if (!await _iStorage.GetRepository<IDevelopmentHolidayRepository>().DeleteById(holiday.Id))
                            {
                                _iLogger.LogInformation($"Holiday failed to remove");
                                throw ErrorConstant.DEVELOPMENT_SCRUM_SPRINT_FAILED_TO_REMOVE;
                            }
                            else
                            {
                                await _iStorage.SaveAsync();
                                _iLogger.LogInformation("Trying to saved Holiday after deleted some data...");
                            }
                        }
                    }

                    if (model.Holidays != null && model.Holidays.Count > 0)
                    {
                        foreach (var holiday in model.Holidays)
                        {
                            _iLogger.LogInformation("Trying to save or update Holiday..");
                            await _iStorage.GetRepository<IDevelopmentHolidayRepository>().AddOrUpdate(new DevelopmentHoliday
                            {
                                Id = holiday.Id,
                                ProjectId = model.ProjectId,
                                DevelopmentScrumSprintId = developmentScrumSprint.Id,
                                Description = holiday.Description,
                                HolidayDate = holiday.Date,
                            });
                            await _iStorage.SaveAsync();
                            _iLogger.LogInformation($"Holiday Data has been updated");
                        }
                    }

                    return new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Updated", null, SuccessConstant.UPDATED_SPRINT_DAYS, developmentScrumSprint);
                }
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to update sprint, err : {ex}");
                throw;
            }
        }
    }
}
