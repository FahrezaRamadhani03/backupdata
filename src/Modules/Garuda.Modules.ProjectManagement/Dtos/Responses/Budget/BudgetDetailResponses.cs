// <copyright file="BudgetDetailRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garuda.Modules.ProjectManagement.Models.Datas;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Budget
{
    public class BudgetDetailResponses
    {
        public Guid TypeId { get; set; }

        public string TypeName { get; set; }

        public List<BudgetActivityDetailResponses> BudgetActivity { get; set; }
    }
}
