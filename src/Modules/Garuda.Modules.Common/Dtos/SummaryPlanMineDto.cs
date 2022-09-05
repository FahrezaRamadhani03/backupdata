using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Modules.Common.Dtos
{
    public class SummaryPlanMineDto
    {
        public int Year { get; set; }

        public string Type { get; set; }

        public PlanMineCourseDto Details { get; set; }
    }
}
