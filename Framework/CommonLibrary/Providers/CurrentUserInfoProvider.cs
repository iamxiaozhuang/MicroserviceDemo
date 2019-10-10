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
    public interface ICurrentUserInfoProvider
    {
        Task<CurrentUserInfo> ReadCurrentUserInfo();
        CurrentUserInfo GetCurrentUserInfo();
    }

    public class CurrentUserInfoProvider : ICurrentUserInfoProvider
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ICallGeneralServiceApi callGeneralServiceApi;
        public CurrentUserInfoProvider(IHttpContextAccessor _httpContextAccessor, ICallGeneralServiceApi _callGeneralServiceApi)
        {
            httpContextAccessor = _httpContextAccessor;
            callGeneralServiceApi = _callGeneralServiceApi;
        }

        public async Task<CurrentUserInfo> ReadCurrentUserInfo()
        {
            CurrentUserInfo currentUserInfo = new CurrentUserInfo();
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
                if (httpContextAccessor.HttpContext.Request.Path.HasValue && httpContextAccessor.HttpContext.Request.Path.Value.StartsWith("/api/permission/getuserinfo/"))
                {
                    return new CurrentUserInfo()
                    {
                        TenantCode = subClaim.Value.Split('-')[0],
                        UserCode = subClaim.Value.Split('-')[1],
                        UserName = "",
                        RoleCode = "",
                        RoleName = "",
                        RolePermission = new List<FunctionPermission>() { new FunctionPermission() { FunctionCode = "permission", PermissionCode = "getuserinfo" } },
                    };
                }
                else
                {
                    currentUserInfo = await GetCurrentUserInfoFromRedis(subClaim.Value, auth_timeClaim.Value);
                }
            }
            return currentUserInfo;
        }

        private async Task<CurrentUserInfo> GetCurrentUserInfoFromRedis(string subject, string auth_time)
        {
            //string redisKey = $"CurrentUserInfo_{subject}";
            string redisKey = $"CurrentUserInfo_{subject}_{auth_time}";
            var currentUserInfo = await RedisHelper.GetAsync<CurrentUserInfo>(redisKey);
            if (currentUserInfo == null)
            {
                //读取用户信息
                var userInfo = await callGeneralServiceApi.GetUserInfo(subject);

                await RedisHelper.SetAsync(redisKey, userInfo, 36000);
            }
            return currentUserInfo;
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
