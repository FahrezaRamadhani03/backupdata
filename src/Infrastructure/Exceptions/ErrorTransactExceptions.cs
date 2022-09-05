// <copyright file="ErrorTransactExceptions.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Dtos;

namespace Garuda.Infrastructure.Exceptions
{
    public class ErrorTransactExceptions : Exception
    {
        public const string CustomError = "Error while transact data.";
        public const int Code = Codes.ERROR_TRANSACT;

        public ErrorTransactExceptions()
            : base(string.Format($"{CustomError}"))
        {
            Title = "Failed to save data";
            MessageIdn = CustomError;
            MessageEng = CustomError;
        }

        public ErrorTransactExceptions(int errorCode, string title, MessageLangDto error)
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
