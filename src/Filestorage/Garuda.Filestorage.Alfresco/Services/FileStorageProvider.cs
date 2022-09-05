// <copyright file="FileStorageProvider.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Garuda.Filestorage.Alfresco.Constants;
using Garuda.Filestorage.Alfresco.Dtos;
using Garuda.Filestorage.Configurations;
using Garuda.Filestorage.Contracts;
using Garuda.Filestorage.Requests;
using Garuda.Filestorage.Responses;
using Garuda.Infrastructure.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Newtonsoft.Json;

namespace Garuda.Filestorage.Alfresco.Services
{
    public class FileStorageProvider : IFileStorageProvider
    {
        private readonly HttpClient _httpClient;
        private readonly FileStorageOptions _fileStorageOptions;

        public FileStorageProvider(IOptions<FileStorageOptions> fileStorageOptions)
        {
            _httpClient = new HttpClient();
            _fileStorageOptions = fileStorageOptions.Value;
        }

        public async Task<GetFileResponse> GetFile(string file, string parentId, string pathDownload)
        {
            byte[] ticketData = System.Convert.FromBase64String(await GetTicket());
            string ticket = Encoding.UTF8.GetString(ticketData);

            var alfrescoUrl = _fileStorageOptions.Host + AlfrescoConstant.AlfrescoUploadFileUrl + file + "/content?alf_ticket=" + ticket;

            GetFileResponse objFile = new GetFileResponse
            {
                Url = alfrescoUrl,
            };

            return objFile;
        }

        public async Task DeleteAvatar(string avatar)
        {
            HttpClient client = _httpClient;
            string ticket = await GetTicket();
            string alfrescoUrl = _fileStorageOptions.Host + AlfrescoConstant.AlfrescoUploadFileUrl + avatar;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", ticket);
            var response = await client.DeleteAsync(alfrescoUrl);
            response.EnsureSuccessStatusCode();
        }

        public async Task<string> UploadFile(FileUploadFormRequest file)
        {
            throw new NotImplementedException();
        }

        public Task<User> CheckLoggedInUser()
        {
            throw new NotImplementedException();
        }

        public async Task<string> UploadFileByString(FileUploadBase64Request file)
        {
            HttpClient client = _httpClient;
            string ticket = await GetTicket();
            var alfrescoUrl = _fileStorageOptions.Host + AlfrescoConstant.AlfrescoUploadFileUrl + _fileStorageOptions.Node + "/children";
            var (data, type) = FileHelper.GetFileDetail(file.Base64);
            var fileContent = new ByteArrayContent(data);
            var content = new MultipartFormDataContent();

            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
            content.Add(fileContent, "filedata", file.Name + type);
            content.Add(new StringContent(file.Path), "relativePath");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", ticket);

            var response = await client.PostAsync(alfrescoUrl, content);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<AlfrescoDto>(response.Content.ReadAsStringAsync().Result);

            return result.Entry.Id;
        }

        public async Task<ICollection<GetFileResponse>> GetFilesByName(string fileName, string parentId)
        {
            throw new NotImplementedException();
        }

        private async Task<string> GetTicket()
        {
            HttpClient client = _httpClient;
            AlfrescoAuthDto account = new AlfrescoAuthDto() { UserId = _fileStorageOptions.UserId, Password = _fileStorageOptions.Password };
            string alfrescoUrl = _fileStorageOptions.Host + AlfrescoConstant.AlfrescoAuthenticationUrl;
            StringContent content = new StringContent(JsonConvert.SerializeObject(account), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(alfrescoUrl, content);
            var result = JsonConvert.DeserializeObject<AlfrescoDto>(response.Content.ReadAsStringAsync().Result);
            return System.Convert.ToBase64String(Encoding.UTF8.GetBytes(result.Entry.Id));
        }
    }
}
