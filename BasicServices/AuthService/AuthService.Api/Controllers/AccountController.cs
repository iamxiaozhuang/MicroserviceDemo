using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [Route("/api/account/userlogin")]
        [HttpPost]
        public async Task<ActionResult<UserLoginResponse>>  UserLogin([FromBody] UserLoginRequest request)
        {
            List<UserModel> testUsers = GetUsers();
            string tenantCode = request.UserCode.Split('-')[0];
            string userCode = request.UserCode.Split('-')[1];
            var user = testUsers.FirstOrDefault(p => p.TenantCode == tenantCode && p.UserCode == userCode && p.UserPassword == request.UserPassword);
            if (user != null)
            {
                return new UserLoginResponse() { UserCode = request.UserCode, IsSuccess = true};
            }
            return new UserLoginResponse() { UserCode = request.UserCode, IsSuccess = false, Message = "invalid credentials" };
        }


        [Route("/api/account/getuserinfo/{subject}")]
        [HttpGet]
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

        [NonAction]
        private List<UserModel> GetUsers()
        {
            List<UserModel> testUsers = new List<UserModel>();
            testUsers.Add(new UserModel() { TenantCode = "MSFT", UserCode = "xiaozhuang", UserPassword = "123456", UserName = "小庄" });
            testUsers.Add(new UserModel() { TenantCode = "MSFT", UserCode = "xiaoming", UserPassword = "123456", UserName = "小明" });
            return testUsers;
        }
    }


    public class UserLoginRequest
    {
        public string UserCode { get; set; }
        public string UserPassword { get; set; }
    }

    public class UserLoginResponse
    {
        public string UserCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class UserModel
    {
        public string TenantCode { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}