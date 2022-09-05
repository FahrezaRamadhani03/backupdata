// <copyright file="BankControllerTest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Controllers;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Bank;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Bank;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;

namespace Garuda.Modules.ProjectManagementTest.Controllers
{
    internal class BankControllerTest
    {
        private IBankServices _service;
        private BankController _controller;

        [SetUp]
        public void Setup()
        {
            _service = Substitute.For<IBankServices>();
            _controller = new BankController(_service);
        }

        [Test]
        public async Task TestGetBankAsync()
        {
            List<BankResponses> _banks = new List<BankResponses>()
            {
                new BankResponses
                {
                    Id = Guid.Parse("750d9ece-91b3-4a07-bd46-57f293d76441"),
                    Code = "MDR",
                    Name = "PT. Bank Mandiri (Persero) Tbk.",
                },
                new BankResponses
                {
                    Id = Guid.Parse("020c7ba0-f677-4367-9f0f-dcafdc4f885a"),
                    Code = "BRI",
                    Name = "PT. Bank Rakyat Indonesia (Persero) Tbk.",
                },
                new BankResponses
                {
                    Id = Guid.Parse("88fd5a36-96b1-4fa8-8b03-c1f4289b101d"),
                    Code = "BCA",
                    Name = "PT. Bank Central Asia Tbk.",
                },
            };

            _service.GetListBank()
                .Returns(Task.FromResult(new MessageDto(200, "Found", null, SuccessConstant.FOUND_BANKS, _banks)
                {
                    Title = "Found",
                    Status = 200,
                    MessageIdn = null,
                    MessageEng = SuccessConstant.FOUND_BANKS,
                    Data = _banks,
                }));

            var ex = await _controller.GetListBank();
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            var convert = (value as MessageDto).Data as List<BankResponses>;
            Assert.AreEqual(3, convert.Count());
        }

        [Test]
        public async Task TestAddBankAsync()
        {
            var technology = new Technology()
            {
                Id = Guid.Parse("af95003e-b31c-4904-bfe8-c315c1d2b805"),
                Name = "Test Bank",
                CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                CreatedBy = null,
                DeletedBy = null,
                UpdatedBy = null,
            };

            var newBank = new CreateBankRequests
            {
                Code = "COD",
                Name = "Test Bank"
            };

            _service.CreateBank(newBank)
                .Returns(Task.FromResult(new MessageDto(201, "Created", null, "New bank has been created", technology)
                {
                    Title = "Created",
                    Status = 201,
                    MessageIdn = null,
                    MessageEng = "New bank has been created",
                    Data = technology,
                }));

            var ex = await _controller.CreateBank(newBank);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            var convert = (value as MessageDto).Data as Technology;
            Assert.AreEqual(newBank.Name, convert.Name);
        }
    }
}
