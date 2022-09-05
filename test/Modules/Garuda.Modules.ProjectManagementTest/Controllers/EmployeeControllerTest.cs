// <copyright file="TechnologyControllerTest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.Common.Controllers;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Controllers;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Technology;
using Garuda.Modules.ProjectManagement.Dtos.Responses;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Technology;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using Sieve.Models;

namespace Garuda.Modules.ProjectManagementTest.Controllers
{
    internal class EmployeeControllerTest
    {
        private IEmployeeServices _service;
        private EmployeeController _controller;

        [SetUp]
        public void Setup()
        {
            _service = Substitute.For<IEmployeeServices>();
            _controller = new EmployeeController(_service);
        }

        [Test]
        public async Task TestGetEmployeeAsync()
        {
            var sieveModel = new SieveModel()
            {
                Filters = null,
                Page = null,
                PageSize = null,
                Sorts = null,
            };

            List<EmployeeResponses> _employee = new List<EmployeeResponses>()
            {
                new EmployeeResponses
                {
                    Id = Guid.Parse("7a9c61cb-0c5f-4603-a2dd-d87181367827"),
                    Fullname = "Sudang Sudrajat",
                    DeveloperRole = "Frontend Developer",
                    ProjectCount = 1,
                    Developers= new List<EmployeeProjectResponses>()
                    {
                        new EmployeeProjectResponses
                        {
                            Name = "IT Portofolio",
                            Status = "In Progress",
                            SprintStart = new DateTime(2022, 02, 23, 00, 00, 00, 000),
                            SprintEnd = new DateTime(2022, 03, 09, 00, 00, 00, 000),
                            DeveloperRoles = new List<DeveloperRoleResponses>()
                            {
                                new DeveloperRoleResponses
                                {
                                    Role = "FE",
                                    Level = "Middle"
                                },
                                new DeveloperRoleResponses
                                {
                                    Role = "BE",
                                    Level = "Junior"
                                }
                            }
                        },
                        new EmployeeProjectResponses
                        {
                            Name = "POC/Research",
                            Status = "Maintenance",
                            SprintStart = new DateTime(2022, 02, 23, 00, 00, 00, 000),
                            SprintEnd = new DateTime(2022, 03, 09, 00, 00, 00, 000),
                            DeveloperRoles = new List<DeveloperRoleResponses>()
                            {
                                new DeveloperRoleResponses
                                {
                                    Role = "BE",
                                    Level = "Middle"
                                },
                                new DeveloperRoleResponses
                                {
                                    Role = "FE",
                                    Level = "Junior"
                                }
                            }
                        }
                    }
                },
                new EmployeeResponses
                {
                    Id = Guid.Parse("eac05bfa-b430-4d36-a1fa-ad533f1f50e5"),
                    Fullname = "Dadang Sudrajat",
                    DeveloperRole = "Backend Developer",
                    ProjectCount = 1,
                    Developers = new List<EmployeeProjectResponses>()
                    {
                        new EmployeeProjectResponses
                        {
                            Name = "IT Portofolio",
                            Status = "In Progress",
                            SprintStart = new DateTime(2022, 02, 23, 00, 00, 00, 000),
                            SprintEnd = new DateTime(2022, 03, 09, 00, 00, 00, 000),
                            DeveloperRoles = new List<DeveloperRoleResponses>()
                            {
                                new DeveloperRoleResponses
                                {
                                    Role = "FE",
                                    Level = "Middle"
                                },
                                new DeveloperRoleResponses
                                {
                                    Role = "BE",
                                    Level = "Junior"
                                }
                            }
                        },
                        new EmployeeProjectResponses
                        {
                            Name = "POC/Research",
                            Status = "Maintenance",
                            SprintStart = new DateTime(2022, 02, 23, 00, 00, 00, 000),
                            SprintEnd = new DateTime(2022, 03, 09, 00, 00, 00, 000),
                            DeveloperRoles = new List<DeveloperRoleResponses>()
                            {
                                new DeveloperRoleResponses
                                {
                                    Role = "BE",
                                    Level = "Middle"
                                },
                                new DeveloperRoleResponses
                                {
                                    Role = "FE",
                                    Level = "Junior"
                                }
                            }
                        }
                    }
                },
            };

            _service.GetListEmployeeWithDevelopmentRole(sieveModel)
                .Returns(Task.FromResult(new MessageDto(200, "Found", null, SuccessConstant.FOUND_TECHNOLOGIES, _employee)
                {
                    Title = "Found",
                    Status = 200,
                    MessageIdn = null,
                    MessageEng = SuccessConstant.FOUND_TECHNOLOGIES,
                    Data = _employee,
                }));

            var ex = await _controller.GetListEmployeeWithDevelopmentRole(sieveModel);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            var convert = (value as MessageDto).Data as List<EmployeeResponses>;
            Assert.AreEqual(2, convert.Count());
        }

        [Test]
        public async Task TestGetListEmployeeForScrumTeamAsync()
        {
            var sieveModel = new SieveModel()
            {
                Filters = null,
                Page = null,
                PageSize = null,
                Sorts = null,
            };

            List<EmployeeScrumResponses> _employee = new List<EmployeeScrumResponses>()
            {
                new EmployeeScrumResponses
                {
                    Id = Guid.Parse("7a9c61cb-0c5f-4603-a2dd-d87181367827"),
                    Fullname = "Sudang Sudrajat",
                    EmployeeId = Guid.Parse("d7454768-a544-4b68-abc6-1e5693363182"),
                    ClientId = null
                },
                new EmployeeScrumResponses
                {
                    Id = Guid.Parse("eac05bfa-b430-4d36-a1fa-ad533f1f50e5"),
                    Fullname = "Dadang Sudrajat",
                    EmployeeId = null,
                    ClientId = 1
                },
            };

            _service.GetListEmployeeForScrumTeam(sieveModel, 1)
                .Returns(Task.FromResult(new MessageDto(200, "Found", null, SuccessConstant.FOUND_TECHNOLOGIES, _employee)
                {
                    Title = "Found",
                    Status = 200,
                    MessageIdn = null,
                    MessageEng = SuccessConstant.FOUND_TECHNOLOGIES,
                    Data = _employee,
                }));

            var ex = await _controller.GetListEmployeeForScrumTeam(sieveModel, 1);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            var convert = (value as MessageDto).Data as List<EmployeeScrumResponses>;
            Assert.AreEqual(2, convert.Count());
        }
    }
}
