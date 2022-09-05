// <copyright file="BudgetActivityDetailResponses.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Budget
{
    public class BudgetActivityDetailResponses
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for BudgetActivityId.
        /// </summary>
        public Guid BudgetActivityId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for BudgetActivityName.
        /// </summary>
        public string BudgetActivityName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for BudgetPercentage.
        /// </summary>
        public decimal BudgetPercentage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for BudgetAmount.
        /// </summary>
        public decimal BudgetAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Utilized.
        /// </summary>
        public decimal Utilized { get; set; }

        /// <summary>
        /// Gets a value indicating whether gets or Sets for Remaining.
        /// </summary>
        public decimal Remaining
        {
            get
            {
                return BudgetAmount - Utilized;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for January.
        /// </summary>
        public decimal January { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for February.
        /// </summary>
        public decimal February { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for March.
        /// </summary>
        public decimal March { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for April.
        /// </summary>
        public decimal April { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for May.
        /// </summary>
        public decimal May { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for June.
        /// </summary>
        public decimal June { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for July.
        /// </summary>
        public decimal July { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for August.
        /// </summary>
        public decimal August { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for September.
        /// </summary>
        public decimal September { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for October.
        /// </summary>
        public decimal October { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for November.
        /// </summary>
        public decimal November { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for December.
        /// </summary>
        public decimal December { get; set; }
    }
}
