using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthService.Application;
using AuthService.Domain;
using CommonLibrary;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        protected readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// user auth
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("/api/account/userlogin")]
        [HttpPost]
        public async Task<ActionResult<CurrentUserInfo>>  UserLogin([FromBody] UserLoginRequest request)
        {
            List<UserModel> testUsers = GetUsers();
            string tenantCode = request.userSubject.Split('-')[0];
            string userCode = request.userSubject.Split('-')[1];
            var user = testUsers.FirstOrDefault(p => p.TenantCode == tenantCode && p.UserCode == userCode && p.UserPassword == request.UserPassword);
            if (user == null)
            {
                return new UnauthorizedResult();
            }
            return new CurrentUserInfo()
            {
                TenantCode = tenantCode,
                UserCode = userCode,
                UserName = "小庄 0202",
                UserEmail = "",
                UserPhone = "" 
            };
        }



        [Route("/api/account/getroles/{userSubject}")]
        [HttpGet]
        public async Task<ActionResult<List<RoleAssignmentModel>>> GetRoleAssignments(string userSubject)
        {
            string tenantCode = userSubject.Split('-')[0];
            string userCode = userSubject.Split('-')[1];
            return Ok(await _mediator.Send(new GetRoleAssignmentsRequest() { TenantCode = tenantCode, PrincipalCode = userCode }));
        }

        [Route("/api/account/getpermission/{principalID}/{userSubject}")]
        [HttpGet]
        public async Task<ActionResult<CurrentUserPermission>> GetPermission(Guid RoleAssignmentID,string userSubject)
        {
            string tenantCode = userSubject.Split('-')[0];
            return Ok(await _mediator.Send(new GetUserPermissionRequest() { RoleAssignmentID = RoleAssignmentID, TenantCode = tenantCode }));
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