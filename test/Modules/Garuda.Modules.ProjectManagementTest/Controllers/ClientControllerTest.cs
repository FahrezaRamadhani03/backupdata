// <copyright file="ClientControllerTest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Controllers;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Client;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Client;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using Sieve.Models;

namespace Garuda.Modules.ProjectManagementTest.Controllers
{
    internal class ClientControllerTest
    {
        private IClientServices _service;
        private ClientController _controller;
        private List<CreateClientRequest> _createClientRequest;

        [SetUp]
        public void Setup()
        {
            _service = Substitute.For<IClientServices>();
            _controller = new ClientController(_service);
        }

        [Test]
        public async Task TestGetClientAsync()
        {
            var sieveModel = new SieveModel();
            sieveModel.Filters = "code@=Test";
            List<ClientResponses> _clients = new List<ClientResponses>()
            {
                new ClientResponses
                {
                    Id = 1,
                    Name = "Test ClientName",
                    Code = "TC",
                    Country = "Indonesia",
                    State = "Jawa Barat",
                    City = "Bandung",
                    District = "Pasirluyu",
                    ZipCode = "14000",
                    Address = "Jl. Jalan",
                    PICName = "User",
                    PICEmail = "user@example.com",
                    PICPhone = "089999999999",
                },
                new ClientResponses
                {
                    Id = 2,
                    Name = "Test ClientName2",
                    Code = "TC2",
                    Country = "Indonesia",
                    State = "Jabar",
                    City = "Bandung",
                    District = "Cipadung",
                    ZipCode = "14064",
                    Address = "Jln jln",
                    PICName = "Bambang",
                    PICEmail = "user@example.com",
                    PICPhone = "089999999999",
                },
            };

            _service.GetData()
                .Returns(Task.FromResult(new MessageDto(200, "Found", null, SuccessConstant.FOUND_CLIENT, _clients)
                {
                    Title = "Found",
                    Status = 200,
                    MessageIdn = null,
                    MessageEng = SuccessConstant.FOUND_CLIENT,
                    Data = _clients,
                }));

            var ex = await _controller.GetDataAll();
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            var convert = (value as MessageDto).Data as List<ClientResponses>;
            Assert.AreEqual(2, convert.Count());
        }

        [Test]
        public async Task TestAddClientAsync()
        {
            var client = new Client()
            {
                Name = "Test ClientName",
                Code = "TC",
                Country = "Indonesia",
                State = "Jawa Barat",
                City = "Bandung",
                District = "Pasirluyu",
                ZipCode = "14000",
                Address = "Jl. Jalan",
                PICName = "User",
                PICEmail = "user@example.com",
                PICPhone = "089999999999",
                CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                CreatedBy = null,
                DeletedBy = null,
                UpdatedBy = null,
            };

            var newClient = new CreateClientRequest
            {
                Name = "Test ClientName",
                Code = "TC",
                Country = "Indonesia",
                State = "Jawa Barat",
                City = "Bandung",
                District = "Pasirluyu",
                ZipCode = "14000",
                Address = "Jl. Jalan",
                PICName = "User",
                PICEmail = "user@example.com",
                PICPhone = "089999999999",
            };

            _service.CreateData(newClient)
                .Returns(Task.FromResult(new MessageDto(201, "Created", null, "Client has been added", client)
                {
                    Title = "Created",
                    Status = 201,
                    MessageIdn = null,
                    MessageEng = "Client has been added",
                    Data = client,
                }));

            var ex = await _controller.CreateClient(newClient);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            var convert = (value as MessageDto).Data as Client;
            Assert.AreEqual(newClient.Code, convert.Code);
        }

        [Test]
        public async Task TestAddClientSuccess()
        {
            var client = new Client()
            {
                Name = "Test ClientName",
                Code = "TC",
                Country = "Indonesia",
                State = "Jawa Barat",
                City = "Bandung",
                District = "Pasirluyu",
                ZipCode = "14000",
                Address = "Jl. Jalan",
                PICName = "User",
                PICEmail = "user@example.com",
                PICPhone = "089999999999",
                CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                CreatedBy = null,
                DeletedBy = null,
                UpdatedBy = null,
            };

            var newClient = new CreateClientRequest
            {
                Name = "Test ClientName",
                Code = "TC",
                Country = "Indonesia",
                State = "Jawa Barat",
                City = "Bandung",
                District = "Pasirluyu",
                ZipCode = "14000",
                Address = "Jl. Jalan",
                PICName = "User",
                PICEmail = "user@example.com",
                PICPhone = "089999999999",
            };

            _service.CreateData(newClient)
                .Returns(Task.FromResult(new MessageDto(201, "Created", null, "Client has been added", client)
                {
                    Title = "Created",
                    Status = 201,
                    MessageIdn = null,
                    MessageEng = "Client has been added",
                    Data = client,
                }));

            var ex = await _controller.CreateClient(newClient);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual("Created", (value as MessageDto).Title);
        }

        [Test]
        public void TestAddClient_InvalidModel()
        {
            var newClient = new CreateClientRequest();

            var context = new ValidationContext(newClient, null, null);
            var results = new List<ValidationResult>();
            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(CreateClientRequest), typeof(CreateClientRequest)), typeof(CreateClientRequest));

            var isModelStateValid = Validator.TryValidateObject(newClient, context, results, true);
            Assert.IsFalse(isModelStateValid);
        }

        [Test]
        public async Task TestDeleteClient()
        {
            _service.SoftDeleteClient(1)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, "Client has been removed", null)
                {
                    Data = null,
                    MessageEng = "Client has been removed",
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Deleted",
                }));

            var ex =  await _controller.SoftDeleteClient(1);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual("Client has been removed", (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestUpdateClientSuccess()
        {
            var client = new Client()
            {
                Name = "Test ClientName",
                Code = "TC",
                Country = "Indonesia",
                State = "Jawa Barat",
                City = "Bandung",
                District = "Pasirluyu",
                ZipCode = "14000",
                Address = "Jl. Jalan",
                PICName = "User",
                PICEmail = "user@example.com",
                PICPhone = "089999999999",
                CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                CreatedBy = null,
                DeletedBy = null,
                UpdatedBy = null,
            };

            var newClient = new CreateClientRequest
            {
                Name = "Test ClientName Update",
                Code = "TC",
                Country = "Malaysia",
                State = "Kuala Lumpur",
                City = "Kuala Lumpur",
                District = "Kampung Duren",
                ZipCode = "14000",
                Address = "Jl. Atok Dalang",
                PICName = "Upin",
                PICEmail = "Upin@example.com",
                PICPhone = "089999999999",
            };

            _service.UpdateClient(1, newClient)
                .Returns(Task.FromResult(new MessageDto(200, "Updated", null, "Client has been updated", newClient)
                {
                    Title = "Updated",
                    Status = 200,
                    MessageIdn = null,
                    MessageEng = "Client has been updated",
                    Data = client,
                }));

            var ex = await _controller.UpdateClient(1, newClient);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual("Updated", (value as MessageDto).Title);
        }
    }
}
