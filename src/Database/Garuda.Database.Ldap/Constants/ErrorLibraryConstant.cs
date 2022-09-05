// <copyright file="ErrorLibraryConstant.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;

namespace Garuda.Database.Ldap.Constants
{
    public class ErrorLibraryConstant
    {
        /* ERROR CODE */
        public static readonly string UNAUTHORIZED_CODE = "401";
        public static readonly string NOT_FOUND_CODE = "404";

        /* ERROR MESSAGE */
        public static readonly HttpResponseLibraryException CREATED = new HttpResponseLibraryException(201, "Created", new MessageLangDto(string.Empty, "The request has been fulfilled, resulting in the creation of a new resource."));
        public static readonly HttpResponseLibraryException BAD_REQUEST = new HttpResponseLibraryException(400, "Bad Request", new MessageLangDto(string.Empty, "The server cannot or will not process the request due to an apparent client error (e.g., malformed request syntax, size too large, invalid request message framing, or deceptive request routing)"));
        public static readonly HttpResponseLibraryException INVALID_BIRTHDAY = new HttpResponseLibraryException(400, "Bad Request", new MessageLangDto(string.Empty, "Date of birth is invalid"));
        public static readonly HttpResponseLibraryException INCORRECT_CREDENTIAL = new HttpResponseLibraryException(40101, "Incorrect Credential", new MessageLangDto(string.Empty, "Incorrect username or password."));
        public static readonly HttpResponseLibraryException ROLE_NOT_APPROPRIATED = new HttpResponseLibraryException(40102, "Unauthorized", new MessageLangDto(string.Empty, "The role is not appropriate"));
        public static readonly HttpResponseLibraryException AD_USER_NOT_REGISTERED = new HttpResponseLibraryException(40103, "Unauthorized", new MessageLangDto(string.Empty, "Account is not registered in DHM. Please contact your administrator."));
        public static readonly HttpResponseLibraryException INACTIVE_USER = new HttpResponseLibraryException(40104, "Unauthorized", new MessageLangDto(string.Empty, "Account is no longer active. Please contact your administrator."));
        public static readonly HttpResponseLibraryException REFRESH_TOKEN_EXPIRED = new HttpResponseLibraryException(40105, "Refresh Token Expired", new MessageLangDto(string.Empty, "Your refresh token has expired. Please refresh it to get new token"));
        public static readonly HttpResponseLibraryException NOT_FOUND = new HttpResponseLibraryException(404, "Not Found", new MessageLangDto(string.Empty, "The requested resource could not be found"));
        public static readonly HttpResponseLibraryException CONFLICT = new HttpResponseLibraryException(409, "Conflict", new MessageLangDto(string.Empty, "The email or username has been used"));
        public static readonly HttpResponseLibraryException HRIS_NOT_FOUND = new HttpResponseLibraryException(202, "AD User empty", new MessageLangDto(string.Empty, "AD User not registered in HRIS. Please input NRIC"));
    }
}
