using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ServiceCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
namespace ServiceCommon.Filters
{
    public class ApiPermissionFilter : IActionFilter
    {
        IHttpContextAccessor httpContextAccessor;
        public ApiPermissionFilter(IHttpContextAccessor _httpContextAccessor)
        {
            httpContextAccessor = _httpContextAccessor;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (httpContextAccessor.HttpContext.Request.Path.HasValue 
                && (httpContextAccessor.HttpContext.Request.Path.Value.StartsWith("/swagger") || httpContextAccessor.HttpContext.Request.Path.Value.StartsWith("/api/heathcheck")))
            {
                return;
            }
            //当前人员权限验证
            if (!httpContextAccessor.HttpContext.User.Identity.IsAuthenticated) 
            {
                throw new FriendlyException(401);
            }
            UserInfo currentUserInfo = context.HttpContext.Items["CurrentUserInfo"] as UserInfo;
            if (currentUserInfo == null)
            {
                throw new FriendlyException(403, $"this user {httpContextAccessor.HttpContext.User.Identity.Name} information was not found.");
            }
            UserPermission currentUserPermission = httpContextAccessor.HttpContext.Items["CurrentUserPermission"] as UserPermission;
            if (currentUserPermission == null)
            {
                throw new FriendlyException(403, $"this user {httpContextAccessor.HttpContext.User.Identity.Name} permission information was not found.");
              
            }
            ApiAuthorizationAttribute authorizationAttribute = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor)
                .MethodInfo.GetCustomAttribute(typeof(ApiAuthorizationAttribute), false) as ApiAuthorizationAttribute;
            if (authorizationAttribute == null)
            {
                throw new FriendlyException(403, $"This action {context.ActionDescriptor.DisplayName} have no authorization attribute configration.");
            }
            var query = currentUserPermission.AllowActionCodes.FirstOrDefault(p => p == authorizationAttribute.ResourceCode);
            if (query == null)
            {
                throw new FriendlyException(403, $"This user  {httpContextAccessor.HttpContext.User.Identity.Name} have no permission for this resource : {authorizationAttribute.ResourceCode}.");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
