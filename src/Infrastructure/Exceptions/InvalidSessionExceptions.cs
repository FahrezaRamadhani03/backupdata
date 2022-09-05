// <copyright file="InvalidSessionExceptions.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;

namespace Garuda.Infrastructure.Exceptions
{
    public class InvalidSessionExceptions : Exception
    {
        public const string CustomError = "You are unauthorized or Your session is invalid!";
        public const int Code = Codes.INVALID_SESSION;

        public InvalidSessionExceptions()
            : base(string.Format($"{CustomError}"))
        {
            Title = "Invalid Session";
            MessageIdn = CustomError;
            MessageEng = CustomError;
        }

        public InvalidSessionExceptions(int errorCode, string title, MessageLangDto error)
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
