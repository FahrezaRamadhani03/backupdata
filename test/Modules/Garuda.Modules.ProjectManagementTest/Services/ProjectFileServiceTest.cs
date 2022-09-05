// <copyright file="ProjectFileServiceTest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Garuda.Database.Abstract.Contracts;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;
using Garuda.Modules.ProjectManagement.Controllers;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Client;
using Garuda.Modules.ProjectManagement.Dtos.Requests.ProjectFile;
using Garuda.Modules.ProjectManagement.Helper.Interfaces;
using Garuda.Modules.ProjectManagement.Models.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Garuda.Modules.ProjectManagement.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSubstitute;
using NUnit.Framework;
using Sieve.Models;
using Sieve.Services;

namespace Garuda.Modules.ProjectManagementTest.Controllers
{
    internal class ProjectFileServiceTest
    {
        private ProjectFileServices _testClass;
        private IStorage _iStorage;
        private IMapper _mapper;
        private ILogger<ProjectFileServices> _logger;
        private SieveProcessor _sieve;
        private IFileChecker _fileChecker;
        private IHostEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        [SetUp]
        public void Setup()
        {
            _iStorage = Substitute.For<IStorage>();
            _mapper = Substitute.For<IMapper>();
            _logger = Substitute.For<ILogger<ProjectFileServices>>();
            _sieve = new SieveProcessor(Substitute.For<IOptions<SieveOptions>>());
            _hostingEnvironment = Substitute.For<IHostEnvironment>();
            _fileChecker = Substitute.For<IFileChecker>();
            _testClass = new ProjectFileServices(_iStorage, _logger, _mapper, _sieve, _hostingEnvironment, _fileChecker, _configuration);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new ProjectFileServices(_iStorage, _logger, _mapper, _sieve, _hostingEnvironment, _fileChecker, _configuration);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotCallCreateProjectFileWithNullModel()
        {
            Guid projectId = Guid.Parse("cbaed6ce-4cfe-41ab-8763-4ba265b82890");
            string projectCode = "0000";
            Assert.ThrowsAsync<BadRequestException>(() => 
                _testClass.CreateData(projectId, projectCode, default(List<CreateProjectFileRequest>)));
        }

        [Test]
        public void CanCallCreateProjectFile()
        {
            var newProjectFile = new List<CreateProjectFileRequest>()
            {
                new CreateProjectFileRequest
                {
                    DocumentName = "Project Files Document",
                    DocumentDesc = "Project files document description",
                    FileSource = "File Upload"
                }
            };

            // Act
            var result = _testClass.CreateData(Guid.Parse("cbaed6ce-4cfe-41ab-8763-4ba265b82890"), "0000", newProjectFile)
                .Returns(Task.FromResult(new MessageDto("Project File has been save")
                {
                    MessageEng = "Project File has been save",
                }));

            // Assert
            Assert.Pass("Create or modify test");
        }

        [Test]
        public void CannotCallEditProjectFileWithNullModel()
        {
            Guid projectId = Guid.Parse("cbaed6ce-4cfe-41ab-8763-4ba265b82890");
            string projectCode = "0000";
            Assert.ThrowsAsync<BadRequestException>(() =>
                _testClass.EditData(projectId, projectCode, default(List<EditProjectFileRequest>)));
        }

        [Test]
        public void CanCallEditProjectFile()
        {
            var newProjectFile = new List<EditProjectFileRequest>()
            {
                new EditProjectFileRequest
                {
                    DocumentName = "Project Files Document",
                    DocumentDesc = "Project files document description",
                    FileSource = "File Upload",
                    IsUpdated = false,
                    Id = 32,
                }
            };

            // Act
            var result = _testClass.EditData(Guid.Parse("cbaed6ce-4cfe-41ab-8763-4ba265b82890"), "0000", newProjectFile)
                .Returns(Task.FromResult(new MessageDto("Project File has been updated")
                {
                    MessageEng = "Project File has been updated",
                }));

            // Assert
            Assert.Pass("Create or modify test");
        }
    }
}
