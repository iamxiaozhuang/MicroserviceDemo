
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
        private readonly ICurrentUserInfoProvider _currentUserInfoProvider;

        public ApiMiddleware(RequestDelegate next, ICurrentUserInfoProvider currentUserInfoProvider)
        {
            _next = next;
            _currentUserInfoProvider = currentUserInfoProvider;
        }

        public async Task Invoke(HttpContext context)
        {
            CurrentUserInfo currentUserInfo = _currentUserInfoProvider.ReadCurrentUserInfo();
            context.Items.Add("CurrentUserInfo", currentUserInfo);

            Guid logID = Guid.NewGuid();
            DateTime requestTime = DateTime.UtcNow;
            string requestBody = await GetRequestBody(context.Request);
            Exception invokeException = null;
            DateTime reponseTime = requestTime;
            string responseBody = "";

            var originalBodyStream = context.Response.Body;
            using (var memoryResponseBody = new MemoryStream())
            {
                context.Response.Body = memoryResponseBody;
                try
                {
                    await _next(context);
                }
                catch (Exception ex)
                {
                    invokeException = ex;
                    context.Response.ContentType = "application/json";
                    var exceptionResponse = "";
                    FriendlyException friendlyException = ex as FriendlyException;
                    if (friendlyException != null)
                    {
                        context.Response.StatusCode = friendlyException.HttpStatusCode;
                        exceptionResponse = JsonConvert.SerializeObject(new { FriendlyExceptionMessage = friendlyException.ExceptionMessage });
                    }
                    else
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        exceptionResponse = JsonConvert.SerializeObject(new
                        {
                            FriendlyExceptionMessage = $"未知异常, 异常ID为{logID},请联系管理员处理。"
                        });
                    }
                    
                    await context.Response.WriteAsync(exceptionResponse);
                }

                reponseTime = DateTime.UtcNow;
                responseBody = await GetResponseBody(context.Response);
                await memoryResponseBody.CopyToAsync(originalBodyStream);
            }

            NlogHelper.LogApiRequestAndResponse(logID, context, currentUserInfo, requestTime, requestBody, invokeException, reponseTime, responseBody);
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
