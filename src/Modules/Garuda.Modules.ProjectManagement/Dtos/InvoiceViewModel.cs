// <copyright file="InvoiceViewModel.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garuda.Modules.ProjectManagement.Dtos
{
    public class InvoiceViewModel
    {
        public string InvoiceNo { get; set; }

        public string ProposalNo { get; set; }

        public DateTime InvoiceDate { get; set; }

        public DateTime OverdueDate { get; set; }

        public string GIKContractNo { get; set; }

        public string ClientContractNo { get; set; }

        public string Client { get; set; }

        public string ClientAddress { get; set; }

        public string ClientCity { get; set; }

        public string AdditionalNote { get; set; }

        public decimal Subtotal { get; set; }

        public decimal DiscountTotal { get; set; }

        public decimal TotalPayment { get; set; }

        public bool IsAdditionalDiscount { get; set; }

        public decimal AdditionalDiscount { get; set; }

        public List<InvoiceDetailModel> InvoiceDetails { get; set; }

        public List<InvoiceDetailTaxModel> InvoiceDetailTaxes { get; set; }
    }

    public class InvoiceDetailModel
    {
        public int No { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public decimal Subtotal { get; set; }
    }

    public class InvoiceDetailTaxModel
    {
        public string Name { get; set; }

        public decimal TaxAmount { get; set; }
    }
}
