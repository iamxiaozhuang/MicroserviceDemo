
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceCommon
{
    public class ApiAuthorizationAttribute : Attribute
    {

        private readonly string resourceCode;
        public ApiAuthorizationAttribute(string _resourceCode)
        {
            resourceCode = _resourceCode;
        }

        public string  ResourceCode {
            get {
                return resourceCode;
            }
        }

    }
}

