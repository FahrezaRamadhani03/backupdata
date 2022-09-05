// <copyright file="FileResponse.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Modules.ProjectManagement.Dtos.Responses.File
{
    public class FileResponse
    {
        public string NameFile { get; set; }

        public string PathFile { get; set; }

        public string ContentType { get; set; }
    }
}
