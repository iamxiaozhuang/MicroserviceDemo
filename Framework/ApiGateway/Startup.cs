using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ApiGateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            #region IdentityServer
            Action<IdentityServerAuthenticationOptions> authApiClientOpt = option =>
            {
                option.Authority = Configuration["IdentityService:Authority"];
                option.ApiName = "AuthServiceApi";
                option.RequireHttpsMetadata = false;
                option.SupportedTokens = SupportedTokens.Both;
            };

            Action<IdentityServerAuthenticationOptions> commonApiClientOpt = option =>
            {
                option.Authority = Configuration["IdentityService:Authority"];
                option.ApiName = "CommonServiceApi";
                option.RequireHttpsMetadata = false;
                option.SupportedTokens = SupportedTokens.Both;
            };
            #endregion

            services.AddAuthentication()
               .AddIdentityServerAuthentication("AuthServiceApiKey", authApiClientOpt)
                .AddIdentityServerAuthentication("CommonServiceApiKey", commonApiClientOpt);

            // Ocelot
            services.AddOcelot(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseWebSockets();
            app.UseOcelot().Wait();
        }
    }
}
