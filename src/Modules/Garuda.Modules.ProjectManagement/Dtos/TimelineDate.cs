using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Modules.ProjectManagement.Dtos
{
    public class TimelineDate
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string SprintNo { get; set; }

        public string Status { get; set; }
    }
}
