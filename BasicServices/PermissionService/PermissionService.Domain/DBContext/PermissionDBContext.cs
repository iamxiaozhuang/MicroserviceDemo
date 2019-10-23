using CommonLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PermissionService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PermissionService.Domain
{
    /// <summary>
    /// Add-Migration 20191021 -Context PermissionDBContext
    /// Update-Database -Context PermissionDBContext
    /// </summary>
    public class PermissionDBContext : DbContext
    {
        private readonly CurrentUserInfo currentUserInfo;
        public PermissionDBContext(DbContextOptions<PermissionDBContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            currentUserInfo = httpContextAccessor.HttpContext.Items["CurrentUserInfo"] as CurrentUserInfo;
            //currentUserInfo = new CurrentUserInfo();
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Principal> Principals { get; set; }
        public DbSet<Scope> Scopes { get; set; }
        public DbSet<RoleAssignment> RoleAssignments { get; set; }

        public DbSet<Recycle> Recycles { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.InitializeEntities();

            foreach (var entityType in GetBaseEntityTypes(builder))
            {
                GlobalTenantQueryMethodInfo.MakeGenericMethod(entityType)
                 .Invoke(this, new object[] { builder });
            }

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            UpdateCommonFileds();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateCommonFileds();
            return base.SaveChangesAsync(cancellationToken);
        }


        /// <summary>
        /// 数据新增、更新前更新公共字段
        /// </summary>
        private void UpdateCommonFileds()
        {
            var nowTime = DateTimeOffset.UtcNow;
            var deleteBatchID = Guid.NewGuid();

            foreach (var entry in this.ChangeTracker.Entries<BaseEntity>().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified))
            {
                var entity = entry.Entity;
                switch (entry.State)
                {
                    case EntityState.Added:
                        if (entity.TenantCode == "")
                            entity.TenantCode = currentUserInfo.TenantCode;
                        entity.CreateIn = nowTime;
                        entity.CreatedBy = currentUserInfo.UserName;
                        break;
                    case EntityState.Modified:
                        entity.UpdateIn = nowTime;
                        entity.UpdatedBy = currentUserInfo.UserName;
                        break;
                    case EntityState.Deleted:
                        Recycle recycle = new Recycle()
                        {
                            TenantCode = currentUserInfo.TenantCode,
                            ID = Guid.NewGuid(),
                            CreateIn = nowTime,
                            CreatedBy = currentUserInfo.UserName,
                            TableName = entity.GetType().Name,
                            RowKey = entity.ID,
                            RowData = JsonConvert.SerializeObject(entity),
                            DeleteBatchID = deleteBatchID
                        };
                        Recycles.Add(recycle);
                        break;
                }
            }
            this.ChangeTracker.DetectChanges();
        }

        #region 多租户全局查询过滤
        private static IList<Type> _baseEntityTypesCache;
        private static IList<Type> GetBaseEntityTypes(ModelBuilder builder)
        {
            if (_baseEntityTypesCache != null)
                return _baseEntityTypesCache.ToList();
            _baseEntityTypesCache = (from t in builder.Model.GetEntityTypes()
                                     where t.ClrType.BaseType == typeof(BaseEntity)
                                     select t.ClrType).ToList();
            return _baseEntityTypesCache;
        }
        static readonly MethodInfo GlobalTenantQueryMethodInfo = typeof(PermissionDBContext).GetMethods(BindingFlags.Public | BindingFlags.Instance)
                                                       .Single(t => t.IsGenericMethod && t.Name == "SetGlobalTenantQuery");
        public void SetGlobalTenantQuery<T>(ModelBuilder builder) where T : BaseEntity
        {
            builder.Entity<T>().HasQueryFilter(e => e.TenantCode == currentUserInfo.TenantCode);
        }
        #endregion
    }
}
