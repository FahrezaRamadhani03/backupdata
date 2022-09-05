using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Expense
{
    public class ProjectCostSummaryResponse
    {
        public decimal ProjectCost { get; set; }

        public decimal Labour { get; set; }

        public decimal Expenses { get; set; }

        public decimal UninvoicedAmount { get; set; }

        public decimal ProjectAmount { get; set; }

        public decimal UnpaidAmount { get; set; }

        public decimal OverdueAmount { get; set; }

        public decimal PaidAmount { get; set; }

        public decimal ProfitEstimation { get; set; }
    }
}
