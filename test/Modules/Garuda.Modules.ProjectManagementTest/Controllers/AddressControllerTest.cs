// <copyright file="AddressControllerTest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Controllers;
using Garuda.Modules.ProjectManagement.Dtos.Requests.Client;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using Sieve.Models;

namespace Garuda.Modules.ProjectManagementTest.Controllers
{
    internal class AddressControllerTest
    {
        private IAddressServices _service;
        private AddressController _controller;

        [SetUp]
        public void Setup()
        {
            _service = Substitute.For<IAddressServices>();
            _controller = new AddressController(_service);
        }

        [Test]
        public async Task TestGetCities()
        {

            _service.GetCities()
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_CITIES, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.FOUND_CITIES,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Found",
                }));

            var ex = await _controller.GetCities();
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.FOUND_CITIES, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestGetContries()
        {

            _service.GetContries()
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_COUNTRIES, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.FOUND_COUNTRIES,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Found",
                }));

            var ex = await _controller.GetContries();
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.FOUND_COUNTRIES, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestGetDistricts()
        {

            _service.GetDistricts()
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_DISTRICTS, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.FOUND_DISTRICTS,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Found",
                }));

            var ex = await _controller.GetDistricts();
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.FOUND_DISTRICTS, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestGetProvinces()
        {

            _service.GetProvinces()
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_PROVINCES, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.FOUND_PROVINCES,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Found",
                }));

            var ex = await _controller.GetProvinces();
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.FOUND_PROVINCES, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestCreateCity()
        {
            var model = new AddressRequest
            {
                Name = "Bandung"
            };

            _service.CreateCity(model)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.CREATED, "Created", null, SuccessConstant.CREATED_CITY, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.CREATED_CITY,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.CREATED,
                    Title = "Created",
                }));

            var ex = await _controller.CreateCity(model);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.CREATED_CITY, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestCreateContry()
        {
            var model = new AddressRequest
            {
                Name = "Zimbabwe"
            };

            _service.CreateContry(model)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.CREATED, "Created", null, SuccessConstant.CREATED_COUNTRY, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.CREATED_COUNTRY,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.CREATED,
                    Title = "Created",
                }));

            var ex = await _controller.CreateContry(model);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.CREATED_COUNTRY, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestCreateDistrict()
        {
            var model = new AddressRequest
            {
                Name = "Sukamaju"
            };

            _service.CreateDistrict(model)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.CREATED, "Created", null, SuccessConstant.CREATED_DISTRICT, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.CREATED_DISTRICT,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.CREATED,
                    Title = "Created",
                }));

            var ex = await _controller.CreateDistricts(model);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.CREATED_DISTRICT, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestCreateProvince()
        {
            var model = new AddressRequest
            {
                Name = "Jawa Timur"
            };

            _service.CreateProvince(model)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.CREATED, "Created", null, SuccessConstant.CREATED_PROVINCE, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.CREATED_PROVINCE,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.CREATED,
                    Title = "Created",
                }));

            var ex = await _controller.CreateProvince(model);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.CREATED_PROVINCE, (value as MessageDto).MessageEng);
        }
    }
}
