// <copyright file="HttpResponseLibraryException.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;

namespace Garuda.Infrastructure.Exceptions
{
    public class HttpResponseLibraryException : Exception
    {
        /// <summary>
        /// Standard Text error for HttpResponseLibraryException
        /// </summary>
        public const string CustomError = "Oops! Something went wrong!";

        /// <summary>
        /// Sets const Code error 414.
        /// </summary>
        public const int Code = Codes.HTTP_RESPONSE;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResponseLibraryException"/> class.
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="title"></param>
        /// <param name="error"></param>
        public HttpResponseLibraryException(int errorCode, string title, MessageLangDto error)
        {
            Status = errorCode;
            Title = title;
            MessageIdn = error.MessageIdn;
            MessageEng = error.MessageEng;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResponseLibraryException"/> class.
        /// </summary>
        /// <param name="customError"></param>
        public HttpResponseLibraryException(string customError)
          : base(string.Format("{0} : {1}", Code, customError))
        {
        }

        /// <summary>
        /// Gets or sets for Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets for Status
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Gets or sets for MessageIdn
        /// </summary>
        public string MessageIdn { get; set; }

        /// <summary>
        /// Gets or sets for MessageEng
        /// </summary>
        public string MessageEng { get; set; }
    }
}
