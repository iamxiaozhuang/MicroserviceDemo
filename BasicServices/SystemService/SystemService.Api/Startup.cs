using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SystemService.Domain;
using CommonLibrary;
using AutoMapper;

namespace SystemService.Api
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
            services.AddMvcCore(options => options.Filters.Add(new AuthorizeFilter()))
                .AddAuthorization()
                .AddJsonFormatters()
                .AddApiExplorer();
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = Configuration["IdentityService:Authority"];
                    options.RequireHttpsMetadata = false;
                    options.Audience = "SystemServiceApi";
                });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContext<SystemDBContext>(option =>option.UseNpgsql(Configuration.GetConnectionString("SystemDBConnStr"), npgsqlOptions =>
            {
                npgsqlOptions.EnableRetryOnFailure();
                npgsqlOptions.CommandTimeout(60);
            })
                 .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            );

            services.AddDbContext<SystemDBReadOnlyContext>(option => option.UseNpgsql(Configuration.GetConnectionString("SystemDBConnStr"), npgsqlOptions =>
            {
                npgsqlOptions.EnableRetryOnFailure();
                npgsqlOptions.CommandTimeout(60);
            })
                        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                    );

            services.AddSwaggerDocumentation("v1", "SystemService API", Assembly.GetExecutingAssembly().GetName().Name);

            services.AddMediatR(Assembly.GetAssembly(typeof(Application.ResourceApp.GetUserMenuslHandler)));
            services.AddAutoMapper(Assembly.GetAssembly(typeof(Application.ResourceApp.GetUserMenusRequest)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseMvc();
            if (env.IsDevelopment())
            {
                app.UseSwaggerDocumentation("v1", "SystemService API 1.0");
            }
        }
    }
}
