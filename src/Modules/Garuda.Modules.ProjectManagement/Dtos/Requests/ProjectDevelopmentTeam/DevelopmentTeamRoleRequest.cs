// <copyright file="DevelopmentTeamRoleRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.DevelopmentTeam
{
    public class DevelopmentTeamRoleRequest
    {
        [Required]
        public Guid RoleId { get; set; }

        public Guid LevelId { get; set; }
    }
}
