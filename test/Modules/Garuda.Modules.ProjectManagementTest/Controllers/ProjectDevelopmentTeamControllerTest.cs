// <copyright file="ProjectDevelopmentTeamControllerTest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Controllers;
using Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentTeam;
using Garuda.Modules.ProjectManagement.Dtos.Requests.PaymentTerm;
using Garuda.Modules.ProjectManagement.Dtos.Responses.ProjectDevelopmentTeam;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;

namespace Garuda.Modules.ProjectManagementTest.Controllers
{
    internal class ProjectDevelopmentTeamControllerTest
    {
        private IProjectDevelopmentTeamServices _service;
        private ProjectDevelopmentTeamController _controller;
        private CreateProjectDevelopmentTeamRequest _createProjectDevelopmentTeampRequest;

        [SetUp]
        public void Setup()
        {
            _service = Substitute.For<IProjectDevelopmentTeamServices>();
            _controller = new ProjectDevelopmentTeamController(_service);
        }

        [Test]
        public async Task TestAddProjectDevelopmentTeamAsync()
        {
            _createProjectDevelopmentTeampRequest = new CreateProjectDevelopmentTeamRequest
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
                        Status = "NEW",
                        DevelopmentTeamRoleRequests = new List<DevelopmentTeamRoleRequest>()
                        {
                            new DevelopmentTeamRoleRequest
                            {
                                RoleId = Guid.Parse("485ee5cb-a939-4b4f-b46e-34dc6d3956d6"),
                                LevelId = Guid.Parse("51ed6887-c40e-4c4b-b5c9-d09478b092bd")
                            }
                        }
                    },
                    new DevelopmentTeamRequest
                    {
                        Id = Guid.Parse("65237ded-9f0b-467c-99a4-5a8815d7ada3"),
                        EmployeeId = Guid.Parse("dfd147a5-f052-4ce9-81c3-047fcb31898b"),
                        Fullname = "Dadang Supratman",
                        ManADay = 1,
                        StartDate = new DateTime(2022, 04, 20, 00, 00, 00, 000),
                        EndDate = new DateTime(2022, 06, 20, 00, 00, 00, 000),
                        ManDays = 60,
                        IsLeader = true,
                        Status = "UPDATE",
                        DevelopmentTeamRoleRequests = new List<DevelopmentTeamRoleRequest>()
                        {
                            new DevelopmentTeamRoleRequest
                            {
                                RoleId = Guid.Parse("485ee5cb-a939-4b4f-b46e-34dc6d3956d6"),
                                LevelId = Guid.Parse("51ed6887-c40e-4c4b-b5c9-d09478b092bd")
                            }
                        }
                    },
                    new DevelopmentTeamRequest
                    {
                        Id = Guid.Parse("6e207d95-de21-4078-b260-9e57cbda2e31"),
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
                }
            };

            _service.CreateProjectDevelopmentTeam(_createProjectDevelopmentTeampRequest)
                .Returns(Task.FromResult(new MessageDto("New development team has been created")
                {
                    MessageEng = "New development team has been created",
                }));

            var ex = await _controller.CreateProjectDevelopmentTeam(_createProjectDevelopmentTeampRequest);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual("New development team has been created", (value as MessageDto).MessageEng);
        }

        [Test]
        public void TestAddProjectDevelopmentTeam_InvalidModel()
        {
            var newDevelopmentTeam = new CreateProjectDevelopmentTeamRequest();

            var context = new ValidationContext(newDevelopmentTeam, null, null);
            var results = new List<ValidationResult>();
            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(CreateProjectDevelopmentTeamRequest), typeof(CreateProjectDevelopmentTeamRequest)), typeof(CreateProjectDevelopmentTeamRequest));

            var isModelStateValid = Validator.TryValidateObject(newDevelopmentTeam, context, results, true);
            Assert.IsFalse(isModelStateValid);
        }

        [Test]
        public async Task TestGetProjectDevelopmentTeamAsync()
        {
            var id = Guid.Parse("750d9ece-91b3-4a07-bd46-57f293d76441");
            ProjectDevelopmentTeamResponses _projectDevelopmentTeams = new ProjectDevelopmentTeamResponses()
            {
                ProjectId = id,
                ProjectDevelopmentTeams = new List<DevelopmentTeamResponses>()
                {
                    new DevelopmentTeamResponses
                    {
                        Id = Guid.Parse("070173ab-743b-423b-9370-b88c3c839bcb"),
                        EmployeeId = Guid.Parse("6e207d95-de21-4078-b260-9e57cbda2e31"),
                        Fullname = "Dadang Sudrajat",
                        ManADay = 1,
                        StartDate = new DateTime(2022, 04, 20, 00, 00, 00, 000),
                        EndDate = new DateTime(2022, 06, 20, 00, 00, 00, 000),
                        ManDays = 60,
                        IsLeader = true,
                        DevelopmentTeamRoles = new List<DevelopmentTeamRoleResponses>()
                        {
                            new DevelopmentTeamRoleResponses
                            {
                                RoleId = Guid.Parse("070173ab-743b-423b-9370-b88c3c839bcb"),
                                RoleName = "Frontend",
                                LevelId = Guid.Parse("070173ab-743b-423b-9370-b88c3c839bcb"),
                                LevelName = "Middle"
                            }
                        }
                    },
                    new DevelopmentTeamResponses
                    {
                        Id = Guid.Parse("070173ab-743b-423b-9370-b88c3c839bcb"),
                        EmployeeId = Guid.Parse("6e207d95-de21-4078-b260-9e57cbda2e31"),
                        Fullname = "Didang Gumilang",
                        ManADay = 1,
                        StartDate = new DateTime(2022, 04, 20, 00, 00, 00, 000),
                        EndDate = new DateTime(2022, 06, 20, 00, 00, 00, 000),
                        ManDays = 60,
                        IsLeader = true,
                        DevelopmentTeamRoles = new List<DevelopmentTeamRoleResponses>()
                        {
                            new DevelopmentTeamRoleResponses
                            {
                                RoleId = Guid.Parse("070173ab-743b-423b-9370-b88c3c839bcb"),
                                RoleName = "Backend",
                                LevelId = Guid.Parse("070173ab-743b-423b-9370-b88c3c839bcb"),
                                LevelName = "Middle"
                            }
                        }
                    },
                }
            };

            _service.GetProjectDevelopmentTeamProjectId(id)
                .Returns(Task.FromResult(new MessageDto(200, "Found", null, "Payment terms is Found", _projectDevelopmentTeams)
                {
                    Title = "Found",
                    Status = 200,
                    MessageIdn = null,
                    MessageEng = "Payment terms is Found",
                    Data = _projectDevelopmentTeams,
                }));

            var ex = await _controller.GetProjectDevelopmentTeams(id);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            var convert = (value as MessageDto).Data as ProjectDevelopmentTeamResponses;
            Assert.AreEqual(2, convert.ProjectDevelopmentTeams.Count);
        }
    }
}
