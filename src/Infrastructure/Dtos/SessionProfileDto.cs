// <copyright file="SessionProfileDto.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

namespace Garuda.Infrastructure.Dtos
{
    public class SessionProfileDto : ProfileDto
    {
        public SessionProfileDto(ProfileDto profile, SessionTokenDto token)
        {
            FullName = profile.FullName;
            Email = profile.Email;
            UserRole = profile.UserRole;
            PictureUrl = profile.PictureUrl;
            PhoneNumber = profile.PhoneNumber;
            Token = token;
        }

        public SessionTokenDto Token { get; set; }
    }
}
