// <copyright file="BadRequestException.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;

namespace Garuda.Filestorage.Exceptions
{
    public class BadRequestException : HttpResponseLibraryException
    {
        public BadRequestException(MessageLangDto message)
            : base(400, "Bad Request", message)
        {
        }
    }
}
