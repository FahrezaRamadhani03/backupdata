using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Timeline
{
    public class TimelineByProjectResponse
    {
        public List<ProjectTimelineDto> Projects { get; set; }

        public int TotalData { get; set; }
    }
}
