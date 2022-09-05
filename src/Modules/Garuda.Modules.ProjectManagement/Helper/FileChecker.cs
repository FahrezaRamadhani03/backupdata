// <copyright file="FileChecker.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Garuda.Modules.ProjectManagement.Helper.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Garuda.Modules.ProjectManagement.Helper
{
    public class FileChecker : IFileChecker
    {

        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileChecker"/> class.
        /// </summary>
        /// <param name="configuration"></param>
        public FileChecker(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool IsValidType(IFormFile file)
        {
            var fileTypes = _configuration.GetSection("UploadFileTypes").Get<List<string>>();
            if (!fileTypes.Any(u => u == file.ContentType))
            {
                return false;
            }

            return true;
        }

        public bool IsValidSize(IFormFile file)
        {
            var maxSize = _configuration.GetSection("UploadFileMaxSize").Get<int>();
            var minSize = _configuration.GetSection("UploadFileMaxMin").Get<int>();

            if (maxSize != null && file.Length >= maxSize * 1024 * 1024)
            {
                return false;
            }

            if (minSize != null && file.Length <= minSize * 1024 * 1024)
            {
                return false;
            }

            return true;
        }

        public string GenerateUniqFileName(IFormFile file)
        {
            var type = string.Empty;
            var fileTypes = _configuration.GetSection("UploadFileTypes").Get<List<string>>();
            var currentType = fileTypes.Where(u => u == file.ContentType).FirstOrDefault();
            if (currentType != null)
            {
                var result = currentType.Split('/');
                type = result[1];
            }

            var time = DateTime.Now;

            return time.ToString("_yyyyMMddHHmmss") + "." + type;
        }

        public string GetContentType(string type)
        {
            var fileTypes = _configuration.GetSection("UploadFileTypes").Get<List<string>>();
            var contenType = fileTypes.Where(u => u.Contains(type)).FirstOrDefault();
            if (contenType!= null)
            {
                return contenType;
            }
            return null;
        }
    }
}
