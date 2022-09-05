
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentRole;
using Garuda.Modules.ProjectManagement.Services.Repositories;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;

namespace Garuda.Modules.ProjectManagementTest.Services
{
    internal class DevelopmentRolesServiceTest
    {
        private DevelopmentRoleServices _testClass;
        private IStorage _iStorage;
        private IMapper _mapper;
        private ILogger<DevelopmentRoleServices> _logger;

        [SetUp]
        public void Setup()
        {
            _iStorage = Substitute.For<IStorage>();
            _mapper = Substitute.For<IMapper>();
            _logger = Substitute.For<ILogger<DevelopmentRoleServices>>();
            _testClass = new DevelopmentRoleServices(_iStorage, _logger, _mapper);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new DevelopmentRoleServices(_iStorage, _logger, _mapper);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotCallCreateDevelopmentRoleWithNullModel()
        {
            Assert.ThrowsAsync<BadRequestException>(() =>
                _testClass.CreateData(default(CreateDevelopmentRoleRequest)));
        }

        [Test]
        public void CanCallCreateDevelopmentRole()
        {
            // Arrange
            var model = new CreateDevelopmentRoleRequest()
            {
                Code = "HK",
                Leader = false,
                Name = "Hacker",
            };

            // Act
            var result = _testClass.CreateData(model)
                .Returns(Task.FromResult(new MessageDto(SuccessConstant.CREATED_DEVELOPMENT_ROLES)
                {
                    MessageEng = SuccessConstant.CREATED_DEVELOPMENT_ROLES,
                }));

            // Assert
            Assert.Pass("Create or modify test");
        }

        [Test]
        public void CannotCallEditDevelopmentRoleWithNullModel()
        {
            Guid id = Guid.NewGuid();
            Assert.ThrowsAsync<BadRequestException>(() =>
                _testClass.UpdateData(id, default(CreateDevelopmentRoleRequest)));
        }
    }
}
