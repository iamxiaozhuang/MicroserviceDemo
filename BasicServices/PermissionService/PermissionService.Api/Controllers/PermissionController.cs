using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CommonLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PermissionService.Api.Controllers
{
    [ApiController]
    public class PermissionController : ControllerBase
    {
        [Route("/api/permission/getuserinfo/{subject}")]
        [HttpGet]
        [ApiAuthorization("permission", "getuserinfo")]
        public async Task<ActionResult<CurrentUserInfo>> GetCurrentUserInfo(string subject)
        {
            var tenantCode = subject.Split('-')[0];
            var userCode = subject.Split('-')[1];
            CurrentUserInfo currentUserInfo = new CurrentUserInfo()
            {
                TenantCode = tenantCode,
                UserCode = userCode,
                UserName = "小庄 0202",
                RoleCode = "",
                RoleName = "",
                RolePermission = new List<FunctionPermission>() { new FunctionPermission() { FunctionCode = "sysuer", PermissionCode = "update" } },
            };
            return currentUserInfo;
        }
    }
}