// <copyright file="GetFileResponse.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Garuda.Filestorage.Responses
{
    public class GetFileResponse
    {
        /// <summary>
        /// Gets or sets for Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets for Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets for Path
        /// </summary>
        [Display(Name = "File directory")]
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets for Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets for CreatedDate
        /// </summary>
        public DateTimeOffset? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets for DownloadUrl
        /// </summary>
        public string DownloadUrl { get; set; }

        /// <summary>
        /// Gets or sets for Url
        /// </summary>
        public string Url { get; set; }

    }
}
