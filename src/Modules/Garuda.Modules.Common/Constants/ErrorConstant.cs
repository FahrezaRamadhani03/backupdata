// <copyright file="ErrorConstant.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;

namespace Garuda.Modules.Common.Constants
{
    /// <summary>
    /// Error Constant
    /// Put every single message error in here.
    /// </summary>
    public class ErrorConstant
    {
        // Untuk menampilkan Source data
        public static readonly HttpResponseLibraryException SOMETHING_WRONG = new HttpResponseLibraryException(Codes.INTERNAL_SERVER_ERROR, "Error", new MessageLangDto(null, "Something wrong!"));
    }
}
