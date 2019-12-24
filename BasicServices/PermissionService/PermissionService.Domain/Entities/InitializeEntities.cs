using ServiceCommon;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PermissionService.Domain.Entities
{

    public static class ModelBuilderExtensions
    {
        public static void InitializeEntities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasKey(p => new { p.TenantCode, p.ID });
            modelBuilder.Entity<Role>().HasIndex(p => p.TenantCode);
            modelBuilder.Entity<Role>().HasIndex(p => new { p.TenantCode, p.RoleCode }).IsUnique(true);
            var adminRoleID = Guid.NewGuid();
            var adminID = Guid.NewGuid();
            var scopeID = Guid.NewGuid();
            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    TenantCode = "SYSTEM",
                    ID = adminRoleID,
                    RoleCode = "administor",
                    RoleName = "administor",
                    RoleType = EnumRoleType.BuildIn,
                    SortNO = 0
                }
                );

            modelBuilder.Entity<RolePermission>().HasKey(p => new { p.TenantCode, p.ID });
            modelBuilder.Entity<RolePermission>().HasIndex(p => p.TenantCode);
            modelBuilder.Entity<RolePermission>().HasOne<Role>(p => p.Role).WithMany(p => p.RolePermissions)
                .HasForeignKey(s => new { s.TenantCode, s.RoleID }).HasPrincipalKey(p => new { p.TenantCode, p.ID });
            modelBuilder.Entity<RolePermission>().HasData(
                new RolePermission()
                {
                    TenantCode = "SYSTEM",
                    ID = Guid.NewGuid(),
                    RoleID = adminRoleID,
                    ResourceCode = "Permission.GetUserMenus",
                    ResourceName = "获取用户菜单"
                },
                 new RolePermission()
                 {
                     TenantCode = "SYSTEM",
                     ID = Guid.NewGuid(),
                     RoleID = adminRoleID,
                     ResourceCode = "values.getuserclaims",
                     ResourceName = "getuserclaims"
                 },
                new RolePermission()
                {
                    TenantCode = "SYSTEM",
                    ID = Guid.NewGuid(),
                    RoleID = adminRoleID,
                    ResourceCode = "RootMenu",
                    ResourceName = "RootMenu"
                },
                new RolePermission()
                {
                    TenantCode = "SYSTEM",
                    ID = Guid.NewGuid(),
                    RoleID = adminRoleID,
                    ResourceCode = "ProductMngmt",
                    ResourceName = "产品管理"
                },
                 new RolePermission()
                 {
                     TenantCode = "SYSTEM",
                     ID = Guid.NewGuid(),
                     RoleID = adminRoleID,
                     ResourceCode = "product.list",
                     ResourceName = "列出"
                 },
                  new RolePermission()
                  {
                      TenantCode = "SYSTEM",
                      ID = Guid.NewGuid(),
                      RoleID = adminRoleID,
                      ResourceCode = "product.get",
                      ResourceName = "获取"
                  },
                   new RolePermission()
                   {
                       TenantCode = "SYSTEM",
                       ID = Guid.NewGuid(),
                       RoleID = adminRoleID,
                       ResourceCode = "product.add",
                       ResourceName = "添加"
                   },
                    new RolePermission()
                    {
                        TenantCode = "SYSTEM",
                        ID = Guid.NewGuid(),
                        RoleID = adminRoleID,
                        ResourceCode = "product.update",
                        ResourceName = "修改"
                    },
                     new RolePermission()
                     {
                         TenantCode = "SYSTEM",
                         ID = Guid.NewGuid(),
                         RoleID = adminRoleID,
                         ResourceCode = "product.delete",
                         ResourceName = "删除"
                     },
                 new RolePermission()
                 {
                     TenantCode = "SYSTEM",
                     ID = Guid.NewGuid(),
                     RoleID = adminRoleID,
                     ResourceCode = "SystemMngmt",
                     ResourceName = "系统管理"
                 }, 
                 new RolePermission()
                 {
                     TenantCode = "SYSTEM",
                     ID = Guid.NewGuid(),
                     RoleID = adminRoleID,
                     ResourceCode = "SystemMngmt.PermissionMngmt",
                     ResourceName = "权限管理"
                 },
                  new RolePermission()
                  {
                      TenantCode = "SYSTEM",
                      ID = Guid.NewGuid(),
                      RoleID = adminRoleID,
                      ResourceCode = "SystemMngmt.PermissionMngmt.RoleMngmt",
                      ResourceName = "角色管理"
                  },
                  new RolePermission()
                  {
                      TenantCode = "SYSTEM",
                      ID = Guid.NewGuid(),
                      RoleID = adminRoleID,
                      ResourceCode = "SystemMngmt.PermissionMngmt.RoleMngmt.Read",
                      ResourceName = "查看"
                  },
                  new RolePermission()
                  {
                      TenantCode = "SYSTEM",
                      ID = Guid.NewGuid(),
                      RoleID = adminRoleID,
                      ResourceCode = "SystemMngmt.PermissionMngmt.RoleMngmt.Update",
                      ResourceName = "更改"
                  },
                  new RolePermission()
                  {
                      TenantCode = "SYSTEM",
                      ID = Guid.NewGuid(),
                      RoleID = adminRoleID,
                      ResourceCode = "SystemMngmt.PermissionMngmt.ScopeMngmt",
                      ResourceName = "范围管理"
                  },
                   new RolePermission()
                   {
                       TenantCode = "SYSTEM",
                       ID = Guid.NewGuid(),
                       RoleID = adminRoleID,
                       ResourceCode = "SystemMngmt.PermissionMngmt.AssignmnentMngmt",
                       ResourceName = "授权管理"
                   },
                    new RolePermission()
                    {
                        TenantCode = "SYSTEM",
                        ID = Guid.NewGuid(),
                        RoleID = adminRoleID,
                        ResourceCode = "basket.createorder",
                        ResourceName = "购物车下单"
                    },
                     new RolePermission()
                     {
                         TenantCode = "SYSTEM",
                         ID = Guid.NewGuid(),
                         RoleID = adminRoleID,
                         ResourceCode = "ordering.add",
                         ResourceName = "新增订单"
                     }
                ) ; 

            modelBuilder.Entity<Principal>().HasKey(p => new { p.TenantCode, p.ID });
            modelBuilder.Entity<Principal>().HasIndex(p => p.TenantCode);
            modelBuilder.Entity<Principal>().HasIndex(p => new { p.TenantCode, p.PrincipalCode }).IsUnique(true);
            modelBuilder.Entity<Principal>().HasData(
                new Principal()
                {
                    TenantCode = "SYSTEM",
                    ID = adminID,
                    PrincipalCode = "admin",
                    PrincipalName = "admin"
                }
                );

            modelBuilder.Entity<Scope>().HasKey(p => new { p.TenantCode, p.ID });
            modelBuilder.Entity<Scope>().HasIndex(p => p.TenantCode);
            modelBuilder.Entity<Scope>().HasIndex(p => new { p.TenantCode, p.ScopeCode }).IsUnique(true);
            modelBuilder.Entity<Scope>().HasOne<Scope>(p => p.ParentScope).WithMany(p => p.ChildrenScopes)
              .HasForeignKey(s => new { s.TenantCode, s.ParentScopeID }).HasPrincipalKey(p => new { p.TenantCode, p.ID });
            var rootID = Guid.Parse("88888888-8888-8888-8888-888888888888");
            var node1ID = Guid.NewGuid();
            var node2ID = Guid.NewGuid();
            modelBuilder.Entity<Scope>().HasData(
               new Scope()
               {
                   TenantCode = "SYSTEM",
                   ID = rootID,
                   ScopeCode = "RootScope",
                   ScopeName = "RootScope",
                   ParentScopeID = rootID,
                   SortNO = 0
               },
                    new Scope()
                    {
                        TenantCode = "SYSTEM",
                        ID = node1ID,
                        ScopeCode = "1Node1",
                        ScopeName = "一级组织",
                        ParentScopeID = rootID,
                        SortNO = 0
                    },
                           new Scope()
                           {
                               TenantCode = "SYSTEM",
                               ID = node2ID,
                               ScopeCode = "1Node1.2Node1",
                               ScopeName = "二级组织1",
                               ParentScopeID = node1ID,
                               SortNO = 1
                           },
                                new Scope()
                                {
                                    TenantCode = "SYSTEM",
                                    ID = Guid.NewGuid(),
                                    ScopeCode = "1Node1.2Node1.3Node1",
                                    ScopeName = "三级组织1",
                                    ParentScopeID = node2ID,
                                    SortNO = 0
                                },
                            new Scope()
                            {
                                TenantCode = "SYSTEM",
                                ID = Guid.NewGuid(),
                                ScopeCode = "1Node1.2Node2",
                                ScopeName = "二级组织2",
                                ParentScopeID = node1ID,
                                SortNO = 2
                            }
               );

            modelBuilder.Entity<RoleAssignment>().HasKey(p => new { p.TenantCode, p.ID });
            modelBuilder.Entity<RoleAssignment>().HasIndex(p => p.TenantCode);
            modelBuilder.Entity<RoleAssignment>().HasOne<Principal>(p => p.Principal).WithMany(p => p.RoleAssignments)
           .HasForeignKey(s => new { s.TenantCode, s.PrincipalID }).HasPrincipalKey(p => new { p.TenantCode, p.ID });
            modelBuilder.Entity<RoleAssignment>().HasOne<Role>(p => p.Role).WithMany(p => p.RoleAssignments)
                .HasForeignKey(s => new { s.TenantCode, s.RoleID }).HasPrincipalKey(p => new { p.TenantCode, p.ID });
            modelBuilder.Entity<RoleAssignment>().HasOne<Scope>(p => p.Scope).WithMany(p => p.RoleAssignments)
             .HasForeignKey(s => new { s.TenantCode, s.ScopeID }).HasPrincipalKey(p => new { p.TenantCode, p.ID });
            modelBuilder.Entity<RoleAssignment>().HasData(
              new RoleAssignment()
              {
                  TenantCode = "SYSTEM",
                  ID = Guid.NewGuid(),
                  RoleID = adminRoleID,
                  PrincipalID = adminID,
                  ScopeID = rootID
              }
              );


            modelBuilder.Entity<Recycle>().HasKey(p => new { p.TenantCode, p.ID });
            modelBuilder.Entity<Recycle>().HasIndex(p => p.TenantCode);
        }
    }
}
