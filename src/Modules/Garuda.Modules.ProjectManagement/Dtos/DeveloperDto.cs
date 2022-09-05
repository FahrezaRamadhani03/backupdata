using System;
using System.Collections.Generic;

namespace Garuda.Modules.ProjectManagement.Dtos
{
    public class DeveloperDto
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public List<string> Roles { get; set; }

        public List<ProjectDateDto> Projects { get; set; }
    }
}
