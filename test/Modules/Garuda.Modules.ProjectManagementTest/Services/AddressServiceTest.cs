// <copyright file="AddressServiceTest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using AutoMapper;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Exceptions;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Client;
using Garuda.Modules.ProjectManagement.Services.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSubstitute;
using NUnit.Framework;
using Sieve.Models;
using Sieve.Services;

namespace Garuda.Modules.ProjectManagementTest.Services
{
    internal class AddressServiceTest
    {
        private AddressServices _testClass;
        private IStorage _iStorage;
        private IMapper _mapper;
        private ILogger<AddressServices> _logger;
        private SieveProcessor _sieve;

        [SetUp]
        public void Setup()
        {
            _iStorage = Substitute.For<IStorage>();
            _mapper = Substitute.For<IMapper>();
            _logger = Substitute.For<ILogger<AddressServices>>();
            _sieve = new SieveProcessor(Substitute.For<IOptions<SieveOptions>>());
            _testClass = new AddressServices(_iStorage, _logger, _mapper);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new AddressServices(_iStorage, _logger, _mapper);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotCallCreateProvinceWithNullModel()
        {
            Assert.ThrowsAsync<BadRequestException>(() =>
                _testClass.CreateProvince(default(AddressRequest)));
        }

        [Test]
        public void CannotCallCreateDistrictWithNullModel()
        {
            Assert.ThrowsAsync<BadRequestException>(() =>
                _testClass.CreateDistrict(default(AddressRequest)));
        }

        [Test]
        public void CannotCallCreateContryWithNullModel()
        {
            Assert.ThrowsAsync<BadRequestException>(() =>
                _testClass.CreateContry(default(AddressRequest)));
        }

        [Test]
        public void CannotCallCreateCityWithNullModel()
        {
            Assert.ThrowsAsync<BadRequestException>(() =>
                _testClass.CreateCity(default(AddressRequest)));
        }

    }
}
