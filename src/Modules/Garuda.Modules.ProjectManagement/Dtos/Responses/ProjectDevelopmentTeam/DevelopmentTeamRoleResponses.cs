// <copyright file="DevelopmentTeamRoleResponses.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.ProjectDevelopmentTeam
{
    public class DevelopmentTeamRoleResponses
    {
        [Required]
        public Guid RoleId { get; set; }

        public string RoleName { get; set; }

        public Guid LevelId { get; set; }

        public string LevelName { get; set; }
    }
}
