// <copyright file="PayloadTooLargeException.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;

namespace Garuda.Filestorage.Exceptions
{
    public class PayloadTooLargeException : HttpResponseLibraryException
    {
        public PayloadTooLargeException(MessageLangDto message)
            : base(413, "Payload Too Large", message)
        {
        }
    }
}
