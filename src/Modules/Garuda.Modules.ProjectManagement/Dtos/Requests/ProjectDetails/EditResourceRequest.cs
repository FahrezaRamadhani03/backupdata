// <copyright file="EditResourceRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.ProjectDetails
{
    public class EditResourceRequest
    {
        [Required(ErrorMessage = "DevelopmentRoles cannot be null")]
        public string DevelopmentRoles { get; set; }

        [Required(ErrorMessage = "Quantity cannot be null")]
        public int Quantity { get; set; }
    }
}
