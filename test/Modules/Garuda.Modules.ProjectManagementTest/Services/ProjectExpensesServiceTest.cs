// <copyright file="ProjectExpensesServiceTest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using AutoMapper;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Exceptions;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Expenses;
using Garuda.Modules.ProjectManagement.Helper.Interfaces;
using Garuda.Modules.ProjectManagement.Services.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSubstitute;
using NUnit.Framework;
using Sieve.Models;
using Sieve.Services;

namespace Garuda.Modules.ProjectManagementTest.Services
{
    internal class ProjectExpensesServiceTest
    {
        private ProjectExpensesServices _testClass;
        private IStorage _iStorage;
        private ILogger<ProjectExpensesServices> _iLogger;
        private IMapper _iMapper;
        private SieveProcessor _sieve;
        private IHostEnvironment _hostingEnvironment;
        private IConfiguration _configuration;
        private IFileChecker _fileChecker;


        [SetUp]
        public void Setup()
        {
            _iStorage = Substitute.For<IStorage>();
            _iMapper = Substitute.For<IMapper>();
            _iLogger = Substitute.For<ILogger<ProjectExpensesServices>>();
            _sieve = new SieveProcessor(Substitute.For<IOptions<SieveOptions>>());
            _hostingEnvironment =  Substitute.For<IHostEnvironment>();
            _configuration =  Substitute.For<IConfiguration>();
            _fileChecker =  Substitute.For<IFileChecker>();

            _testClass = new ProjectExpensesServices(_iStorage, _iLogger, _iMapper, _sieve, _hostingEnvironment, _configuration, _fileChecker);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new ProjectExpensesServices(_iStorage, _iLogger, _iMapper, _sieve, _hostingEnvironment, _configuration, _fileChecker);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotCallCreateExpenseWithNullModel()
        {
            Assert.ThrowsAsync<BadRequestException>(() =>
                _testClass.CreateExpense(default(ExpenseRequest)));
        }
    }
}
