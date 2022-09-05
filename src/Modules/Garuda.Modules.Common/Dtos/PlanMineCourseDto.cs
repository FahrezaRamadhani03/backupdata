using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Modules.Common.Dtos
{
    public class PlanMineCourseDto
    {
        public QHeaderMandatory Mandatory { get; set; }

        public QHeaderPerfomance Performance { get; set; }
    }

    public class QHeaderMandatory
    {
        public QDetailstring Safety { get; set; }
    }

    public class QHeaderPerfomance
    {
        public QDetailint Tonnage { get; set; }

        public QDetailint ProductionCostPerTon { get; set; }

        public QCoalQualityDetail CoalQuality { get; set; }

        public QDetailint Revegation { get; set; }
    }

    public class QCoalQualityDetail
    {
        public QDetailint CV { get; set; }

        public QDetailint TS { get; set; }
    }

    public class QDetailint
    {
        public int Q1 { get; set; }

        public int Q2 { get; set; }

        public int Q3 { get; set; }

        public int Q4 { get; set; }
    }

    public class QDetailstring
    {
        public string Q1 { get; set; }

        public string Q2 { get; set; }

        public string Q3 { get; set; }

        public string Q4 { get; set; }
    }
}
