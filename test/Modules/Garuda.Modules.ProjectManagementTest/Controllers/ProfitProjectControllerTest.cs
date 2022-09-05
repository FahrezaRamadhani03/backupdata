
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
    internal class ProfitProjectControllerTest
    {
        private IProfitProjectServices _service;
        private ProfitProjectController _controller;

        [SetUp]
        public void Setup()
        {
            _service = Substitute.For<IProfitProjectServices>();
            _controller = new ProfitProjectController(_service);
        }

        [Test]
        public async Task TestGetData()
        {
            var sieveModel = new SieveModel();
            var year = 2022;
            _service.GetDatas(sieveModel, year)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_PROJECT, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.FOUND_PROFIT,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Found",
                }));

            var ex = await _controller.GetDatas(sieveModel, year);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.FOUND_PROFIT, (value as MessageDto).MessageEng);
        }
    }
}
