// <copyright file="GlobalResponses.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Infrastructure.Constants;

namespace Garuda.Infrastructure.Dtos.Responses
{
    public class GlobalResponses
    {
        public GlobalResponses(string message, int code, string status, object data, string reroute, string token = null, string refreshToken = null)
        {
            Data = data;
            Token = token;
            RefreshToken = refreshToken;
        }

        public string Message { get; set; }

        public string Status { get; set; }

        public int Code { get; set; }

        public object Data { get; set; }

        public string Reroute { get; set; }

        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }
}
