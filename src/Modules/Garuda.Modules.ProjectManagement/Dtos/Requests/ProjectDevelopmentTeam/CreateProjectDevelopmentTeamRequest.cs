// <copyright file="CreateProjectDevelopmentTeamRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentTeam
{
    public class CreateProjectDevelopmentTeamRequest
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "ProjectId cannot be null")]
        public Guid ProjectId { get; set; }

        [Required(ErrorMessage = "ScrumMasterId cannot be null")]
        public Guid ScrumMasterId { get; set; }

        [Required(ErrorMessage = "Project Owner cannot be null")]
        public string ProjectOwner { get; set; }

        [Required]
        public List<DevelopmentTeamRequest> DevelopmentTeams { get; set; }
    }
}
