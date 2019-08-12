
using CommonService.Enities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CommonService.Utilities
{
   

    public interface ICurrentTenantInfoProvider
    {
        CurrentTenantInfo ReadCurrentTenantInfo();
        CurrentTenantInfo GetCurrentTenantInfo();
    }

    public class CurrentTenantInfoProvider : ICurrentTenantInfoProvider
    {
        public CurrentTenantInfo TenantInfo { get; set; }

        IHttpContextAccessor httpContextAccessor;
        public CurrentTenantInfoProvider(IHttpContextAccessor _httpContextAccessor)
        {
            httpContextAccessor = _httpContextAccessor;
        }
       
        public CurrentTenantInfo ReadCurrentTenantInfo()
        {

            CurrentTenantInfo currentTenantInfo = new CurrentTenantInfo();
           if (httpContextAccessor.HttpContext.User != null &&
                httpContextAccessor.HttpContext.User.Identity.IsAuthenticated) //external
            {
                ClaimsPrincipal claimsPrincipal = httpContextAccessor.HttpContext.User;
                var subject = claimsPrincipal.Claims.FirstOrDefault(w => w.Type == "role");
                currentTenantInfo.TenantCode = subject.Value;
            }
            else  //internal
            {
                //currentTenantInfo.CurrentTenantCode = httpContextAccessor.HttpContext.Request.Headers["CurrentTenantCode"].FirstOrDefault();
                currentTenantInfo.TenantCode = "CMB";
            }
            return currentTenantInfo;
        }

        public CurrentTenantInfo GetCurrentTenantInfo()
        {

            CurrentTenantInfo currentTenantInfo = httpContextAccessor.HttpContext.Items["CurrentTenantInfo"] as CurrentTenantInfo;
            if (currentTenantInfo == null)
            {
                throw new FriendlyException()
                {
                    ExceptionCode = 400,
                    ExceptionMessage = $"CurrentTenantInfo is null."
                };
            }
            return currentTenantInfo;
        }


    }


}
