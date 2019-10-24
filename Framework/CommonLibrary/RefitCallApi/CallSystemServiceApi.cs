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

    public interface ICallSystemServiceApi
    {
        [Post("/SystemService/account/userlogin")]
        [Headers("Authorization: Bearer")]
        Task<UserInfo> UserLogin([Body] UserLoginRequest request);

        [Post("/SystemService/resource/menus")]
        [Headers("Authorization: Bearer")]
        Task<List<UserMenu>> GetUserMenus([Body] List<string> allowResourceCodes);

    }



    public class CallSystemServiceApi : ICallSystemServiceApi
    {
        public IConfiguration Configuration { get; }
        private readonly IHttpClientFactory _httpClientFactory;
        public CallSystemServiceApi(IConfiguration configuration, IHttpClientFactory httpClientFactory)
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
                ClientId = "SystemApiClient",
                ClientSecret = "P@ssw0rd",
                Scope = "SystemServiceApi"
            });

            if (tokenResponse.IsError)
            {
                throw new Exception(tokenResponse.Error + " " + tokenResponse.ErrorDescription);
            }

            return tokenResponse.AccessToken;
        }

        private ICallSystemServiceApi callSystemServiceApi {
            get {
                return RestService.For<ICallSystemServiceApi>(Configuration["ApiGatewayService:Url"],
                    new RefitSettings() { AuthorizationHeaderValueGetter = GetAuthServiceApiToken });
            }
        }

        public async Task<UserInfo> UserLogin(UserLoginRequest userLoginRequest)
        { 
            return await callSystemServiceApi.UserLogin(userLoginRequest);
        }

        public async Task<List<UserMenu>> GetUserMenus(List<string> allowResourceCodes)
        {
            return await callSystemServiceApi.GetUserMenus(allowResourceCodes);
        }
    }

    public class UserLoginRequest
    {
        public string UserSubject { get; set; }
        public string UserPassword { get; set; }
    }

}
