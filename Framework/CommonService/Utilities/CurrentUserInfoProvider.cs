
using CommonService.Enities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CommonService.Utilities
{
    public interface ICurrentUserInfoProvider
    {
        CurrentUserInfo ReadCurrentUserInfo();
        CurrentUserInfo GetCurrentUserInfo();
    }

    public class CurrentUserInfoProvider : ICurrentUserInfoProvider
    {
        IHttpContextAccessor httpContextAccessor;
        public CurrentUserInfoProvider(IHttpContextAccessor _httpContextAccessor)
        {
            httpContextAccessor = _httpContextAccessor;
        }

        public CurrentUserInfo ReadCurrentUserInfo()
        {
            CurrentUserInfo currentUserInfo = new CurrentUserInfo();
           if (httpContextAccessor.HttpContext.User != null &&
                httpContextAccessor.HttpContext.User.Identity.IsAuthenticated) //external
            {
                ClaimsPrincipal claimsPrincipal = httpContextAccessor.HttpContext.User;
                var subject = claimsPrincipal.Claims.FirstOrDefault(w => w.Type == "sub");
                currentUserInfo = GetCurrentUserInfoFromRedis(subject.Value);
            }
            else  //internal
            {
                currentUserInfo.UserCode = "internal";
                currentUserInfo.UserName = "internal";
            }
            return currentUserInfo;
        }

        private CurrentUserInfo GetCurrentUserInfoFromRedis(string usercode)
        {
            CurrentUserInfo currentUserInfo = new CurrentUserInfo()
            {
                UserCode = "0202",//currentUserCode
                UserName = "小庄 0202",
                OrgCode = "",
                OrgPermission = new List<FunctionPermission>(),
                RoleCode = "",
                RolePermission = new List<FunctionPermission>() { new FunctionPermission() { FunctionCode = "sysuer", PermissionCode = "update" } }
            };
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
