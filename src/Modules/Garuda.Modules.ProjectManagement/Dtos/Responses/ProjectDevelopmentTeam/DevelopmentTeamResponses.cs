// <copyright file="DevelopmentTeamResponses.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.ProjectDevelopmentTeam
{
    public class DevelopmentTeamResponses
    {
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }

        [Required(ErrorMessage = "Fullname cannot be null")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "ManADay cannot be null")]
        public decimal ManADay { get; set; }

        [Required(ErrorMessage = "StartDate cannot be null")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "EndDate cannot be null")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "ManDays cannot be null")]
        public decimal ManDays { get; set; }

        [Required(ErrorMessage = "IsLeader cannot be null")]
        public bool IsLeader { get; set; }

        public int ProjectCount { get; set; }

        public string DeveloperRole { get; set; }

        public string DeveloperLevel { get; set; }

        public List<DevelopmentTeamRoleResponses> DevelopmentTeamRoles { get; set; }
    }
}
