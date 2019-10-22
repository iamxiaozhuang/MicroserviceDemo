using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary
{
    public class CurrentUserInfo
    {
        public string TenantCode { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
    }



    public class CurrentUserPermission
    {
        public string RoleCode { get; set; }
        public string ScopeCode { get; set; }
        public List<string> AllowResourceCodes { get; set; }
        public List<string> AllowScopeCodes { get; set; }

    }




}
