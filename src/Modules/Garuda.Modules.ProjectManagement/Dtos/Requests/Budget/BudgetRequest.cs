// <copyright file="BudgetRequest.cs" company="CV Garuda Infinity Kreasindo">
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
    public class BudgetRequest
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Year cannot be null")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Projection cannot be null")]
        public decimal Projection { get; set; }

    }
}
