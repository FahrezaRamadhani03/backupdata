// <copyright file="BudgetDetailTypeRequest.cs" company="CV Garuda Infinity Kreasindo">
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
    public class BudgetDetailTypeRequest
    {
        [Required(ErrorMessage = "TypeId cannot be null")]
        public Guid TypeId { get; set; }

        public string TypeName { get; set; }

        public List<BudgetDetailActivityRequest> BudgetActivities { get; set; }
    }
}
