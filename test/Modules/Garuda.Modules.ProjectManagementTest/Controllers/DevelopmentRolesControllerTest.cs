using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Controllers;
using Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentRole;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;

namespace Garuda.Modules.ProjectManagementTest.Controllers
{
    internal class DevelopmentRolesControllerTest
    {
        private IDevelopmentRoleService _service;
        private DevelopmentRolesController _controller;
        private CreateDevelopmentRoleRequest _createDevelopmetRoleRequest;

        [SetUp]
        public void Setup()
        {
            _service = Substitute.For<IDevelopmentRoleService>();
            _controller = new DevelopmentRolesController(_service);
        }

        [Test]
        public async Task TestGetDevelopmentRoles()
        {

            _service.GetAllData()
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_DEVELOPMENT_ROLES, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.FOUND_DEVELOPMENT_ROLES,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Found",
                }));

            var ex = await _controller.GetDatas();
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.FOUND_DEVELOPMENT_ROLES, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestAddDevelopmentRoles()
        {
            _createDevelopmetRoleRequest = new CreateDevelopmentRoleRequest()
            {
                Code = "HK",
                Leader = false,
                Name = "Hacker",
            };

            _service.CreateData(_createDevelopmetRoleRequest)
                 .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.CREATED, "Created", null, SuccessConstant.CREATED_DEVELOPMENT_ROLES, _createDevelopmetRoleRequest)
                 {
                     Data = _createDevelopmetRoleRequest,
                     MessageEng = SuccessConstant.CREATED_DEVELOPMENT_ROLES,
                     MessageIdn = null,
                     Status = Infrastructure.Constants.Codes.CREATED,
                     Title = "Created",
                 }));

            var ex = await _controller.CreateData(_createDevelopmetRoleRequest);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.CREATED_DEVELOPMENT_ROLES, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestEditDevelopmentRoles()
        {
            Guid id = Guid.NewGuid();
            _createDevelopmetRoleRequest = new CreateDevelopmentRoleRequest()
            {
                Code = "HKED",
                Leader = false,
                Name = "Hacker Edit",
            };

            _service.UpdateData(id, _createDevelopmetRoleRequest)
                 .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Updated", null, SuccessConstant.UPDATED_DEVELOPMENT_ROLE, _createDevelopmetRoleRequest)
                 {
                     Data = _createDevelopmetRoleRequest,
                     MessageEng = SuccessConstant.UPDATED_DEVELOPMENT_ROLE,
                     MessageIdn = null,
                     Status = Infrastructure.Constants.Codes.SUCCESS,
                     Title = "Updated",
                 }));

            var ex = await _controller.UpdateData(id, _createDevelopmetRoleRequest);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.UPDATED_DEVELOPMENT_ROLE, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestDeleteDevelopmentRoles()
        {
            Guid id = Guid.NewGuid();
            _service.Delete(id)
                .Returns(Task.FromResult(new MessageDto("Data has been deleted.")
                {
                    Title = string.Empty,
                    MessageEng = "Data has been deleted.",
                }));

            var ex = await _controller.Delete(id);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual("Data has been deleted.", (value as MessageDto).MessageEng);
        }
    }
}
