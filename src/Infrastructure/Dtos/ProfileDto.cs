// <copyright file="ProfileDto.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garuda.Infrastructure.Dtos
{
    public class ProfileDto
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string PictureUrl { get; set; }

        public string UserRole { get; set; }
    }
}
