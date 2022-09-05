using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Controllers;
using Garuda.Modules.ProjectManagement.Dtos.Requests.ProjectDetails;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using Sieve.Models;

namespace Garuda.Modules.ProjectManagementTest.Controllers
{
    internal class TimelineControllerTest
    {
        private ITimelineServices _service;
        private TimelineController _controller;

        [SetUp]
        public void Setup()
        {
            _service = Substitute.For<ITimelineServices>();
            _controller = new TimelineController(_service);
        }

        [Test]
        public async Task TestGetTimelineByProject()
        {
            var sieveModel = new SieveModel();
            sieveModel.Filters = "Name@=dota";
            _service.GetByProjects(sieveModel)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_TIMELINE, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.FOUND_TIMELINE,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Found",
                }));

            var ex = await _controller.GetByProjects(sieveModel);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.FOUND_TIMELINE, (value as MessageDto).MessageEng);
        }
    }
}
