// <copyright file="UnauthorizedException.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>


using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;

namespace Garuda.Filestorage.Exceptions
{
    public class UnauthorizedException : HttpResponseLibraryException
    {
        public UnauthorizedException(MessageLangDto message)
            : base(401, "Unauthorized", message)
        {
        }
    }
}
