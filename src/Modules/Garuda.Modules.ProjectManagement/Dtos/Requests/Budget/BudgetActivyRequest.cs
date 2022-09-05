// <copyright file="BudgetActivyRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.Budget
{
    public class BudgetActivyRequest
    {
        [Required(ErrorMessage = "BudgetTypeId cannot be null")]
        public Guid BudgetTypeId { get; set; }

        [Required(ErrorMessage = "Name cannot be null")]
        public string Name { get; set; }

        [Required(ErrorMessage = "IsShowInProjectExpense cannot be null")]
        public bool IsShowInProjectExpense { get; set; }
    }
}
