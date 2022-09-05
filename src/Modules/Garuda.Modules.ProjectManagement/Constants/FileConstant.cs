// <copyright file="FileConstant.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.ComponentModel;

namespace Garuda.Modules.ProjectManagement.Constants
{
    public class FileConstant
    {
        public const int MAX_FILE_SIZE_PROPOSAL = 10 * 1024 * 1024;
        public const int MAX_FILE_SIZE_PROJECT_FILE = 10 * 1024 * 1024;
        public const int MAX_FILE_SIZE_SPK = 10 * 1024 * 1024;

        public const string ALLOWED_EXTENSION_PROJECT_FILE = ".pdf, .jpg, .jpeg, .png, .gif, .doc, .docx";
        public const string ALLOWED_EXTENSION_PROPOSAL = ".pdf, .doc, .docx";
        public const string ALLOWED_EXTENSION_SPK = ".pdf";
    }
}
