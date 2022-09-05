// <copyright file="ReqResetPasswordRequests.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.Common.Dtos.Requests
{
    public class ReqResetPasswordRequests
    {
        [Required(ErrorMessage = "Email or Username field is required.")]
        public string EmailOrUser { get; set; }
    }
}
