using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceCommon.Models
{
    public class GeneralApiToken
    {
        public DateTime ExpiresAt { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }

    public class UserInfo
    {
        public string TenantCode { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
    }



    public class UserPermission
    {
        public string RoleCode { get; set; }
        public string ScopeCode { get; set; }
        public List<string> AllowMenuCodes { get; set; }
        public List<string> AllowActionCodes { get; set; }
        public List<string> AllowBtnCodes { get; set; }
        public List<string> AllowScopeCodes { get; set; }

    }

    public class UserMenu
    {
        public string MenuCode { get; set; }
        public string MenuName { get; set; }
        public int SortNO { get; set; }
        public List<UserMenu> ChildrenMenus { get; set; }
        

    }

    public class ResourceData
    {
        public Guid ID { get; set; }
        public string ResourceCode { get; set; }
        public string ResourceName { get; set; }
        public EnumResourceType ResourceType { get; set; }
        public Guid ParentResourceID { get; set; }
        public int SortNO { get; set; }
        public string ResourceDesc { get; set; }
    }
    public enum EnumResourceType
    {
        Menu = 1,
        Action = 2,
        Button = 3
    }



}
