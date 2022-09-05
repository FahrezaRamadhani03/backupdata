// <copyright file="PaymentTermControllerTest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Controllers;
using Garuda.Modules.ProjectManagement.Dtos.Requests.PaymentTerm;
using Garuda.Modules.ProjectManagement.Dtos.Responses;
using Garuda.Modules.ProjectManagement.Dtos.Responses.PaymentTerm;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;

namespace Garuda.Modules.ProjectManagementTest.Controllers
{
    internal class PaymentTermControllerTest
    {
        private IPaymentTermServices _service;
        private PaymentTermController _controller;
        private CreatePaymentTermRequest _createPaymentTermpRequest;

        [SetUp]
        public void Setup()
        {
            _service = Substitute.For<IPaymentTermServices>();
            _controller = new PaymentTermController(_service);
        }

        [Test]
        public async Task TestAddPaymentTermAsync()
        {
            _createPaymentTermpRequest = new CreatePaymentTermRequest
            {
                ProjectId = Guid.Parse("61bb97e8-1af1-4130-ba44-8e50dae55fdf"),
                OverdueLength = 10,
                OverdueUnit = "Days",
                PaymentTerms = new List<PaymentTermRequest>
                {
                    new PaymentTermRequest
                    {
                        TermNo = 1,
                        Title = "Down Payment",
                        Remarks = "Sayap",
                        Percentage = 10,
                        Amount = 10000000,
                        InvoiceDate = new DateTime(2022, 04, 20, 00, 00, 00, 000),
                        ReminderDate = new DateTime(2022, 04, 20, 00, 00, 00, 000),
                        InvoiceNote = "sayap sayap gelap",
                        Taxes = new List<PaymentTermTaxRequest>()
                        {
                            new PaymentTermTaxRequest
                            {
                                TaxId = Guid.Parse("070173ab-743b-423b-9370-b88c3c839bcb"),
                            }
                        }
                    }
                }                
            };

            _service.CreatePaymentTerms(_createPaymentTermpRequest)
                .Returns(Task.FromResult(new MessageDto("New payment term has been created")
                {
                    MessageEng = "New payment term has been created",
                }));

            var ex = await _controller.CreatePaymentTerms(_createPaymentTermpRequest);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual("New payment term has been created", (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestGetPaymentTermAsync()
        {
            var id = Guid.Parse("750d9ece-91b3-4a07-bd46-57f293d76441");
            PaymentTermResponses _paymentTerms = new PaymentTermResponses()
            {
                ProjectId = id,
                OverdueLength = 60,
                OverdueUnit = "Day",
                ProjectAmount = 100000000,
                PaymentTerms = new List<PaymentTermsResponses>()
                {
                    new PaymentTermsResponses
                    {
                        Id = Guid.Parse("070173ab-743b-423b-9370-b88c3c839bcb"),
                        TermNo = 1,
                        Title = "Down Payment",
                        Remarks = "Sayap",
                        Percentage = 10,
                        Amount = 10000000,
                        InvoiceDate = new DateTime(2022, 04, 20, 00, 00, 00, 000),
                        ReminderDate = new DateTime(2022, 04, 20, 00, 00, 00, 000),
                        InvoiceNote = "sayap sayap gelap",
                        Taxes = new List<PaymentTermTaxResponses>()
                        {
                            new PaymentTermTaxResponses
                            {
                                Id = Guid.Parse("070173ab-743b-423b-9370-b88c3c839bcb"),
                                PaymentTermId = Guid.Parse("070173ab-743b-423b-9370-b88c3c839bcb"),
                                TaxId = Guid.Parse("070173ab-743b-423b-9370-b88c3c839bcb"),
                            }
                        }

                    },
                    new PaymentTermsResponses
                    {
                        Id = Guid.Parse("070173ab-743b-423b-9370-b88c3c839bcb"),
                        TermNo = 1,
                        Title = "UAT Sign-off",
                        Remarks = "UAT",
                        Percentage = 10,
                        Amount = 10000000,
                        InvoiceDate = new DateTime(2022, 04, 20, 00, 00, 00, 000),
                        ReminderDate = new DateTime(2022, 04, 20, 00, 00, 00, 000),
                        InvoiceNote = "Sigm-off UAT",
                        Taxes = new List<PaymentTermTaxResponses>()
                        {
                            new PaymentTermTaxResponses
                            {
                                Id = Guid.Parse("070173ab-743b-423b-9370-b88c3c839bcb"),
                                PaymentTermId = Guid.Parse("070173ab-743b-423b-9370-b88c3c839bcb"),
                                TaxId = Guid.Parse("070173ab-743b-423b-9370-b88c3c839bcb"),
                            }
                        }
                    }
                }
            };

            _service.GetPaymentTermByProjectId(id)
                .Returns(Task.FromResult(new MessageDto(200, "Found", null, "Payment terms is Found", _paymentTerms)
                {
                    Title = "Found",
                    Status = 200,
                    MessageIdn = null,
                    MessageEng = "Payment terms is Found",
                    Data = _paymentTerms,
                }));

            var ex = await _controller.GetPaymentTerms(id);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            var convert = (value as MessageDto).Data as PaymentTermResponses;
            Assert.AreEqual(2, convert.PaymentTerms.Count);
        }
    }
}
