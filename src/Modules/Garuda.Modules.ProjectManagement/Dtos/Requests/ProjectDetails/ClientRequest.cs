// <copyright file="ClientRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using System;
using System.ComponentModel;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.ProjectDetails
{
    public class ClientRequest
    {
        public int Id { get; set; }

        [DefaultValue(false)]
        public bool IsRegisteredPIC { get; set; }

        public PICRequest PIC { get; set; }
    }
}
