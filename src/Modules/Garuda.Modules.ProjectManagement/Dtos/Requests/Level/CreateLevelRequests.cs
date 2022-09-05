// <copyright file="CreateLevelRequests.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.Level
{
    public class CreateLevelRequests
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Techname
        /// </summary>
        [Required(ErrorMessage = "Name cannot be null")]
        public string Name { get; set; }
    }
}
