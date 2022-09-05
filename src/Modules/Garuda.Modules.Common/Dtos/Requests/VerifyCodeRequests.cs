// <copyright file="VerifyCodeRequests.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.Common.Dtos.Requests
{
    public class VerifyCodeRequests
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        public string Provider { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string Code { get; set; }

        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
