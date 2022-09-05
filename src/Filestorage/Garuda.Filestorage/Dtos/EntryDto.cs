// <copyright file="EntryDto.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Runtime.Serialization;

namespace Garuda.Filestorage.Dtos
{
    [DataContract]
    public class EntryDto
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "userId")]
        public string UserId { get; set; }
    }
}
