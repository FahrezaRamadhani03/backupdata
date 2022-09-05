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
    internal class StatusControllerTest
    {
        private IStatusServices _service;
        private StatusController _controller;

        [SetUp]
        public void Setup()
        {
            _service = Substitute.For<IStatusServices>();
            _controller = new StatusController(_service);
        }
        [Test]
        public async Task TestGetStatus()
        {
           
            _service.GetAllData()
                .Returns(Task.FromResult(new MessageDto(
                    Infrastructure.Constants.Codes.SUCCESS,
                    "Found",
                    null,
                    SuccessConstant.FOUND_STATUS,
                    null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.FOUND_STATUS,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Found",
                }));

            var ex = await _controller.GetDatas();
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.FOUND_STATUS, (value as MessageDto).MessageEng);
        }
    }
}
