// <copyright file="CreateProposalRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Garuda.Modules.ProjectManagement.Dtos.Requests.FileUpload;
using Microsoft.AspNetCore.Http;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests
{
    public class CreateProposalRequest
    {
        [Required(ErrorMessage = "The Project Id field is required.")]
        public Guid ProjectId { get; set; }

        public string ProjectCode { get; set; }

        public string DocumentNo { get; set; }

        public int? ProjectAmount { get; set; }

        public DateTime? SentDate { get; set; }

        public string FileName { get; set; }

        public string FileNameOri { get; set; }

        public string GikContractNo { get; set; }

        public string GikFileName { get; set; }

        public string GikFileNameOri { get; set; }

        public string ClientContractNo { get; set; }

        public string ClientFileName { get; set; }

        public string ClientFileNameOri { get; set; }

        public string OtherInfo { get; set; }

        public string Remark { get; set; }

        public IFormFile FileProposal { get; set; }

        public IFormFile FileGIKContract { get; set; }

        public IFormFile FileClientContract { get; set; }
    }
}
