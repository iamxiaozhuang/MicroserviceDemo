using IdentityModel.Client;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace AuthWeb.Config
{
    public class CallApiUtil
    {
        public async Task<string> GetAuthServiceApiToken()
        {
            HttpClient client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("http://localhost:8700");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return "";
            }
            // request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "AuthWeb",
                ClientSecret = "P@ssw0rd",
                Scope = "AuthServiceApi"
            });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return "";
            }

            return tokenResponse.AccessToken;
        }
    }

    public interface ICallUserLogin
    {
        [Post("/api/account/userlogin")]
        [Headers("Authorization: Bearer")]
        Task<UserLoginResponse> UserLogin([Body] UserLoginRequest request);

        [Post("api/values")]
        [Headers("Authorization: Bearer")]
        Task<string> GetValues();
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

    public class AuthenticatedHttpClientHandler : HttpClientHandler
    {
        private readonly Func<Task<string>> getToken;

        public AuthenticatedHttpClientHandler(Func<Task<string>> getToken)
        {
            if (getToken == null) throw new ArgumentNullException(nameof(getToken));
            this.getToken = getToken;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // See if the request has an authorize header
            var auth = request.Headers.Authorization;
            if (auth != null)
            {
                var token = await getToken().ConfigureAwait(false);
                request.Headers.Authorization = new AuthenticationHeaderValue(auth.Scheme, token);
            }

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }

    
}
