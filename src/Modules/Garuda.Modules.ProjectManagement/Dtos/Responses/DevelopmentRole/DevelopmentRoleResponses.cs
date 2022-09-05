// <copyright file="DevelopmentRoleResponses.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.DevelopmentRole
{
    public class DevelopmentRoleResponses
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
        /// Gets or sets a value indicating whether gets or Sets for Code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Leader.
        /// </summary>
        public bool Leader { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Level.
        /// </summary>
        public string Level { get; set; }
    }
}
