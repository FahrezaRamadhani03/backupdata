// <copyright file="SprintListResponses.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.DevelopmentSprint
{
    public class SprintListResponses
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Sprint Name.
        /// </summary>
        public string SprintName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Sprint Start.
        /// </summary>
        public string SprintStart { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Sprint End.
        /// </summary>
        public string SprintEnd { get; set; }

        // <summary>
        /// Gets or sets a value indicating whether gets or Sets for Start Day.
        /// </summary>
        public string StartDay { get; set; }

        // <summary>
        /// Gets or sets a value indicating whether gets or Sets for End Day.
        /// </summary>
        public string EndDay { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Holidays.
        /// </summary>
        public string Holidays { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Total Work Day.
        /// </summary>
        public int TotalWorkDay { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Total Holiday.
        /// </summary>
        public int TotalHoliday { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Duration.
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Remark.
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Remark.
        /// </summary>
        public List<HolidayDto> Holiday { get; set; }
    }
}
