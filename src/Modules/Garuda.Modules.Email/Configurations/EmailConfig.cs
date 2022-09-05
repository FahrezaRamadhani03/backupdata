// <copyright file="EmailConfig.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace Garuda.Modules.Email.Configurations
{
    public class EmailConfig
    {
        public string SmtpName { get; set; }

        public string SmtpServer { get; set; }

        public int SmtpPort { get; set; }

        public string SmtpUsername { get; set; }

        public string SmtpPassword { get; set; }

        public int ExpireTime { get; set; }
    }
}
