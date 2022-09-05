// <copyright file="CreateUserRequests.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.Common.Dtos.Requests
{
    public class CreateUserRequests
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Email
        /// </summary>
        [Required(ErrorMessage = "Email field is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Username
        /// </summary>
        [Required(ErrorMessage = "The Username field is required.")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Username
        /// </summary>
        [Required(ErrorMessage = "The Fullname field is required.")]
        public string Fullname { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for IsActive
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for LastLogin
        /// </summary>
        public DateTime? LastLogin { get; set; }
    }
}
