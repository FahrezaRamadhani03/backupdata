// <copyright file="InvoiceTaxRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using System;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.Invoice
{
    public class InvoiceTaxRequest
    {
        public Guid TaxId { get; set; }

        public decimal Rate { get; set; }

        public decimal Amount { get; set; }
    }
}
