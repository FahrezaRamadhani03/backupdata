// <copyright file="DevelopmentSprintDateRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentInfo
{
    public class DevelopmentSprintDateRequest
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for SprintName.
        /// </summary>
        public string SprintName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DevelopmentStart.
        /// </summary>
        public DateTime SprintStart { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DevelopmentEnd.
        /// </summary>
        public DateTime SprintEnd { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DayLength.
        /// </summary>
        public int DayLength { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for HolidayLength.
        /// </summary>
        public int HolidayLength { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Remark.
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Holidays.
        /// </summary>
        public List<HolidayRequest> Holidays { get; set; }
    }
}
