// <copyright file="RefreshTokenDto.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;

namespace Garuda.Infrastructure.Dtos
{
    public class RefreshTokenDto
    {
        public string StrRefreshToken { get; set; }

        public int? UserId { get; set; }

        public DateTime? DatRevoked { get; set; }

        public DateTime DatExpired { get; set; }

        public string StrJti { get; set; }
    }
}
