// <copyright file="DataNotFoundExceptions.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;

namespace Garuda.Infrastructure.Exceptions
{
    public class DataNotFoundExceptions : Exception
    {
        public const string CustomError = "Data not found!";
        public const int Code = Codes.NOT_FOUND;

        public DataNotFoundExceptions()
            : base(string.Format($"{CustomError}"))
        {
            Status = Code;
            Title = "Data not Found";
            MessageIdn = CustomError;
            MessageEng = CustomError;
        }

        public DataNotFoundExceptions(int errorCode, string title, MessageLangDto error)
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
