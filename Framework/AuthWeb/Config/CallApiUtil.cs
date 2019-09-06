using CommonService.Enities;
using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
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
        Task<UserLoginResponse> CallUserLogin(UserLoginRequest userLoginRequest);
        Task<TokenResponse> GetCommonServiceApiToken(string userName, string userPassword);
    }
    public class CallApiUtil : ICallApiUtil
    {
        public IConfiguration Configuration { get; }
        private readonly IHttpClientFactory _httpClientFactory;
        public CallApiUtil(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            Configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        private async Task<string> GetTokenEndpoint()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            var disco = await client.GetDiscoveryDocumentAsync(Configuration["IdentityService:Authority"]);
            if (disco.IsError)
            {
                throw new Exception(disco.Error);
            }
            return disco.TokenEndpoint;
        }
        private async Task<string> GetAuthServiceApiToken()
        {
            // request token
            HttpClient client = _httpClientFactory.CreateClient();
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = await GetTokenEndpoint(),
                ClientId = "AuthApiClient",
                ClientSecret = "P@ssw0rd",
                Scope = "AuthServiceApi"
            }); 

            if (tokenResponse.IsError)
            {
                throw new Exception(tokenResponse.Error+" " + tokenResponse.ErrorDescription);
            }

            return tokenResponse.AccessToken;
        }
        public async Task<UserLoginResponse> CallUserLogin(UserLoginRequest userLoginRequest)
        {
             //var callUserLogin = RestService.For<ICallUserLogin>((new HttpClient(new AuthenticatedHttpClientHandler(util.GetAuthServiceApiToken)) { BaseAddress = new Uri("http://localhost:8810") }));
            var callUserLogin = RestService.For<ICallUserLogin>(Configuration["ApiGatewayService:Url"], 
                new RefitSettings() { AuthorizationHeaderValueGetter = GetAuthServiceApiToken });
            return await callUserLogin.UserLogin(userLoginRequest);
        }

        public async Task<TokenResponse> GetCommonServiceApiToken(string userName,string userPassword)
        {
            // request token
            HttpClient client = _httpClientFactory.CreateClient();
            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = await GetTokenEndpoint(),
                ClientId = "CommonApiClient",
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
        [Post("/AuthService/account/userlogin")]
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
        public CurrentUserInfo UserInfo { get; set; }
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
