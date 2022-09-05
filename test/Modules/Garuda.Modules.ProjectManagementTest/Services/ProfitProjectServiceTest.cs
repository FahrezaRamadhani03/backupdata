using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentRole;
using Garuda.Modules.ProjectManagement.Dtos.Requests.ProjectDetails;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Garuda.Modules.ProjectManagement.Services.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSubstitute;
using NUnit.Framework;
using Sieve.Models;
using Sieve.Services;

namespace Garuda.Modules.ProjectManagementTest.Services
{
    internal class ProfitProjectServiceTest
    {
        private ProfitProjectServices _testClass;
        private IStorage _iStorage;
        private IMapper _mapper;
        private ILogger<ProfitProjectServices> _logger;
        private IConfiguration _configuration;
        private SieveProcessor _sieve;

        [SetUp]
        public void Setup()
        {
            _iStorage = Substitute.For<IStorage>();
            _mapper = Substitute.For<IMapper>();
            _logger = Substitute.For<ILogger<ProfitProjectServices>>();
            _configuration = Substitute.For<IConfiguration>();
            _sieve = new SieveProcessor(Substitute.For<IOptions<SieveOptions>>());
            _testClass = new ProfitProjectServices(_configuration, _iStorage, _logger, _mapper, _sieve);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new ProfitProjectServices(_configuration, _iStorage, _logger, _mapper, _sieve);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CanCallGetProposalHistory()
        {
            var sieve = new SieveModel();
            var year = 2022;
            var result = _testClass.GetDatas(sieve, year);
            Assert.AreEqual(null, result.Exception);
        }
    }
}
