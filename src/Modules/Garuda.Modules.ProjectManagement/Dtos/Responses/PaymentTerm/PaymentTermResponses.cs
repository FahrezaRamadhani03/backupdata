// <copyright file="PaymentTermResponses.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.PaymentTerm
{
    public class PaymentTermResponses
    {
        public Guid ProjectId { get; set; }

        public decimal ProjectAmount { get; set; }

        public int OverdueLength { get; set; }

        public string OverdueUnit { get; set; }

        public IList<PaymentTermsResponses> PaymentTerms { get; set; } = new List<PaymentTermsResponses>();
    }
}
