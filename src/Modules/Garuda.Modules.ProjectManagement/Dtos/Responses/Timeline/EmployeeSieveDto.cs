// <copyright file="EmployeeSieveDto.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Sieve.Attributes;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Timeline
{
    public class EmployeeSieveDto
    {
        public Guid Id { get; set; }

        public string Fullname { get; set; }

        public Guid? EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public int? ClientId { get; set; }

        public ClientDto Client { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public IList<ProjectDevelopmentTeamDto> ProjectDevelopmentTeams { get; set; } = new List<ProjectDevelopmentTeamDto>();

        public IList<DeveloperRole> DeveloperRoles { get; set; } = new List<DeveloperRole>();
    }
}
