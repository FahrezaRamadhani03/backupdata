using System;
using Garuda.Modules.ProjectManagement.Dtos.Requests.FileUpload;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.ProjectFile
{
    /// <summary>
    /// Dto for Project File Response.
    /// </summary>
    public class ProjectFileResponses
    {
        public int Id { get; set; }

        public Guid ProjectId { get; set; }

        public string DocumentName { get; set; }

        public string DocumentDesc { get; set; }

        public string FileSource { get; set; }

        public string FileNameOri { get; set; }

        public string FileName { get; set; }

        public string Link { get; set; }

        public string FileUrl { get; set; }
    }
}
