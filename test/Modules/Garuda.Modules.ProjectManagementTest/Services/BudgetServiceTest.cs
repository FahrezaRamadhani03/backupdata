// <copyright file="BudgetServiceTest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using AutoMapper;
using DinkToPdf;
using DinkToPdf.Contracts;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Exceptions;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Budget;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Client;
using Garuda.Modules.ProjectManagement.Services.Repositories;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSubstitute;
using NUnit.Framework;
using Sieve.Models;
using Sieve.Services;
using System;

namespace Garuda.Modules.ProjectManagementTest.Services
{
    internal class BudgetServiceTest
    {
        private BudgetServices _testClass;
        private IStorage _iStorage;
        private IMapper _mapper;
        private ILogger<BudgetServices> _logger;
        private SieveProcessor _sieve;
        private IConverter _converter;
        private IHostEnvironment _hostingEnvironment;

        [SetUp]
        public void Setup()
        {
            _iStorage = Substitute.For<IStorage>();
            _mapper = Substitute.For<IMapper>();
            _logger = Substitute.For<ILogger<BudgetServices>>();
            _sieve = new SieveProcessor(Substitute.For<IOptions<SieveOptions>>());
            _converter = new SynchronizedConverter(new PdfTools());
            _hostingEnvironment = Substitute.For<IHostEnvironment>();
            _testClass = new BudgetServices(_iStorage, _logger, _mapper, _sieve, _converter, _hostingEnvironment);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new BudgetServices(_iStorage, _logger, _mapper, _sieve, _converter, _hostingEnvironment);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotCallCreateBudgetActivitiesWithNullModel()
        {
            Assert.ThrowsAsync<BadRequestException>(() =>
                _testClass.CreateBudgetActivities(default(BudgetActivyRequest)));
        }

        [Test]
        public void CannotCallCreateBudgetTypesWithNullModel()
        {
            Assert.ThrowsAsync<BadRequestException>(() =>
                _testClass.CreateBudgetTypes(default(BudgetTypeRequest)));
        }

        [Test]
        public void CannotCallEditBudgetActivitiesWithNullModel()
        {
            var id = Guid.Parse("750d9ece-91b3-4a07-bd46-57f293d76441");

            Assert.ThrowsAsync<BadRequestException>(() =>
                _testClass.EditBudgetActivities(default(BudgetActivyRequest), id));
        }

        [Test]
        public void CannotCallEditBudgetTypesWithNullModel()
        {
            var id = Guid.Parse("750d9ece-91b3-4a07-bd46-57f293d76441");

            Assert.ThrowsAsync<BadRequestException>(() =>
                _testClass.EditBudgetTypes(default(BudgetTypeRequest), id));
        }

    }
}
