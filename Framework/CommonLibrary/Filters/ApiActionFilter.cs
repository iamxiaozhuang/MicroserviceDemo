using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
namespace CommonLibrary
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
            if (!httpContextAccessor.HttpContext.User.Identity.IsAuthenticated) 
            {
                throw new FriendlyException()
                {
                    ExceptionCode = 401,
                    ExceptionMessage = $"The current user is not logged on."
                };
            }
            UserInfo currentUserInfo = context.HttpContext.Items["CurrentUserInfo"] as UserInfo;
            if (currentUserInfo == null )
            {
                throw new FriendlyException()
                {
                    ExceptionCode = 401,
                    ExceptionMessage = $"this user {httpContextAccessor.HttpContext.User.Identity.Name} information was not found."
                };
            }
            UserPermission currentUserPermission = httpContextAccessor.HttpContext.Items["CurrentUserPermission"] as UserPermission;
            if (currentUserPermission == null)
            {
                throw new FriendlyException()
                {
                    ExceptionCode = 401,
                    ExceptionMessage = $"this user {httpContextAccessor.HttpContext.User.Identity.Name} permission information was not found."
                };
            }
            ApiAuthorizationAttribute authorizationAttribute = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor)
                .MethodInfo.GetCustomAttribute(typeof(ApiAuthorizationAttribute), false) as ApiAuthorizationAttribute;
            if (authorizationAttribute == null)
            {
                throw new FriendlyException()
                {
                    ExceptionCode = 401,
                    ExceptionMessage = $"This action {context.ActionDescriptor.DisplayName} have no authorization attribute configration."
                };
            }
            var query = currentUserPermission.AllowActionCodes.FirstOrDefault(p => p == authorizationAttribute.ResourceCode);
            if (query == null)
            {
                throw new FriendlyException()
                {
                    ExceptionCode = 401,
                    ExceptionMessage = $"This user  {httpContextAccessor.HttpContext.User.Identity.Name} have no permission for this resource : {authorizationAttribute.ResourceCode}."
                };
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
