// <copyright file="EditSprintRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentInfo
{
    public class EditSprintRequest
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ProjectId.
        /// </summary>
        [Required(ErrorMessage = "ProjectId cannot be null")]
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for SprintStart.
        /// </summary>
        [Required(ErrorMessage = "SprintStart cannot be null")]
        public DateTime SprintStart { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for SprintEnd.
        /// </summary>
        [Required(ErrorMessage = "SprintEnd cannot be null")]
        public DateTime SprintEnd { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Remarks.
        /// </summary>
        [Required(ErrorMessage = "Remarks cannot be null")]
        public string Remarks { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DayLength.
        /// </summary>
        public int DayLength { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for HolidayLength.
        /// </summary>
        public int HolidayLength { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Holidays.
        /// </summary>
        public List<HolidayRequest> Holidays { get; set; }
    }
}
