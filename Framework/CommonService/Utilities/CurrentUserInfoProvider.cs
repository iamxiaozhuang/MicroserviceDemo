
using CommonService.Enities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
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
                var currentUserInfoClaim = claimsPrincipal.Claims.FirstOrDefault(w => w.Type == "CurrentUserInfo");
                currentUserInfo = JsonConvert.DeserializeObject(currentUserInfoClaim.Value) as CurrentUserInfo;
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
