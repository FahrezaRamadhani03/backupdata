// <copyright file="CreatePaymentTermRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.PaymentTerm
{
    public class CreatePaymentTermRequest
    {
        [Required(ErrorMessage = "ProjectId cannot be null")]
        public Guid ProjectId { get; set; }

        [Required(ErrorMessage = "OverdueLength cannot be null")]
        public int OverdueLength { get; set; }

        [Required(ErrorMessage = "OverdueUnit cannot be null")]
        public string OverdueUnit { get; set; }

        public List<PaymentTermRequest> PaymentTerms { get; set; }
    }
}
