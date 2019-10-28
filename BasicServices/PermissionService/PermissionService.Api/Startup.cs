using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using ServiceCommon;
using ServiceCommon.Caches;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PermissionService.Domain;

namespace PermissionService.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore(options => options.Filters.Add(typeof(ApiActionFilter)))
                .AddAuthorization()
                .AddJsonFormatters()
                .AddApiExplorer();
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = Configuration["IdentityService:Authority"];
                    options.Audience = "GeneralServiceApi";
                    options.RequireHttpsMetadata = false;
                });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IUserPermissionCache, UserPermissionCache>();
            services.AddHttpClient<CallPermissionServiceApi>();
            services.AddSingleton<ICallPermissionServiceApi, CallPermissionServiceApi>();

            services.AddSingleton<ISystemDataCache, SystemDataCache>();
            services.AddHttpClient<ICallSystemServiceApi>();
            services.AddSingleton<ICallSystemServiceApi, CallSystemServiceApi>();

            services.AddDbContext<PermissionDBContext>(option =>
            option.UseNpgsql(Configuration.GetConnectionString("PermissionDBConnStr"), npgsqlOptions =>
                    {
                        npgsqlOptions.EnableRetryOnFailure();
                        npgsqlOptions.CommandTimeout(60);
                    })
                 .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            );

            services.AddDbContext<PermissionDBReadOnlyContext>(option => option.UseNpgsql(Configuration.GetConnectionString("PermissionDBConnStr"), npgsqlOptions =>
                    {
                        npgsqlOptions.EnableRetryOnFailure();
                        npgsqlOptions.CommandTimeout(60);
                    })
                        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                    );
            services.Configure<ApiBehaviorOptions>(options =>
                    {
                        options.SuppressModelStateInvalidFilter = true;  //去掉自动模型验证
                    });
            services.AddSwaggerDocumentation("v1", "PermissionService API", Assembly.GetExecutingAssembly().GetName().Name);

            services.AddMediatR(Assembly.GetAssembly(typeof(Application.GetUserPermissionHandler)));
            services.AddAutoMapper(Assembly.GetAssembly(typeof(Domain.Models.AutoMapperProfile)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseApiMiddleware();
            app.UseMvc();
            if (env.IsDevelopment())
            {
                app.UseSwaggerDocumentation("v1", "PermissionService API 1.0");
            }
        }
    }
}
