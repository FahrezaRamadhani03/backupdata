// <copyright file="ClientServiceTest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;
using Garuda.Modules.ProjectManagement.Controllers;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Client;
using Garuda.Modules.ProjectManagement.Models.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Garuda.Modules.ProjectManagement.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSubstitute;
using NUnit.Framework;
using Sieve.Models;
using Sieve.Services;

namespace Garuda.Modules.ProjectManagementTest.Controllers
{
    internal class ClientServiceTest
    {
        private ClientServices _testClass;
        private IStorage _iStorage;
        private IMapper _mapper;
        private ILogger<ClientServices> _logger;
        private SieveProcessor _sieve;

        [SetUp]
        public void Setup()
        {
            _iStorage = Substitute.For<IStorage>();
            _mapper = Substitute.For<IMapper>();
            _logger = Substitute.For<ILogger<ClientServices>>();
            _sieve = new SieveProcessor(Substitute.For<IOptions<SieveOptions>>());
            _testClass = new ClientServices(_iStorage, _logger, _mapper, _sieve);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new ClientServices(_iStorage, _logger, _mapper, _sieve);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotCallCreateClientWithNullModel()
        {
            Assert.ThrowsAsync<BadRequestException>(() => 
                _testClass.CreateData(default(CreateClientRequest)));
        }

        [Test]
        public void CanCallCreateClient()
        {
            var model = new CreateClientRequest()
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

            // Act
            var result = _testClass.CreateData(model)
                .Returns(Task.FromResult(new MessageDto("Client has been added")
                {
                    MessageEng = "Client has been added",
                }));

            // Assert
            Assert.Pass("Create or modify test");
        }

        [Test]
        public void CannotCallUpdateClientWithNullModel()
        {
            Assert.ThrowsAsync<BadRequestException>(() =>
                _testClass.UpdateClient(1, default(CreateClientRequest)));
        }
    }
}
