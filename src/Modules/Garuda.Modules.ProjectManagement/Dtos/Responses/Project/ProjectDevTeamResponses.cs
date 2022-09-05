using System;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Project
{
    /// <summary>
    /// Dto for Project Development Team Response.
    /// </summary>
    public class ProjectDevTeamResponses
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public bool IsLeader { get; set; }
    }
}
