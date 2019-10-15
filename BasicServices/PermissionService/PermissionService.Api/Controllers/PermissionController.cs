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
        [ApiAuthorization("userpermission.get")]
        public async Task<ActionResult<CurrentUserPermission>> Get(string subject)
        {
            var tenantCode = subject.Split('-')[0];
            var userCode = subject.Split('-')[1];
            CurrentUserPermission userPermission = new CurrentUserPermission()
            {
                RoleCode = "",
                RoleName = "",
                AllowResourceCodes = new List<string>() { "values.getuserclaims" } 
            };
            return userPermission;
        }

    }
}