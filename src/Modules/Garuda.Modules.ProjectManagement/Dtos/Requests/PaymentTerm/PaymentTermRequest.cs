// <copyright file="PaymentTermRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.PaymentTerm
{
    public class PaymentTermRequest
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Name cannot be null")]
        public int TermNo { get; set; }

        [Required(ErrorMessage = "Title cannot be null")]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(255)]
        public string Remarks { get; set; }

        [Required(ErrorMessage = "Percentage cannot be null")]
        public decimal Percentage { get; set; }

        [Required(ErrorMessage = "Amount cannot be null")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "InvoiceDate cannot be null")]
        public DateTime InvoiceDate { get; set; }

        [Required(ErrorMessage = "ReminderDate cannot be null")]
        public DateTime ReminderDate { get; set; }

        public string InvoiceNote { get; set; }

        public string Status { get; set; }

        public List<PaymentTermTaxRequest> Taxes { get; set; }
    }
}
