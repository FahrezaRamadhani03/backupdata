// <copyright file="AlfrescoAuthDto.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Runtime.Serialization;

namespace Garuda.Filestorage.Alfresco.Dtos
{
    [DataContract]
    public class AlfrescoAuthDto
    {
        [DataMember(Name = "userId")]
        public string UserId { get; set; }

        [DataMember(Name = "password")]
        public string Password { get; set; }
    }
}