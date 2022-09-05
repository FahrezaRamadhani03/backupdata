// <copyright file="RequestTimeoutException.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;

namespace Garuda.Filestorage.Exceptions
{
    public class RequestTimeoutException : HttpResponseLibraryException
    {
        public RequestTimeoutException(MessageLangDto message)
            : base(408, "Request Timeout", message)
        {
        }
    }
}
