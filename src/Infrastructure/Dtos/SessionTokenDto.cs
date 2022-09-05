// <copyright file="SessionTokenDto.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garuda.Infrastructure.Dtos
{
    public class SessionTokenDto
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public DateTime SessionExpiredAt { get; set; }

        public string Jti { get; set; }
    }
}
