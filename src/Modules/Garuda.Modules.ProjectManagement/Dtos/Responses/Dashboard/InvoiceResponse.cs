using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Dashboard
{
    public class InvoiceResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string StatusInvoice { get; set; }

        public string Invoice { get; set; }

        public string InvoiceDate { get; set; }
    }
}
