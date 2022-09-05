// <copyright file="DevelopmentHolidayDto.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using System;

namespace Garuda.Modules.ProjectManagement.Dtos
{
    public class DevelopmentHolidayDto
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Description.
        /// </summary>
        public string Description { get; set; }

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
