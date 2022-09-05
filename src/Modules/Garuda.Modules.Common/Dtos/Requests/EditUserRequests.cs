// <copyright file="EditUserRequests.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.Common.Dtos.Requests
{
    public class EditUserRequests
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Email
        /// </summary>
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Fullname
        /// </summary>
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
