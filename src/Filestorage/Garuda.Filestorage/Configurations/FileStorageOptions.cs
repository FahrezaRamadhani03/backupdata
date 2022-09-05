using System;
using System.Collections.Generic;
using System.Text;

namespace Garuda.Filestorage.Configurations
{
    public class FileStorageOptions
    {
        public string UserId { get; set; }

        public string Password { get; set; }

        public string TenantId { get; set; }

        public string ApplicationId { get; set; }

        public string MaxUploadSize { get; set; }

        public string Host { get; set; }

        public string Node { get; set; }
    }
}
