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

    public interface ICallPermissionServiceApi
    {
        [Get("/PermissionService/getpermission/{roleAssignmentID}")]
        [Headers("Authorization: Bearer")]
        Task<CurrentUserPermission> GetPermission(Guid roleAssignmentID);
    }



    public class CallPermissionServiceApi : ICallPermissionServiceApi
    {
        public IConfiguration Configuration { get; }
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CallPermissionServiceApi(IConfiguration configuration,IHttpContextAccessor httpContextAccessor)
        {
            Configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
    }
        private async Task<string> GetGeneralServiceApiToken()
        {
            return await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
        } 

        private ICallPermissionServiceApi callPermissionServiceApi
        {
            get {
                return RestService.For<ICallPermissionServiceApi>(Configuration["ApiGatewayService:Url"],
                    new RefitSettings() { AuthorizationHeaderValueGetter = GetGeneralServiceApiToken });
            }
        }

        public async Task<CurrentUserPermission> GetPermission(Guid roleAssignmentID)
        {
            return await callPermissionServiceApi.GetPermission(roleAssignmentID);
        }
    }

}
