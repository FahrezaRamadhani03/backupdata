// <copyright file="IFileChecker.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;

namespace Garuda.Modules.ProjectManagement.Helper.Interfaces
{
    /// <summary>
    /// Address Service contract
    /// </summary>
    public interface IFileChecker
    {
        /// <summary>
        /// Check file types
        /// </summary>
        /// <param name="file"></param>
        /// <returns>A <see cref="bool"/> representing the asynchronous operation.</returns>
        bool IsValidType(IFormFile file);

        /// <summary>
        ///  Check file size
        /// </summary>
        /// <param name="file"></param>
        /// <returns>A <see cref="bool"/> representing the asynchronous operation.</returns>
        bool IsValidSize(IFormFile file);

        /// <summary>
        ///  Check file size
        /// </summary>
        /// <param name="file"></param>
        /// <returns>A <see cref="bool"/> representing the asynchronous operation.</returns>
        string GenerateUniqFileName(IFormFile file);

        /// <summary>
        ///  Get file content type
        /// </summary>
        /// <param name="file"></param>
        /// <returns>A <see cref="bool"/> representing the asynchronous operation.</returns>
        string GetContentType(string type);
    }
}
