using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Contracts;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentRole;
using Garuda.Modules.ProjectManagement.Dtos.Requests.ProjectDetails;
using Garuda.Modules.ProjectManagement.Hubs;
using Garuda.Modules.ProjectManagement.Hubs.Contracts;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Garuda.Modules.ProjectManagement.Services.Repositories;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSubstitute;
using NUnit.Framework;
using Sieve.Models;
using Sieve.Services;

namespace Garuda.Modules.ProjectManagementTest.Services
{
    internal class ProjectDetailServiceTest
    {
        private ProjectDetailServices _testClass;
        private IStorage _iStorage;
        private IMapper _mapper;
        private ILogger<ProjectDetailServices> _logger;
        private IConfiguration _configuration;
        private IDevelopmentRoleService _developmentRoleService;
        private SieveProcessor _sieve;
        private readonly IHubContext<NotificationHub, INotificationHub> _notifHub;

        [SetUp]
        public void Setup()
        {
            _iStorage = Substitute.For<IStorage>();
            _mapper = Substitute.For<IMapper>();
            _logger = Substitute.For<ILogger<ProjectDetailServices>>();
            _configuration = Substitute.For<IConfiguration>();
            _developmentRoleService = Substitute.For<IDevelopmentRoleService>();
            _sieve = new SieveProcessor(Substitute.For<IOptions<SieveOptions>>());
            _testClass = new ProjectDetailServices(_iStorage, _logger, _mapper, _configuration, _developmentRoleService, _sieve, _notifHub);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new ProjectDetailServices(_iStorage, _logger, _mapper, _configuration, _developmentRoleService, _sieve, _notifHub);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotCallCreateProjectDetailWithNullModel()
        {
            Assert.ThrowsAsync<BadRequestException>(() =>
                _testClass.CreateData(default(CreateProjectDetailRequest), Guid.Parse("cbaed6ce-4cfe-41ab-8763-4ba265b82890")));
        }

        [Test]
        public void CannotCallEditProjectDetailWithNullModel()
        {
            Assert.ThrowsAsync<BadRequestException>(() =>
                _testClass.EditData(default(EditProjectDetailRequest)));
        }

        [Test]
        public void CannotCallUpdateStatusWithNullModel()
        {
            Assert.ThrowsAsync<BadRequestException>(() =>
                _testClass.UpdateStatus(default(UpdateStatusRequest), Guid.Parse("cbaed6ce-4cfe-41ab-8763-4ba265b82890")));
        }

        [Test]
        public void CanCallCronJobUpdateStatus()
        {
            var result = _testClass.CronJobUpdateStatus();
            Assert.AreEqual(null, result.Exception);
        }
    }
}
