// <copyright file="UserProfileResponses.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garuda.Modules.Common.Models.Datas;

namespace Garuda.Modules.Common.Dtos.Responses
{
    /// <summary>
    /// Dto User Profile Responses
    /// </summary>
    public class UserProfileResponses
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Fullname
        /// </summary>
        public string Fullname { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for IsActive
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for LastLogin
        /// </summary>
        public DateTime? LastLogin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for UserGroups
        /// </summary>
        public IList<UserGroup> UserGroups { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for UserUnits
        /// </summary>
        public IList<UserUnit> UserUnits { get; set; }
    }
}
