// <copyright file="CreateInvoiceRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.Invoice
{
    public class CreateInvoiceRequest
    {
        public Guid? Id { get; set; }

        [Required]
        public Guid ProjectId { get; set; }

        public Guid? PaymentTermId { get; set; }

        [Required]
        public DateTime InvoiceDate { get; set; }

        public string InvoiceNo { get; set; }

        public bool IsDifferentAddress { get; set; }

        public string AdditionalNote { get; set; }

        public string BillingAddress { get; set; }

        public string CompanyName { get; set; }

        [Required]
        public int OverdueLength { get; set; }

        [Required]
        public string OverdueUnit { get; set; }

        [Required]
        public DateTime ReminderDate { get; set; }

        public bool IsAdditionalDiscount { get; set; }

        public decimal AdditionalDiscount { get; set; }

        public string Status { get; set; }

        public decimal Subtotal { get; set; }

        public List<InvoiceDetailRequest> InvoiceDetail { get; set; }

        public List<InvoiceTaxRequest> TaxDetail { get; set; }
    }
}
