// <copyright file="IAuthLibraryService.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Garuda.Infrastructure.Exceptions;
using Novell.Directory.Ldap;

namespace Garuda.Database.Ldap.Contracts
{
    /// <summary>
    /// IAuthLibraryService Ldap.
    /// </summary>
    public interface IAuthLibraryService
    {
        /// <summary>
        /// Check AD Users.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="findUsername"></param>
        /// <returns></returns>
        Task<(LdapEntry ldapEntry, string domain, HttpResponseLibraryException error)> CheckAdUser(string username, string password, string findUsername = null);
    }
}
