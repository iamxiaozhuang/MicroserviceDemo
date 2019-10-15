using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{

    public interface ICallGeneralServiceApi
    {
        [Get("/PermissionService/userpermission/get/{subject}")]
        [Headers("Authorization: Bearer")]
        Task<CurrentUserPermission> GetUserPermission(string subject);
    }



    public class CallGeneralServiceApi : ICallGeneralServiceApi
    {
        public IConfiguration Configuration { get; }
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CallGeneralServiceApi(IConfiguration configuration,IHttpContextAccessor httpContextAccessor)
        {
            Configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
    }
        private async Task<string> GetGeneralServiceApiToken()
        {
            return await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
        } 

        private ICallGeneralServiceApi callGenaralServiceApi {
            get {
                return RestService.For<ICallGeneralServiceApi>(Configuration["ApiGatewayService:Url"],
                    new RefitSettings() { AuthorizationHeaderValueGetter = GetGeneralServiceApiToken });
            }
        }

        public async Task<CurrentUserPermission> GetUserPermission(string subject)
        {
            return await callGenaralServiceApi.GetUserPermission(subject);
        }
    }

}
