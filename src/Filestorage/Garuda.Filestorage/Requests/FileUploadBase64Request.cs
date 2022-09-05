// <copyright file="FileUploadBase64Request.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Garuda.Filestorage.Requests
{
    public class FileUploadBase64Request
    {
        /// <summary>
        /// Gets or sets for Name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets for Path.
        /// </summary>
        [Display(Name = "File directory")]
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets for ParentPathID.
        /// </summary>
        public string ParentPathID { get; set; }

        /// <summary>
        /// Gets or sets for ChildrenPathID.
        /// </summary>
        public string ChildrenPathID { get; set; }

        /// <summary>
        /// Gets or sets for Base64
        /// </summary>
        public string Base64 { get; set; }

    }
}
