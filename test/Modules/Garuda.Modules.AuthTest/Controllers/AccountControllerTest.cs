
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.Auth.Controllers;
using Garuda.Modules.Auth.Services.Contracts;
using Garuda.Modules.Common.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using Sieve.Models;

namespace Garuda.Modules.AuthTest.Controllers
{
    internal class AccountControllerTest
    {
        private IAccountServices _service;
        private AccountController _controller;

        [SetUp]
        public void Setup()
        {
            _service = Substitute.For<IAccountServices>();
            _controller = new AccountController(_service);
        }

        [Test]
        public async Task TestRequestResetPassword()
        {
            var reqResetPassword = new ReqResetPasswordRequests()
            {
                EmailOrUser = "user@example.com",
            };

            var ex = await _controller.RequestReset(reqResetPassword);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(value, null);
        }

        [Test]
        public async Task TestResetPassword()
        {
            var resetPassword = new ResetPasswordRequests
            {
                Password = "newPass",
                ConfirmPassword = "newPass",
                Code = "4xG8nY",
            };

            _service.ResetPassword(resetPassword)
                .Returns(Task.FromResult(new MessageDto(200, "Updated", null, "Your password has been successfully updated", resetPassword)
                {
                    Title = "Created",
                    Status = 200,
                    MessageIdn = null,
                    MessageEng = "Your password has been successfully updated",
                    Data = resetPassword,
                }));

            var ex = await _controller.ResetPassword(resetPassword);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual("Created", (value as MessageDto).Title);
        }
    }
}
