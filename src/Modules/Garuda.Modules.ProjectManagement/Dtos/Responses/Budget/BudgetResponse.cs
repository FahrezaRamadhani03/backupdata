// <copyright file="BudgetResponse.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Garuda.Modules.ProjectManagement.Models.Datas;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Budget
{
    public class BudgetResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Year.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for Projection.
        /// </summary>
        public decimal Projection { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets for BudgetDetails.
        /// </summary>
        public List<BudgetTypeDetailResponses> BudgetTypes { get; set; }
    }
}
