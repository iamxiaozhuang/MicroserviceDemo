using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<UserLoginResponse>>  UserLogin([FromBody] UserLoginRequest request)
        {
            List<UserModel> testUsers = GetUsers();
            var user = testUsers.FirstOrDefault(p => p.UserCode == request.UserCode && p.UserPassword == request.UserPassword);
            if (user != null)
            {
                return new UserLoginResponse() { IsSuccess = true,UserCode = user.UserCode,UserName = user.UserName };
            }
            return new UserLoginResponse() { IsSuccess = false, UserCode = request.UserCode, Message = "用户认证失败" };
        }

        [NonAction]
        private List<UserModel> GetUsers()
        {
            List<UserModel> testUsers = new List<UserModel>();
            testUsers.Add(new UserModel() { UserCode = "xiaozhuang", UserPassword = "123456", UserName = "小庄" });
            testUsers.Add(new UserModel() { UserCode = "xiaoming", UserPassword = "123456", UserName = "小明" });
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
        public bool IsSuccess { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
    }

    public class UserModel
    {
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}