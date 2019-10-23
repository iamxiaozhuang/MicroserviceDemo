using CommonLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PermissionService.Domain
{
    

    [Table("Role")]
    public class Role : BaseEntity
    {
        [Required]
        public string RoleCode { get; set; }
        [Required]
        public string RoleName { get; set; }
        [Required]
        public EnumRoleType RoleType { get; set; }
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
        public virtual ICollection<RoleAssignment> RoleAssignments { get; set; }
        [Required]
        public int SortNO { get; set; }
        public string RoleDesc { get; set; }
    }
    public enum EnumRoleType
    {
        BuildIn = 1,
        Custom = 2
    }

    [Table("RolePermission")]
    public class RolePermission : BaseEntity
    {
        [Required]
        public Guid RoleID { get; set; }
        public virtual Role Role { get; set; }
        [Required]
        public string ResourceCode { get; set; }
        [Required]
        public string ResourceName { get; set; }
    }

    [Table("Principal")]
    public class Principal : BaseEntity
    {
        [Required]
        public string PrincipalCode { get; set; }
        [Required]
        public string PrincipalName { get; set; }
        public virtual ICollection<RoleAssignment> RoleAssignments { get; set; }
        public string PrincipalDesc { get; set; }
    }

    [Table("Scope")]
    public class Scope : BaseEntity
    {
        [Required]
        public string ScopeCode { get; set; }
        [Required]
        public string ScopeName { get; set; }
        [Required]
        public Guid ParentScopeID { get; set; }

        public virtual Scope ParentScope { get; set; }
        public virtual ICollection<Scope> ChildrenScopes { get; set; }

        public virtual ICollection<RoleAssignment> RoleAssignments { get; set; }

        [Required]
        public int SortNO { get; set; }
        public string ScopeDesc { get; set; }
    }


    [Table("RoleAssignment")]
    public class RoleAssignment : BaseEntity
    {
        [Required]
        public Guid PrincipalID { get; set; }
        public virtual Principal Principal { get; set; }
        [Required]
        public Guid RoleID { get; set; }
        public virtual Role Role { get; set; }
        [Required]
        public Guid ScopeID { get; set; }
        public virtual Scope Scope { get; set; }
    }



}
