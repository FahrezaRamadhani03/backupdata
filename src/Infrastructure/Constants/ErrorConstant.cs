// <copyright file="ErrorConstant.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Infrastructure.Dtos;
using Garuda.Infrastructure.Exceptions;

namespace Garuda.Infrastructure.Constants
{
    /// <summary>
    /// Error Constant
    /// Put every single message error in here.
    /// </summary>
    public class ErrorConstant
    {
        // Untuk menampilkan Source data
        public static readonly HttpResponseLibraryException UNAUTHORIZED = new HttpResponseLibraryException(Codes.UNAUTHORIZED, "Unauthorized user", new MessageLangDto("Tidak mempunyai permission", "Unauthorized"));
        public static readonly HttpResponseLibraryException INACTIVE_USER = new HttpResponseLibraryException(Codes.INACTIVE, "Inactive User", new MessageLangDto("Akun anda tidak aktif", "Your account is inactive."));
        public static readonly HttpResponseLibraryException INVALID_USERNAME = new HttpResponseLibraryException(Codes.INACTIVE, "Invalid Username", new MessageLangDto(string.Empty, "Invalid username and Password"));
        public static readonly HttpResponseLibraryException INVALID_USER = new HttpResponseLibraryException(Codes.INACTIVE, "Invalid User", new MessageLangDto(string.Empty, "Invalid username or email"));

        public static readonly InvalidSessionExceptions INVALID_SESSION = new InvalidSessionExceptions(Codes.INVALID_SESSION, "Invalid Session", new MessageLangDto("sesi anda telah habis", "Your session is invalid"));

        public static readonly ErrorTransactExceptions TRANSACT_ERROR = new ErrorTransactExceptions(Codes.ERROR_TRANSACT, "Transact Failed", new MessageLangDto("Terjadi kesalahan dalam Transact", "Something went wrong on Transact Data"));
        public static readonly ErrorTransactExceptions TRANSACT_SAVE = new ErrorTransactExceptions(Codes.ERROR_TRANSACT_SAVE, "Transact Failed", new MessageLangDto("Terjadi kesalahan dalam menyimpan data", "Failed to save data"));
        public static readonly ErrorTransactExceptions TRANSACT_UPDATE = new ErrorTransactExceptions(Codes.ERROR_TRANSACT_UPDATE, "Transact Failed", new MessageLangDto("Terjadi kesalahan dalam mengupdate data", "Failed to update data"));
        public static readonly ErrorTransactExceptions TRANSACT_DELETE = new ErrorTransactExceptions(Codes.ERROR_TRANSACT_DELETE, "Transact Failed", new MessageLangDto("Terjadi kesalahan dalam menghapus data", "Failed to delete data"));
        public static readonly ErrorTransactExceptions TRANSACT_DUPLICATE = new ErrorTransactExceptions(Codes.ERROR_TRANSACT_DELETE, "Transact Failed", new MessageLangDto("terjadi duplikasi data", "Duplicated Data"));
    }
}
