using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public interface IUserPermissionCache
    {
        Task SetCurrentUserPermission(CurrentUserPermission currentUserPermission);
        Task<CurrentUserPermission> GetCurrentUserPermission();
    }

    public class UserPermissionCache : IUserPermissionCache
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ICallPermissionServiceApi callPermissionServiceApi;
        public UserPermissionCache(IHttpContextAccessor _httpContextAccessor, ICallPermissionServiceApi _callPermissionServiceApi)
        {
            httpContextAccessor = _httpContextAccessor;
            callPermissionServiceApi = _callPermissionServiceApi;
        }

        private string GetRedisKey()
        {
            if (!httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                throw new FriendlyException()
                {
                    ExceptionCode = 401,
                    ExceptionMessage = "Unauthorized Request."
                };
            }
            Claim subClaim = httpContextAccessor.HttpContext.User.FindFirst("sub");
            Claim auth_timeClaim = httpContextAccessor.HttpContext.User.FindFirst("auth_time");
            if (subClaim == null || auth_timeClaim == null)
            {
                throw new FriendlyException()
                {
                    ExceptionCode = 401,
                    ExceptionMessage = "The user claim: sub or auth_time is null."
                };
            }

            return $"CurrentUserPermission_{subClaim.Value}_{auth_timeClaim.Value}";
        }

        public async Task SetCurrentUserPermission(CurrentUserPermission currentUserPermission)
        {
            await RedisHelper.SetAsync(GetRedisKey(), currentUserPermission, 36000);
        }

        public async Task<CurrentUserPermission> GetCurrentUserPermission()
        {
            string redisKey = GetRedisKey();
            var currentUserPermission = await RedisHelper.GetAsync<CurrentUserPermission>(redisKey);
            if (currentUserPermission == null)
            {
                if (httpContextAccessor.HttpContext.Request.Path.Value.StartsWith("/api/permission/"))
                {

                    currentUserPermission = new CurrentUserPermission();
                    currentUserPermission.RoleCode = "";
                    currentUserPermission.ScopeCode = "";
                    currentUserPermission.AllowResourceCodes = new List<string>() { "permission.getroles", "permission.get" };
                    currentUserPermission.AllowScopeCodes = new List<string>();
                }
                else
                {
                    currentUserPermission = await callPermissionServiceApi.GetPermission(Guid.Empty);
                }
                await RedisHelper.SetAsync(redisKey, currentUserPermission);
            }
            return currentUserPermission;
        }

       
    }



}
