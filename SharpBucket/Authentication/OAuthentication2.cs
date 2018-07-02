using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using System.Linq;

namespace SharpBucket.Authentication
{
    public class OAuthentication2 : OauthAuthentication
    {
        private const string TokenUrl = "https://bitbucket.org/site/oauth2/access_token";
        private const string TokenType = "Bearer";
        private string _token;

        public OAuthentication2(string consumerKey, string consumerSecret, string baseUrl)
            : base(consumerKey, consumerSecret, baseUrl)
        {
        }

        public void GetToken()
        {
            var tokenResponse = ExecuteTokenRequest();
            _token = tokenResponse.AccessToken;
            client = new RestClient(_baseUrl)
            {
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(_token, TokenType)
            };
        }

        private Token ExecuteTokenRequest()
        {
            return ExecuteTokenRequest(GetTokenRequestHeaders(), GetTokenRequestParamters());
        }

        internal virtual Token ExecuteTokenRequest(Dictionary<string,string> headers, Dictionary<string, string> parameters)
        {
            var tempClient = new RestClient(TokenUrl)
            {
                Authenticator = new HttpBasicAuthenticator(ConsumerKey, ConsumerSecret),
            };
            var request = new RestRequest
            {
                Method = Method.POST
            };
            headers.Select(i=> request.AddHeader(i.Key, i.Value)).ToArray();
            parameters.Select(i => request.AddParameter(i.Key, i.Value)).ToArray(); 
            var response = tempClient.Execute<Token>(request);
            return response.Data;
        }

        internal virtual Dictionary<string,string> GetTokenRequestHeaders()
        {
            var headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/x-www-form-urlencoded");
            headers.Add("Accept", "application/json");
            return headers;
        }

        internal virtual Dictionary<string, string> GetTokenRequestParamters()
        {
            var headers = new Dictionary<string, string>();
            headers.Add("grant_type", "client_credentials");
            return headers;
        }
    }
}