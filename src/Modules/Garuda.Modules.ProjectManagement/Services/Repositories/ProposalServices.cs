// <copyright file="ProposalServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Garuda.Database.Abstract.Contracts;
using Garuda.Filestorage.Exceptions;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Contracts;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;
using Garuda.Infrastructure.Helpers;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Dtos.Requests;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Proposal;
using Garuda.Modules.ProjectManagement.Helper.Interfaces;
using Garuda.Modules.ProjectManagement.Hubs;
using Garuda.Modules.ProjectManagement.Hubs.Contracts;
using Garuda.Modules.ProjectManagement.Models.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Sieve.Services;

namespace Garuda.Modules.ProjectManagement.Services.Repositories
{
    public class ProposalServices : IProposalServices
    {
        private readonly IStorage _iStorage;
        private readonly ILogger _iLogger;
        private readonly IMapper _iMapper;
        private readonly SieveProcessor _sieve;
        private readonly IFileChecker _fileChecker;
        private readonly IHubContext<NotificationHub, INotificationHub> _notifHub;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProposalServices"/> class.
        /// </summary>
        /// <param name="iLogger"></param>
        /// <param name="iMapper"></param>
        /// <param name="iStorage"></param>
        /// <param name="iFileCheker"></param>
        /// <param name="notifHub"></param>
        public ProposalServices(
            IStorage iStorage,
            ILogger<ProposalServices> iLogger,
            IMapper iMapper,
            SieveProcessor sieve,
            IFileChecker iFileCheker,
            IHubContext<NotificationHub, INotificationHub> notifHub)
        {
            _iStorage = iStorage;
            _iLogger = iLogger;
            _iMapper = iMapper;
            _sieve = sieve;
            _fileChecker = iFileCheker;
            _notifHub = notifHub;
        }

        public async Task<MessageDto> GetData(Guid projectId)
        {
            try
            {
                _iLogger.LogInformation("Trying to get proposal data..");
                var proposal = await _iStorage.GetRepository<IProposalRepository>().GetbyProject(projectId);
                var contractInfo = await _iStorage.GetRepository<IContractInfoRepository>().GetbyProject(projectId);
                var proposalAndContract = new ProposalResponses();

                if (proposal == null && contractInfo == null)
                {
                    return new MessageDto(Codes.NOT_FOUND, "Not Found", "Proposal data not found", null, new ProposalResponses());
                }
                else
                {
                    var datas = new ProposalResponses();
                    if (proposal != null)
                    {
                        datas = _iMapper.Map<Proposal, ProposalResponses>(proposal);
                        datas.ProposalUrl = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "media" + Path.DirectorySeparatorChar + "proposal" + Path.DirectorySeparatorChar + proposal.FileName.Substring(proposal.FileName.Length - 18, 6) + Path.DirectorySeparatorChar + proposal.FileName;
                        datas.Remark = datas.Remark == "null" || datas.Remark == null ? null : datas.Remark;
                    }

                    if (contractInfo != null)
                    {
                        datas.ContractId = contractInfo.Id;
                        datas.ClientContractNo = contractInfo.ClientContractNo == "null" || contractInfo.ClientContractNo == null ? null : contractInfo.ClientContractNo;
                        datas.ClientFileNameOri = contractInfo.ClientFileNameOri == "null" || contractInfo.ClientFileNameOri == null ? null : contractInfo.ClientFileNameOri;
                        datas.GikContractNo = contractInfo.GikContractNo == "null" || contractInfo.GikContractNo == null ? null : contractInfo.GikContractNo;
                        datas.GikFileNameOri = contractInfo.GikFileNameOri == "null" || contractInfo.GikFileNameOri == null ? null : contractInfo.GikFileNameOri;
                        datas.OtherInfo = contractInfo.OtherInfo == "null" || contractInfo.OtherInfo == null ? null : contractInfo.OtherInfo;
                        datas.GikFileName = contractInfo.GikFileName == "null" || contractInfo.GikFileName == null ? null : contractInfo.GikFileName;
                        datas.ClientFileName = contractInfo.ClientFileName == "null" || contractInfo.ClientFileName == null ? null : contractInfo.ClientFileName;
                        datas.ClientContractUrl = datas.ClientContractNo == null ? null : Path.Combine(Directory.GetCurrentDirectory(), "media", "proposal", contractInfo.ClientFileName.Substring(contractInfo.ClientFileName.Length - 18, 6), contractInfo.ClientFileName);
                        datas.GikContractlUrl = datas.GikContractNo == null ? null : Path.Combine(Directory.GetCurrentDirectory(), "media", "proposal", contractInfo.GikFileName.Substring(contractInfo.GikFileName.Length - 18, 6), contractInfo.GikFileName);
                    }

                    datas.ProjectId = projectId;

                    _iLogger.LogInformation($"Data has been fetched.");
                    return new MessageDto(Codes.SUCCESS, "Found", SuccessConstant.FOUND_PROPOSAL, null, datas);
                }
            }
            catch (Infrastructure.Exceptions.BadRequestException ex)
            {
                _iLogger.LogInformation($"Failed to fetching proposal, err : {ex}");
                throw new Infrastructure.Exceptions.BadRequestException();
            }
        }

        public async Task<MessageDto> CreateData(CreateProposalRequest model, Guid userId)
        {
            try
            {
                if (model == null)
                {
                    throw new Infrastructure.Exceptions.BadRequestException();
                }

                if (model.ProjectAmount < 0)
                {
                    throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.PROJECT_AMOUNT;
                }

                var newDirectory = Path.Combine(Directory.GetCurrentDirectory(), "media", "proposal", DateTime.Now.Date.ToString("yyyyMM"));
                if (!Directory.Exists(newDirectory))
                {
                    Directory.CreateDirectory(newDirectory);
                }

                if (await _iStorage.GetRepository<IProposalRepository>().IsRegisteredDocumentNo(model.DocumentNo, model.ProjectId))
                {
                    throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.CONFLICT_DOCUMENT_NO;
                }

                var proposal = await _iStorage.GetRepository<IProposalRepository>().GetbyProject(model.ProjectId);
                if (model.FileProposal != null)
                {
                    if (!_fileChecker.IsValidSize(model.FileProposal))
                    {
                        throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.FILE_UPLOAD_SIZE;
                    }

                    var fileName = model.FileProposal.FileName + _fileChecker.GenerateUniqFileName(model.FileProposal);
                    var itemPath = Path.Combine(newDirectory, fileName.Trim('/'));
                    var itemFile = File.Create(itemPath);
                    await model.FileProposal.CopyToAsync(itemFile);
                    itemFile.Close();

                    model.FileNameOri = model.FileProposal.FileName == null ? null : model.FileProposal.FileName;
                    model.FileName = fileName;

                    var proposalData = _iMapper.Map<CreateProposalRequest, Proposal>(model);
                    await _iStorage.GetRepository<IProposalRepository>().AddOrUpdate(proposalData);
                    var proposalHistoryData = _iMapper.Map<CreateProposalRequest, ProposalHistory>(model);
                    proposalHistoryData.ProposalNo = proposalData.DocumentNo;
                    await _iStorage.GetRepository<IProposalHistoryRepository>().AddData(proposalHistoryData);
                }
                else if (proposal != null)
                {
                    proposal.DocumentNo = model.DocumentNo;
                    proposal.ProjectAmount = (decimal)model.ProjectAmount;
                    proposal.SentDate = (DateTime)model.SentDate;
                    proposal.Remark = model.Remark;

                    await _iStorage.GetRepository<IProposalRepository>().AddOrUpdate(proposal);
                }

                var contractInfo = await _iStorage.GetRepository<IContractInfoRepository>().GetbyProject(model.ProjectId);
                if (model.FileGIKContract != null)
                {
                    if (await _iStorage.GetRepository<IContractInfoRepository>().IsRegisteredGarudaContractNo(model.GikContractNo, model.ProjectId))
                    {
                        throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.CONFLICT_GIK_CONTRACT_NO;
                    }

                    if (!_fileChecker.IsValidSize(model.FileGIKContract))
                    {
                        throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.FILE_UPLOAD_SIZE;
                    }

                    var fileName = model.FileGIKContract.FileName + _fileChecker.GenerateUniqFileName(model.FileGIKContract);
                    var itemPath = Path.Combine(newDirectory, fileName.Trim('/'));
                    var itemFile = File.Create(itemPath);
                    await model.FileGIKContract.CopyToAsync(itemFile);
                    itemFile.Close();

                    model.GikFileNameOri = model.FileGIKContract.FileName == null ? null : model.FileGIKContract.FileName;
                    model.GikFileName = fileName;
                }
                else if (contractInfo != null)
                {
                    model.GikFileNameOri = contractInfo.GikFileNameOri;
                    model.GikFileName = contractInfo.GikFileName;
                }

                if (model.FileClientContract != null)
                {
                    if (await _iStorage.GetRepository<IContractInfoRepository>().IsRegisteredClientContractNo(model.ClientContractNo, model.ProjectId))
                    {
                        throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.CONFLICT_CLIENT_CONTRACT_NO;
                    }

                    if (!_fileChecker.IsValidSize(model.FileClientContract))
                    {
                        throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.FILE_UPLOAD_SIZE;
                    }

                    var fileName = model.FileClientContract.FileName + _fileChecker.GenerateUniqFileName(model.FileClientContract);
                    var itemPath = Path.Combine(newDirectory, fileName.Trim('/'));
                    var itemFile = File.Create(itemPath);
                    await model.FileClientContract.CopyToAsync(itemFile);
                    itemFile.Close();

                    model.ClientFileNameOri = model.FileClientContract.FileName == null ? null : model.FileClientContract.FileName;
                    model.ClientFileName = fileName;
                }
                else if (contractInfo != null)
                {
                    model.ClientFileNameOri = contractInfo.ClientFileNameOri;
                    model.ClientFileName = contractInfo.ClientFileName;
                }

                var contractData = _iMapper.Map<CreateProposalRequest, ContractInfo>(model);
                await _iStorage.GetRepository<IContractInfoRepository>().AddOrUpdate(contractData);

                _iLogger.LogInformation("Saving proposal to database..");
                await _iStorage.SaveAsync();

                _iLogger.LogInformation("Saving proposal status to database..");
                var projectHistory = new ProjectHistory()
                {
                    ProjectId = model.ProjectId,
                    Status = AppConstant.ProposalSubmitted,
                };
                await _iStorage.GetRepository<IProjectDetailRepository>().UpdateStatus(model.ProjectId, AppConstant.ProposalSubmitted);
                await _iStorage.GetRepository<IProjectHistoryRepository>().AddData(projectHistory);
                await _iStorage.SaveAsync();

                // send notification to client
                _iLogger.LogInformation($"Create notification");
                var employe = await _iStorage.GetRepository<IEmployeeRepository>().GetDataByUserId(userId);
                var project = await _iStorage.GetRepository<IProjectDetailRepository>().GetById(model.ProjectId);
                var message = AppConstant.UserUpdateStatusProject;
                message = message.Replace("ProjectName", project.Name);
                message = message.Replace("ProjectStatus", AppConstant.ProposalSubmitted);
                message = message.Replace("EmployeeName", employe?.Fullname);

                var notif = new Notification
                {
                    Message = message,
                    ProjectId = model.ProjectId,
                    EmployeeId = employe?.Id,
                };
                await _iStorage.GetRepository<INotificationRepository>().AddOrUpdate(notif);
                await _iStorage.SaveAsync();

                _iLogger.LogInformation($"Send notification to all client");
                await _notifHub.Clients.All.ReceiveMessage(new Notification
                {
                    Id = notif.Id,
                    Message = notif.Message,
                    ProjectId = notif.ProjectId,
                    EmployeeId = notif?.EmployeeId,
                });

                return new MessageDto(Codes.CREATED, "Created", "Proposal has been uploaded", null, model);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to save proposal, err : {ex}");
                throw ex;
            }
        }

        public async Task<MessageDto> GetHistory(Guid projectId)
        {
            try
            {
                _iLogger.LogInformation("Trying to get proposal history data..");
                var proposalHistories = await _iStorage.GetRepository<IProposalHistoryRepository>().GetbyProject(projectId);

                if (proposalHistories == null)
                {
                    return new MessageDto(Codes.NOT_FOUND, "Not Found", "Proposal historydata not found", null, new ProposalHistory());
                }
                else
                {
                    _iLogger.LogInformation($"Data has been fetched.");
                    return new MessageDto(Codes.SUCCESS, "Found", SuccessConstant.FOUND_PROPOSAL_HISTORY, null, proposalHistories);
                }
            }
            catch (Infrastructure.Exceptions.BadRequestException ex)
            {
                _iLogger.LogInformation($"Failed to fetching proposal history, err : {ex}");
                throw new Infrastructure.Exceptions.BadRequestException();
            }
        }

        public (string path, string contextType, string fileName) Download(string fileName)
        {
            var fileDate = fileName.Substring(fileName.LastIndexOf('_') + 1, 6);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "media", "proposal", fileDate, fileName);

            FileInfo fileInfo = new FileInfo(path);
            var fileExt = fileInfo.Extension;

            string contextType = FileHelper.GetFileContextType(fileExt);

            return (path, contextType, fileName);
        }
    }
}
