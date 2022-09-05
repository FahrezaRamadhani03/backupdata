
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Controllers;
using Garuda.Modules.ProjectManagement.Dtos.Requests.ProjectDetails;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using Sieve.Models;

namespace Garuda.Modules.ProjectManagementTest.Controllers
{
    internal class ProjectDetailControllerTest
    {
        private IProjectDetailServices _service;
        private ProjectManagementController _controller;
        private CreateProjectDetailRequest _createProjectDetailRequest;
        private ProjectDetail _getProjectDetailRequest;
        private EditProjectDetailRequest _editProjectDetailRequest;

        [SetUp]
        public void Setup()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "070173ab-743b-423b-9370-b88c3c839bcb"),
            }, "mock"));

            _service = Substitute.For<IProjectDetailServices>();
            _controller = new ProjectManagementController(_service);

            _controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };
        }

        [Test]
        public async Task TestGetProjectList()
        {
            var sieveModel = new SieveModel();
            sieveModel.Filters = "code@=Test";
            _service.GetData(sieveModel)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_PROJECT, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.FOUND_PROJECT,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Found",
                }));

            var ex = await _controller.GetData(sieveModel);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.FOUND_PROJECT, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestGetProjectShortInfo()
        {
            Guid projectId = Guid.Parse("cbaed6ce-4cfe-41ab-8763-4ba265b82890");
            _service.GetShortInfo(projectId)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_PROJECT, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.FOUND_PROJECT,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Found",
                }));

            var ex = await _controller.GetShortInfo(projectId);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.FOUND_PROJECT, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestAddProjectWithExisClientPIC()
        {
            _createProjectDetailRequest = new CreateProjectDetailRequest()
            {
                Client = new ClientRequest { Id = 1, IsRegisteredPIC = true },
                Name = "Test Case 1",
                Key = "TC-1",
                InitState = "New",
                Status = "New Project",
                ShortDescription = "Dota tiga short description",
                Description = "Dota Tiga Description",
                Technologies = new List<string> { "Vue", "React" },
                Resources = new List<ResourceRequest> { new ResourceRequest { DevelopmentRoles = "Project manager", Quantity = 1 } },
                TypeOfCorporation = "Software",
            };

            _service.CreateData(_createProjectDetailRequest, Guid.Parse("070173ab-743b-423b-9370-b88c3c839bcb"))
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.CREATED, "Created", null, SuccessConstant.CREATED_PROJECT_DETAIL, _createProjectDetailRequest)
                {
                    Data = _createProjectDetailRequest,
                    MessageEng = SuccessConstant.CREATED_PROJECT_DETAIL,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.CREATED,
                    Title = "Created",
                }));

            var ex = await _controller.CreateData(_createProjectDetailRequest);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.CREATED_PROJECT_DETAIL, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestAddProjectWithNewClientPic()
        {
            _createProjectDetailRequest = new CreateProjectDetailRequest()
            {
                Client = new ClientRequest { Id = 1, IsRegisteredPIC = false, PIC = new PICRequest { Email = "newPIC@gmail.com", Name = "Test New PIC", NoHandphone = "08886289689" } },
                Name = "Test Case 2",
                Key = "TC-2",
                InitState = "New",
                Status = "New Project",
                ShortDescription = "Dota tiga short description",
                Description = "Dota Tiga Description",
                Technologies = new List<string> { "Vue", "React" },
                Resources = new List<ResourceRequest> { new ResourceRequest { DevelopmentRoles = "Project manager", Quantity = 1 } },
                TypeOfCorporation = "Software",
            };

            _service.CreateData(_createProjectDetailRequest, Guid.Parse("070173ab-743b-423b-9370-b88c3c839bcb"))
                 .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.CREATED, "Created", null, SuccessConstant.CREATED_PROJECT_DETAIL, _createProjectDetailRequest)
                 {
                     Data = _createProjectDetailRequest,
                     MessageEng = SuccessConstant.CREATED_PROJECT_DETAIL,
                     MessageIdn = null,
                     Status = Infrastructure.Constants.Codes.CREATED,
                     Title = "Created",
                 }));

            var ex = await _controller.CreateData(_createProjectDetailRequest);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.CREATED_PROJECT_DETAIL, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestGetProjectById()
        {
            var id = Guid.Parse("070173ab-743b-423b-9370-b88c3c839bcb");
            _getProjectDetailRequest = new ProjectDetail()
            {
                Id = id,
                TypeOfCoorporation = "Software",
                ClientId = 2,
                Code = "2205",
                Name = "gensin",
                Key = "Gen",
                InitState = "New",
                Status = "New Project",
                ShortDescription = "test short des",
                Description = "test description",
                Technology = "Vue",
            };
            _service.GetDataById(id)
               .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_PROJECT_DETAIL, _getProjectDetailRequest)
               {
                   Data = _getProjectDetailRequest,
                   MessageEng = SuccessConstant.FOUND_PROJECT_DETAIL,
                   MessageIdn = null,
                   Status = Infrastructure.Constants.Codes.SUCCESS,
                   Title = "Found",
               }));

            var ex = await _controller.GetDataById(id);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.FOUND_PROJECT_DETAIL, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestEditProjectDetail()
        {
            _editProjectDetailRequest = new EditProjectDetailRequest()
            {
                Id = Guid.Parse("070173ab-743b-423b-9370-b88c3c839bcb"),
                Client = new ClientRequest { Id = 1, IsRegisteredPIC = true },
                Name = "Test Case 1",
                Key = "TC-1",
                InitState = "New",
                Status = "New Project",
                ShortDescription = "Dota tiga short description",
                Description = "Dota Tiga Description",
                Technologies = new List<string> { "Vue", "React" },
                Resources = new List<EditResourceRequest> { new EditResourceRequest { DevelopmentRoles = "Project manager", Quantity = 1 } },
                TypeOfCorporation = "Software",
            };

            _service.EditData(_editProjectDetailRequest)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Updated", null, SuccessConstant.UPDATE_PROJECT_DETAIL, _editProjectDetailRequest)
                {
                    Data = _editProjectDetailRequest,
                    MessageEng = SuccessConstant.UPDATE_PROJECT_DETAIL,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Updated",
                }));

            var ex = await _controller.EditData(_editProjectDetailRequest);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.UPDATE_PROJECT_DETAIL, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestUpdateProjectStatus()
        {
            var updateProjectStatusRequest = new UpdateStatusRequest()
            {
                ProjectId = Guid.Parse("d90a8359-67e7-4e47-b231-7b268ce897fe"),
                Action = "Hold",
                Remark = "Test",
                SPKNo = null,
                SPKDate = null,
                SPKUploads = null,
            };

            _service.UpdateStatus(updateProjectStatusRequest, Guid.Parse("070173ab-743b-423b-9370-b88c3c839bcb"))
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Updated", null, SuccessConstant.UPDATE_PROJECT_DETAIL, updateProjectStatusRequest)
                {
                    Data = updateProjectStatusRequest,
                    MessageEng = SuccessConstant.UPDATE_PROJECT_DETAIL,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Updated",
                }));

            var ex = await _controller.CreateStatusHistoryData(updateProjectStatusRequest);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.UPDATE_PROJECT_DETAIL, (value as MessageDto).MessageEng);
        }
    }
}
