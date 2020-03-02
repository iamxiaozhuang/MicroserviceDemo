using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Refit;
using ServiceCommon.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCommon
{

    public interface ICallPermissionServiceApi
    {
        [Get("/PermissionService/permissionprovider/{roleAssignmentID}")]
        [Headers("Authorization: Bearer")]
        Task<UserPermission> GetUserPermission(Guid roleAssignmentID);
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

        public async Task<UserPermission> GetUserPermission(Guid roleAssignmentID)
        {
            return await callPermissionServiceApi.GetUserPermission(roleAssignmentID);
        }
    }

}
