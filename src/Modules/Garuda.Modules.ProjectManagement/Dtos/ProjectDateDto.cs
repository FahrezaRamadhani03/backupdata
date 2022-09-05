using System;

namespace Garuda.Modules.ProjectManagement.Dtos
{
    public class ProjectDateDto
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string Role { get; set; }

        public string Status { get; set; }
    }
}
