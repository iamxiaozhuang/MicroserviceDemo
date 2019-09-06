using IdentityModel.Client;
using Refit;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var callapi = RestService.For<ICallUserLogin>("http://localhost:8800", new RefitSettings() { AuthorizationHeaderValueGetter = GetAuthServiceApiToken });
            //var callapi = RestService.For<ICallApi>((new HttpClient(new AuthenticatedHttpClientHandler(GetApiToken)) { BaseAddress = new Uri("http://localhost:5001") }));
            UserLoginRequest userLoginRequest = new UserLoginRequest() { UserCode = "xiaozhuang", UserPassword = "7777" };
            UserLoginResponse p = await callapi.UserLogin(userLoginRequest);
            Console.WriteLine(p);
            Console.ReadKey();
        }

        static async Task<string> GetAuthServiceApiToken()
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
                ClientId = "AuthApiClient",
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
        [Post("/AuthService/account/userlogin")]
        [Headers("Authorization: Bearer")]
        Task<UserLoginResponse> UserLogin([Body] UserLoginRequest request);

        [Post("/AuthService/values")]
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
