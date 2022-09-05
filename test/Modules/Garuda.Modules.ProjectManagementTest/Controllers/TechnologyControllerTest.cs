// <copyright file="TechnologyControllerTest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Controllers;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Technology;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Technology;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;

namespace Garuda.Modules.ProjectManagementTest.Controllers
{
    internal class TechnologyControllerTest
    {
        private ITechnologyServices _service;
        private TechnologyController _controller;

        [SetUp]
        public void Setup()
        {
            _service = Substitute.For<ITechnologyServices>();
            _controller = new TechnologyController(_service);
        }

        [Test]
        public async Task TestGetTechnologyAsync()
        {
            List<TechnologyResponses> _technologies = new List<TechnologyResponses>()
            {
                new TechnologyResponses
                {
                    Id = Guid.Parse("750d9ece-91b3-4a07-bd46-57f293d76441"),
                    Name = "Vue",
                },
                new TechnologyResponses
                {
                    Id = Guid.Parse("020c7ba0-f677-4367-9f0f-dcafdc4f885a"),
                    Name = "Node Js",
                },
                new TechnologyResponses
                {
                    Id = Guid.Parse("88fd5a36-96b1-4fa8-8b03-c1f4289b101d"),
                    Name = "React",
                },
            };

            _service.GetListTechnology()
                .Returns(Task.FromResult(new MessageDto(200, "Found", null, SuccessConstant.FOUND_TECHNOLOGIES, _technologies)
                {
                    Title = "Found",
                    Status = 200,
                    MessageIdn = null,
                    MessageEng = SuccessConstant.FOUND_TECHNOLOGIES,
                    Data = _technologies,
                }));

            var ex = await _controller.GetListTechnology();
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            var convert = (value as MessageDto).Data as List<TechnologyResponses>;
            Assert.AreEqual(3, convert.Count());
        }

        [Test]
        public async Task TestAddTechnologyAsync()
        {
            var technology = new Technology()
            {
                Id = Guid.Parse("af95003e-b31c-4904-bfe8-c315c1d2b805"),
                Name = "Test TechName",
                CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                CreatedBy = null,
                DeletedBy = null,
                UpdatedBy = null,
            };

            var newTech = new CreateTechnologyRequests
            {
                Name = "Test TechName"
            };

            _service.CreateTechnology(newTech)
                .Returns(Task.FromResult(new MessageDto(201, "Created", null, "New technology has been created", technology)
                {
                    Title = "Created",
                    Status = 201,
                    MessageIdn = null,
                    MessageEng = "New technology has been created",
                    Data = technology,
                }));

            var ex = await _controller.CreateTechnology(newTech);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            var convert = (value as MessageDto).Data as Technology;
            Assert.AreEqual(newTech.Name, convert.Name);
        }

        [Test]
        public async Task TestAddTechnologySuccess()
        {
            var technology = new Technology()
            {
                Id = Guid.Parse("af95003e-b31c-4904-bfe8-c315c1d2b805"),
                Name = "Test TechName",
                CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                CreatedBy = null,
                DeletedBy = null,
                UpdatedBy = null,
            };

            var newTech = new CreateTechnologyRequests
            {
                Name = "Test TechName"
            };

            _service.CreateTechnology(newTech)
                .Returns(Task.FromResult(new MessageDto(201, "Created", null, "New technology has been created", technology)
                {
                    Title = "Created",
                    Status = 201,
                    MessageIdn = null,
                    MessageEng = "New technology has been created",
                    Data = technology,
                }));

            var ex = await _controller.CreateTechnology(newTech);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual("Created", (value as MessageDto).Title);
        }
    }
}
