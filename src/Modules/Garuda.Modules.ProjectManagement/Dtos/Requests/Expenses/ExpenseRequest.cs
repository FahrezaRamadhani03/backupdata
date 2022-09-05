// <copyright file="ExpenseRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.Expenses
{
    public class ExpenseRequest
    {
        public Guid? ProjectId { get; set; }

        public Guid? ActivityId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal BillAmount { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        public List<IFormFile> Bills { get; set; }
    }
}
