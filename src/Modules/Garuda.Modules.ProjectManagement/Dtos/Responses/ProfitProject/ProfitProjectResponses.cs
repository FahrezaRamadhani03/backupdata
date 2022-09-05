// <copyright file="ProfitProjectResponses.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garuda.Modules.Common.Dtos.Responses;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.ProfitProject
{
    public class ProfitProjectResponses
    {
        public decimal TotalAmount { get; set; }

        public decimal TotalCost { get; set; }

        public decimal TotalProfit { get; set; }

        public PaginatedResponses<ProfitProjectDetail> ProfitProjectDetail { get; set; }
    }
}
