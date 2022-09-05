// <copyright file="TimelineServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.Common.Dtos.Responses;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Timeline;
using Garuda.Modules.ProjectManagement.Models.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sieve.Models;
using Sieve.Services;

namespace Garuda.Modules.ProjectManagement.Services.Repositories
{
    public class TimelineServices : ITimelineServices
    {
        private readonly IStorage _iStorage;
        private readonly ILogger _iLogger;
        private readonly IMapper _iMapper;
        private readonly IConfiguration _configuration;
        private readonly SieveProcessor _sieve;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimelineServices"/> class.
        /// </summary>
        /// <param name="iStorage"></param>
        /// <param name="iLogger"></param>
        /// <param name="iMapper"></param>
        /// <param name="iconfiguration"></param>
        public TimelineServices(
           IConfiguration iconfiguration,
           IStorage iStorage,
           ILogger<StatusServices> iLogger,
           IMapper iMapper,
           SieveProcessor sieve)
        {
            _configuration = iconfiguration;
            _iStorage = iStorage;
            _iLogger = iLogger;
            _iMapper = iMapper;
            _sieve = sieve;
        }

        public async Task<MessageDto> GetByEmployees(SieveModel model)
        {
            try
            {
                var developers = new List<DeveloperDto> { };
                var resultDate = GenerateWeek();

                // Find employee
                var employees = await _iStorage.GetRepository<IDeveloperRepository>().GetDataDevelopmentTeamAndProject();
                var datas = _iMapper.Map<List<Developer>, List<EmployeeSieveDto>>(employees.ToList());
                var result = _sieve.Apply(model, datas.AsQueryable(), applyPagination: false);

                foreach (var employee in result)
                {
                    foreach (var project in employee.ProjectDevelopmentTeams)
                    {
                        foreach (var projectDate in resultDate)
                        {
                            if (project.ProjectDetail.DevelopmentScrums.FirstOrDefault() != null)
                            {
                                foreach (var sprint in project.ProjectDetail.DevelopmentScrums.FirstOrDefault().DevelopmentScrumSprints)
                                {
                                    if (sprint.SprintStart.Date >= projectDate.StartDate.Date &&
                                    sprint.SprintEnd.Date <= projectDate.EndDate.Date)
                                    {
                                        var currentRole = project.DevelopmentTeamRoles.FirstOrDefault().DeveloperRole.DevelopmentRole.Name;
                                        if (developers.Where(u => u.UserId == employee.Id).FirstOrDefault() == null)
                                        {
                                            developers.Add(new DeveloperDto
                                            {
                                                UserId = employee.Id,
                                                Name = employee.Fullname,
                                                Projects = new List<ProjectDateDto>
                                                {
                                                    new ProjectDateDto
                                                    {
                                                        ProjectId = project.ProjectId,
                                                        EndDate = projectDate.EndDate,
                                                        StartDate = projectDate.StartDate,
                                                        ProjectName = project.ProjectDetail.Name,
                                                        Role = currentRole,
                                                        Status = project.ProjectDetail.Status,
                                                    },
                                                },
                                                Roles = new List<string> { currentRole },
                                            });
                                        }
                                        else
                                        {
                                            var index = developers.FindIndex(u => u.UserId == employee.Id);
                                            developers[index].Projects.Add(new ProjectDateDto
                                            {
                                                ProjectId = employee.ProjectDevelopmentTeams.FirstOrDefault().ProjectDetail.Id,
                                                EndDate = projectDate.EndDate,
                                                StartDate = projectDate.StartDate,
                                                ProjectName = employee.ProjectDevelopmentTeams.FirstOrDefault().ProjectDetail.Name,
                                                Role = currentRole,
                                                Status = project.ProjectDetail.Status,
                                            });
                                            developers[index].Roles.Add(currentRole);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // Mapping
                // To be Discussion with other dev
                var mapper = RemappingResultProject(developers);
                var finalResult = _sieve.Apply(model, mapper.AsQueryable(), applyPagination: false);
                var finalResultPagination = _sieve.Apply(model, mapper.AsQueryable());
                if (developers.Count() > 0 && model.Page != null && model.PageSize != null)
                {
                    _iLogger.LogInformation("Trying to map pagination..");
                    var count = finalResult.Count();
                    var response = new PaginatedResponses<TimelineProjectDto>()
                    {
                        Data = finalResultPagination.ToList(),
                        TotalData = count,
                        TotalPage = (int)Math.Ceiling((double)count / model.PageSize.Value),
                        CurrentPage = model.Page.Value,
                        PageSize = model.PageSize.Value,
                    };
                    return new MessageDto(Codes.SUCCESS, "Found", SuccessConstant.FOUND_TIMELINE, null, response);
                }
                else
                {
                    return new MessageDto(Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_TIMELINE, finalResult);
                }
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation("Failed to fetch timeline by employee, err: ", ex);
                throw;
            }
        }

        public async Task<MessageDto> GetByProjects(SieveModel model)
        {
            try
            {
                var projectTimelines = new List<ProjectTimelineDto> { };

                _iLogger.LogInformation("Trying to generate date..");
                var resultDate = GenerateWeek();

                _iLogger.LogInformation("Trying to get project data..");
                var projects = _iStorage.GetRepository<IProjectDetailRepository>().GetDataTimelineAsQueryable();

                var datas = _iMapper.Map<List<ProjectDetail>, List<ProjectSieveDto>>(projects.ToList());

                foreach (var project in datas)
                {
                    foreach (var date in resultDate)
                    {
                        // mapping base on preparation development
                        if (project.DevelopmentStart != null && project.DevelopmentEnd != null)
                        {
                            if ((project.CreatedDate >= date.StartDate && project.CreatedDate <= date.EndDate) ||
                                (project.DevelopmentStart >= date.StartDate && project.DevelopmentStart <= date.EndDate))
                            {
                                if (projectTimelines.Where(u => u.ProjectId == project.Id).FirstOrDefault() == null)
                                {
                                    projectTimelines.Add(new ProjectTimelineDto
                                    {
                                        ProjectId = project.Id,
                                        Name = project.Name,
                                        Dates = new List<TimelineDate>
                                            {
                                                new TimelineDate
                                                {
                                                    EndDate = date.EndDate,
                                                    StartDate = date.StartDate,
                                                    Status = AppConstant.Preparation,
                                                },
                                            },
                                        Sprints = new List<string> { },
                                        ClientName = project.ClientName,
                                        ClientId = project.ClientId,
                                    });
                                }
                                else
                                {
                                    var index = projectTimelines.FindIndex(u => u.ProjectId == project.Id);
                                    projectTimelines[index].Dates.Add(new TimelineDate
                                    {
                                        EndDate = date.EndDate,
                                        StartDate = date.StartDate,
                                        Status = AppConstant.Preparation,
                                    });
                                }
                            }
                        }

                        // mapping base on sprints development
                        if (project.DevelopmentScrums.FirstOrDefault() != null)
                        {
                            foreach (var sprint in project.DevelopmentScrums.FirstOrDefault().DevelopmentScrumSprints)
                            {
                                if (sprint.SprintStart >= date.StartDate &&
                                    sprint.SprintEnd <= date.EndDate)
                                {
                                    if (projectTimelines.Where(u => u.ProjectId == project.Id).FirstOrDefault() == null)
                                    {
                                        projectTimelines.Add(new ProjectTimelineDto
                                        {
                                            ProjectId = project.Id,
                                            Name = project.Name,
                                            Dates = new List<TimelineDate>
                                            {
                                                new TimelineDate
                                                {
                                                    EndDate = date.EndDate,
                                                    StartDate = date.StartDate,
                                                    SprintNo = string.Concat("Sprint ", sprint.Sprintname),
                                                    Status = AppConstant.InProgress,
                                                },
                                            },
                                            Sprints = new List<string>
                                            {
                                                string.Concat("Sprint ", sprint.Sprintname),
                                            },
                                            ClientName = project.ClientName,
                                            ClientId = project.ClientId,
                                        });
                                    }
                                    else
                                    {
                                        var index = projectTimelines.FindIndex(u => u.ProjectId == project.Id);
                                        projectTimelines[index].Dates.Add(new TimelineDate
                                        {
                                            EndDate = date.EndDate,
                                            StartDate = date.StartDate,
                                            SprintNo = string.Concat("Sprint ", sprint.Sprintname),
                                            Status = AppConstant.InProgress,
                                        });
                                        projectTimelines[index].Sprints.Add(string.Concat("Sprint ", sprint.Sprintname));
                                    }
                                }
                            }
                        }

                        //// mapping base on maintanance development
                        if ((project.MaintenanceStart >= date.StartDate && project.MaintenanceStart <= date.EndDate) ||
                               (project.MaintenanceEnd >= date.StartDate && project.MaintenanceEnd <= date.EndDate))
                        {
                            if (projectTimelines.Where(u => u.ProjectId == project.Id).FirstOrDefault() == null)
                            {
                                projectTimelines.Add(new ProjectTimelineDto
                                {
                                    ProjectId = project.Id,
                                    Name = project.Name,
                                    Dates = new List<TimelineDate>
                                            {
                                                new TimelineDate
                                                {
                                                    EndDate = date.EndDate,
                                                    StartDate = date.StartDate,
                                                    Status = AppConstant.Maintenance,
                                                },
                                            },
                                    Sprints = new List<string> { },
                                    ClientName = project.ClientName,
                                    ClientId = project.ClientId,
                                });
                            }
                            else
                            {
                                var index = projectTimelines.FindIndex(u => u.ProjectId == project.Id);
                                projectTimelines[index].Dates.Add(new TimelineDate
                                {
                                    EndDate = date.EndDate,
                                    StartDate = date.StartDate,
                                    Status = AppConstant.Maintenance,
                                });
                            }
                        }
                    }
                }

                var mapper = RemappingResultProject(projectTimelines.ToList());
                var finalResult = _sieve.Apply(model, mapper.AsQueryable(), applyPagination: false);
                var finalResultPagination = _sieve.Apply(model, finalResult.AsQueryable());
                if (projectTimelines.Count() > 0 && model.Page != null && model.PageSize != null)
                {
                    _iLogger.LogInformation("Trying to map pagination..");
                    var count = finalResultPagination.Count();
                    var response = new PaginatedResponses<TimelineProjectDto>()
                    {
                        Data = finalResultPagination.ToList(),
                        TotalData = count,
                        TotalPage = (int)Math.Ceiling((double)count / model.PageSize.Value),
                        CurrentPage = model.Page.Value,
                        PageSize = model.PageSize.Value,
                    };
                    return new MessageDto(Codes.SUCCESS, "Found", SuccessConstant.FOUND_TIMELINE, null, response);
                }
                else
                {
                    return new MessageDto(Codes.SUCCESS, "Found", "Timeline Found", null, finalResult);
                }
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation("Failed to fetch timeline by project: ", ex);
                throw;
            }
        }

        private List<TimelineDate> GenerateWeek()
        {
            var currentYear = DateTime.Now.Year;

            // Generate date range one year per week
            var date = new DateTime(currentYear, 01, 01);
            bool isEndYear = false;
            var firstDayOfWeek = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            var resultDate = new List<TimelineDate> { };
            while (!isEndYear)
            {
                if (date.DayOfWeek.ToString() == firstDayOfWeek.ToString())
                {
                    resultDate.Add(new TimelineDate { StartDate = date.Date, EndDate = date.AddDays(6) });
                    date = date.AddDays(7);
                }
                else
                {
                    date = date.AddDays(1);
                }

                if (date.Year != currentYear)
                {
                    isEndYear = true;
                }
            }

            return resultDate;
        }

        private List<TimelineProjectDto> RemappingResultProject(List<ProjectTimelineDto> projects)
        {
            var result = new List<TimelineProjectDto> { };
            int fakeId = 1;
            foreach (var project in projects)
            {
                var tempProject = new List<TimelineProjectDto>{ };
                var parentId = fakeId;
                tempProject.Add(new TimelineProjectDto
                {
                    Id = fakeId,
                    ProjectId = project.ProjectId,
                    Text = project.Name,
                    Start_date = project.Dates.FirstOrDefault().StartDate.ToString("yyyy-MM-dd"),
                    Duration = (project.Dates.LastOrDefault().EndDate - project.Dates.FirstOrDefault().StartDate).TotalDays,
                    Status = project.Dates.FirstOrDefault()?.Status,
                    StartDate = project.Dates.FirstOrDefault()?.StartDate,
                    EndDate = project.Dates.LastOrDefault()?.StartDate,
                    ProjectName = project.Name,
                    ClientId = project.ClientId,
                    ClientName = project.ClientName,
                });
                fakeId++;
                foreach (var sprint in project.Dates)
                {
                    tempProject.Add(new TimelineProjectDto
                    {
                        Id = fakeId,
                        ProjectId = project.ProjectId,
                        Text = sprint.SprintNo,
                        Start_date = sprint.StartDate.ToString("yyyy-MM-dd"),
                        EndDate = sprint.EndDate,
                        StartDate = sprint.StartDate,
                        Duration = (sprint.EndDate - sprint.StartDate).TotalDays,
                        Parent = parentId,
                        Status = sprint.Status,
                        Color = GetColorTimelineByStatus(sprint.Status),
                        ProjectName = project.Name,
                        ClientId = project.ClientId,
                        ClientName = project.ClientName,
                    });
                    fakeId++;
                }

                result.AddRange(tempProject);
            }

            return result;
        }

        private List<TimelineProjectDto> RemappingResultProject(List<DeveloperDto> developers)
        {
            var result = new List<TimelineProjectDto> { };
            int fakeId = 1;
            foreach (var developer in developers)
            {
                var tempProject = new List<TimelineProjectDto> { };
                var parentId = fakeId;
                tempProject.Add(new TimelineProjectDto
                {
                    Id = fakeId,
                    ProjectId = developer.UserId,
                    Text = developer.Name,
                    Start_date = developer.Projects.FirstOrDefault().StartDate.ToString("yyyy-MM-dd"),
                    Duration = (developer.Projects.LastOrDefault().EndDate - developer.Projects.FirstOrDefault().StartDate).TotalDays,
                    StartDate = developer.Projects.FirstOrDefault()?.StartDate,
                    EndDate = developer.Projects.LastOrDefault()?.StartDate,
                });
                fakeId++;
                foreach (var project in developer.Projects)
                {
                    tempProject.Add(new TimelineProjectDto
                    {
                        Id = fakeId,
                        ProjectId = project.ProjectId,
                        Text = project.ProjectName,
                        Start_date = project.StartDate.ToString("yyyy-MM-dd"),
                        EndDate = project.EndDate,
                        StartDate = project.StartDate,
                        Duration = (project.EndDate - project.StartDate).TotalDays,
                        Parent = parentId,
                        Status = project.Status,
                        Color = GetColorTimelineByStatus(project.Status),
                    });
                    fakeId++;

                    result.AddRange(tempProject);
                }
            }

            return result;
        }
        private string GetColorTimelineByStatus(string name)
        {
            var color = string.Empty;
            switch (name)
            {
                case AppConstant.InProgress:
                    color = AppConstant.InProgressColor;
                    break;
                case AppConstant.Preparation:
                    color = AppConstant.PreparationColor;
                    break;
                case AppConstant.Maintenance:
                    color = AppConstant.MaintananceColor;
                    break;
            }

            return color;
        }
    }
}
