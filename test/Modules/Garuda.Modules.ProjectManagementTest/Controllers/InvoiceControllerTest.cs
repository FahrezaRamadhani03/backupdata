// <copyright file="InvoiceControllerTest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Controllers;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Invoice;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Technology;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Invoice;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Technology;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using Sieve.Models;

namespace Garuda.Modules.ProjectManagementTest.Controllers
{
    internal class InvoiceControllerTest
    {
        private IInvoiceServices _service;
        private InvoiceController _controller;

        [SetUp]
        public void Setup()
        {
            _service = Substitute.For<IInvoiceServices>();
            _controller = new InvoiceController(_service);
        }

        [Test]
        public async Task TestGetAllInvoiceAsync()
        {
            List<ProjectInvoiceResponses> _invoice = new List<ProjectInvoiceResponses>()
            {
                new ProjectInvoiceResponses
                {
                    ClientCode= "himakom",
                    ProjectName= "dota",
                    ProjectKey= "ape",
                    ProjectAmount= 100000000,
                    QtyPaid= 0,
                    AmountPaid= 0,
                    QtyUnpaid= 1,
                    AmountUnpaid= 11000000,
                    QtyOverdue= 0,
                    AmountOverdue= 0,
                    Invoices= new List<ProjectInvoiceDetailResponses>()
                    {
                        new ProjectInvoiceDetailResponses()
                        {
                            Id= Guid.Parse("807781d0-deb0-4ed6-8043-a5f7b0f4e709"),
                            InvoiceNo= "INV-ape/01/GIK/V/2022",
                            ProjectId= Guid.Parse("24c92f0c-e6ef-4216-93b7-3b4d620d87ce"),
                            PaymentTermId= Guid.Parse("7395dabb-2390-4ee2-b45d-b46bd4abe578"),
                            InvoiceDate= new DateTime(2022, 05, 11, 01, 48, 59),
                            TotalPayment= 11000000,
                            Status= "Draft",
                            OverdueDate= new DateTime(2022, 05, 14, 01, 48, 59),
                            SubmitDate= new DateTime(2022, 05, 20, 08, 50, 38),
                            PaymentDate= null
                        }
                    }
                },
            };
            var sieveModel = new SieveModel();
            _service.GetAllList(sieveModel)
                .Returns(Task.FromResult(new MessageDto(200, "Found", null, SuccessConstant.FOUND_TECHNOLOGIES, _invoice)
                {
                    Title = "Found",
                    Status = 200,
                    MessageIdn = null,
                    MessageEng = SuccessConstant.FOUND_TECHNOLOGIES,
                    Data = _invoice,
                }));

            var ex = await _controller.GetAllList(sieveModel);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            var convert = (value as MessageDto).Data as List<ProjectInvoiceResponses>;
            Assert.AreEqual(1, convert.Count());
        }

        [Test]
        public async Task TestAddInvoiceAsync()
        {
            var newInvoice = new CreateInvoiceRequest()
            {
                Id = null,
                ProjectId = Guid.Parse("24c92f0c-e6ef-4216-93b7-3b4d620d87ce"),
                PaymentTermId = Guid.Parse("7395dabb-2390-4ee2-b45d-b46bd4abe578"),
                InvoiceDate = new DateTime(2022, 05, 11, 01, 48, 59),
                AdditionalNote = "String",
                OverdueLength = 3,
                OverdueUnit = "Days",
                ReminderDate = new DateTime(2022, 05, 11, 01, 48, 59),
                IsAdditionalDiscount = false,
                AdditionalDiscount = 0,
                Status = "Draft",
                InvoiceDetail = new List<InvoiceDetailRequest>()
                {
                    new InvoiceDetailRequest()
                    {
                        Id = null,
                        InvoiceId = null,
                        Description = "String",
                        Quantity = 1,
                        Price = 10000000,
                        Discount = 0,
                        Subtotal = 10000000
                    }
                },
                TaxDetail = new List<InvoiceTaxRequest>()
                {
                    new InvoiceTaxRequest()
                    {
                        TaxId = Guid.Parse("2a69de34-7b4a-4c92-8644-bd78182bb9c7"),
                        Rate = 10,
                        Amount = 1000000,
                    }
                }
            };

            _service.Create(newInvoice)
                .Returns(Task.FromResult(new MessageDto("Create or modified invoice success")
                {
                    MessageEng = "New payment term has been created",
                }));

            var ex = await _controller.Create(newInvoice);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual("New payment term has been created", (value as MessageDto).MessageEng);
        }
    }
}
