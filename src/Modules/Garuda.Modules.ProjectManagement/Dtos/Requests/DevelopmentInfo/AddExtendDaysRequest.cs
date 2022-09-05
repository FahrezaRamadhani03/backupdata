// <copyright file="AddExtendDaysRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentInfo
{
    public class AddExtendDaysRequest
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ProjectId.
        /// </summary>
        [Required(ErrorMessage = "ProjectId cannot be null")]
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Descriptions.
        /// </summary>
        [Required(ErrorMessage = "Descriptions cannot be null")]
        public string Descriptions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DevelopmentPeriodEnd.
        /// </summary>
        [Required(ErrorMessage = "DevelopmentPeriodEnd cannot be null")]
        [DefaultValue(0)]
        public int Days { get; set; }
    }
}
