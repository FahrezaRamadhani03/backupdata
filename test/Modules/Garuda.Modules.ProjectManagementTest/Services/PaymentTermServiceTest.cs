// <copyright file="PaymentTermServiceTest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using AutoMapper;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Exceptions;
using Garuda.Modules.Email.Actions;
using Garuda.Modules.GoogleAp.Services.Contracts;
using Garuda.Modules.ProjectManagement.Dtos.Requests.PaymentTerm;
using Garuda.Modules.ProjectManagement.Services.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSubstitute;
using NUnit.Framework;
using Sieve.Models;
using Sieve.Services;

namespace Garuda.Modules.ProjectManagementTest.Controllers
{
    internal class PaymentTermServiceTest
    {
        private PaymentTermServices _testClass;
        private IStorage _iStorage;
        private IMapper _mapper;
        private ILogger<PaymentTermServices> _logger;
        private IGoogleCalendarSender _iGoogleCalendarSender;
        private SieveProcessor _sieve;
        private AdditionalEmailConfiguration _additionalEmail;

        [SetUp]
        public void Setup()
        {
            _iStorage = Substitute.For<IStorage>();
            _mapper = Substitute.For<IMapper>();
            _logger = Substitute.For<ILogger<PaymentTermServices>>();
            _iGoogleCalendarSender = Substitute.For<IGoogleCalendarSender>();
            _sieve = new SieveProcessor(Substitute.For<IOptions<SieveOptions>>());
            //_additionalEmail = Options.Create(new AdditionalEmailConfiguration());
            _testClass = new PaymentTermServices(_iStorage, _logger, _mapper, _iGoogleCalendarSender, _sieve, (IOptions<AdditionalEmailConfiguration>)_additionalEmail);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new PaymentTermServices(_iStorage, _logger, _mapper, _iGoogleCalendarSender, _sieve, (IOptions<AdditionalEmailConfiguration>)_additionalEmail);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotCallCreatePaymentTermWithNullModel()
        {
            Assert.ThrowsAsync<BadRequestException>(() => 
                _testClass.CreatePaymentTerms(default(CreatePaymentTermRequest)));
        }
    }
}
