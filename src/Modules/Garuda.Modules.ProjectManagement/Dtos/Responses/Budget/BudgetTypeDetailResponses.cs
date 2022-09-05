// <copyright file="BudgetTypeDetailResponses.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Expense;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Budget
{
    public class BudgetTypeDetailResponses
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid TypeId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for TypeName.
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for BudgetActivities.
        /// </summary>
        public IList<BudgetActivityDetailResponses> BudgetActivities { get; set; } = new List<BudgetActivityDetailResponses>();
    }
}
