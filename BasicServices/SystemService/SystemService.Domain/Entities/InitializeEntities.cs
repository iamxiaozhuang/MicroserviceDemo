using ServiceCommon;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SystemService.Domain.Entities
{
    public static class ModelBuilderExtensions
    {
        public static void InitializeEntities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>().HasKey(p => new { p.ID });
            modelBuilder.Entity<Resource>().HasIndex(p => new { p.ResourceCode }).IsUnique(true);
            modelBuilder.Entity<Resource>().HasOne<Resource>(p => p.ParentResource).WithMany(p => p.ChildrenResources)
              .HasForeignKey(s => new { s.ParentResourceID }).HasPrincipalKey(p => new { p.ID });
            var rootID = Guid.Parse("88888888-8888-8888-8888-888888888888");
            var productMngmtID = Guid.NewGuid();
            var productMngmtAddID = Guid.NewGuid();
            var orderingMngmtID = Guid.NewGuid();
            var systemMngmtID = Guid.NewGuid();
            var platformMngmtID = Guid.NewGuid();
            var permissionMngmtID = Guid.NewGuid();
            var permissionMngmtRoleID = Guid.NewGuid();
            modelBuilder.Entity<Resource>().HasData(
                 new Resource()
                 {
                     ID = rootID,
                     ResourceCode = "RootMenu",
                     ResourceName = "RootMenu",
                     ResourceType = EnumResourceType.Menu,
                     ParentResourceID = rootID,
                     SortNO = 0
                 },
                   new Resource()
                   {
                       ID = Guid.NewGuid(),
                       ResourceCode = "Permission.GetUserMenus",
                       ResourceName = "获取用户菜单",
                       ResourceType = EnumResourceType.Action,
                       ParentResourceID = rootID,
                       SortNO = 0
                   },
                 new Resource()
                 {
                     ID = productMngmtID,
                     ResourceCode = "ProductMngmt",
                     ResourceName = "产品管理",
                     ResourceType = EnumResourceType.Menu,
                     ParentResourceID = rootID,
                     SortNO = 1
                 },
                         new Resource()
                         {
                             ID = Guid.NewGuid(),
                             ResourceCode = "product.list",
                             ResourceName = "列出",
                             ResourceType = EnumResourceType.Action,
                             ParentResourceID = productMngmtID,
                             SortNO = 1
                         },
                         new Resource()
                         {
                             ID = Guid.NewGuid(),
                             ResourceCode = "product.get",
                             ResourceName = "获取单个",
                             ResourceType = EnumResourceType.Action,
                             ParentResourceID = productMngmtID,
                             SortNO = 2
                         },
                          new Resource()
                          {
                              ID = productMngmtAddID,
                              ResourceCode = "product.add",
                              ResourceName = "添加",
                              ResourceType = EnumResourceType.Action,
                              ParentResourceID = productMngmtID,
                              SortNO = 3
                          },
                                   new Resource()
                                   {
                                       ID = Guid.NewGuid(),
                                       ResourceCode = "product.add.addbtn",
                                       ResourceName = "添加按钮",
                                       ResourceType = EnumResourceType.Button,
                                       ParentResourceID = productMngmtAddID,
                                       SortNO = 1
                                   },
                           new Resource()
                           {
                               ID = Guid.NewGuid(),
                               ResourceCode = "product.update",
                               ResourceName = "更新",
                               ResourceType = EnumResourceType.Action,
                               ParentResourceID = productMngmtID,
                               SortNO = 4
                           },
                            new Resource()
                            {
                                ID = Guid.NewGuid(),
                                ResourceCode = "product.delete",
                                ResourceName = "删除",
                                ResourceType = EnumResourceType.Action,
                                ParentResourceID = productMngmtID,
                                SortNO = 5
                            },
                          
                            new Resource()
                            {
                                ID = Guid.NewGuid(),
                                ResourceCode = "basket.createorder",
                                ResourceName = "购物车下单",
                                ResourceType = EnumResourceType.Action,
                                ParentResourceID = productMngmtID,
                                SortNO = 6
                            },
                  new Resource()
                  {
                      ID = orderingMngmtID,
                      ResourceCode = "OrderingMngmt",
                      ResourceName = "订单管理",
                      ResourceType = EnumResourceType.Menu,
                      ParentResourceID = rootID,
                      SortNO = 2
                  },
                         new Resource()
                         {
                             ID = Guid.NewGuid(),
                             ResourceCode = "ordering.add",
                             ResourceName = "新增订单",
                             ResourceType = EnumResourceType.Action,
                             ParentResourceID = orderingMngmtID,
                             SortNO = 1
                         },
                   new Resource()
                   {
                       ID = Guid.NewGuid(),
                       ResourceCode = "PaymentMngmt",
                       ResourceName = "支付管理",
                       ResourceType = EnumResourceType.Menu,
                       ParentResourceID = rootID,
                       SortNO = 3
                   },
                   new Resource()
                   {
                       ID = systemMngmtID,
                       ResourceCode = "SystemMngmt",
                       ResourceName = "系统管理",
                       ResourceType = EnumResourceType.Menu,
                       ParentResourceID = rootID,
                       SortNO = 4
                   },
                               new Resource()
                               {
                                   ID = permissionMngmtID,
                                   ResourceCode = "SystemMngmt.PermissionMngmt",
                                   ResourceName = "权限管理",
                                   ResourceType = EnumResourceType.Menu,
                                   ParentResourceID = systemMngmtID,
                                   SortNO = 1
                               },
                                        new Resource()
                                        {
                                            ID = permissionMngmtRoleID,
                                            ResourceCode = "SystemMngmt.PermissionMngmt.RoleMngmt",
                                            ResourceName = "角色管理",
                                            ResourceType = EnumResourceType.Menu,
                                            ParentResourceID = permissionMngmtID,
                                            SortNO = 1
                                        },
                                                 new Resource()
                                                 {
                                                     ID = Guid.NewGuid(),
                                                     ResourceCode = "SystemMngmt.PermissionMngmt.RoleMngmt.Read",
                                                     ResourceName = "查看",
                                                     ResourceType = EnumResourceType.Action,
                                                     ParentResourceID = permissionMngmtRoleID,
                                                     SortNO = 1
                                                 },
                                                  new Resource()
                                                  {
                                                      ID = Guid.NewGuid(),
                                                      ResourceCode = "SystemMngmt.PermissionMngmt.RoleMngmt.Update",
                                                      ResourceName = "更改",
                                                      ResourceType = EnumResourceType.Action,
                                                      ParentResourceID = permissionMngmtRoleID,
                                                      SortNO = 2
                                                  },

                                        new Resource()
                                        {
                                            ID = Guid.NewGuid(),
                                            ResourceCode = "SystemMngmt.PermissionMngmt.ScopeMngmt",
                                            ResourceName = "范围管理",
                                            ResourceType = EnumResourceType.Menu,
                                            ParentResourceID = permissionMngmtID,
                                            SortNO = 2
                                        },
                                         new Resource()
                                         {
                                             ID = Guid.NewGuid(),
                                             ResourceCode = "SystemMngmt.PermissionMngmt.UserMngmt",
                                             ResourceName = "用户管理",
                                             ResourceType = EnumResourceType.Menu,
                                             ParentResourceID = permissionMngmtID,
                                             SortNO = 2
                                         },
                                         new Resource()
                                         {
                                             ID = Guid.NewGuid(),
                                             ResourceCode = "SystemMngmt.PermissionMngmt.AssignmnentMngmt",
                                             ResourceName = "授权管理",
                                             ResourceType = EnumResourceType.Menu,
                                             ParentResourceID = permissionMngmtID,
                                             SortNO = 3
                                         },

                                new Resource()
                                {
                                    ID = Guid.NewGuid(),
                                    ResourceCode = "SystemMngmt.JobMngmt",
                                    ResourceName = "任务管理",
                                    ResourceType = EnumResourceType.Menu,
                                    ParentResourceID = systemMngmtID,
                                    SortNO = 2
                                },
                                new Resource()
                                {
                                    ID = Guid.NewGuid(),
                                    ResourceCode = "SystemMngmt.MessageMngmt",
                                    ResourceName = "消息管理",
                                    ResourceType = EnumResourceType.Menu,
                                    ParentResourceID = systemMngmtID,
                                    SortNO = 3
                                },
                                 new Resource()
                                 {
                                     ID = Guid.NewGuid(),
                                     ResourceCode = "SystemMngmt.CacheMngmt",
                                     ResourceName = "缓存管理",
                                     ResourceType = EnumResourceType.Menu,
                                     ParentResourceID = systemMngmtID,
                                     SortNO = 3
                                 },
                              new Resource()
                              {
                                  ID = Guid.NewGuid(),
                                  ResourceCode = "SystemMngmt.LogMngmt",
                                  ResourceName = "日志管理",
                                  ResourceType = EnumResourceType.Menu,
                                  ParentResourceID = systemMngmtID,
                                  SortNO = 4
                              }
                );

            modelBuilder.Entity<Tenant>().HasKey(p => new { p.ID });
            modelBuilder.Entity<Tenant>().HasIndex(p => new { p.TenantCode }).IsUnique(true);
            modelBuilder.Entity<Tenant>().HasData(
                 new Tenant()
                 {
                     ID = Guid.NewGuid(),
                     TenantCode = "SYSTEM",
                     TenantName = "SYSTEM",
                     TenantUrl = "www.system.com",
                     TenantLogo = "",
                     SortNO = 0
                 },
                new Tenant()
                {
                    ID = Guid.NewGuid(),
                    TenantCode = "MSFT",
                    TenantName = "Microsoft",
                    TenantUrl = "www.microsoft.com",
                    TenantLogo = "",
                    SortNO = 1
                },
                new Tenant()
                {
                    ID = Guid.NewGuid(),
                    TenantCode = "GOOG",
                    TenantName = "Google",
                    TenantUrl = "www.Google.com",
                    TenantLogo = "",
                    SortNO = 2
                }
                );




            modelBuilder.Entity<Recycle>().HasKey(p => new { p.TenantCode, p.ID });
            modelBuilder.Entity<Recycle>().HasIndex(p => p.TenantCode);
        }
    }
}
