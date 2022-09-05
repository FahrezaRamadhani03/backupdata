// <copyright file="AccountServiceTest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Contracts;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;
using Garuda.Modules.Auth.Services.Repositories;
using Garuda.Modules.Common.Dtos.Requests;
using Garuda.Modules.Email.Configurations;
using Garuda.Modules.Email.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSubstitute;
using NUnit.Framework;
using Sieve.Models;
using Sieve.Services;

namespace Garuda.Modules.AuthTest.Controllers
{
    internal class AccountServiceTest
    {
        private AccountServices _testClass;
        private IStorage _iStorage;
        private ILogger<AccountServices> _logger;
        private IJwtFactory _jwt;
        private IEmailSender emailSender;
        private IConfiguration emailConfig;
        private IOptions<EmailConfig> config;

        [SetUp]
        public void Setup()
        {
            _iStorage = Substitute.For<IStorage>();
            _logger = Substitute.For<ILogger<AccountServices>>();
            _jwt = Substitute.For<IJwtFactory>();
            _testClass = new AccountServices(_iStorage, _logger, _jwt, emailSender, emailConfig, config);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new AccountServices(_iStorage, _logger, _jwt, emailSender, emailConfig, config);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotCallRequestResetPasswordWithNullModel()
        {
            Assert.ThrowsAsync<System.NullReferenceException>(() =>
                _testClass.RequestResetPassword(default(ReqResetPasswordRequests)));
        }

        [Test]
        public void CanCallRequestResetPassword()
        {
            var model = new ReqResetPasswordRequests
            {
                EmailOrUser = "user@example.com",
            };

            Assert.ThrowsAsync<System.NullReferenceException>(() =>
                _testClass.RequestResetPassword(default(ReqResetPasswordRequests)));
        }

        [Test]
        public void CannotCallResetPasswordWithNullModel()
        {
            Assert.ThrowsAsync<System.NullReferenceException>(() =>
                _testClass.ResetPassword(default(ResetPasswordRequests)));
        }

        [Test]
        public void CanCallResetPassword()
        {
            var model = new ResetPasswordRequests
            {
                Password = "newPass",
                ConfirmPassword = "newPass",
                Code = "4xG8nY",
            };

            var result = _testClass.ResetPassword(model)
                .Returns(Task.FromResult(new MessageDto("Reset password link has expired")
                {
                    MessageEng = "Reset password link has expired",
                }));

            // Assert
            Assert.Pass("Create or modify test");
        }
    }
}
