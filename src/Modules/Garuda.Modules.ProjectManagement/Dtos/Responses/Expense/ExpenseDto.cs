// <copyright file="ExpenseDto.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Sieve.Attributes;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Expense
{
    public class ExpenseDto
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ActivityId.
        /// </summary>
        public Guid? ActivityId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for BudgetActivity.
        /// </summary>
        public BudgetActivityDto BudgetActivity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for TransactionDate.
        /// </summary>
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for BillAmount.
        /// </summary>
        public decimal BillAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ProjectId.
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public Guid? ProjectId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for ExpenseBills.
        /// </summary>
        public List<BillDto> ExpenseBills { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for CreatedDate.
        /// </summary>
        [Sieve(CanFilter = true, CanSort = true)]
        public DateTime CreatedDate { get; set; }
    }
}
