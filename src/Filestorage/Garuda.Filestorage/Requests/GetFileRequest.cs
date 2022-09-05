// <copyright file="GetFileRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Garuda.Filestorage.Requests
{
    public class GetFileRequest
    {
        /// <summary>
        /// Gets or sets for Id
        /// </summary>
        [Required]
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
        /// Gets or sets for ParentPathID
        /// </summary>
        public string ParentPathID { get; set; }

    }
}
