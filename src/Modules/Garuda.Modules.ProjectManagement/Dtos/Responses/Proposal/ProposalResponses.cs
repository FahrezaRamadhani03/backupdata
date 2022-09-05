using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.Proposal
{
    /// <summary>
    /// Dto for Proposal Response.
    /// </summary>
    public class ProposalResponses
    {
        public int Id { get; set; }

        public Guid ProjectId { get; set; }

        public string DocumentNo { get; set; }

        public decimal? ProjectAmount { get; set; } = null;

        public DateTime? SentDate { get; set; } = null;

        public string FileName { get; set; }

        public string FileNameOri { get; set; }

        public string Remark { get; set; }

        public int ContractId { get; set; }

        public string ClientContractNo { get; set; }

        public string ClientFileNameOri { get; set; }

        public string GikContractNo { get; set; }

        public string GikFileNameOri { get; set; }

        public string OtherInfo { get; set; }

        public string ProposalUrl { get; set; }

        public string ClientContractUrl { get; set; }

        public string GikContractlUrl { get; set; }

        public string GikFileName { get; set; }

        public string ClientFileName { get; set; }
    }
}
