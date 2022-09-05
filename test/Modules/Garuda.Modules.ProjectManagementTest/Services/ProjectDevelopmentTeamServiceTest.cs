// <copyright file="ProjectDevelopmentTeamServiceTest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;
using Garuda.Modules.Email.Contracts;
using Garuda.Modules.ProjectManagement.Controllers;
using Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentTeam;
using Garuda.Modules.ProjectManagement.Dtos.Requests.PaymentTerm;
using Garuda.Modules.ProjectManagement.Models.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Garuda.Modules.ProjectManagement.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSubstitute;
using NUnit.Framework;
using Sieve.Models;
using Sieve.Services;

namespace Garuda.Modules.ProjectManagementTest.Controllers
{
    internal class ProjectDevelopmentTeamServiceTest
    {
        private ProjectDevelopmentTeamServices _testClass;
        private IStorage _iStorage;
        private IMapper _mapper;
        private ILogger<ProjectDevelopmentTeamServices> _logger;
        private SieveProcessor _sieve;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _config;

        [SetUp]
        public void Setup()
        {
            _iStorage = Substitute.For<IStorage>();
            _mapper = Substitute.For<IMapper>();
            _logger = Substitute.For<ILogger<ProjectDevelopmentTeamServices>>();
            _sieve = new SieveProcessor(Substitute.For<IOptions<SieveOptions>>());
            _testClass = new ProjectDevelopmentTeamServices(_iStorage, _logger, _mapper, _sieve, _config, _emailSender);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new ProjectDevelopmentTeamServices(_iStorage, _logger, _mapper, _sieve, _config, _emailSender);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotCallCreateProjectDevelopmentTeamWithNullModel()
        {
            Assert.ThrowsAsync<BadRequestException>(() => 
                _testClass.CreateProjectDevelopmentTeam(default(CreateProjectDevelopmentTeamRequest)));
        }

        [Test]
        public void CanCallCreateProjectDevelopmentTeam()
        {
            // Arrange
            var model = new CreateProjectDevelopmentTeamRequest
            {
                ProjectId = Guid.Parse("61bb97e8-1af1-4130-ba44-8e50dae55fdf"),
                ScrumMasterId = Guid.Parse("3adf613e-ac2d-4c25-81fc-6060579e270a"),
                DevelopmentTeams = new List<DevelopmentTeamRequest>()
                {
                    new DevelopmentTeamRequest
                    {
                        EmployeeId = Guid.Parse("dfd147a5-f052-4ce9-81c3-047fcb31898b"),
                        Fullname = "Dadang Supratman",
                        ManADay = 1,
                        StartDate = new DateTime(2022, 04, 20, 00, 00, 00, 000),
                        EndDate = new DateTime(2022, 06, 20, 00, 00, 00, 000),
                        ManDays = 60,
                        IsLeader = true,
                        DevelopmentTeamRoleRequests = new List<DevelopmentTeamRoleRequest>()
                        {
                            new DevelopmentTeamRoleRequest
                            {
                                RoleId = Guid.Parse("485ee5cb-a939-4b4f-b46e-34dc6d3956d6"),
                                LevelId = Guid.Parse("51ed6887-c40e-4c4b-b5c9-d09478b092bd")
                            }
                        }
                    }
                },
            };

            // Act
            var result = _testClass.CreateProjectDevelopmentTeam(model)
                .Returns(Task.FromResult(new MessageDto("New development team has been created")
                {
                    MessageEng = "New development team has been created",
                }));

            // Assert
            Assert.IsNull(result);
            //Assert.Pass("Create or modify test");
        }

        [Test]
        public void CanCallDeleteProjectDevelopmentTeam()
        {
            // Arrange
            var model = new CreateProjectDevelopmentTeamRequest
            {
                ProjectId = Guid.Parse("61bb97e8-1af1-4130-ba44-8e50dae55fdf"),
                ScrumMasterId = Guid.Parse("3adf613e-ac2d-4c25-81fc-6060579e270a"),
                DevelopmentTeams = new List<DevelopmentTeamRequest>()
                {
                    new DevelopmentTeamRequest
                    {
                        Id = Guid.Parse("dfd147a5-f052-4ce9-81c3-047fcb31898b"),
                        EmployeeId = Guid.Parse("dfd147a5-f052-4ce9-81c3-047fcb31898b"),
                        Fullname = "Dadang Supratman",
                        ManADay = 1,
                        StartDate = new DateTime(2022, 04, 20, 00, 00, 00, 000),
                        EndDate = new DateTime(2022, 06, 20, 00, 00, 00, 000),
                        ManDays = 60,
                        IsLeader = true,
                        Status = "DELETE",
                        DevelopmentTeamRoleRequests = new List<DevelopmentTeamRoleRequest>()
                        {
                            new DevelopmentTeamRoleRequest
                            {
                                RoleId = Guid.Parse("485ee5cb-a939-4b4f-b46e-34dc6d3956d6"),
                                LevelId = Guid.Parse("51ed6887-c40e-4c4b-b5c9-d09478b092bd")
                            }
                        }
                    }
                },
            };

            // Act
            var result = _testClass.CreateProjectDevelopmentTeam(model)
                .Returns(Task.FromResult(new MessageDto("New development team has been created")
                {
                    MessageEng = "New development team has been created",
                }));

            // Assert
            Assert.Pass("Create or modify test");
        }
    }
}
