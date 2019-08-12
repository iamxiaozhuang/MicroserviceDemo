using CommonService.Enities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
namespace CommonService.Utilities
{
    public class ApiActionFilter : IActionFilter
    {
        IHttpContextAccessor httpContextAccessor;
        public ApiActionFilter(IHttpContextAccessor _httpContextAccessor)
        {
            httpContextAccessor = _httpContextAccessor;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //参数验证
            if (!context.ModelState.IsValid)
            {
                //context.Result = new BadRequestObjectResult(context.ModelState);
                string errorString = string.Empty;
                foreach (var key in context.ModelState.Keys)
                {
                    var state = context.ModelState[key];
                    if (state.Errors.Any())
                    {
                        errorString += $"{state.Errors.First().ErrorMessage} ";
                    }
                }
                throw new FriendlyException()
                {
                    ExceptionCode = 400,
                    ExceptionMessage = $"Model validation error: {errorString}."
                };
            }

            //当前人员权限验证
            if (!httpContextAccessor.HttpContext.User.Identity.IsAuthenticated) //external
            {
                throw new FriendlyException()
                {
                    ExceptionCode = 401,
                    ExceptionMessage = $"The current user is not logged on."
                };
            }
            CurrentUserInfo currentUserInfo = context.HttpContext.Items["CurrentUserInfo"] as CurrentUserInfo;
            if (currentUserInfo == null )
            {
                throw new FriendlyException()
                {
                    ExceptionCode = 401,
                    ExceptionMessage = $"this user {httpContextAccessor.HttpContext.User.Identity.Name} information was not found."
                };
            }
            if (currentUserInfo.RolePermission == null)
            {
                throw new FriendlyException()
                {
                    ExceptionCode = 401,
                    ExceptionMessage = $"this user {httpContextAccessor.HttpContext.User.Identity.Name} have no permission configration."
                };
            }
            ApiAuthorizationAttribute authorizationAttribute = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor)
                .MethodInfo.GetCustomAttribute(typeof(ApiAuthorizationAttribute), false) as ApiAuthorizationAttribute;
            if (authorizationAttribute == null)
            {
                throw new FriendlyException()
                {
                    ExceptionCode = 401,
                    ExceptionMessage = $"This action {context.ActionDescriptor.DisplayName} have no permission configration."
                };
            }
            var query = currentUserInfo.RolePermission.FirstOrDefault(p => p.FunctionCode == authorizationAttribute.FunctionCode && p.PermissionCode == authorizationAttribute.PermissionCode);
            if (query == null)
            {
                throw new FriendlyException()
                {
                    ExceptionCode = 401,
                    ExceptionMessage = $"This user  {httpContextAccessor.HttpContext.User.Identity.Name} have no permission for this function/permission:{authorizationAttribute.FunctionCode}/{authorizationAttribute.PermissionCode}."
                };
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
