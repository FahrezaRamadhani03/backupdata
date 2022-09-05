// <copyright file="ProjectExpenseControllerTest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Controllers;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Client;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Expenses;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Expense;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using Sieve.Models;
namespace Garuda.Modules.ProjectManagementTest.Controllers
{
    internal class ProjectExpensesControllerTest
    {
        private IProjectExpensesServices _service;
        private ProjectExpensesController _controller;

        [SetUp]
        public void Setup()
        {
            _service = Substitute.For<IProjectExpensesServices>();
            _controller = new ProjectExpensesController(_service);
        }

        [Test]
        public async Task TestGetDataProject()
        {
            var sieveModel = new SieveModel();
            _service.GetDataProject(sieveModel)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_PROJECT_EXPENSES, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.FOUND_PROJECT_EXPENSES,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Found",
                }));

            var ex = await _controller.GetDataProject(sieveModel);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.FOUND_PROJECT_EXPENSES, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestCreateDataProjectExpenses()
        {
            var createProjectExpense = new ExpenseRequest();
            _service.CreateExpense(createProjectExpense)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.CREATED, "Created", null, SuccessConstant.CREATED_PROJECT_EXPENSES, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.CREATED_PROJECT_EXPENSES,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.CREATED,
                    Title = "Created",
                }));

            var ex = await _controller.CreateExpense(createProjectExpense);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.CREATED_PROJECT_EXPENSES, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestGetDataExpense()
        {
            _service.GetData(Guid.Parse("750d9ece-91b3-4a07-bd46-57f293d76441"))
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_EXPENSES, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.FOUND_EXPENSES,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Found",
                }));

            var ex = await _controller.GetData(Guid.Parse("750d9ece-91b3-4a07-bd46-57f293d76441"));
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.FOUND_EXPENSES, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestDeleteExpense()
        {
            _service.DeleteExpense(Guid.Parse("750d9ece-91b3-4a07-bd46-57f293d76441"))
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Deleted", null, SuccessConstant.REMOVE_EXPENSES, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.REMOVE_EXPENSES,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Deleted",
                }));

            var ex = await _controller.DeleteExpense(Guid.Parse("750d9ece-91b3-4a07-bd46-57f293d76441"));
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.REMOVE_EXPENSES, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestEditExpense()
        {
            var editProjectExpense = new ExpenseRequest();
            _service.EditExpense(Guid.Parse("750d9ece-91b3-4a07-bd46-57f293d76441"), editProjectExpense)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Updated", null, SuccessConstant.UPDATE_EXPENSES, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.UPDATE_EXPENSES,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Deleted",
                }));

            var ex = await _controller.EditExpense(Guid.Parse("750d9ece-91b3-4a07-bd46-57f293d76441"), editProjectExpense);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.UPDATE_EXPENSES, (value as MessageDto).MessageEng);
        }
    }
}
