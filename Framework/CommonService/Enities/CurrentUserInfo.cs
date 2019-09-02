using System;
using System.Collections.Generic;
using System.Text;

namespace CommonService.Enities
{

    public class CurrentUserInfo
    {
        public string TenantCode { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public List<FunctionPermission> RolePermission { get; set; }
        public string OrgCode { get; set; }
        public string OrgName { get; set; }
        public List<FunctionPermission> OrgPermission { get; set; }
    }

    public class FunctionPermission
    {
        public string FunctionCode { get; set; }
        public string PermissionCode { get; set; }
    }
}
