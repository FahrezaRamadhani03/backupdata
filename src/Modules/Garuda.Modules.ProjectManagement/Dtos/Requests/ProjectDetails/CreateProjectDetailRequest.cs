// <copyright file="CreateProjectDetailRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Garuda.Modules.ProjectManagement.Dtos.Requests.ProjectDetails
{
    public class CreateProjectDetailRequest
    {
        public ClientRequest Client { get; set; }

        [Required(ErrorMessage = "Name cannot be null")]
        [StringLength(maximumLength: 255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Key cannot be null")]
        [StringLength(maximumLength: 100)]
        public string Key { get; set; }

        [Required(ErrorMessage = "InitState cannot be null")]
        [StringLength(maximumLength: 100)]
        public string InitState { get; set; }

        [Required(ErrorMessage = "Status cannot be null")]
        [StringLength(maximumLength: 100)]
        public string Status { get; set; }

        [StringLength(maximumLength: 255, ErrorMessage = "ShortDescription cannot be longer than 255 characther")]
        public string ShortDescription { get; set; }

        [StringLength(maximumLength: 255, ErrorMessage = "Description cannot be longer than 255 characther")]
        public string Description { get; set; }

        public List<string> Technologies { get; set; }

        public List<ResourceRequest> Resources { get; set; }

        public string TypeOfCorporation { get; set; }
    }
}
