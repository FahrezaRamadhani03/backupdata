// <copyright file="ExternalLoginConfirmationRequests.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.Common.Dtos.Requests
{
    /// <summary>
    /// Models.
    /// </summary>
    public class ExternalLoginConfirmationRequests
    {
        /// <summary>
        /// Gets or sets email.
        /// </summary>
        [Required(ErrorMessage = "The {0} field is required.")]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets fullname.
        /// </summary>
        [Required(ErrorMessage = "The {0} field is required.")]
        [Display(Name = "Name")]
        public string FullName { get; set; }
    }
}
