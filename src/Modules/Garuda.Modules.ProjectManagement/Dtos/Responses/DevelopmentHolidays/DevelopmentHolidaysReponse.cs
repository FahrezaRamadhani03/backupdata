// <copyright file="DevelopmentHolidaysReponses.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Garuda.Modules.ProjectManagement.Models.Datas;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.DevelopmentHolidays
{
    public class DevelopmentHolidaysReponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Project Id.
        /// </summary>
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for HolidayDate.
        /// </summary>
        public DateTime HolidayDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DevelopmentScrumSprintId.
        /// </summary>
        public Guid DevelopmentScrumSprintId { get; set; }
    }
}
