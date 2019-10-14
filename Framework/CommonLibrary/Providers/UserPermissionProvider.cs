using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public interface IUserPermissonProvider
    {
        Task<UserPermission> GetUserPermission();
    }

    public class UserPermissionProvider : IUserPermissonProvider
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ICallGeneralServiceApi callGeneralServiceApi;
        public UserPermissionProvider(IHttpContextAccessor _httpContextAccessor, ICallGeneralServiceApi _callGeneralServiceApi)
        {
            httpContextAccessor = _httpContextAccessor;
            callGeneralServiceApi = _callGeneralServiceApi;
        }

        public async Task<UserPermission> GetUserPermission()
        {
            UserPermission userPermission = new UserPermission();
            if (httpContextAccessor.HttpContext.User != null &&
                 httpContextAccessor.HttpContext.User.Identity.IsAuthenticated) 
            {
                Claim subClaim = httpContextAccessor.HttpContext.User.FindFirst("sub");
                Claim auth_timeClaim = httpContextAccessor.HttpContext.User.FindFirst("auth_time");
                if (subClaim == null || auth_timeClaim == null)
                {
                    throw new FriendlyException()
                    {
                        ExceptionCode = 401,
                        ExceptionMessage = "Unauthorized Request."
                    };
                }
                if (httpContextAccessor.HttpContext.Request.Path.HasValue && httpContextAccessor.HttpContext.Request.Path.Value.StartsWith("/api/userpermission/get/"))
                {
                    return new UserPermission()
                    {
                        RoleCode = "",
                        RoleName = "",
                        Permissions = new List<FunctionPermission>() { new FunctionPermission() { FunctionCode = "userpermission", PermissionCode = "get" } },
                    };
                }
                else
                {
                    userPermission = await GetUserPermissonFromRedis(subClaim.Value, auth_timeClaim.Value);
                }
            }
            return userPermission;
        }

        private async Task<UserPermission> GetUserPermissonFromRedis(string subject, string auth_time)
        {
            //string redisKey = $"CurrentUserInfo_{subject}";
            string redisKey = $"CurrentUserInfo_{subject}_{auth_time}";
            var userPermission = await RedisHelper.GetAsync<UserPermission>(redisKey);
            if (userPermission == null)
            {
                //读取用户信息
                userPermission = await callGeneralServiceApi.GetUserPermission(subject);

                await RedisHelper.SetAsync(redisKey, userPermission, 36000);
            }
            return userPermission;
        }

        public CurrentUserInfo GetCurrentUserInfo()
        {

            CurrentUserInfo currentUserInfo = httpContextAccessor.HttpContext.Items["CurrentUserInfo"] as CurrentUserInfo;
            if (currentUserInfo == null)
            {
                throw new FriendlyException()
                {
                    ExceptionCode = 400,
                    ExceptionMessage = $"CurrentUserInfo is null."
                };
            }
            return currentUserInfo;
        }
    }



}
