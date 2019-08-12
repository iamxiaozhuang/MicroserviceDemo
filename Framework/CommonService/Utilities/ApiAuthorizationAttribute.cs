
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonService.Utilities
{
    public class ApiAuthorizationAttribute : Attribute
    {

        private readonly string functionCode, permissionCode;
        public ApiAuthorizationAttribute(string _functionCode, string _permissionCode)
        {
            functionCode = _functionCode;
            permissionCode = _permissionCode;
        }

        public string  FunctionCode {
            get {
                return functionCode;
            }
        }
        public string PermissionCode
        {
            get
            {
                return permissionCode;
            }
        }

    }
}

