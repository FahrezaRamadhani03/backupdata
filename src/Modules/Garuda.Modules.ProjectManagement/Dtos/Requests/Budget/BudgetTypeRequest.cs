// <copyright file="BudgetTypeRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.Budget
{
    public class BudgetTypeRequest
    {
        [Required(ErrorMessage = "Name cannot be null")]
        public string Name { get; set; }
    }
}
