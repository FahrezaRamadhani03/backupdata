// <copyright file="GetStatusResponses.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Status
{
    public class GetStatusResponses
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Status.
        /// </summary>
        public List<StatusDto> Status { get; set; }
    }
}
