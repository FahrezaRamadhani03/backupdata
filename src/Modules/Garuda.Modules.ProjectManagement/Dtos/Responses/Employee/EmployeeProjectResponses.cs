// <copyright file="EmployeeProjectResponses.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Sieve.Attributes;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses
{
    public class EmployeeProjectResponses
    {
        public string Name { get; set; }

        public string Status { get; set; }

        public DateTime SprintStart { get; set; }

        public DateTime SprintEnd { get; set; }

        public IList<DeveloperRoleResponses> DeveloperRoles { get; set; } = new List<DeveloperRoleResponses>();
    }
}
