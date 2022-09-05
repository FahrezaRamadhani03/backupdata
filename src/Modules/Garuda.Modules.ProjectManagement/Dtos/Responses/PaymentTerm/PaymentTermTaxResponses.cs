// <copyright file="PaymentTermTaxResponses.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Sieve.Attributes;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses
{
    public class PaymentTermTaxResponses
    {
        public Guid Id { get; set; }

        public Guid PaymentTermId { get; set; }

        public Guid TaxId { get; set; }
    }
}
