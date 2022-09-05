// <copyright file="FileStorageProvider.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Threading.Tasks;
using Garuda.Filestorage.Configurations;
using Garuda.Filestorage.Contracts;
using Garuda.Filestorage.Exceptions;
using Garuda.Filestorage.Helper;
using Garuda.Filestorage.Requests;
using Garuda.Filestorage.Responses;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Microsoft.Identity.Client;

namespace Garuda.Filestorage.OneDrive.Services
{
    public class FileStorageProvider : IFileStorageProvider
    {
        private readonly string userName;
        private readonly SecureString userPassword;
        private readonly FileStorageOptions _onedriveConfig;
        private readonly ICollection<GetFileResponse> _listItem = new List<GetFileResponse> { };
        private readonly GraphServiceClient info;
        private readonly IPublicClientApplication _clientApplication;
        private string[] _scopes;
        private IDriveItemRequestBuilder request;

        public FileStorageProvider(IOptions<FileStorageOptions> onedriveConfig)
        {
            var timeoutConfig = 5;
            _onedriveConfig = onedriveConfig.Value;
            _clientApplication = PublicClientApplicationBuilder.Create(_onedriveConfig.ApplicationId)
                                                    .WithAuthority($"https://login.microsoftonline.com/{_onedriveConfig.TenantId}/v2.0")
                                                    .Build();
            userName = _onedriveConfig.UserId;
            userPassword = new NetworkCredential(string.Empty, _onedriveConfig.Password).SecurePassword;

            var setting = LoadAppSettings(_onedriveConfig);
            info = GetAuthenticatedGraphClient(setting, userName, userPassword);

            info.HttpProvider.OverallTimeout = TimeSpan.FromMinutes(timeoutConfig);
        }

        public GraphServiceClient GetClient()
        {
            return info;
        }

        public async Task<string> GetToken()
        {
            var result = await _clientApplication.AcquireTokenByUsernamePassword(_scopes, userName, userPassword).ExecuteAsync();

            return result.AccessToken;
        }

        // Check loggen in user by configuration
        public async Task<User> CheckLoggedInUser()
        {
            try
            {
                var request = await info.Me.Request().GetAsync();

                if (request != null)
                {
                    await System.IO.File.WriteAllTextAsync("token.txt", await GetToken());
                    return request;
                }

                return null;
            }
            catch
            {
                string msg = "Username atau password salah";
                string msgEn = "Wrong username or password";
                MessageLangDto message = new MessageLangDto(msg, msgEn);
                throw new UnauthorizedException(message);
            }
        }

        public async Task<string> UploadFile(FileUploadFormRequest file)
        {
            var maxUploadSize = (long)Convert.ToDouble(_onedriveConfig.MaxUploadSize);
            var fileSize = file.FormFile.Length;
            if (fileSize <= maxUploadSize)
            {
                var fileName = file.Name + Path.GetExtension(file.FormFile.FileName);
                var currentFolder = System.IO.Directory.GetCurrentDirectory() + "/" + file.Path;
                var filePath = Path.Combine(currentFolder, fileName);
                DriveItem uploadedFile = new DriveItem();
                UploadSession uploadSession = new UploadSession();

                // upload file with size less than 4 MB
                if (fileSize < FileConstant.SESSION_UPLOAD_SIZE)
                {
                    FileStream fileStream = new FileStream(filePath, FileMode.Open);

                    if (file.ParentPathID != string.Empty)
                    {
                        try
                        {
                            // upload file to user root folder
                            uploadedFile = file.ChildrenPathID == null ?
                                  info.Me.Drive.Root // Upload file to a root directory
                                 .ItemWithPath(fileName).Content.Request()
                                 .PutAsync<DriveItem>(fileStream).Result :
                                  info.Me.Drive.Items[file.ChildrenPathID] // Upload file to a children directory
                                 .ItemWithPath(fileName).Content.Request()
                                 .PutAsync<DriveItem>(fileStream).Result;
                        }
                        catch
                        {
                            string msg = "Server terlalu lama merespons, silakan coba lagi";
                            string msgEn = "Server is taking too long to respond, please try again";
                            var message = new MessageLangDto(msg, msgEn);
                            throw new RequestTimeoutException(message);
                        }
                    }
                    else
                    {
                        try
                        {
                            // upload file to other folder by Id
                            uploadedFile = file.ChildrenPathID != null ?
                                 info.Me.Drives[file.ParentPathID] // Upload file to a children directory
                                .Items[file.ChildrenPathID]
                                .ItemWithPath(fileName).Content.Request()
                                .PutAsync<DriveItem>(fileStream).Result :
                                 info.Me.Drives[file.ParentPathID] // Upload file to a root directory
                                .Root
                                .ItemWithPath(fileName).Content.Request()
                                .PutAsync<DriveItem>(fileStream).Result;
                        }
                        catch
                        {
                            string msg = "Server terlalu lama merespons, silakan coba lagi";
                            string msgEn = "Server is taking too long to respond, please try again";
                            var message = new MessageLangDto(msg, msgEn);
                            throw new RequestTimeoutException(message);
                        }
                    }

                    return "File Uploaded";
                }

                // upload file with size more than 4 MB
                if (file.ParentPathID != string.Empty)
                {
                    using (Stream fileStream = new FileStream(filePath, FileMode.Open))
                    {
                        try
                        {
                            // upload file to user folder
                            uploadSession = file.ChildrenPathID != null ?
                                 info.Me.Drive.Items[file.ChildrenPathID] // Upload file to a children directory
                                .ItemWithPath(fileName)
                                .CreateUploadSession()
                                .Request().PostAsync()
                                .Result :
                                 info.Me.Drive.Root.ItemWithPath(fileName) // Upload file to a root directory
                                .CreateUploadSession()
                                .Request().PostAsync()
                                .Result;

                            var maxChunkSize = 320 * 1024;
                            var largeUploadTask = new LargeFileUploadTask<DriveItem>(uploadSession, fileStream, maxChunkSize);

                            // show upload progress on console
                            IProgress<long> uploadProgress = new Progress<long>();

                            UploadResult<DriveItem> uploadResult = largeUploadTask.UploadAsync(uploadProgress).Result;
                            if (uploadResult.UploadSucceeded)
                            {
                                return "File uploaded to user's OneDrive root folder.";
                            }
                        }
                        catch
                        {
                            string msg = "Server terlalu lama merespons, silakan coba lagi";
                            string msgEn = "Server is taking too long to respond, please try again";
                            var message = new MessageLangDto(msg, msgEn);
                            throw new RequestTimeoutException(message);
                        }
                    }
                }
                else
                {
                    using (Stream fileStream = new FileStream(filePath, FileMode.Open))
                    {
                        try
                        {
                            // upload file to other folder by id
                            uploadSession = file.ChildrenPathID != null ?
                                 info.Me.Drives[file.ParentPathID] // Upload file to a children directory
                                .Items[file.ChildrenPathID]
                                .ItemWithPath(fileName)
                                .CreateUploadSession()
                                .Request().PostAsync()
                                .Result :
                                 info.Me.Drives[file.ParentPathID] // Upload file to a root directory
                                .Root
                                .ItemWithPath(fileName)
                                .CreateUploadSession()
                                .Request().PostAsync()
                                .Result;

                            var maxChunkSize = 320 * 1024;
                            var largeUploadTask = new LargeFileUploadTask<DriveItem>(uploadSession, fileStream, maxChunkSize);

                            // show upload progress on console
                            IProgress<long> uploadProgress = new Progress<long>();

                            UploadResult<DriveItem> uploadResult = largeUploadTask.UploadAsync(uploadProgress).Result;
                            if (uploadResult.UploadSucceeded)
                            {
                                return "File uploaded to user's OneDrive root folder.";
                            }
                        }
                        catch
                        {
                            string msg = "Server terlalu lama merespons, silakan coba lagi";
                            string msgEn = "Server is taking too long to respond, please try again";
                            var message = new MessageLangDto(msg, msgEn);
                            throw new RequestTimeoutException(message);
                        }
                    }
                }

                return "File uploaded";
            }
            else
            {
                string msg = "Ukuran upload file melebihi batas ukuran file server.";
                string msgEn = "Size of a request exceeds the server's file size limit.";
                var message = new MessageLangDto(msg, msgEn);
                throw new PayloadTooLargeException(message);
            }
        }

        public async Task<string> UploadFileByString(FileUploadBase64Request file)
        {
            var maxUploadSize = (long)Convert.ToDouble(_onedriveConfig.MaxUploadSize);
            var (data, type) = FileHelper.GetFileDetail(file.Base64);
            var fileSize = data.Length;
            if (fileSize <= maxUploadSize)
            {
                var fileName = file.Name + type;
                var currentFolder = System.IO.Directory.GetCurrentDirectory() + "/" + file.Path;
                System.IO.File.WriteAllBytes(currentFolder + "/" + fileName, data);
                var filePath = Path.Combine(currentFolder, fileName);

                DriveItem uploadedFile = new DriveItem();
                UploadSession uploadSession = new UploadSession();

                // upload file with size less than 4 MB
                if (fileSize < FileConstant.SESSION_UPLOAD_SIZE)
                {
                    FileStream fileStream = new FileStream(filePath, FileMode.Open);

                    if (file.ParentPathID == null)
                    {
                        try
                        {
                            // upload file to user root folder
                            uploadedFile = file.ChildrenPathID == null ?
                                  info.Me.Drive.Root // Upload file to a root directory
                                 .ItemWithPath(fileName).Content.Request()
                                 .PutAsync<DriveItem>(fileStream).Result :
                                  info.Me.Drive.Items[file.ChildrenPathID] // Upload file to a children directory
                                 .ItemWithPath(fileName).Content.Request()
                                 .PutAsync<DriveItem>(fileStream).Result;
                        }
                        catch
                        {
                            string msg = "Server terlalu lama merespons, silakan coba lagi";
                            string msgEn = "Server is taking too long to respond, please try again";
                            var message = new MessageLangDto(msg, msgEn);
                            throw new RequestTimeoutException(message);
                        }
                    }
                    else
                    {
                        try
                        {
                            // upload file to other folder by Id
                            uploadedFile = file.ChildrenPathID != null ?
                                 info.Me.Drives[file.ParentPathID] // Upload file to a children directory
                                .Items[file.ChildrenPathID]
                                .ItemWithPath(fileName).Content.Request()
                                .PutAsync<DriveItem>(fileStream).Result :
                                 info.Me.Drives[file.ParentPathID] // Upload file to a root directory
                                .Root
                                .ItemWithPath(fileName).Content.Request()
                                .PutAsync<DriveItem>(fileStream).Result;
                        }
                        catch
                        {
                            string msg = "Server terlalu lama merespons, silakan coba lagi";
                            string msgEn = "Server is taking too long to respond, please try again";
                            var message = new MessageLangDto(msg, msgEn);
                            throw new RequestTimeoutException(message);
                        }
                    }

                    return "File Uploaded";
                }

                // upload file with size more than 4 MB
                if (file.ParentPathID != string.Empty)
                {
                    using (Stream fileStream = new FileStream(filePath, FileMode.Open))
                    {
                        try
                        {
                            // upload file to user folder
                            uploadSession = file.ChildrenPathID != null ?
                                 info.Me.Drive.Items[file.ChildrenPathID] // Upload file to a children directory
                                .ItemWithPath(fileName)
                                .CreateUploadSession()
                                .Request().PostAsync()
                                .Result :
                                 info.Me.Drive.Root.ItemWithPath(fileName) // Upload file to a root directory
                                .CreateUploadSession()
                                .Request().PostAsync()
                                .Result;

                            var maxChunkSize = 320 * 1024;
                            var largeUploadTask = new LargeFileUploadTask<DriveItem>(uploadSession, fileStream, maxChunkSize);

                            // show upload progress on console
                            IProgress<long> uploadProgress = new Progress<long>();

                            UploadResult<DriveItem> uploadResult = largeUploadTask.UploadAsync(uploadProgress).Result;
                            if (uploadResult.UploadSucceeded)
                            {
                                return "File uploaded to user's OneDrive root folder.";
                            }
                        }
                        catch
                        {
                            string msg = "Server terlalu lama merespons, silakan coba lagi";
                            string msgEn = "Server is taking too long to respond, please try again";
                            var message = new MessageLangDto(msg, msgEn);
                            throw new RequestTimeoutException(message);
                        }
                    }

                    return "File uploaded.";
                }
                else
                {
                    using (Stream fileStream = new FileStream(filePath, FileMode.Open))
                    {
                        try
                        {
                            // upload file to other folder by id
                            uploadSession = file.ChildrenPathID != null ?
                                 info.Me.Drives[file.ParentPathID] // Upload file to a children directory
                                .Items[file.ChildrenPathID]
                                .ItemWithPath(fileName)
                                .CreateUploadSession()
                                .Request().PostAsync()
                                .Result :
                                 info.Me.Drives[file.ParentPathID] // Upload file to a root directory
                                .Root
                                .ItemWithPath(fileName)
                                .CreateUploadSession()
                                .Request().PostAsync()
                                .Result;

                            var maxChunkSize = 320 * 1024;
                            var largeUploadTask = new LargeFileUploadTask<DriveItem>(uploadSession, fileStream, maxChunkSize);

                            // show upload progress on console
                            IProgress<long> uploadProgress = new Progress<long>();

                            UploadResult<DriveItem> uploadResult = largeUploadTask.UploadAsync(uploadProgress).Result;
                            if (uploadResult.UploadSucceeded)
                            {
                                return "File uploaded to user's OneDrive root folder.";
                            }
                        }
                        catch
                        {
                            string msg = "Server terlalu lama merespons, silakan coba lagi";
                            string msgEn = "Server is taking too long to respond, please try again";
                            var message = new MessageLangDto(msg, msgEn);
                            throw new RequestTimeoutException(message);
                        }
                    }

                    return "File uploaded.";
                }
            }
            else
            {
                string msg = "Ukuran upload file melebihi batas ukuran file server.";
                string msgEn = "Size of a request exceeds the server's file size limit.";
                var message = new MessageLangDto(msg, msgEn);
                throw new PayloadTooLargeException(message);
            }
        }

        public async Task<GetFileResponse> GetFile(string fileId, string parentId, string pathDownload)
        {
            try
            {
                if (parentId == null)
                {
                    request = info.Me.Drive.Items[fileId];
                }
                else
                {
                    request = info.Me.Drives[parentId].Items[fileId];
                }

                try
                {
                    var infoFile = request.Request().GetAsync().Result;
                    var stream = request.Content.Request().GetAsync().Result;
                    var driveItemPath = Path.Combine(System.IO.Directory.GetCurrentDirectory() + "/" + pathDownload, infoFile.Name);
                    var driveItemFile = System.IO.File.Create(driveItemPath);   // Save file to directory
                    object downloadUrl;
                    infoFile.AdditionalData.TryGetValue("@microsoft.graph.downloadUrl", out downloadUrl);   // Get item download link

                    GetFileResponse objFile = new GetFileResponse
                    {
                        Id = fileId,
                        Name = infoFile.Name,
                        CreatedDate = infoFile.CreatedDateTime,
                        Type = infoFile.File.MimeType,
                        Path = driveItemPath,
                        Url = infoFile.WebUrl,
                        DownloadUrl = downloadUrl.ToString(),
                    };

                    stream.CopyTo(driveItemFile);
                    stream.Close();
                    driveItemFile.Close();

                    return objFile;
                }
                catch
                {
                    string msg = "Server terlalu lama merespons, silakan coba lagi";
                    string msgEn = "Server is taking too long to respond, please try again";
                    var message = new MessageLangDto(msg, msgEn);
                    throw new RequestTimeoutException(message);
                }
            }
            catch
            {
                string msg = "Tidak ditemukan";
                string msgEn = "Not Found";
                var message = new MessageLangDto(msg, msgEn);
                throw new NotFoundException(message);
            }
        }

        public Task DeleteAvatar(string avatar)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<GetFileResponse>> GetFilesByName(string fileName, string parentId)
        {
            object downloadUrl;
            DriveItem tempData;

            if (string.IsNullOrEmpty(fileName) || fileName.Length < 3)
            {
                string msg = "Input tidak valid.";
                string msgEn = "Invalid input.";
                var message = new MessageLangDto(msg, msgEn);
                throw new BadRequestException(message);
            }

            try
            {
                request = parentId == null ? info.Me.Drive.Root : // Search from user drive
                    info.Me.Drives[parentId].Root; // Search from quick access drive using driveId

                var search = request
                            .Search(fileName)
                            .Request()
                            .GetAsync()
                            .Result;

                if (search.Count > 0)
                {
                    foreach (var file in search)
                    {
                        if (parentId == null)
                        {
                            tempData = info.Me.Drive.Items[file.Id].Request().GetAsync().Result;
                        }
                        else
                        {
                            tempData = info.Me.Drives[parentId].Items[file.Id].Request().GetAsync().Result;
                        }

                        tempData.AdditionalData.TryGetValue("@microsoft.graph.downloadUrl", out downloadUrl);   // Get item download link
                        if (file.Folder != null)
                        {
                            continue; // if file is a folder then skip item
                        }

                        GetFileResponse objFile = new GetFileResponse
                        {
                            Id = file.Id,
                            Name = file.Name,
                            CreatedDate = file.CreatedDateTime,
                            Type = file.File.MimeType,
                            Path = file.ParentReference.Path,
                            Url = file.WebUrl,
                            DownloadUrl = downloadUrl.ToString(),
                        };
                        _listItem.Add(objFile);
                    }

                    return _listItem.ToList();
                }
                else
                {
                    string msg = "Tidak ditemukan";
                    string msgEn = "Not Found";
                    var message = new MessageLangDto(msg, msgEn);
                    throw new NotFoundException(message);
                }
            }
            catch
            {
                string msg = "Tidak ditemukan";
                string msgEn = "Not Found";
                var message = new MessageLangDto(msg, msgEn);
                throw new NotFoundException(message);
            }
        }

        private static GraphServiceClient GetAuthenticatedGraphClient(FileStorageOptions config, string userName, SecureString userPassword)
        {
            var authenticationProvider = CreateAuthorizationProvider(config, userName, userPassword);
            var graphClient = new GraphServiceClient(authenticationProvider);
            return graphClient;
        }

        private static IAuthenticationProvider CreateAuthorizationProvider(FileStorageOptions config, string userName, SecureString userPassword)
        {
            var clientId = config.ApplicationId;
            var authority = $"https://login.microsoftonline.com/{config.TenantId}/v2.0";

            List<string> scopes = new List<string>();
            scopes.Add("Files.ReadWrite.All");

            var cca = PublicClientApplicationBuilder.Create(clientId)
                                                    .WithAuthority(authority)
                                                    .Build();
            return MsalAuthenticationHelper.GetInstance(cca, scopes.ToArray(), userName, userPassword);
        }

        private static FileStorageOptions LoadAppSettings(FileStorageOptions onedriveConfig)
        {
            try
            {
                if (string.IsNullOrEmpty(onedriveConfig.ApplicationId) ||
                    string.IsNullOrEmpty(onedriveConfig.TenantId))
                {
                    return null;
                }

                return onedriveConfig;
            }
            catch (System.IO.FileNotFoundException)
            {
                return null;
            }
        }
    }
}
