// <copyright file="ProjectResourcesDto.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using System;

namespace Garuda.Modules.ProjectManagement.Dtos
{
    public class ProjectResourcesDto
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
        /// Gets or sets a value indicating whether gets or Sets for Role Id.
        /// </summary>
        public Guid RoleId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Project Detail.
        /// </summary>
        public DevelopmentRoleDto DevelopmentRole { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Role Id.
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Qty.
        /// </summary>
        public int Qty { get; set; }
    }
}
