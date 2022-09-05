// <copyright file="Codes.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

namespace Garuda.Infrastructure.Constants
{
    /// <summary>
    /// Error Status Code
    /// </summary>
    public static class Codes
    {
        // Connection Lost
        public const int CONNECTION_LOST = 100;

        // Success Code
        public const int SUCCESS = 200;

        // Created Code
        public const int CREATED = 201;

        // Validation Entity/Model
        public const int BAD_REQUEST = 400;

        // Unauthorized
        public const int UNAUTHORIZED = 401;

        // User Inactive
        public const int INACTIVE = 4011;

        // Wrong Credential User login
        public const int WRONG_CREDENTIAL = 4012;

        // Data Not Found
        public const int NOT_FOUND = 404;

        // Data Conflict
        public const int CONFLICT = 409;

        // Error URI too large
        public const int HTTP_RESPONSE = 414;

        // Error Transaction -> Save Update Delete
        public const int ERROR_TRANSACT = 422;

        // If theres any duplicate data error on Save
        public const int ERROR_TRANSACT_DUPLICATE = 4221;

        // Error code while Save Data to database
        public const int ERROR_TRANSACT_SAVE = 4222;

        // Error code while Update Data to database
        public const int ERROR_TRANSACT_UPDATE = 4223;

        // Error code while Delete Data to Database
        public const int ERROR_TRANSACT_DELETE = 4224;

        // Invalid Session/Expired
        public const int INVALID_SESSION = 440;

        // Internal Server Error -> Framework etc..
        public const int INTERNAL_SERVER_ERROR = 500;
    }
}
