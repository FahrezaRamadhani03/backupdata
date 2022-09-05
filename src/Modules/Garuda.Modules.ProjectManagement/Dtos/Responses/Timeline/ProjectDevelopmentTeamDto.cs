using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garuda.Modules.ProjectManagement.Models.Datas;
using Sieve.Attributes;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Timeline
{
    public class ProjectDevelopmentTeamDto
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public ProjectDetailDto ProjectDetail { get; set; }

        public Guid DeveloperId { get; set; }

        public Developer Developer { get; set; }

        public decimal ManADay { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal ManDays { get; set; }

        public bool IsLeader { get; set; }

        public IList<DevelopmentTeamRole> DevelopmentTeamRoles { get; set; } = new List<DevelopmentTeamRole>();
    }

}
