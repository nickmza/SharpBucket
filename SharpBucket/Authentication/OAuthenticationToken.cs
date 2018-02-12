using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBucket.Authentication
{
    /// <summary>
    /// Allows SharpBucket to authenticate using a token obtained from the OAUTH https://bitbucket.org/site/oauth2/authorize endpoint. 
    /// </summary>
    public class OAuthenticationToken : OAuthentication2
    {
        private const string TokenUrl = "https://bitbucket.org/site/oauth2/access_token";
        private const string TokenType = "Bearer";

        public string RefreshToken { get; private set; }

        public OAuthenticationToken(string baseUrl, string consumerKey, string consumerSecret)
            : base(consumerKey, consumerSecret, baseUrl)
        {
        }

        /// <summary>
        /// Initialise the Authenticator with an existing token.
        /// </summary>
        /// <param name="token"></param>
        public void SetToken(string token)
        {
            CreateClientWithToken(token);
        }

        private void CreateClientWithToken(string token)
        {
            client = new RestClient(_baseUrl)
            {
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(token, TokenType)
            };
        }

        public void GetTokenFromCode(string code)
        {
            var response = ExecuteTokenRequest(GetTokenRequestHeaders(), new Dictionary<string, string>
            {
                { "grant_type", "authorization_code"},
                { "code", code}
            });

            var token = response.AccessToken;
            RefreshToken = response.RefreshToken;

            CreateClientWithToken(token);
        }

        public void GetTokenFromRefreshToken(string refreshToken)
        {
            var response = ExecuteTokenRequest(GetTokenRequestHeaders(), new Dictionary<string, string>
            {
                { "grant_type", "refresh_token"},
                { "refresh_token", refreshToken}
            });

            var token = response.AccessToken;
            RefreshToken = response.RefreshToken;

            CreateClientWithToken(token);
        }
    }
}
