// <copyright file="IFileStorageProvider.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Filestorage.Requests;
using Garuda.Filestorage.Responses;
using Microsoft.Graph;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Garuda.Filestorage.Contracts
{
    public interface IFileStorageProvider
    {
        /// <summary>
        /// Upload file storage.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        Task<string> UploadFile(FileUploadFormRequest file);

        /// <summary>
        /// Upload file storage by string.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        Task<string> UploadFileByString(FileUploadBase64Request file);

        /// <summary>
        /// Check user.
        /// </summary>
        /// <returns></returns>
        Task<User> CheckLoggedInUser();

        /// <summary>
        /// Delete avatar.
        /// </summary>
        /// <param name="avatar"></param>
        /// <returns></returns>
        Task DeleteAvatar(string avatar);

        /// <summary>
        /// Get File from storage.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="parentId"></param>
        /// <param name="pathDownload"></param>
        /// <returns></returns>
        Task<GetFileResponse> GetFile(string request, string parentId, string pathDownload);

        /// <summary>
        /// Get files by name from storage.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        Task<ICollection<GetFileResponse>> GetFilesByName(string fileName, string parentId);
    }
}
