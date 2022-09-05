using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Garuda.Modules.ProjectManagement.Dtos.Requests.FileUpload;
using Microsoft.AspNetCore.Http;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.ProjectFile
{
    public class CreateProjectFileRequest
    {
        [Required(ErrorMessage = "The Document Name field is required.")]
        public string DocumentName { get; set; }

        public string DocumentDesc { get; set; }

        [Required(ErrorMessage = "The File Source field is required.")]
        public string FileSource { get; set; }

        public string Link { get; set; }

        public IFormFile FileUploads { get; set; }
    }

    public class RequestProjectFile
    {
        public CreateProjectFileRequest[] Model { get; set; }
    }
}
