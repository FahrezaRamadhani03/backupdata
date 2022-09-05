using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sieve.Attributes;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Timeline
{
    public class clientTimelineDto
    {
        public string ClientName { get; set; }

        public string PICName { get; set; }

        public string PICPhone { get; set; }

        public string PICEmail { get; set; }
    }
}
