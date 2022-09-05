// <copyright file="UsersResponses.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Garuda.Modules.Common.Models.Datas;
using Sieve.Attributes;

namespace Garuda.Modules.Common.Dtos.Responses
{
    public class UsersResponses
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for User ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Email
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Username
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Fullname
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public string Fullname { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for IsActive
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for UserGroups
        /// </summary>
        public IList<UserGroup> UserGroups { get; set; } = new List<UserGroup>();

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for LastLogin
        /// </summary>
        public DateTime? LastLogin { get; set; }
    }
}
