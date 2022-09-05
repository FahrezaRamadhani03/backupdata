// <copyright file="NotFoundException.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;

namespace Garuda.Filestorage.Exceptions
{
    public class NotFoundException : HttpResponseLibraryException
    {
        public NotFoundException(MessageLangDto message)
            : base(404, "Not Found", message)
        {
        }
    }
}
