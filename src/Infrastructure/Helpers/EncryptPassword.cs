using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Infrastructure.Helpers
{
    public static class EncryptPassword
    {
        /// <summary>
        /// Verify Password
        /// </summary>
        /// <param name="enteredPassword"></param>
        /// <param name="hashedPassword"></param>
        /// <returns></returns>
        public static bool VerifyPassword(this string enteredPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
        }

        /// <summary>
        /// Encrypt passwowrd
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Encrypt(this string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
