using AutoMapper;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Exceptions;
using Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentInfo;
using Garuda.Modules.ProjectManagement.Hubs;
using Garuda.Modules.ProjectManagement.Hubs.Contracts;
using Garuda.Modules.ProjectManagement.Services.Repositories;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using System;

namespace Garuda.Modules.ProjectManagementTest.Services
{
    internal class DevelopmentInfoServiceTest
    {
        private DevelopmentInfoServices _testClass;
        private IStorage _iStorage;
        private IMapper _mapper;
        private ILogger<DevelopmentInfoServices> _logger;
        private IConfiguration _configuration;
        private readonly IHubContext<NotificationHub, INotificationHub> _notifHub;

        [SetUp]
        public void Setup()
        {
            _iStorage = Substitute.For<IStorage>();
            _mapper = Substitute.For<IMapper>();
            _logger = Substitute.For<ILogger<DevelopmentInfoServices>>();
            _configuration = Substitute.For<IConfiguration>();
            _testClass = new DevelopmentInfoServices(_iStorage, _logger, _mapper, _configuration, _notifHub);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new DevelopmentInfoServices(_iStorage, _logger, _mapper, _configuration, _notifHub);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotCallCreateDevelopmentInfoWithNullModel()
        {
            Assert.ThrowsAsync<BadRequestException>(() =>
                _testClass.CreateData(default(CreateDevelopmentInfoRequest), Guid.Parse("cbaed6ce-4cfe-41ab-8763-4ba265b82890")));
        }

        [Test]
        public void CannotCallEditDevelopmentInfoWithNullModel()
        {
            Assert.ThrowsAsync<BadRequestException>(() =>
                _testClass.EditData(default(EditDevelopmentInfoRequest)));
        }

        [Test]
        public void CannotCallGetDevelopmentInfoWithNullModel()
        {
            Assert.ThrowsAsync<BadRequestException>(() =>
                _testClass.GetData(default(Guid)));
        }

        [Test]
        public void CanCallGetSprintList()
        {
            Guid projectId = Guid.Parse("cbaed6ce-4cfe-41ab-8763-4ba265b82890");

            var result = _testClass.GetSprintList(projectId);
            Assert.AreEqual(null, result.Exception);
        }
    }
}
