// <copyright file="BudgetTypesResponse.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Expense;
using Sieve.Attributes;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Budget
{
    public class BudgetTypesResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for TypeName.
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public string TypeName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for BudgetActivities.
        /// </summary>
        public IList<BudgetActivityDto> BudgetActivities { get; set; } = new List<BudgetActivityDto>();
    }
}
