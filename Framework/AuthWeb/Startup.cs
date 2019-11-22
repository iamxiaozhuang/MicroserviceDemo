using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthWeb.Config;
using ServiceCommon;
using IdentityServer;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthWeb
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            ICollection<string> redirectUris = Configuration.GetValue<string>("HostWebHybrid:RedirectUris").Split(';');
            ICollection<string> postLogoutRedirectUris = Configuration.GetValue<string>("HostWebHybrid:PostLogoutRedirectUris").Split(';');
            string identityServerUri = Configuration.GetValue<string>("IdentityService:IssuerUri");

            var builder = services.AddIdentityServer(opt => { opt.IssuerUri = identityServerUri; opt.PublicOrigin = identityServerUri; })
               .AddInMemoryIdentityResources(IdentityServer.Config.GetIdentityResources())
               .AddInMemoryApiResources(IdentityServer.Config.GetApis())
               .AddInMemoryClients(IdentityServer.Config.GetClients(redirectUris,postLogoutRedirectUris))
               .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
               .AddProfileService<ProfileService>();
            //services.Configure<IISOptions>(iis =>
            //{
            //    iis.AuthenticationDisplayName = "Windows";
            //    iis.AutomaticAuthentication = false;
            //});

            services.AddHttpClient<CallSystemServiceApi>();
            services.AddSingleton<ICallSystemServiceApi, CallSystemServiceApi>();

            if (Environment.IsDevelopment() || Environment.IsEnvironment("Development.Kube"))
            {
               
                builder.AddDeveloperSigningCredential();
            }
            else
            {
                throw new Exception("Need to configure credential for environment " + Environment.EnvironmentName);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseIdentityServer();

            app.UseMvcWithDefaultRoute();


        }
    }
}
