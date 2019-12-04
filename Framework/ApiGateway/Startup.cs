using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiGateway.Extensions;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Ocelot.Administration;
using Ocelot.Cache;
using Ocelot.Configuration.File;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Kubernetes;

namespace ApiGateway
{
    public class Startup
    {
        public IHostingEnvironment Environment { get; }
        public IConfiguration Configuration { get; }
        public Startup(IHostingEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            #region IdentityServer
            Action<IdentityServerAuthenticationOptions> systemApiClientOpt = option =>
            {
                option.Authority = Configuration["IdentityService:Authority"];
                option.ApiName = "SystemServiceApi";
                option.RequireHttpsMetadata = false;
                option.SupportedTokens = SupportedTokens.Both;
            };

            Action<IdentityServerAuthenticationOptions> generalApiClientOpt = option =>
            {
                option.Authority = Configuration["IdentityService:Authority"];
                option.ApiName = "GeneralServiceApi";
                option.RequireHttpsMetadata = false;
                option.SupportedTokens = SupportedTokens.Both;
            };
            #endregion

            services.AddAuthentication()
               .AddIdentityServerAuthentication("SystemServiceApiKey", systemApiClientOpt)
                .AddIdentityServerAuthentication("GeneralServiceApiKey", generalApiClientOpt);

            // Ocelot
            if (Environment.IsDevelopment())
                services.AddOcelot(Configuration).AddAdministration("/console","02020511"); 
            else
                services.AddOcelot(Configuration).AddKubernetes().AddAdministration("/console", "02020511");



            //OcelotCaching
            services.AddSingleton<IOcelotCache<CachedResponse>, InRedisCache<CachedResponse>>();
            //services.AddSingleton<IOcelotCache<CachedResponse>, RedisOcelotCache>();
           
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
