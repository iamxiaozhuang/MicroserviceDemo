
using CommonService.Enities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.Utilities
{
    /// <summary>
    /// https://elanderson.net/2017/02/log-requests-and-responses-in-asp-net-core/
    /// https://stackoverflow.com/questions/38630076/asp-net-core-web-api-exception-handling
    /// </summary>
    public class ApiMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ICurrentTenantInfoProvider _currentTenantInfoProvider;
        private readonly ICurrentUserInfoProvider _currentUserInfoProvider;
        private CurrentUserInfo currentUserInfo = null;
        NLog.Logger requestLogger = NLog.LogManager.GetLogger("ApiRequestLogger");

        public ApiMiddleware(RequestDelegate next, ICurrentTenantInfoProvider currentTenantInfoProvider, ICurrentUserInfoProvider currentUserInfoProvider)
        {
            _next = next;
            _currentTenantInfoProvider = currentTenantInfoProvider;
            _currentUserInfoProvider = currentUserInfoProvider;
        }

        public async Task Invoke(HttpContext context)
        {
            CurrentTenantInfo currentTenantInfo = _currentTenantInfoProvider.ReadCurrentTenantInfo();
            context.Items.Add("CurrentTenantInfo", currentTenantInfo);
            currentUserInfo = _currentUserInfoProvider.ReadCurrentUserInfo();
            context.Items.Add("CurrentUserInfo", currentUserInfo);


            NLog.LogEventInfo requestLogEvent = new NLog.LogEventInfo(NLog.LogLevel.Trace, "ApiRequestLogger", "Invoke");
            requestLogEvent.Properties["RequestLogID"] = Guid.NewGuid().ToString();
            requestLogEvent.Properties["RequestTimestamp"] = DateTime.UtcNow;
            requestLogEvent.Properties["RequestMethod"] = context.Request.Method;
            requestLogEvent.Properties["RequestUrl"] = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}?{context.Request.QueryString}";//context.Request.GetDisplayUrl()
            requestLogEvent.Properties["RequestContentType"] = context.Request.ContentType;
            requestLogEvent.Properties["RequestBody"] = await GetRequestBody(context.Request);
            requestLogEvent.Properties["RequestUser"] = currentUserInfo == null ? "" : currentUserInfo.UserCode + " " + currentUserInfo.UserName;
            requestLogEvent.Properties["RequestTenant"] = currentTenantInfo == null ? "" : currentTenantInfo.TenantCode;
            requestLogEvent.Properties["HasError"] = false;
            var originalBodyStream = context.Response.Body;
            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;
                try
                {
                    await _next(context);
                }
                catch (Exception ex)
                {
                    context.Response.ContentType = "application/json";
                    var exceptionResponse = "";
                    FriendlyException friendlyException = ex as FriendlyException;
                    if (friendlyException != null)
                    {
                        context.Response.StatusCode = friendlyException.HttpStatusCode;
                        requestLogEvent.Properties["HasError"] = true;
                        requestLogEvent.Properties["ErrorMessage"] = friendlyException.ExceptionMessage;
                        exceptionResponse = JsonConvert.SerializeObject(new { FriendlyExceptionMessage = friendlyException.ExceptionMessage });
                    }
                    else
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        requestLogEvent.Properties["HasError"] = true;
                        requestLogEvent.Properties["ErrorMessage"] = ex.Message;
                        requestLogEvent.Properties["ErrorStackTrace"] = ex.StackTrace;
                        if (ex.InnerException != null)
                        {
                            requestLogEvent.Properties["ErrorMessage"] = requestLogEvent.Properties["ErrorMessage"] + ";\n InnerExceptionMessage: " + ex.InnerException.Message;
                            requestLogEvent.Properties["ErrorStackTrace"] = requestLogEvent.Properties["ErrorMessage"] + ";\n InnerExceptionStackTrace: " + ex.InnerException.StackTrace;
                        }

                        exceptionResponse = JsonConvert.SerializeObject(new {
                            FriendlyExceptionMessage = $"未知异常,异常ID为{requestLogEvent.Properties["RequestLogID"]},请联系管理员处理。" });
                    }
                    
                    await context.Response.WriteAsync(exceptionResponse);
                }
                requestLogEvent.Properties["ResponseCode"] = context.Response.StatusCode.ToString();
                requestLogEvent.Properties["ResponseContentType"] = context.Response.ContentType;
                requestLogEvent.Properties["ResponseBody"] = await GetResponseBody(context.Response);
                await responseBody.CopyToAsync(originalBodyStream);
            }
            requestLogEvent.Properties["ResponseTimestamp"] = DateTime.UtcNow;
            requestLogEvent.Properties["ExecuteDuration"] = (int)(Convert.ToDateTime(requestLogEvent.Properties["ResponseTimestamp"]) -
                                                                  Convert.ToDateTime(requestLogEvent.Properties["RequestTimestamp"])).TotalMilliseconds;
             requestLogger.Log(requestLogEvent);
            //NLog.Logger generalLogger = NLog.LogManager.GetLogger("GeneralLogger");
            //generalLogger.Info("testlog");
        }

        private async Task<string> GetRequestBody(HttpRequest request)
        {
            //var body = request.Body;
            request.EnableRewind();
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyText = Encoding.UTF8.GetString(buffer);
            //request.Body = body;
            request.Body.Position = 0;

            return bodyText;
        }

        private async Task<string> GetResponseBody(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var bodyText = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);
            return bodyText;
        }
    }

    public static class ApiMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiMiddleware>();
        }
    }

    
}
