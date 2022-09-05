// <copyright file="UnauthorizedException.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;

namespace Garuda.Infrastructure.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public const string CustomError = "You are unauthorized";
        public const int Code = Codes.UNAUTHORIZED;

        public UnauthorizedException()
            : base(string.Format($"{CustomError}"))
        {
            Title = "Unauthorized";
            MessageIdn = CustomError;
            MessageEng = CustomError;
            Status = Code;
        }

        public UnauthorizedException(int errorCode, string title, MessageLangDto error)
        {
            Status = errorCode;
            Title = title;
            MessageIdn = error.MessageIdn;
            MessageEng = error.MessageEng;
        }

        public int Status { get; set; }

        public string Title { get; set; }

        public string MessageIdn { get; set; }

        public string MessageEng { get; set; }
    }
}
