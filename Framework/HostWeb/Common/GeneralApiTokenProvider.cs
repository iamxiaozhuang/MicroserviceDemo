using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using IdentityModel.Client;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using ServiceCommon;
using Newtonsoft.Json;
using ServiceCommon.Models;

namespace HostWeb.Common
{
    public interface IGeneralApiTokenProvider
    {
        Task<string> GetGeneralApiToken(HttpContext httpContext);
    }

    public class GeneralApiTokenProvider : IGeneralApiTokenProvider
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration Configuration;
        public GeneralApiTokenProvider(IHttpClientFactory _httpClientFactory, IConfiguration configuration)
        {
            httpClientFactory = _httpClientFactory;
            Configuration = configuration;
        }
        public async Task<string> GetGeneralApiToken(HttpContext httpContext)
        {
            var web_access_token = await httpContext.GetTokenAsync("access_token");
            JwtSecurityToken jwtSecurityToken = (new JwtSecurityTokenHandler()).ReadToken(web_access_token) as JwtSecurityToken;
            string cacheKey = $"CurrentUserToken_{jwtSecurityToken.Claims.First(claim => claim.Type == "sub").Value}_{jwtSecurityToken.Claims.First(claim => claim.Type == "auth_time").Value}";
            
            string general_api_token = await RedisHelper.GetAsync<string>(cacheKey);
            if (string.IsNullOrEmpty(general_api_token))
            {
                general_api_token = jwtSecurityToken.Claims.First(claim => claim.Type == "general_api_token").Value;
            }
            GeneralApiToken generalApiToken = JsonConvert.DeserializeObject<GeneralApiToken>(general_api_token);
            if (generalApiToken.ExpiresAt > DateTime.UtcNow)
            {
                return generalApiToken.AccessToken;
            }
            else
            {
                HttpClient client = httpClientFactory.CreateClient("GetGeneralApiToken");
                var disco = await client.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
                {
                    Address = Configuration["IdentityService:Authority"],
                    Policy =
                    {
                       RequireHttps = false
                    }
                });
                if (disco.IsError)
                {
                    return null;
                }
                var tokenResponse = await client.RequestRefreshTokenAsync(new RefreshTokenRequest
                {
                    Address = disco.TokenEndpoint,
                    ClientId = "GeneralApiClient",
                    ClientSecret = "P@ssw0rd",
                    RefreshToken = generalApiToken.RefreshToken,
                    Scope = "GeneralServiceApi offline_access"
                });
                if (tokenResponse.IsError)
                {
                    return null;
                }
                generalApiToken = new GeneralApiToken()
                {
                    ExpiresAt = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn),
                    AccessToken = tokenResponse.AccessToken,
                    RefreshToken = tokenResponse.RefreshToken
                };
                await RedisHelper.SetAsync(cacheKey, JsonConvert.SerializeObject(generalApiToken));
                return generalApiToken.AccessToken;
            }

        }
    }
}
