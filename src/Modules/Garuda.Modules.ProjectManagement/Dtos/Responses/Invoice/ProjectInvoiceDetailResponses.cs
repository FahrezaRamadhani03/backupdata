// <copyright file="ProjectInvoiceDetailResponses.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;
using Sieve.Attributes;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Invoice
{
    public class ProjectInvoiceDetailResponses
    {
        public Guid Id { get; set; }

        public string InvoiceNo { get; set; }

        public Guid ProjectId { get; set; }

        public Guid? PaymentTermId { get; set; }

        [Sieve(CanFilter = true)]
        public DateTime InvoiceDate { get; set; }

        public decimal TotalPayment { get; set; }

        [Sieve(CanFilter = true)]
        public string Status { get; set; }

        public DateTime OverdueDate { get; set; }

        public DateTime? SubmitDate { get; set; }

        public DateTime? PaymentDate { get; set; }
    }
}
