// <copyright file="AdditionalEmailConfiguration.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace Garuda.Modules.Email.Actions
{
    public class AdditionalEmailConfiguration
    {
        public string EmailEnvironment { get; set; }

        public List<string> AdditionalEmails { get; set; }

        public List<string> EmailToMembers { get; set; }
    }
}
