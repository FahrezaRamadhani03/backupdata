using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.PaymentTerm
{
    public class PaymentTermsResponses
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public int TermNo { get; set; }

        public string Title { get; set; }

        public string Remarks { get; set; }

        public decimal Percentage { get; set; }

        public decimal Amount { get; set; }

        public Guid? InvoiceId { get; set; }

        public DateTime InvoiceDate { get; set; }

        public DateTime ReminderDate { get; set; }

        public string InvoiceNote { get; set; }

        public IList<PaymentTermTaxResponses> Taxes { get; set; } = new List<PaymentTermTaxResponses>();
    }
}
