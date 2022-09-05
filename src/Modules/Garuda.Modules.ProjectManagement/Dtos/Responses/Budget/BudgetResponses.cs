// <copyright file="BudgetResponses.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Expense;
using Sieve.Attributes;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Budget
{
    public class BudgetResponses
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Year.
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Projection.
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public decimal Projection { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Utilized.
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public decimal Utilized { get; set; }

        /// <summary>
        /// Gets a value indicating whether gets or Sets for Remaining.
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public decimal Remaining
        {
            get
            {
                return Projection - Utilized;
            }
        }
    }
}
