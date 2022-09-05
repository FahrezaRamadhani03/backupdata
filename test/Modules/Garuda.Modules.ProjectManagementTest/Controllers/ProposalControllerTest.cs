// <copyright file="ProposalControllerTest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Controllers;
using Garuda.Modules.ProjectManagement.Dtos.Requests;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Proposal;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using Sieve.Models;

namespace Garuda.Modules.ProjectManagementTest.Controllers
{
    internal class ProposalControllerTest
    {
        private IProposalServices _service;
        private ProposalController _controller;
        private List<CreateProposalRequest> _createProposalRequest;

        [SetUp]
        public void Setup()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "070173ab-743b-423b-9370-b88c3c839bcb"),
            }, "mock"));

            _service = Substitute.For<IProposalServices>();
            _controller = new ProposalController(_service);

            _controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };
        }

        [Test]
        public async Task TestGetProposalAsync()
        {
            Guid projectId = Guid.Parse("9245fe4a-d402-451c-b9ed-9c1a04247482");
            ProposalResponses _proposal = new ProposalResponses()
            {
                Id = 2,
                ProjectId = Guid.Parse("cbaed6ce-4cfe-41ab-8763-4ba265b82890"),
                DocumentNo = "DOC/GIK/1/2022",
                ProjectAmount = 100000000,
                SentDate = new DateTime(2022, 04, 20, 00, 00, 00, 000),
                FileNameOri = "asdf123-proposal.pdf",
                Remark = null,
                ProposalUrl = "file:///E:/internal-project-be/internal-project-be/src/Host/media/proposal/202205/20220517095139-ini-proposal.pdf",
                ContractId = 2,
                GikContractNo = null,
                ClientContractNo = "CONTRACT01",
                GikFileNameOri = null,
                ClientFileNameOri = "ghjkl456-client-contract.pdf",
                GikContractlUrl = null,
                ClientContractUrl = "file:///E:/internal-project-be/internal-project-be/src/Host/media/proposal/202205/20220517095139-ini-proposal.pdf",
                OtherInfo = "string"
            };

            _service.GetData(projectId)
                .Returns(Task.FromResult(new MessageDto(200, "Found", null, SuccessConstant.FOUND_PROPOSAL, _proposal)
                {
                    Title = "Found",
                    Status = 200,
                    MessageIdn = null,
                    MessageEng = SuccessConstant.FOUND_PROPOSAL,
                    Data = _proposal,
                }));

            var ex = await _controller.GetData(projectId);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual("Found", (value as MessageDto).Title);
        }

        [Test]
        public async Task TestAddProposalSuccess()
        {
            var newProposal = new CreateProposalRequest
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
            };

            _service.CreateData(newProposal, Guid.Parse("070173ab-743b-423b-9370-b88c3c839bcb"))
                .Returns(Task.FromResult(new MessageDto(201, "Created", null, "Proposal has been uploaded", newProposal)
                {
                    Title = "Created",
                    Status = 201,
                    MessageIdn = null,
                    MessageEng = "Proposal has been uploaded",
                    Data = newProposal,
                }));

            var ex = await _controller.CreateProposal(newProposal);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual("Created", (value as MessageDto).Title);
        }

        [Test]
        public async Task TestGetProposalHistory()
        {
            var projectId = Guid.Parse("cbaed6ce-4cfe-41ab-8763-4ba265b82890");
            _service.GetHistory(projectId)
                .Returns(Task.FromResult(new MessageDto(Infrastructure.Constants.Codes.SUCCESS, "Found", null, SuccessConstant.FOUND_PROPOSAL_HISTORY, null)
                {
                    Data = null,
                    MessageEng = SuccessConstant.FOUND_PROPOSAL_HISTORY,
                    MessageIdn = null,
                    Status = Infrastructure.Constants.Codes.SUCCESS,
                    Title = "Found",
                }));

            var ex = await _controller.GetHistory(projectId);
            Assert.IsInstanceOf<OkObjectResult>(ex);
            var value = (ex as OkObjectResult).Value;
            Assert.AreEqual(SuccessConstant.FOUND_PROPOSAL_HISTORY, (value as MessageDto).MessageEng);
        }
    }
}
