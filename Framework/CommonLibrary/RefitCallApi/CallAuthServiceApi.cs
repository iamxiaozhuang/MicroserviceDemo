using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{

    public interface ICallAuthServiceApi
    {
        [Post("/AuthService/account/userlogin")]
        [Headers("Authorization: Bearer")]
        Task<UserLoginResponse> UserLogin([Body] UserLoginRequest request);

        //[Get("/AuthService/account/getuserinfo/{subject}")]
        //[Headers("Authorization: Bearer")]
        //Task<CurrentUserInfo> GetUserInfo(string subject);

    }



    public class CallAuthServiceApi : ICallAuthServiceApi
    {
        public IConfiguration Configuration { get; }
        private readonly IHttpClientFactory _httpClientFactory;
        public CallAuthServiceApi(IConfiguration configuration, IHttpClientFactory httpClientFactory)
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
                throw new Exception(tokenResponse.Error + " " + tokenResponse.ErrorDescription);
            }

            return tokenResponse.AccessToken;
        }

        private ICallAuthServiceApi callAuthServiceApi {
            get {
                return RestService.For<ICallAuthServiceApi>(Configuration["ApiGatewayService:Url"],
                    new RefitSettings() { AuthorizationHeaderValueGetter = GetAuthServiceApiToken });
            }
        }

        public async Task<UserLoginResponse> UserLogin(UserLoginRequest userLoginRequest)
        { 
            return await callAuthServiceApi.UserLogin(userLoginRequest);
        }

        //public async Task<CurrentUserInfo> GetUserInfo(string subject)
        //{
        //    return await callAuthServiceApi.GetUserInfo(subject);
        //}
    }

    public class UserLoginRequest
    {
        public string UserCode { get; set; }
        public string UserPassword { get; set; }
    }

    public class UserLoginResponse
    {
        public string UserCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
