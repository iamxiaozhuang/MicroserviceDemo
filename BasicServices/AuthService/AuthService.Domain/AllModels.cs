using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthService.Domain
{
    public class RoleAssignmentModel : BaseModel
    {
        public string PrincipalCode { get; set; }
        public string PrincipalName { get; set; }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public string ScopeCode { get; set; }
        public string FullScopeCode { get; set; }
        public string ScopeName { get; set; }
        public int SortNO { get; set; }

    }
}
