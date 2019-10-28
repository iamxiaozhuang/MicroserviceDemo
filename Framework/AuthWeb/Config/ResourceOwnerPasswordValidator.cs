using AuthWeb.Config;
using ServiceCommon;
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
        private readonly ICallSystemServiceApi _callSystemServiceApi;
        public ResourceOwnerPasswordValidator(ICallSystemServiceApi callSystemServiceApi)
        {
            _callSystemServiceApi = callSystemServiceApi;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            // call api
            UserLoginRequest userLoginRequest = new UserLoginRequest() { UserSubject = context.UserName, UserPassword = context.Password };
            try
            {
                UserInfo currentUserInfo = await _callSystemServiceApi.UserLogin(userLoginRequest);
                context.Result = new GrantValidationResult(
                   subject: userLoginRequest.UserSubject,
                   authenticationMethod: "custom",
                   claims: new Claim[] { new Claim("current_user_info", JsonConvert.SerializeObject(currentUserInfo)) }
               );
            }
            catch(Exception ex)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, ex == null ? "InvalidGrant" : ex.Message);
            }
        }


    }
}
