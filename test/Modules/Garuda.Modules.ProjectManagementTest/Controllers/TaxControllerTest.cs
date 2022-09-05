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
using Garuda.Modules.ProjectManagement.Dtos.Requests;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Tax;
using Garuda.Modules.ProjectManagement.Dtos.Responses;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using Sieve.Models;

namespace Garuda.Modules.ProjectManagementTest.Controllers
{
    internal class TaxControllerTest
    {
        private ITaxServices _service;
        private TaxController _controller;

        [SetUp]
        public void Setup()
        {
            _service = Substitute.For<ITaxServices>();
            _controller = new TaxController(_service);
        }

        [Test]
        public async Task TestGetTaxAsync()
        {
            List<TaxResponses> _technologies = new List<TaxResponses>()
            {
                new TaxResponses
                {
                    Id = Guid.Parse("750d9ece-91b3-4a07-bd46-57f293d76441"),
                    Name = "PPN",
                },
                new TaxResponses
                {
                    Id = Guid.Parse("020c7ba0-f677-4367-9f0f-dcafdc4f885a"),
                    Name = "PPh 23",
                },
            };
            var sieveModel = new SieveModel();

            _service.GetListTax(sieveModel)
                .Returns(Task.FromResult(new MessageDto(200, "Found", null, SuccessConstant.FOUND_TECHNOLOGIES, _technologies)
                {
                    Title = "Found",
                    Status = 200,
                    MessageIdn = null,
                    MessageEng = SuccessConstant.FOUND_TECHNOLOGIES,
                    Data = _technologies,
                }));

            var ex = await _controller.GetListTax(sieveModel);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            var convert = (value as MessageDto).Data as List<TaxResponses>;
            Assert.AreEqual(2, convert.Count());
        }

        [Test]
        public async Task TestPostTaxAsync()
        {

            var request = new TaxRequest
            {
                Name = "PPP",
                Rate = 20,
                IsActive = true,
                Code = "P",
            };
            _service.CreateData(request)
                .Returns(Task.FromResult(new MessageDto(201, "Created", null, SuccessConstant.CREATED_TAX, request)
                {
                    Title = "Found",
                    Status = 201,
                    MessageIdn = null,
                    MessageEng = SuccessConstant.CREATED_TAX,
                    Data = request,
                }));

            var ex = await _controller.CreateData(request);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.CREATED_TAX, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestEditTaxAsync()
        {

            var request = new TaxRequest
            {
                Name = "PPP",
                Rate = 20,
                IsActive = true,
                Code = "P",
            };
            var id = Guid.Parse("750d9ece-91b3-4a07-bd46-57f293d76441");
            _service.EditData(id, request)
                .Returns(Task.FromResult(new MessageDto(200, "Updated", null, SuccessConstant.UPDATED_TAX, request)
                {
                    Title = "Updated",
                    Status = 200,
                    MessageIdn = null,
                    MessageEng = SuccessConstant.UPDATED_TAX,
                    Data = request,
                }));

            var ex = await _controller.EditData(id, request);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.UPDATED_TAX, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestDeleteTaxAsync()
        {

            var id = Guid.Parse("750d9ece-91b3-4a07-bd46-57f293d76441");
            _service.DeleteData(id)
                .Returns(Task.FromResult(new MessageDto(200, "Deleted", null, SuccessConstant.REMOVE_TAX, null)
                {
                    Title = "Deleted",
                    Status = 200,
                    MessageIdn = null,
                    MessageEng = SuccessConstant.REMOVE_TAX,
                    Data = null,
                }));

            var ex = await _controller.DeleteData(id);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.REMOVE_TAX, (value as MessageDto).MessageEng);
        }
    }
}
