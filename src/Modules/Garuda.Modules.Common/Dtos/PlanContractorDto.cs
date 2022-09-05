using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Modules.Common.Dtos
{
    public class PlanContractorDto
    {
        public QPlanMineHeaderMandatory Mandatory { get; set; }

        public QPlanMineHeaderPerfomance Performance { get; set; }
    }

    public class QPlanMineHeaderMandatory
    {
        public QDetailstring Safety { get; set; }

        public QDetailstring Environment { get; set; }
    }

    public class QPlanMineHeaderPerfomance
    {
        public QDetailint ProductiveHours { get; set; }

        public QDetailint ObVolume { get; set; }

        public QDetailint CoalVolume { get; set; }
    }
}
