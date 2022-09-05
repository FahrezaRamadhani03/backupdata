using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.FileUpload
{
    public class FileUploadRequest
    {
        public string FileName { get; set; }

        public string FileType { get; set; }

        public string FileExtension { get; set; }

        public string Base64 { get; set; }

        public byte[] Data { get; set; }
    }
}
