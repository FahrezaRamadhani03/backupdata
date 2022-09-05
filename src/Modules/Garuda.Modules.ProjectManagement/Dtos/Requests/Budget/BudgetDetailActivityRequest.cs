// <copyright file="BudgetDetailActivityRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.Budget
{
    public class BudgetDetailActivityRequest
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "BudgetActivityId cannot be null")]
        public Guid BudgetActivityId { get; set; }

        [Required(ErrorMessage = "BudgetPercentage cannot be null")]
        public decimal BudgetPercentage { get; set; }

        [Required(ErrorMessage = "BudgetAmount cannot be null")]
        public decimal BudgetAmount { get; set; }
    }
}
