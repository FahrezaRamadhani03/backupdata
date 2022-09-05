// <copyright file="TaxResponses.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Sieve.Attributes;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses
{
    public class TaxResponses
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Technology ID
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Technology Name
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Code.
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Code.
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public decimal Rate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Code.
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public bool IsActive { get; set; }
    }
}
