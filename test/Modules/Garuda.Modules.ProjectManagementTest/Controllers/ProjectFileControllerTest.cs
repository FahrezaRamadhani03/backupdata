// <copyright file="ProjectFileControllerTest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Controllers;
using Garuda.Modules.ProjectManagement.Dtos.Requests.ProjectFile;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using Sieve.Models;

namespace Garuda.Modules.ProjectManagementTest.Controllers
{
    internal class ProjectFileControllerTest
    {
        private IProjectFileServices _service;
        private ProjectFileController _controller;
        private List<CreateProjectFileRequest> _createProjectFileRequest;

        [SetUp]
        public void Setup()
        {
            _service = Substitute.For<IProjectFileServices>();
            _controller = new ProjectFileController(_service);
        }

        [Test]
        public async Task TestGetProjectFile()
        {
            var projectId = Guid.Parse("cbaed6ce-4cfe-41ab-8763-4ba265b82890");
            _service.GetData(projectId, "1234")
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_PROJECT_FILE, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.FOUND_PROJECT_FILE,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Found",
                }));

            var ex = await _controller.GetData(projectId, "1234");
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.FOUND_PROJECT_FILE, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestAddProjectFileSuccess()
        {
            var ProjectFile = new ProjectFile()
            {
                ProjectId = Guid.Parse("cbaed6ce-4cfe-41ab-8763-4ba265b82890"),
                DocumentName = "Project Files Document",
                DocumentDesc = "Project files document description",
                FileSource = "File Upload",
                CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                CreatedBy = null,
                DeletedBy = null,
                UpdatedBy = null,
            };

            var newProjectFile = new List<CreateProjectFileRequest>()
            {
                new CreateProjectFileRequest
                {
                    DocumentName = "Project Files Document",
                    DocumentDesc = "Project files document description",
                    FileSource = "File Upload",
                }
            };

            _service.CreateData(Guid.Parse("cbaed6ce-4cfe-41ab-8763-4ba265b82890"), "1234", newProjectFile)
                .Returns(Task.FromResult(new MessageDto(201, "Created", null, "Project File has been save", ProjectFile)
                {
                    Title = "Created",
                    Status = 201,
                    MessageIdn = null,
                    MessageEng = "Project File has been save",
                    Data = ProjectFile,
                }));

            var ex = await _controller.CreateProjectFile(Guid.Parse("cbaed6ce-4cfe-41ab-8763-4ba265b82890"), "1234", newProjectFile);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual("Created", (value as MessageDto).Title);
        }

        [Test]
        public void TestAddProjectFile_InvalidModel()
        {
            var newProjectFile = new CreateProjectFileRequest();

            var context = new ValidationContext(newProjectFile, null, null);
            var results = new List<ValidationResult>();
            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(CreateProjectFileRequest), typeof(CreateProjectFileRequest)), typeof(CreateProjectFileRequest));

            var isModelStateValid = Validator.TryValidateObject(newProjectFile, context, results, true);
            Assert.IsFalse(isModelStateValid);
        }

        [Test]
        public async Task TestEditProjectFileSuccess()
        {
            var ProjectFile = new ProjectFile()
            {
                ProjectId = Guid.Parse("cbaed6ce-4cfe-41ab-8763-4ba265b82890"),
                DocumentName = "Project Files Document",
                DocumentDesc = "Project files document description",
                FileSource = "File Upload",
                CreatedDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                CreatedBy = null,
                DeletedBy = null,
                UpdatedBy = null,
            };

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

            _service.EditData(Guid.Parse("cbaed6ce-4cfe-41ab-8763-4ba265b82890"), "1234", newProjectFile)
                .Returns(Task.FromResult(new MessageDto(201, "Updated", null, "Project File has been updated", ProjectFile)
                {
                    Title = "Updated",
                    Status = 201,
                    MessageIdn = null,
                    MessageEng = "Project File has been updated",
                    Data = ProjectFile,
                }));

            var ex = await _controller.EditProjectFile(Guid.Parse("cbaed6ce-4cfe-41ab-8763-4ba265b82890"), "1234", newProjectFile);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual("Updated", (value as MessageDto).Title);
        }
    }
}
