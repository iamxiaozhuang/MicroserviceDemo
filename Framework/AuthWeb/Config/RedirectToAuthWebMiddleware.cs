using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class RedirectToAuthWebMiddleware
    {
        private readonly RequestDelegate _next;
        public IConfiguration Configuration { get; }
        public RedirectToAuthWebMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            Configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            if (context.Request.Path == "/connect/authorize" && context.Response.StatusCode == 302)
            {
                string location = context.Response.Headers["Location"];
                string identityServerInternalUri = Configuration.GetValue<string>("IdentityService:Authority");
                string identityServerExternalUri = Configuration.GetValue<string>("IdentityService:IssuerUri");
                location = location.Replace(identityServerInternalUri, identityServerExternalUri);
                context.Response.Headers["Location"] = location;
            }
        }
    }

    public static class RedirectToAuthWebExtensions
    {
        public static IApplicationBuilder UseRedirectToAuthWebMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RedirectToAuthWebMiddleware>();
        }
    }

}
