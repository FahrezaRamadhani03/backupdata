// <copyright file="ProfitProjectDetail.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sieve.Attributes;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.ProfitProject
{
    public class ProfitProjectDetail
    {
        [Sieve(CanFilter = true, CanSort = true)]
        public Guid Id { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string Name { get; set; }

        public DateTime? DevelopmentStart { get; set; }

        public DateTime? DevelopmentEnd { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string Periode
        {
            get
            {
                if (DevelopmentStart != null)
                {
                    return DevelopmentStart?.ToString("dd MMM yyyy") + " - " + DevelopmentEnd?.ToString("dd MMM yyyy");
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        [Sieve(CanFilter = true, CanSort = true)]
        public decimal ProjectAmount { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public decimal ProjectCost { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public decimal ProjectProfit
        {
            get
            {
                return ProjectAmount - ProjectCost;
            }
        }
    }
}
