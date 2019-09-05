using AuthWeb.Config;
using IdentityModel.Client;
using IdentityServer4.Models;
using IdentityServer4.Validation;
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
        private readonly IHttpClientFactory _httpClientFactory;
        public ResourceOwnerPasswordValidator(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            // call api
            CallApiUtil util = new CallApiUtil();
            UserLoginRequest userLoginRequest = new UserLoginRequest() { UserCode = context.UserName, UserPassword = context.Password };
            var callUserLogin = RestService.For<ICallUserLogin>("http://localhost:8810", new RefitSettings() { AuthorizationHeaderValueGetter = util.GetAuthServiceApiToken });
            //var callUserLogin = RestService.For<ICallUserLogin>((new HttpClient(new AuthenticatedHttpClientHandler(util.GetAuthServiceApiToken)) { BaseAddress = new Uri("http://localhost:8810") }));
            UserLoginResponse userLoginResponse = await callUserLogin.UserLogin(userLoginRequest);

            if (!userLoginResponse.IsSuccess)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, userLoginResponse.Message);
            }
            else
            {
                context.Result = new GrantValidationResult(
                    subject: userLoginResponse.UserCode,
                    authenticationMethod: "custom",
                    claims: new Claim[] {
                        new Claim("Name", userLoginResponse.UserName),
                        new Claim("CurrentUserInfo", "CurrentUserInfo2222888")
                    }
                );
            }
        }


    }
}
