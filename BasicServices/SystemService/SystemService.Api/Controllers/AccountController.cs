using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceCommon;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SystemService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        [Route("/api/account/userlogin")]
        [HttpPost]
        public async Task<ActionResult<UserInfo>> UserLogin([FromBody] UserLoginRequest request)
        {
            List<UserModel> testUsers = GetUsers();
            string tenantCode = request.userSubject.Split('-')[0];
            string userCode = request.userSubject.Split('-')[1];
            var user = testUsers.FirstOrDefault(p => p.TenantCode == tenantCode && p.UserCode == userCode && p.UserPassword == request.UserPassword);
            if (user == null)
            {
                return new UnauthorizedResult();
            }
            return new UserInfo()
            {
                TenantCode = tenantCode,
                UserCode = userCode,
                UserName = user.UserName,
                UserEmail = "",
                UserPhone = ""
            };
        }





        [NonAction]
        private List<UserModel> GetUsers()
        {
            List<UserModel> testUsers = new List<UserModel>();
            testUsers.Add(new UserModel() { TenantCode = "SYSTEM", UserCode = "admin", UserPassword = "123456", UserName = "Admin" });
            testUsers.Add(new UserModel() { TenantCode = "SYSTEM", UserCode = "xiaozhuang", UserPassword = "123456", UserName = "xiaozhuang" });
            return testUsers;
        }
    }


    public class UserLoginRequest
    {
        public string userSubject { get; set; }
        public string UserPassword { get; set; }
    }

    public class UserModel
    {
        public string TenantCode { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}