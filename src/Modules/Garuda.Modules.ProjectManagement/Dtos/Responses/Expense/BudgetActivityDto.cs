// <copyright file="BudgetActivityDto.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Sieve.Attributes;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Expense
{
    public class BudgetActivityDto
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Name.
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for BudgetTypeId.
        /// </summary>
        public Guid BudgetTypeId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for BudgetTypeId.
        /// </summary>
        public bool IsShowInProjectExpense { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for BudgetType.
        /// </summary>
        public BudgetTypeDto BudgetType { get; set; }
    }
}
