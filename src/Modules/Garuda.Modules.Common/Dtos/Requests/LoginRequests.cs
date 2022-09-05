// <copyright file="LoginRequests.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.Common.Dtos.Requests
{
    public class LoginRequests
    {
        /// <summary>
        /// Gets or sets username.
        /// </summary>
        [Required(ErrorMessage = "The Username or Email field are required.")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets user Password login.
        /// </summary>
        [Required(ErrorMessage = "The Password field is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}