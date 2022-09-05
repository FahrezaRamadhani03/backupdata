
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Controllers;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;

namespace Garuda.Modules.ProjectManagementTest.Controllers
{
    internal class DashboardControllerTest
    {
        private IDashboardServices _service;
        private DashboardController _controller;

        [SetUp]
        public void Setup()
        {
            _service = Substitute.For<IDashboardServices>();
            _controller = new DashboardController(_service);
        }
        [Test]
        public async Task TestGetRecentProject()
        {

            _service.GetRecentProject()
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_RECENT_PROJECT, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.FOUND_RECENT_PROJECT,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Found",
                }));

            var ex = await _controller.GetRecentProject();
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.FOUND_RECENT_PROJECT, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestGetProjectCount()
        {

            _service.GetProjectSummary()
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_PROJECT_SUMMARY, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.FOUND_PROJECT_SUMMARY,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Found",
                }));

            var ex = await _controller.GetProjectSummary();
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.FOUND_PROJECT_SUMMARY, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestGetRecentProjectInvoice()
        {

            _service.GetRecentProjectInvoice()
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_RECENT_INVOICE, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.FOUND_RECENT_INVOICE,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Found",
                }));

            var ex = await _controller.GetRecentProjectInvoice();
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.FOUND_RECENT_INVOICE, (value as MessageDto).MessageEng);
        }
    }
}
