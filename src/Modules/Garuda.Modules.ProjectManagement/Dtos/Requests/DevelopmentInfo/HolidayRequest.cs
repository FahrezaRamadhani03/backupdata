// <copyright file="HolidayRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentInfo
{
    public class HolidayRequest
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Description.
        /// </summary>
        [Required(ErrorMessage = "Description cannot be null")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Date.
        /// </summary>
        [Required(ErrorMessage = "Date cannot be null")]
        public DateTime Date { get; set; }
    }
}
