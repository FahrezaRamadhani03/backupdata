// <copyright file="InvoiceDetailRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.Invoice
{
    public class InvoiceDetailRequest
    {
        public Guid? Id { get; set; }

        public Guid? InvoiceId { get; set; }

        [Required]
        [StringLength(maximumLength: 512)]
        public string Description { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        [Required]
        public decimal Subtotal { get; set; }
    }
}
