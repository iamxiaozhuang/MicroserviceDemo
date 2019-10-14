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
    public class UserPermissionController : ControllerBase
    {
        [Route("/api/userpermission/get/{subject}")]
        [HttpGet]
        [ApiAuthorization("userpermission", "get")]
        public async Task<ActionResult<UserPermission>> Get(string subject)
        {
            var tenantCode = subject.Split('-')[0];
            var userCode = subject.Split('-')[1];
            UserPermission userPermission = new UserPermission()
            {
                RoleCode = "",
                RoleName = "",
                Permissions = new List<FunctionPermission>() { new FunctionPermission() { FunctionCode = "sysuer", PermissionCode = "update" } },
            };
            return userPermission;
        }
    }
}