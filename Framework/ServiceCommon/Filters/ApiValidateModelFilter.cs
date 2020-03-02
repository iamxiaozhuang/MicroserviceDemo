using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using ServiceCommon.Models;

namespace ServiceCommon.Filters
{
    public class ApiValidateModelFilter : IActionFilter
    {
        IHttpContextAccessor httpContextAccessor;
        public ApiValidateModelFilter(IHttpContextAccessor _httpContextAccessor)
        {
            httpContextAccessor = _httpContextAccessor;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
         
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (httpContextAccessor.HttpContext.Request.Path.HasValue
              && httpContextAccessor.HttpContext.Request.Path.Value.StartsWith("/swagger") && httpContextAccessor.HttpContext.Request.Path.Value.StartsWith("/api/heathcheck"))
            {
                return;
            }
            if (!context.ModelState.IsValid)
            {
                List<ValidationError> validationErrors = context.ModelState.Keys
                            .SelectMany(key => context.ModelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                            .ToList();
                throw new FriendlyException(422, $"Model validation error:{JsonConvert.SerializeObject(validationErrors)}.");
            }
        }
    }

    public class ValidationError
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; }
        public string Message { get; }
        public ValidationError(string field, string message)
        {
            Field = field != string.Empty ? field : null;
            Message = message;
        }
    }
}
