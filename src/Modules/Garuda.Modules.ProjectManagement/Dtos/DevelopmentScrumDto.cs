// <copyright file="DevelopmentScrumDto.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;

namespace Garuda.Modules.ProjectManagement.Dtos
{
    public class DevelopmentScrumDto
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for DevelopmentHolidays.
        /// </summary>
        public IList<DevelopmentScrumSprintDto> DevelopmentScrumSprints { get; set; } = new List<DevelopmentScrumSprintDto>();
    }
}
