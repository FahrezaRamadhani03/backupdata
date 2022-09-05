// <copyright file="SendInvoiceRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using System;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.Invoice
{
    public class SendInvoiceRequest
    {
        public Guid InvoiceId { get; set; }

        public DateTime SendDate { get; set; }

        public string Remarks { get; set; }
    }
}
