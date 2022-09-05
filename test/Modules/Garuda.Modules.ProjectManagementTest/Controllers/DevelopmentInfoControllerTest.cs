using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Controllers;
using Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentInfo;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;

namespace Garuda.Modules.ProjectManagementTest.Controllers
{
    internal class DevelopmentInfoControllerTest
    {
        private IDevelopmentInfoServices _service;
        private DevelopmentInfoController _controller;
        private CreateDevelopmentInfoRequest _createDevelopmetInfoRequest;
        private EditDevelopmentInfoRequest _editDevelopmetInfoRequest;

        [SetUp]
        public void Setup()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "cabc4be9-36c8-4e63-b2f4-477bdbdb0139"),
            }, "mock"));

            _service = Substitute.For<IDevelopmentInfoServices>();
            _controller = new DevelopmentInfoController(_service);

            _controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };
        }
        [Test]
        public async Task TestGetDayOfSprint()
        {

            _service.GetDayOfSprint()
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_DAY_OF_SPRINT, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.FOUND_DAY_OF_SPRINT,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Found",
                }));

            var ex = await _controller.GetDayOfSprint();
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.FOUND_DAY_OF_SPRINT, (value as MessageDto).MessageEng);
        }
        [Test]
        public async Task TestGetHolidays()
        {
            DateTime start = new DateTime(2022, 01, 01, 00, 00, 00, 000);
            DateTime end = new DateTime(2022, 12, 31, 00, 00, 00, 000);
            _service.GetHolidays(start, end)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_HOLIDAYS, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.FOUND_HOLIDAYS,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Found",
                }));

            var ex = await _controller.GetHolidays(start, end);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            //Assert.IsNull(value);
            Assert.AreEqual(SuccessConstant.FOUND_HOLIDAYS, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestCreateData()
        {
            _createDevelopmetInfoRequest = new CreateDevelopmentInfoRequest()
            {
                ProjectId = Guid.Parse("cabc4be9-36c8-4e63-b2f4-477bdbdb0139"),
                DevelopmentMethod = "scrum",
                Quantity = 1,
                DayOfSprint = "5",
                KickoffDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                DevelopmentStart = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                DevelopmentEnd = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                SprintDates = new List<DevelopmentSprintDateRequest> { 
                    new DevelopmentSprintDateRequest
                    {
                        DayLength = 4, HolidayLength =1,
                        SprintEnd = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                        SprintStart = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                        SprintName = "1", Holidays = new List<HolidayRequest> 
                        { 
                            new HolidayRequest 
                            { 
                                Date = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                                Description = "Libur hangout garuda" 
                            } 
                        } 
                    } 
                },
                MaintenanceEnd = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                MaintenanceLength = 5,
                MaintenanceStart = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                DevelopmentUnit = "days",
            };

            _service.CreateData(_createDevelopmetInfoRequest, Guid.Parse("cabc4be9-36c8-4e63-b2f4-477bdbdb0139"))
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Created", null, SuccessConstant.CREATED_DEVELOPMENT_INFO, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.CREATED_DEVELOPMENT_INFO,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.CREATED,
                    Title = "Created",
                }));

            var ex = await _controller.CreateData(_createDevelopmetInfoRequest);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.CREATED_DEVELOPMENT_INFO, (value as MessageDto).MessageEng);
        }
        [Test]
        public async Task TestEditData()
        {
            _editDevelopmetInfoRequest = new EditDevelopmentInfoRequest()
            {
                ProjectId = Guid.Parse("cabc4be9-36c8-4e63-b2f4-477bdbdb0139"),
                DevelopmentMethod = "scrum",
                Quantity = 1,
                DayOfSprint = "5",
                KickoffDate = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                DevelopmentStart = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                DevelopmentEnd = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                SprintDates = new List<DevelopmentSprintDateRequest> {
                    new DevelopmentSprintDateRequest
                    {
                        DayLength = 4, HolidayLength =1,
                        SprintEnd = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                        SprintStart = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                        SprintName = "1", Holidays = new List<HolidayRequest>
                        {
                            new HolidayRequest
                            {
                                Date = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                                Description = "Libur hangout garuda"
                            }
                        }
                    }
                },
                MaintenanceEnd = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                MaintenanceLength = 5,
                MaintenanceStart = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                DevelopmentUnit = "days",
            };

            _service.EditData(_editDevelopmetInfoRequest)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Updated", null, SuccessConstant.UPDATE_DEVELOPMENT_INFO, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.UPDATE_DEVELOPMENT_INFO,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Updated",
                }));

            var ex = await _controller.EditeData(_editDevelopmetInfoRequest);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.UPDATE_DEVELOPMENT_INFO, (value as MessageDto).MessageEng);
        }
        [Test]
        public async Task TestGetData()
        {
            var id = Guid.Parse("cabc4be9-36c8-4e63-b2f4-477bdbdb0139");

            _service.GetData(id)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_DEVELOPMENT_INFO, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.FOUND_DEVELOPMENT_INFO,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Found",
                }));

            var ex = await _controller.GetData(id);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.FOUND_DEVELOPMENT_INFO, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestGetSprintList()
        {
            var projectId = Guid.Parse("cbaed6ce-4cfe-41ab-8763-4ba265b82890");
            _service.GetSprintList(projectId)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_SPRINT_LIST, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.FOUND_SPRINT_LIST,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Found",
                }));

            var ex = await _controller.GetSprintList(projectId);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.FOUND_SPRINT_LIST, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestAddExtendDays()
        {
            var projectId = Guid.Parse("cbaed6ce-4cfe-41ab-8763-4ba265b82890");
            var extendDays = new AddExtendDaysRequest
            {
                Days = 1,
                ProjectId = projectId,
                Descriptions = "Extend days",
            };
            _service.AddExtendDays(extendDays)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.CREATED, "Created", null, SuccessConstant.CREATE_EXTEND_DAYS, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.CREATE_EXTEND_DAYS,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.CREATED,
                    Title = "Created",
                }));

            var ex = await _controller.AddExtendDays(extendDays);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.CREATE_EXTEND_DAYS, (value as MessageDto).MessageEng);
        }

        [Test]
        public async Task TestEditSprint()
        {
            var projectId = Guid.Parse("cbaed6ce-4cfe-41ab-8763-4ba265b82890");
            var sprint = new EditSprintRequest
            {
                ProjectId = projectId,
                DayLength = 3,
                HolidayLength = 1,
                Holidays = new List<HolidayRequest>
                   {
                       new HolidayRequest
                        {
                         Date = new DateTime(2022, 04, 11, 00, 00, 00, 000),
                         Description = "Ultah Reza",
                        }
                   },
                Remarks = "test remaks",
                SprintEnd = new DateTime(2022, 04, 14, 00, 00, 00, 000),
                SprintStart = new DateTime(2022, 04, 11, 00, 00, 00, 000),
            };
            _service.EditSprint(sprint, Guid.Parse("cbaed6ce-4cfe-41ab-8763-4ba265b82891"))
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Updated", null, SuccessConstant.UPDATED_SPRINT_DAYS, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.UPDATED_SPRINT_DAYS,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Updated",
                }));

            var ex = await _controller.EditSprint(sprint, Guid.Parse("cbaed6ce-4cfe-41ab-8763-4ba265b82891"));
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.UPDATED_SPRINT_DAYS, (value as MessageDto).MessageEng);
        }
    }
}
