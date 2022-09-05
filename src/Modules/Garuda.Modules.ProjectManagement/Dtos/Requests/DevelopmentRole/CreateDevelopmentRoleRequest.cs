// <copyright file="CreateDevelopmentRoleRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentRole
{
    public class CreateDevelopmentRoleRequest
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Name.
        /// </summary>
        [Required(ErrorMessage = "Name cannot be null")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Code.
        /// </summary>
        [Required(ErrorMessage = "Code cannot be null")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Leader.
        /// </summary>
        [DefaultValue(false)]
        public bool Leader { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Level.
        /// </summary>
        public List<string> Level { get; set; }
    }
}
