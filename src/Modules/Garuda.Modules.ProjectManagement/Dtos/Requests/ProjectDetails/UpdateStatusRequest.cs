// <copyright file="UpdateStatusRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using Garuda.Modules.ProjectManagement.Dtos.Requests.FileUpload;
using System;
using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.ProjectDetails
{
    public class UpdateStatusRequest
    {
        public Guid ProjectId { get; set; }

        public string Action { get; set; }

        public string Remark { get; set; }

        public string SPKNo { get; set; }

        public DateTime? SPKDate { get; set; }

        public FileUploadRequest SPKUploads { get; set; }
    }
}
