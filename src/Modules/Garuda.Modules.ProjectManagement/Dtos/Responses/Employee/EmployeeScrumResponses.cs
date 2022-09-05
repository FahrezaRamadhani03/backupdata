// <copyright file="EmployeeScrumResponses.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Sieve.Attributes;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses
{
    public class EmployeeScrumResponses
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or sets for User ID
        /// </summary>
        public Guid Id { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string Fullname { get; set; }

        public Guid? EmployeeId { get; set; }

        public int? ClientId { get; set; }
    }
}
