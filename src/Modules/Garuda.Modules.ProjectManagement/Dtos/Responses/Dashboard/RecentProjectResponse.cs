using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Dashboard
{
    public class RecentProjectResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public string PeriodDate { get; set; }

        public string KickOffDate { get; set; }

        public DateTime? LastModified { get; set; }
    }
}
