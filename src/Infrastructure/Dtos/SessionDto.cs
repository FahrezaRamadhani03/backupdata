// <copyright file="SessionDto.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garuda.Infrastructure.Dtos
{
    public class SessionDto
    {
        public Guid UserId { get; set; }

        public string UserRole { get; set; }

        public string Jti { get; set; }

        public string FullName { get; set; }

        public string AppName { get; set; }
    }
}
