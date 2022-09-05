// <copyright file="ProjectDevelopmentTeamServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;
using Garuda.Modules.Email.Contracts;
using Garuda.Modules.Email.Models.Contracts;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Dtos;
using Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentTeam;
using Garuda.Modules.ProjectManagement.Dtos.Responses.ProjectDevelopmentTeam;
using Garuda.Modules.ProjectManagement.Models.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;
using MimeKit.Utils;
using Sieve.Services;

namespace Garuda.Modules.ProjectManagement.Services.Repositories
{
    public class ProjectDevelopmentTeamServices : IProjectDevelopmentTeamServices
    {
        private readonly IStorage _iStorage;
        private readonly ILogger _iLogger;
        private readonly IMapper _iMapper;
        private readonly SieveProcessor _sieve;
        private readonly IConfiguration _config;
        private readonly IEmailSender _emailSender;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectDevelopmentTeamServices"/> class.
        /// </summary>
        /// <param name="iStorage"></param>
        /// <param name="iLogger"></param>
        /// <param name="iMapper"></param>
        /// <param name="sieve"></param>
        /// <param name="config"></param>
        /// <param name="emailSender"></param>
        public ProjectDevelopmentTeamServices(
            IStorage iStorage,
            ILogger<ProjectDevelopmentTeamServices> iLogger,
            IMapper iMapper,
            SieveProcessor sieve,
            IConfiguration config,
            IEmailSender emailSender)
        {
            _iStorage = iStorage;
            _iLogger = iLogger;
            _iMapper = iMapper;
            _sieve = sieve;
            _config = config;
            _emailSender = emailSender;
        }

        public async Task<MessageDto> CreateProjectDevelopmentTeam(CreateProjectDevelopmentTeamRequest model)
        {
            try
            {
                _iLogger.LogInformation("Saving new development team to database..");
                var scrumMaster = new ProjectScrumTeam()
                {

                    ProjectId = model.ProjectId,
                    SmDeveloperId = model.ScrumMasterId,
                    PoDeveloper = model.ProjectOwner,
                };
                await _iStorage.GetRepository<IProjectScrumTeamRepository>().AddOrUpdate(scrumMaster);

                foreach (var data in model.DevelopmentTeams)
                {
                    if (data.Status != "DELETE")
                    {
                        var developer = await _iStorage.GetRepository<IDeveloperRepository>().GetDataByEmployeeId(data.EmployeeId);
                        if (developer == null)
                        {
                            developer = _iMapper.Map<Developer>(data);
                            await _iStorage.GetRepository<IDeveloperRepository>().AddOrUpdate(developer);
                        }

                        var developmentTeam = _iMapper.Map<DevelopmentTeamRequest, ProjectDevelopmentTeam>(data);
                        developmentTeam.DeveloperId = developer.Id;
                        developmentTeam.ProjectId = model.ProjectId;
                        await _iStorage.GetRepository<IProjectDevelopmentTeamRepository>().AddOrUpdate(developmentTeam);

                        foreach (var role in data.DevelopmentTeamRoleRequests)
                        {
                            var newDeveloperRole = new DeveloperRole()
                            {
                                DeveloperId = developer.Id,
                                RoleId = role.RoleId,
                                LevelId = role.LevelId,
                            };

                            var developerRole = await _iStorage.GetRepository<IDeveloperRoleRepository>().FindById(newDeveloperRole);
                            if (developerRole == null)
                            {
                                await _iStorage.GetRepository<IDeveloperRoleRepository>().AddOrUpdate(newDeveloperRole);

                                var developmentTeamRole = new DevelopmentTeamRole()
                                {
                                    DevelopmentTeamId = developmentTeam.Id,
                                    DeveloperRoleId = newDeveloperRole.Id,
                                };

                                await _iStorage.GetRepository<IDevelopmentTeamRoleRepository>().AddOrUpdate(developmentTeamRole);
                            }
                            else
                            {
                                var developmentTeamRole = new DevelopmentTeamRole()
                                {
                                    DevelopmentTeamId = developmentTeam.Id,
                                    DeveloperRoleId = developerRole.Id,
                                };

                                await _iStorage.GetRepository<IDevelopmentTeamRoleRepository>().AddOrUpdate(developmentTeamRole);
                            }
                        }
                    }
                    else
                    {
                        await _iStorage.GetRepository<IProjectDevelopmentTeamRepository>().Delete((Guid)data.Id);
                    }
                }

                await _iStorage.SaveAsync();

                await SendEmailToDeveloperAssignedToProject(
                    model.DevelopmentTeams.Where(u => u.Status != "DELETE")
                    .Select(u => u.EmployeeId).ToList(),
                    model.ProjectId);

                return new MessageDto("New development team has been created");
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

        public async Task<MessageDto> GetProjectDevelopmentTeamProjectId(Guid projectId)
        {
            try
            {
                _iLogger.LogInformation("Getting data list employee..");
                var project = await _iStorage.GetRepository<IProjectDetailRepository>().GetDevelopmentTeambyProjectId(projectId);
                if (project != null)
                {
                    var data = _iMapper.Map<ProjectDetail, ProjectDevelopmentTeamResponses>(project);
                    if (data.ProjectDevelopmentTeams.Count == 0)
                    {
                        return new MessageDto(Codes.NOT_FOUND, "Not Found", "Data Not Found", null, new ProjectDevelopmentTeamResponses());
                    }
                    _iLogger.LogInformation($"Data has been fetched. with data");
                    return new MessageDto(Codes.SUCCESS, "Found", "Project development teams is Found", null, data);
                }
                else
                {
                    return new MessageDto(Codes.NOT_FOUND, "Not Found", "Data Not Found", null, new ProjectDevelopmentTeamResponses());
                }
            }
            catch (Exception ex)
            {
                throw new BadRequestException();
            }
        }

        private async Task SendEmailToDeveloperAssignedToProject(List<Guid> employees, Guid projectId)
        {
            try
            {
                var project = await _iStorage.GetRepository<IProjectDetailRepository>().GetById(projectId);
                var template = await _iStorage.GetRepository<ITemplateEmailRepository>().GetData(AppConstant.DeveloperAssign);
                var logo = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Image" + Path.DirectorySeparatorChar + "logo-gik.png";
                var projectLink = _config.GetValue<string>("WebUrl") + "/view-project?id=" + projectId + "&code=" + project.Code;

                var builder = new BodyBuilder();
                var image = builder.LinkedResources.Add(logo);
                image.ContentId = MimeUtils.GenerateMessageId();

                foreach (var employee in employees)
                {
                    var recipient = await _iStorage.GetRepository<IEmployeeRepository>().GetData(employee);
                    var email_body = template.Body.Replace("#-link-#", projectLink)
                                     .Replace("#-logo-#", "cid:" + image.ContentId)
                                     .Replace("#-fullname-#", recipient.Fullname)
                                     .Replace("#-projectName-#", project.Name)
                                     .Replace("#-footer-#", template.Footer);
                    await _emailSender.SendEmailAsync(recipient.Email, AppConstant.DeveloperAssign, email_body, true, builder);
                }
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Send email failed, with error: ", ex);
            }
        }
    }
}
