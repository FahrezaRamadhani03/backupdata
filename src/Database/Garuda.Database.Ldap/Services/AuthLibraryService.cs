// <copyright file="AuthLibraryService.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Linq;
using System.Threading.Tasks;
using Garuda.Database.Ldap.Configurations;
using Garuda.Database.Ldap.Constants;
using Garuda.Database.Ldap.Contracts;
using Garuda.Infrastructure.Constants;
using Garuda.Infrastructure.Exceptions;
using Microsoft.Extensions.Options;
using Novell.Directory.Ldap;

namespace Garuda.Database.Ldap.Services
{
    public class AuthLibraryService : IAuthLibraryService
    {
        // LDAP Login attributes
        private const string MailAttribute = "mail";
        private const string DisplayNameAttribute = "displayName";
        private const string SAMAccountNameAttribute = "sAMAccountName";

        private readonly LdapLibraryConfig _config;
        private readonly ILdapConnection _connection;

        public AuthLibraryService(
            IOptions<LdapLibraryConfig> config,
            ILdapConnection ldapConnection)
        {
            _config = config.Value;
            _connection = ldapConnection;
        }

        public async Task<(LdapEntry ldapEntry, string domain, HttpResponseLibraryException error)> CheckAdUser(string username, string password, string findUsername = null)
        {
            foreach (var config in _config.LdapLibraryItems)
            {
                try
                {
                    // AD User Check
                    var ldapUser = new LdapEntry();
                    if (findUsername != null)
                    {
                        ldapUser = await ADUserCheck(_connection, username, password, config, findUsername);
                    }
                    else
                    {
                        ldapUser = await ADUserCheck(_connection, username, password, config, username);
                    }

                    if (ldapUser != null)
                    {
                        return (ldapUser, config.Domain, ErrorLibraryConstant.HRIS_NOT_FOUND);
                    }
                    else
                    {
                        return (null, config.Domain, ErrorLibraryConstant.AD_USER_NOT_REGISTERED);
                    }
                }
                catch (BadRequestException)
                {
                    throw new BadRequestException();
                }
            }

            return (null, null, ErrorLibraryConstant.NOT_FOUND);
        }

        private async Task<LdapEntry> ADUserCheck(ILdapConnection connection, string username, string password, LdapLibraryItem config, string findUsername = null)
        {
            try
            {
                _connection.Connect(config.Url, LdapConnection.DefaultPort);
                _connection.Bind(string.Concat(username, "@", config.Domain), password);

                var searchFilter = string.Format(config.SearchFilter, findUsername);
                var results = connection.Search(
                    config.SearchBase,
                    LdapConnection.ScopeSub,
                    searchFilter,
                    new[] { MailAttribute, DisplayNameAttribute, SAMAccountNameAttribute },
                    false);

                await Task.Delay(1000);

                while (results.HasMore())
                {
                    LdapEntry ldap = null;
                    try
                    {
                        ldap = results.Next();
                    }
                    catch
                    {
                        continue;
                    }

                    ldap.GetAttributeSet();
                    _connection.Disconnect();
                    return ldap;
                }

                return null;
            }
            catch (Exception)
            {
                if (_connection.Connected)
                {
                    _connection.Disconnect();
                }

                throw ErrorConstant.INVALID_SESSION;
            }
        }
    }
}
