// <copyright file="MsalAuthenticationHelper.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Microsoft.Graph;
using Microsoft.Identity.Client;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using System.Threading.Tasks;

namespace Garuda.Filestorage.Helper
{
    public class MsalAuthenticationHelper : IAuthenticationProvider
    {
        private static MsalAuthenticationHelper _singleton;
        private IPublicClientApplication _clientApplication;
        private string[] _scopes;
        private string _username;
        private SecureString _password;
        private string _userId;

        private MsalAuthenticationHelper(IPublicClientApplication clientApplication, string[] scopes, string username, SecureString password)
        {
            _clientApplication = clientApplication;
            _scopes = scopes;
            _password = password;
            _username = username;
            _userId = null;
        }

        public static MsalAuthenticationHelper GetInstance(IPublicClientApplication clientApplication, string[] scopes, string username, SecureString password)
        {
            if (_singleton == null)
            {
                _singleton = new MsalAuthenticationHelper(clientApplication, scopes, username, password);
            }
            return _singleton;
        }

        public async Task AuthenticateRequestAsync(HttpRequestMessage request)
        {
            var accessToken = await GetTokenAsync();

            request.Headers.Authorization = new AuthenticationHeaderValue("bearer", accessToken);
        }

        public async Task<string> GetTokenAsync()
        {
            if (!string.IsNullOrEmpty(_userId))
            {
                try
                {
                    var account = await _clientApplication.GetAccountAsync(_userId);

                    if (account != null)
                    {
                        var silentResult = await _clientApplication.AcquireTokenSilent(_scopes, account).ExecuteAsync();
                        return silentResult.AccessToken;
                    }
                }
                catch (MsalUiRequiredException) { }
            }
            var result = await _clientApplication.AcquireTokenByUsernamePassword(_scopes, _username, _password).ExecuteAsync();
            _userId = result.Account.HomeAccountId.Identifier;
            return result.AccessToken;
        }
    }
}
