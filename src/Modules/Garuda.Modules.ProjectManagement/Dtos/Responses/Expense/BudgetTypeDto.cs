// <copyright file="BudgetTypeDto.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Sieve.Attributes;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Expense
{
    public class BudgetTypeDto
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for TypeName.
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public string TypeName { get; set; }
    }
}
