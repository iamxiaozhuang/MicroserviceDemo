using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonService.Enities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PermissionService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        [Route("/api/getuserInfo")]
        [HttpGet]
        public async Task<ActionResult<CurrentUserInfo>> GetCurrentUserInfo()
        {
            CurrentUserInfo currentUserInfo = new CurrentUserInfo()
            {
                UserCode = HttpContext.User.FindFirst("sub").Value,
                UserName = "小庄 0202",
                OrgCode = "",
                OrgPermission = new List<FunctionPermission>(),
                RoleCode = "",
                RolePermission = new List<FunctionPermission>() { new FunctionPermission() { FunctionCode = "sysuer", PermissionCode = "update" } }
            };
            return currentUserInfo;
        }
    }
}