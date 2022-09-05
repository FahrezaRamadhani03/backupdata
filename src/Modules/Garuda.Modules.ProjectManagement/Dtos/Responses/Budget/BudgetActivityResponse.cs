// <copyright file="BudgetActivityResponse.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Garuda.Modules.ProjectManagement.Dtos.Responses.Expense;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Budget
{
    public class BudgetActivityResponse
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
