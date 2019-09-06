using AuthWeb.Config;
using IdentityModel.Client;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly ICallApiUtil _callApiUtil;
        public ResourceOwnerPasswordValidator(ICallApiUtil callApiUtil)
        {
            _callApiUtil = callApiUtil;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            // call api
            UserLoginRequest userLoginRequest = new UserLoginRequest() { UserCode = context.UserName, UserPassword = context.Password };
            UserLoginResponse userLoginResponse = await _callApiUtil.CallUserLogin(userLoginRequest);
            if (!userLoginResponse.IsSuccess)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, userLoginResponse.Message);
            }
            else
            {
                string userInfoStr = JsonConvert.SerializeObject(userLoginResponse.UserInfo);
                context.Result = new GrantValidationResult(
                    subject: userLoginResponse.UserInfo.UserCode,
                    authenticationMethod: "custom",
                    claims: new Claim[] {
                        new Claim("TenantCode", userLoginResponse.UserInfo.TenantCode),
                        new Claim("UserName", userLoginResponse.UserInfo.UserName),
                        new Claim("RoleCode", userLoginResponse.UserInfo.RoleCode),
                        new Claim("CurrentUserInfo", userInfoStr)
                    }
                );
            }
        }


    }
}
