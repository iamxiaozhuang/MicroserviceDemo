using IdentityModel.Client;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace AuthWeb.Config
{
    public interface ICallApiUtil
    {
        Task<string> GetAuthServiceApiToken();
        Task<TokenResponse> GetCommonServiceApiToken(string userName, string userPassword);
    }
    public class CallApiUtil : ICallApiUtil
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CallApiUtil(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        private async Task<string> GetTokenEndpoint()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            var disco = await client.GetDiscoveryDocumentAsync("http://localhost:8700");
            if (disco.IsError)
            {
                throw new Exception(disco.Error);
            }
            return disco.TokenEndpoint;
        }
        public async Task<string> GetAuthServiceApiToken()
        {
            // request token
            HttpClient client = _httpClientFactory.CreateClient();
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = await GetTokenEndpoint(),
                ClientId = "AuthWeb",
                ClientSecret = "P@ssw0rd",
                Scope = "AuthServiceApi"
            }); 

            if (tokenResponse.IsError)
            {
                throw new Exception(tokenResponse.Error+" " + tokenResponse.ErrorDescription);
            }

            return tokenResponse.AccessToken;
        }

        public async Task<TokenResponse> GetCommonServiceApiToken(string userName,string userPassword)
        {
            // request token
            HttpClient client = _httpClientFactory.CreateClient();
            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = await GetTokenEndpoint(),
                ClientId = "ApiGateway",
                ClientSecret = "P@ssw0rd",
                UserName = userName,
                Password = userPassword,
                Scope = "CommonServiceApi"
            }); 
            return tokenResponse;
        }
    }

    public interface ICallUserLogin
    {
        [Post("/api/account/userlogin")]
        [Headers("Authorization: Bearer")]
        Task<UserLoginResponse> UserLogin([Body] UserLoginRequest request);

    }

    public class UserLoginRequest
    {
        public string UserCode { get; set; }
        public string UserPassword { get; set; }
    }

    public class UserLoginResponse
    {
        public bool IsSuccess { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
    }

    public class AuthenticatedHttpClientHandler : HttpClientHandler
    {
        private readonly Func<Task<string>> getToken;

        public AuthenticatedHttpClientHandler(Func<Task<string>> getToken)
        {
            if (getToken == null) throw new ArgumentNullException(nameof(getToken));
            this.getToken = getToken;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // See if the request has an authorize header
            var auth = request.Headers.Authorization;
            if (auth != null)
            {
                var token = await getToken().ConfigureAwait(false);
                request.Headers.Authorization = new AuthenticationHeaderValue(auth.Scheme, token);
            }

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }

    
}
