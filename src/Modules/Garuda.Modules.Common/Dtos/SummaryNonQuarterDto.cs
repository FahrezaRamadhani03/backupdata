using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Modules.Common.Dtos
{
    public class SummaryNonQuarterDto
    {
        public int Year { get; set; }

        public string Type { get; set; }

        public SummaryNonQuarterDetailDto Detail { get; set; }
    }

    public class SummaryNonQuarterDetailDto
    {
        public int Q1 { get; set; }

        public int Q2 { get; set; }

        public int Q3 { get; set; }

        public int Q4 { get; set; }

    }
}
