using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class NlogHelper
    {
        public static void LogApiRequestAndResponse(Guid logID, HttpContext context, DateTime requestTime, string requestTenant, string requestUser,  string requestBody, Exception ex, DateTime reponseTime, string responseBody)
        {
            NLog.Logger requestLogger = NLog.LogManager.GetLogger("ApiRequestLogger");
            NLog.LogEventInfo requestLogEvent = new NLog.LogEventInfo(NLog.LogLevel.Trace, "ApiRequestLogger", "Invoke");
            requestLogEvent.Properties["RequestLogID"] = logID;
            requestLogEvent.Properties["RequestTimestamp"] = requestTime;
            requestLogEvent.Properties["RequestMethod"] = context.Request.Method;
            requestLogEvent.Properties["RequestUrl"] = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}?{context.Request.QueryString}";//context.Request.GetDisplayUrl()
            requestLogEvent.Properties["RequestContentType"] = context.Request.ContentType;
            requestLogEvent.Properties["RequestBody"] = requestBody;
            requestLogEvent.Properties["RequestUser"] = requestUser;
            requestLogEvent.Properties["RequestTenant"] = requestTenant;
            requestLogEvent.Properties["HasError"] = false;
            if (ex != null)
            {
                FriendlyException friendlyException = ex as FriendlyException;
                if (friendlyException != null)
                {
                    requestLogEvent.Properties["HasError"] = true;
                    requestLogEvent.Properties["ErrorMessage"] = friendlyException.ExceptionMessage;
                }
                else
                {
                    requestLogEvent.Properties["HasError"] = true;
                    requestLogEvent.Properties["ErrorMessage"] = ex.Message;
                    requestLogEvent.Properties["ErrorStackTrace"] = ex.StackTrace;
                    if (ex.InnerException != null)
                    {
                        requestLogEvent.Properties["ErrorMessage"] = requestLogEvent.Properties["ErrorMessage"] + ";\n InnerExceptionMessage: " + ex.InnerException.Message;
                        requestLogEvent.Properties["ErrorStackTrace"] = requestLogEvent.Properties["ErrorMessage"] + ";\n InnerExceptionStackTrace: " + ex.InnerException.StackTrace;
                    }
                }
            }
            requestLogEvent.Properties["ResponseCode"] = context.Response.StatusCode.ToString();
            requestLogEvent.Properties["ResponseContentType"] = context.Response.ContentType;
            requestLogEvent.Properties["ResponseBody"] = responseBody;
            requestLogEvent.Properties["ResponseTimestamp"] = reponseTime;
            requestLogEvent.Properties["ExecuteDuration"] = (int)(reponseTime - requestTime).TotalMilliseconds;
            requestLogger.Log(requestLogEvent);
        }

        public static void LogGeneralInfo(string info)
        {
            NLog.Logger generalLogger = NLog.LogManager.GetLogger("GeneralLogger");
            generalLogger.Info(info);
        }

    }
}
