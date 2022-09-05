using Garuda.Modules.ProjectManagement.Dtos.Requests.FileUpload;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.ProjectFile
{
    public class EditProjectFileRequest : CreateProjectFileRequest
    {
        public int? Id { get; set; }

        public bool IsUpdated { get; set; }
    }

    public class RequestEditProjectFile
    {
        public EditProjectFileRequest[] Model { get; set; }
    }
}
