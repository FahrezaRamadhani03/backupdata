using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.ProjectDevelopmentTeam
{
    public class ProjectDevelopmentTeamResponses
    {
        [Required(ErrorMessage = "ProjectId cannot be null")]
        public Guid ProjectId { get; set; }

        [Required(ErrorMessage = "PoDeveloper cannot be null")]
        public string PoDeveloper { get; set; }

        [Required(ErrorMessage = "SmDeveloperId cannot be null")]
        public Guid SmDeveloperId { get; set; }

        [Required(ErrorMessage = "ProjectDevelopmentTeams cannot be null")]
        public List<DevelopmentTeamResponses> ProjectDevelopmentTeams { get; set; }
    }
}
