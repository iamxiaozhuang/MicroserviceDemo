using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Enities
{

    public class CurrentUserInfo
    {
        public string TenantCode { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public List<FunctionPermission> RolePermission { get; set; }
    }

    public class FunctionPermission
    {
        public string FunctionCode { get; set; }
        public string PermissionCode { get; set; }
    }
}
