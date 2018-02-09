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
    public class OAuthenticationToken : Authenticate
    {
        private const string TokenType = "Bearer";
        private string _token;
        private string _baseUrl;

        public OAuthenticationToken(string token, string baseUrl)
        {
            _token = token;
            _baseUrl = baseUrl;
        }

        public void GetToken()
        {
            client = new RestClient(_baseUrl)
            {
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(_token, TokenType)
            };
        }
    }
}
