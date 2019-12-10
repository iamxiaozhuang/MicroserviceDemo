using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceCommon;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog.Web;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ProductService.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using MediatR;
using OrderingService.Application;

namespace OrderingService.Api
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

            services.AddDbContext<OrderingDBContext>(option => option.UseNpgsql(Configuration.GetConnectionString("OrderingDBConnStr"), npgsqlOptions =>
            {
                npgsqlOptions.EnableRetryOnFailure();
                npgsqlOptions.CommandTimeout(60);
            })
                        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                    );
            services.AddDbContext<OrderingDBReadOnlyContext>(option => option.UseNpgsql(Configuration.GetConnectionString("OrderingDBConnStr"), npgsqlOptions =>
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
            services.AddSwaggerDocumentation("v1", "OrderingService API", Assembly.GetExecutingAssembly().GetName().Name);

            services.AddMediatR(Assembly.GetAssembly(typeof(AddOrderHandler)));
            //services.AddAutoMapper(Assembly.GetAssembly(typeof(Domain.Models.ProductMamagementAutoMapperProfile)));

            //services.AddCap(x =>
            //{
            //    //如果你使用的 EF 进行数据操作，你需要添加如下配置：
            //    x.UseEntityFramework<ProductDBContext>();  //可选项
            //    //x.UsePostgreSql("数据库连接字符串");
            //    x.UseRabbitMQ(o =>
            //    {
            //        o.HostName = Configuration.GetValue<string>("RabbitMQ:HostName");
            //        o.Port = Configuration.GetValue<int>("RabbitMQ:Port");
            //    });
            //    x.UseDashboard();
            //    x.FailedRetryCount = 5;
            //    x.FailedThresholdCallback = (type, name, content) =>
            //    {
            //        Console.WriteLine($@"A message of type {type} failed after executing {x.FailedRetryCount} several times, requiring manual troubleshooting. Message name: {name}, message body: {content}");
            //    };
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            env.ConfigureNLog($"Nlog.{env.EnvironmentName}.config");
            app.UseApiMiddleware();
            app.UseMvc();
            if (env.IsDevelopment())
            {
                app.UseSwaggerDocumentation("v1", "OrderingService API 1.0");
            }
        }
    }
}
