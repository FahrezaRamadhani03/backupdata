// <copyright file="LoginResponses.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using Garuda.Infrastructure.Exceptions;

namespace Garuda.Modules.Common.Dtos.Responses
{
    /// <summary>
    /// Dto Login Responses
    /// </summary>
    public class LoginResponses
    {
        /// <summary>
        /// Gets or Sets for UserId
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets for Tokens
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets for RefreshTokens
        /// </summary>
        public string RefreshToken { get; set; }
    }
}