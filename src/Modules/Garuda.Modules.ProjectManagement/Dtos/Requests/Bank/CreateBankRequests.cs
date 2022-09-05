// <copyright file="CreateBankRequests.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.Bank
{
    public class CreateBankRequests
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Code
        /// </summary>
        [Required(ErrorMessage = "Code cannot be null")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for Name
        /// </summary>
        [Required(ErrorMessage = "Name cannot be null")]
        public string Name { get; set; }
    }
}
