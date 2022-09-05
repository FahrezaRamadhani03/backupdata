// <copyright file="DevelopmentTeamRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentTeam
{
    public class DevelopmentTeamRequest
    {
        public Guid? Id { get; set; }

        public Guid EmployeeId { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required]
        public decimal ManADay { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal ManDays { get; set; }

        [Required]
        public bool IsLeader { get; set; }

        public string Status { get; set; }

        public List<DevelopmentTeamRoleRequest> DevelopmentTeamRoleRequests { get; set; }
    }
}
