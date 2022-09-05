using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Client
{
    public class ClientDetailResponse
    {
        public int Id { get; set; }

        public string CompanyCode { get; set; }

        public string CompanyAddress { get; set; }

        public string CompanyName { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string District { get; set; }

        public string ZipCode { get; set; }

        public string PICName { get; set; }

        public string PICEmail { get; set; }

        public string PICPhone { get; set; }

        public string InvoiceName { get; set; }

        public string InvoiceEmail { get; set; }
    }
}
