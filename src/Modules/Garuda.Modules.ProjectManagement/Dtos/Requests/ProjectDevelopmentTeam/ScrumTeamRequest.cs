// <copyright file="ScrumTeamRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentTeam
{
    public class ScrumTeamRequest
    {
        public Guid? EmployeeId { get; set; }

        public Guid? ClientId { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
