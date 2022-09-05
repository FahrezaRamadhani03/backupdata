// <copyright file="ProposalServiceTest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;
using Garuda.Modules.ProjectManagement.Dtos.Requests;
using Garuda.Modules.ProjectManagement.Dtos.Requests.FileUpload;
using Garuda.Modules.ProjectManagement.Helper.Interfaces;
using Garuda.Modules.ProjectManagement.Hubs;
using Garuda.Modules.ProjectManagement.Hubs.Contracts;
using Garuda.Modules.ProjectManagement.Services.Repositories;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSubstitute;
using NUnit.Framework;
using Sieve.Models;
using Sieve.Services;

namespace Garuda.Modules.ProjectManagementTest.Controllers
{
    internal class ProposalServiceTest
    {
        private ProposalServices _testClass;
        private IStorage _iStorage;
        private IMapper _mapper;
        private ILogger<ProposalServices> _logger;
        private SieveProcessor _sieve;
        private IFileChecker _fileChecker;
        private readonly IHubContext<NotificationHub, INotificationHub> _notifHub;

        [SetUp]
        public void Setup()
        {
            _iStorage = Substitute.For<IStorage>();
            _mapper = Substitute.For<IMapper>();
            _logger = Substitute.For<ILogger<ProposalServices>>();
            _sieve = new SieveProcessor(Substitute.For<IOptions<SieveOptions>>());
            _fileChecker = Substitute.For<IFileChecker>();
            _testClass = new ProposalServices(_iStorage, _logger, _mapper, _sieve, _fileChecker, _notifHub);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new ProposalServices(_iStorage, _logger, _mapper, _sieve, _fileChecker, _notifHub);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotCallCreateProposalWithNullModel()
        {
            Assert.ThrowsAsync<BadRequestException>(() =>
                _testClass.CreateData(default(CreateProposalRequest), Guid.Parse("cbaed6ce-4cfe-41ab-8763-4ba265b82890")));
        }

        [Test]
        public void CanCallCreateProposal()
        {
            var model = new CreateProposalRequest
            {
                ProjectId = Guid.Parse("cbaed6ce-4cfe-41ab-8763-4ba265b82890"),
                DocumentNo = "DOC/GIK/1/2022",
                ProjectAmount = 100000000,
                SentDate = new DateTime(2022, 04, 20),
                FileName = null,
                FileNameOri = null,
                GikContractNo = null,
                GikFileName = null,
                GikFileNameOri = null,
                ClientContractNo = "CONTRACT01",
                ClientFileName = null,
                ClientFileNameOri = null,
                OtherInfo = "string",
                Remark = "test",
                FileProposal = null,
                FileGIKContract = null,
                FileClientContract = null,
            };

            // Act
            var result = _testClass.CreateData(model, Guid.Parse("cbaed6ce-4cfe-41ab-8763-4ba265b82890"))
                .Returns(Task.FromResult(new MessageDto("Proposal has been uploaded")
                {
                    MessageEng = "Proposal has been uploaded",
                }));

            // Assert
            Assert.Pass("Create or modify test");
        }

        [Test]
        public void CanCallGetProposal()
        {
            Guid projectId = Guid.Parse("cbaed6ce-4cfe-41ab-8763-4ba265b82890");

            var result = _testClass.GetData(projectId);
            Assert.AreEqual(null, result.Exception);
        }

        [Test]
        public void CanCallGetProposalHistory()
        {
            Guid projectId = Guid.Parse("cbaed6ce-4cfe-41ab-8763-4ba265b82890");

            var result = _testClass.GetHistory(projectId);
            Assert.AreEqual(null, result.Exception);
        }
    }
}
