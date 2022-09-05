// <copyright file="ProjectFileServices.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Garuda.Infrastructure.Dtos;
using Garuda.Modules.ProjectManagement.Models.Contracts;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Garuda.Database.Abstract.Contracts;
using Garuda.Filestorage.Exceptions;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Helpers;
using Garuda.Modules.ProjectManagement.Constants;
using Garuda.Modules.ProjectManagement.Dtos.Responses.ProjectFile;
using Garuda.Modules.ProjectManagement.Dtos.Requests.ProjectFile;
using Garuda.Modules.ProjectManagement.Dtos.Requests.FileUpload;
using Garuda.Modules.ProjectManagement.Services.Contracts;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sieve.Services;
using Garuda.Modules.ProjectManagement.Dtos.Responses.File;
using Garuda.Modules.ProjectManagement.Helper.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Garuda.Modules.ProjectManagement.Services.Repositories
{
    public class ProjectFileServices : IProjectFileServices
    {
        private readonly IStorage _iStorage;
        private readonly ILogger _iLogger;
        private readonly IMapper _iMapper;
        private readonly SieveProcessor _sieve;
        private readonly IHostEnvironment _hostingEnvironment;
        private readonly IFileChecker _fileChecker;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectFileServices"/> class.
        /// </summary>
        /// <param name="iLogger"></param>
        /// <param name="iMapper"></param>
        /// <param name="iStorage"></param>
        /// <param name="iFileCheker"></param>
        /// <param name="iHostingEnvironment"></param>
        /// <param name="sieve"></param>
        /// <param name="iConfiguration"></param>
        public ProjectFileServices(
            IStorage iStorage,
            ILogger<ProjectFileServices> iLogger,
            IMapper iMapper,
            SieveProcessor sieve,
            IHostEnvironment iHostingEnvironment,
            IFileChecker iFileCheker,
            IConfiguration iConfiguration)
        {
            _iStorage = iStorage;
            _iLogger = iLogger;
            _iMapper = iMapper;
            _sieve = sieve;
            _hostingEnvironment = iHostingEnvironment;
            _fileChecker = iFileCheker;
            _configuration = iConfiguration;
        }

        public async Task<MessageDto> GetData(Guid projectId, string projectCode)
        {
            try
            {
                _iLogger.LogInformation("Trying to get project file data..");
                var projectFiles = await _iStorage.GetRepository<IProjectFileRepository>().GetbyProject(projectId);

                if (projectFiles.Count() <= 0)
                {
                    return new MessageDto(Codes.NOT_FOUND, "Not Found", "Project file data not found", null, new ProjectFileResponses());
                }
                else
                {
                    var datas = _iMapper.Map<List<ProjectFileResponses>>(projectFiles);

                    datas.ForEach(d =>
                    {
                        if (d.FileSource != "Link")
                        {
                            d.FileUrl = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "media" + Path.DirectorySeparatorChar + "projectfiles" + projectCode + Path.DirectorySeparatorChar + d.FileName;
                        }

                        d.ProjectId = projectId;
                    });

                    _iLogger.LogInformation($"Data has been fetched.");
                    return new MessageDto(Codes.SUCCESS, "Found", SuccessConstant.FOUND_PROJECT_FILE, null, datas);
                }
            }
            catch (Infrastructure.Exceptions.BadRequestException ex)
            {
                _iLogger.LogInformation($"Failed to fetching proposal, err : {ex}");
                throw new Infrastructure.Exceptions.BadRequestException();
            }
        }

        public async Task<MessageDto> CreateData(Guid projectId, string projectCode, List<CreateProjectFileRequest> model)
        {
            try
            {
                if (model != null)
                {
                    foreach (var file in model)
                    {
                        if (file?.FileUploads != null)
                        {
                            ValidateFile(file.FileUploads);
                        }
                    }
                }
                else
                {
                    throw new Infrastructure.Exceptions.BadRequestException();
                }

                var newDirectory = Path.Combine(_hostingEnvironment.ContentRootPath, "media", "projectfiles", projectCode);

                if (!Directory.Exists(newDirectory))
                {
                    Directory.CreateDirectory(newDirectory);
                }

                var projectFileList = new List<ProjectFile>();

                foreach (var file in model)
                {
                    if (file.FileSource != "Link")
                    {
                        var projectFileData = _iMapper.Map<CreateProjectFileRequest, ProjectFile>(file);
                        if (projectFileData != null)
                        {
                            var fileName = file.FileUploads.FileName + _fileChecker.GenerateUniqFileName(file.FileUploads);
                            var itemPath = Path.Combine(newDirectory, fileName.Trim('/'));
                            var itemFile = File.Create(itemPath);
                            await file.FileUploads.CopyToAsync(itemFile);
                            itemFile.Close();

                            projectFileData.ProjectId = projectId;
                            projectFileData.FileNameOri = file.FileUploads.FileName;
                            projectFileData.FileName = fileName;
                            projectFileData.Link = null;
                            await _iStorage.GetRepository<IProjectFileRepository>().AddOrUpdate(projectFileData, projectCode);

                            projectFileList.Add(projectFileData);
                        }
                    }
                    else
                    {
                        var projectFileData = _iMapper.Map<CreateProjectFileRequest, ProjectFile>(file);
                        if (projectFileData != null)
                        {
                            projectFileData.ProjectId = projectId;
                            await _iStorage.GetRepository<IProjectFileRepository>().AddOrUpdate(projectFileData, projectCode);
                            projectFileList.Add(projectFileData);
                        }
                    }
                }

                _iLogger.LogInformation("Saving new project file to database..");
                await _iStorage.SaveAsync();

                return new MessageDto(Codes.CREATED, "Created", "Project File has been save", null, projectFileList);

            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to save project file, err : {ex}");
                throw ex;
            }
        }

        public async Task<MessageDto> EditData(Guid projectId, string projectCode, List<EditProjectFileRequest> model)
        {
            try
            {
                if (model != null)
                {
                    foreach (var file in model)
                    {
                        if (file.IsUpdated || file.Id == null)
                        {
                            if (file?.FileUploads != null)
                            {
                                ValidateFile(file.FileUploads);
                            }
                        }
                    }
                }
                else
                {
                    throw new Infrastructure.Exceptions.BadRequestException();
                }

                var newDirectory = Path.Combine(_hostingEnvironment.ContentRootPath, "media", "projectfiles", projectCode);

                if (!Directory.Exists(newDirectory))
                {
                    Directory.CreateDirectory(newDirectory);
                }

                var projectFilesList = new List<ProjectFile>();

                var projectFileIds = await _iStorage.GetRepository<IProjectFileRepository>().GetAllIdbyProject(projectId);
                foreach (var projectFile in model)
                {
                    var projectFileData = _iMapper.Map<EditProjectFileRequest, ProjectFile>(projectFile);
                    if (projectFileData != null)
                    {
                        if (projectFile.FileSource != "Link")
                        {
                            if (projectFile.IsUpdated || projectFile.Id == null)
                            {
                                var fileName = projectFile.FileUploads.FileName + _fileChecker.GenerateUniqFileName(projectFile.FileUploads);
                                var itemPath = Path.Combine(newDirectory, fileName.Trim('/'));
                                var itemFile = File.Create(itemPath);
                                await projectFile.FileUploads.CopyToAsync(itemFile);
                                itemFile.Close();

                                projectFileData.ProjectId = projectId;
                                projectFileData.FileNameOri = projectFile.FileUploads.FileName;
                                projectFileData.FileName = fileName;
                                projectFileData.Link = null;
                                await _iStorage.GetRepository<IProjectFileRepository>().AddOrUpdate(projectFileData, projectCode);
                                projectFilesList.Add(projectFileData);
                            }
                        }
                        else
                        {
                            projectFileData.ProjectId = projectId;
                            await _iStorage.GetRepository<IProjectFileRepository>().AddOrUpdate(projectFileData, projectCode);
                            projectFilesList.Add(projectFileData);
                        }
                    }
                }

                var deletedFiles = projectFileIds?.Where(p => !model.Any(p2 => p2.Id == p)).ToList();
                if(deletedFiles != null)
                {
                    foreach (var deletedFile in deletedFiles)
                    {
                        await _iStorage.GetRepository<IProjectFileRepository>().Delete(deletedFile, projectCode);
                    }
                }

                _iLogger.LogInformation("Updating project file to database..");
                await _iStorage.SaveAsync();

                return new MessageDto(Codes.CREATED, "Updated", "Project File has been updated", null, projectFilesList);
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to update project file, err : {ex}");
                throw ex;
            }
        }

        public void ValidateFile(IFormFile file)
        {
            var fileTypes = _configuration.GetSection("UploadFileTypes").Get<List<string>>();

            if (!_fileChecker.IsValidType(file))
            {
                _iLogger.LogInformation($"Failed to save File");
                throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.FILE_UPLOAD_TYPE;
            }

            if (!_fileChecker.IsValidSize(file))
            {
                _iLogger.LogInformation($"Failed to save File");
                throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.FILE_UPLOAD_SIZE;
            }
        }

        public async Task<FileResponse> Download(string fileName)
        {
            // code below (original code from author) has change to new code to see whts wrong on server.
            // Later need to remove old code, if that new code has solved the issued.
            // string path = Path.Combine(Directory.GetCurrentDirectory(), "media" + Path.DirectorySeparatorChar + "projectfiles" + Path.DirectorySeparatorChar + projectCode + Path.DirectorySeparatorChar + fileName);
            // FileInfo fileInfo = new FileInfo(path);
            // var fileExt = fileInfo.Extension;
            // string contextType = FileHelper.GetFileContextType(fileExt);
            // string savedFileName = fileName.Substring(fileName.IndexOf('-') + 1);
            // return (path, contextType, savedFileName);
            try
            {
                var (originalFileName, projectCode) = await _iStorage.GetRepository<IProjectFileRepository>().GetOriginalFileName(fileName);

                var mediaPath = Path.Combine(_hostingEnvironment.ContentRootPath, "media", "projectfiles", projectCode, fileName);

                if (mediaPath == null || originalFileName == null)
                {
                    throw Garuda.Modules.ProjectManagement.Constants.ErrorConstant.PROJECT_FILE_NOT_FOUND;
                }

                FileInfo file = new FileInfo(mediaPath);
                return new FileResponse
                {
                    NameFile = originalFileName,
                    ContentType = _fileChecker.GetContentType(file.Extension.TrimStart(new Char[] { '.' })),
                    PathFile = mediaPath,
                };
            }
            catch (Exception ex)
            {
                _iLogger.LogInformation($"Failed to download Project File, err : {ex}");
                throw;
            }
        }
    }
}
