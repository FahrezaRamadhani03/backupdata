// <copyright file="ProjectInvoiceResponses.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sieve.Attributes;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Invoice
{
    public class ProjectInvoiceResponses
    {
        [Sieve(CanFilter = true, CanSort = true)]
        public string ClientCode { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string ProjectName { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string ProjectKey { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public int ProjectAmount { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public int QtyPaid { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public decimal AmountPaid { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public int QtyUnpaid { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public decimal AmountUnpaid { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public int QtyOverdue { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public decimal AmountOverdue { get; set; }

        public List<ProjectInvoiceDetailResponses> Invoices { get; set; }
    }
}
