// <copyright file="BudgetControllerTest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Controllers;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Budget;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Client;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using Sieve.Models;

namespace Garuda.Modules.ProjectManagementTest.Controllers
{
    
    internal class BudgetControllerTest
    {
        private IBudgetServices _service;
        private BudgetController _controller;

        [SetUp]
        public void Setup()
        {
            _service = Substitute.For<IBudgetServices>();
            _controller = new BudgetController(_service);
        }

        [Test]
        public async Task TestGetBudgetTypes()
        {
            var sieveModel = new SieveModel();
            _service.GetBudgetTypes(sieveModel)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_BUDGET_TYPES, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.FOUND_BUDGET_TYPES,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Found",
                }));

            var ex = await _controller.GetBudgetTypes(sieveModel);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.FOUND_BUDGET_TYPES, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestGetBudgetActivities()
        {
            var sieveModel = new SieveModel();
            _service.GetBudgetActivities(sieveModel)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_BUDGET_ACTIVITIES, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.FOUND_BUDGET_ACTIVITIES,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Found",
                }));

            var ex = await _controller.GetBudgetActivities(sieveModel);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.FOUND_BUDGET_ACTIVITIES, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestCreateBudgetActivities()
        {
            var request = new BudgetActivyRequest
            {
                Name = "Operasional",
            };
            _service.CreateBudgetActivities(request)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.CREATED, "Created", null, SuccessConstant.CREATED_BUDGET_ACTIVITIES, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.CREATED_BUDGET_ACTIVITIES,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.CREATED,
                    Title = "Created",
                }));

            var ex = await _controller.CreateBudgetActivities(request);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.CREATED_BUDGET_ACTIVITIES, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestCreateBudgetTypes()
        {
            var request = new BudgetTypeRequest
            {
                Name = "Operasional",
            };
            _service.CreateBudgetTypes(request)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.CREATED, "Created", null, SuccessConstant.CREATED_BUDGET_TYPES, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.CREATED_BUDGET_TYPES,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.CREATED,
                    Title = "Created",
                }));

            var ex = await _controller.CreateBudgetTypes(request);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.CREATED_BUDGET_TYPES, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestDeleteBudgetActivities()
        {
            var id = Guid.Parse("750d9ece-91b3-4a07-bd46-57f293d76441");
            _service.DeleteBudgetActivities(id)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Deleted", null, SuccessConstant.REMOVED_BUDGET_ACTIVITIES, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.REMOVED_BUDGET_ACTIVITIES,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Deleted",
                }));

            var ex = await _controller.DeleteBudgetActivities(id);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.REMOVED_BUDGET_ACTIVITIES, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestDeleteBudgetTypes()
        {
            var id = Guid.Parse("750d9ece-91b3-4a07-bd46-57f293d76441");
            _service.DeleteBudgetTypes(id)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Deleted", null, SuccessConstant.REMOVED_BUDGET_TYPES, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.REMOVED_BUDGET_TYPES,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Deleted",
                }));

            var ex = await _controller.DeleteBudgetTypes(id);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.REMOVED_BUDGET_TYPES, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestEditBudgetActivities()
        {
            var request = new BudgetActivyRequest
            {
                Name = "Operasional",
            };
            var id = Guid.Parse("750d9ece-91b3-4a07-bd46-57f293d76441");
            _service.EditBudgetActivities(request, id)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Updated", null, SuccessConstant.UPDATED_BUDGET_ACTIVITIES, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.UPDATED_BUDGET_ACTIVITIES,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Updated",
                }));

            var ex = await _controller.EditBudgetActivities(request, id);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.UPDATED_BUDGET_ACTIVITIES, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestEditBudgetTypes()
        {
            var request = new BudgetTypeRequest
            {
                Name = "Operasional",
            };
            var id = Guid.Parse("750d9ece-91b3-4a07-bd46-57f293d76441");
            _service.EditBudgetTypes(request, id)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Updated", null, SuccessConstant.UPDATED_BUDGET_TYPES, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.UPDATED_BUDGET_TYPES,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Updated",
                }));

            var ex = await _controller.EditBudgetTypes(request, id);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.UPDATED_BUDGET_TYPES, (value as MessageDto).MessageEng);
        }



        [Test]
        public async Task TestGetBudgets()
        {
            var sieveModel = new SieveModel();
            _service.GetDatas(sieveModel)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_BUDGET_ACTIVITIES, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.FOUND_BUDGET,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Found",
                }));
            var ex = await _controller.GetBudgets(sieveModel);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.FOUND_BUDGET, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestGetBudget()
        {
            Guid id = Guid.Parse("750d9ece-91b3-4a07-bd46-57f293d76441");
            _service.GetData(id)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_BUDGET_ACTIVITIES, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.FOUND_BUDGET,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Found",
                }));

            var ex = await _controller.GetBudget(id);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.FOUND_BUDGET, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestCreateBudget()
        {
            var request = new BudgetRequest
            {
                Year = 2022,
                Projection = 10000000,
            };
            _service.CreateBudget(request)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.CREATED, "Created", null, SuccessConstant.CREATED_BUDGET_TYPES, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.CREATED_BUDGET_TYPES,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.CREATED,
                    Title = "Created",
                }));

            var ex = await _controller.CreateBudget(request);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.CREATED_BUDGET_TYPES, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestCreateBudgetDetail()
        {
            var request = new BudgetDetailRequest
            {
                BudgetId = Guid.Parse("750d9ece-91b3-4a07-bd46-57f293d76441"),
                BudgetTypes = new List<BudgetDetailTypeRequest>()
                {
                    new BudgetDetailTypeRequest()
                    {
                        TypeId = Guid.Parse("14bf9b80-56a2-4aa1-8705-98b79b4a08e9"),
                        TypeName = "Biaya SDM",
                        BudgetActivities = new List<BudgetDetailActivityRequest>()
                        {
                            new BudgetDetailActivityRequest()
                            {
                                BudgetActivityId = Guid.Parse("782e1fa2-05f7-4b34-a5fe-5642d3a15a51"),
                                BudgetAmount = 10000000,
                                BudgetPercentage = 100,
                            }
                        }
                    }
                }
            };
            _service.CreateBudgetDetail(request)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.CREATED, "Created", null, SuccessConstant.CREATED_BUDGET_TYPES, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.CREATE_BUDGET,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.CREATED,
                    Title = "Created",
                }));

            var ex = await _controller.CreateBudgetDetail(request);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.CREATE_BUDGET, (value as MessageDto).MessageEng);
        }
    }
}
