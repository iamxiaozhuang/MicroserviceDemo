using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
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
    public interface IRequestPasswordToken
    {
        Task<TokenResponse> RequestToken(string userName, string userPassword);
    }
    public class RequestPasswordToken : IRequestPasswordToken
    {
        public IConfiguration Configuration { get; }
        private readonly IHttpClientFactory _httpClientFactory;
        public RequestPasswordToken(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            Configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        private async Task<string> GetTokenEndpoint()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            var disco = await client.GetDiscoveryDocumentAsync(Configuration["IdentityService:Authority"]);
            if (disco.IsError)
            {
                throw new Exception(disco.Error);
            }
            return disco.TokenEndpoint;
        }

        public async Task<TokenResponse> RequestToken(string userName,string userPassword)
        {
            // request token
            HttpClient client = _httpClientFactory.CreateClient();
            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = await GetTokenEndpoint(),
                ClientId = "CommonApiClient",
                ClientSecret = "P@ssw0rd",
                UserName = userName,
                Password = userPassword,
                Scope = "CommonServiceApi"
            }); 
            return tokenResponse;
        }

    }

    
    //public class AuthenticatedHttpClientHandler : HttpClientHandler
    //{
    //    private readonly Func<Task<string>> getToken;

    //    public AuthenticatedHttpClientHandler(Func<Task<string>> getToken)
    //    {
    //        if (getToken == null) throw new ArgumentNullException(nameof(getToken));
    //        this.getToken = getToken;
    //    }

    //    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    //    {
    //        // See if the request has an authorize header
    //        var auth = request.Headers.Authorization;
    //        if (auth != null)
    //        {
    //            var token = await getToken().ConfigureAwait(false);
    //            request.Headers.Authorization = new AuthenticationHeaderValue(auth.Scheme, token);
    //        }

    //        return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
    //    }
    //}

    
}
