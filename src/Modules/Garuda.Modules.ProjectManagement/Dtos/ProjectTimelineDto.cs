// <copyright file="ProjectTimelineDto.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Modules.ProjectManagement.Dtos
{
    public class ProjectTimelineDto
    {
        public Guid ProjectId { get; set; }

        public int? ClientId { get; set; }

        public string Name { get; set; }

        public string ClientName { get; set; }

        public List<string> Sprints { get; set; }

        public List<TimelineDate> Dates { get; set; }
    }
}
