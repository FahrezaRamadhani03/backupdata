// <copyright file="InvoicePaymentRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using System;
using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.Invoice
{
    public class InvoicePaymentRequest
    {
        [Required(ErrorMessage = "InvoiceId cannot be null")]
        public Guid InvoiceId { get; set; }

        [Required(ErrorMessage = "PaymentAmount cannot be null")]
        public decimal PaymentAmount { get; set; }

        [Required(ErrorMessage = "Name cannot be null")]
        public Guid BankId { get; set; }

        [Required(ErrorMessage = "AccountName cannot be null")]
        public string AccountName { get; set; }

        [Required(ErrorMessage = "PaymentDate cannot be null")]
        public DateTime PaymentDate { get; set; }

        public string Remarks { get; set; }
    }
}
