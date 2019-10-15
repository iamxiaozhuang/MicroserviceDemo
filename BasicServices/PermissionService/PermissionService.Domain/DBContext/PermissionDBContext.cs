using CommonLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
    /// Add-Migration 20191015 -Context PermissionDBContext
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

        public DbSet<Resource> Resources { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Principal> Principals { get; set; }
        public DbSet<Scope> Scopes { get; set; }
        public DbSet<RoleAssignment> RoleAssignments { get; set; }

        public DbSet<Recycle> Recycles { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Resource>().HasKey(p => new { p.TenantCode, p.ID });
            builder.Entity<Resource>().HasIndex(p => p.TenantCode);
            builder.Entity<Resource>().HasIndex(p => new { p.TenantCode, p.ResourceCode }).IsUnique(true);
            builder.Entity<Resource>().HasOne<Resource>(p => p.ParentResource).WithMany(p => p.ChildrenResources)
              .HasForeignKey(s => new { s.TenantCode, s.ParentResourceID }).HasPrincipalKey(p => new { p.TenantCode, p.ID });

            builder.Entity<Role>().HasKey(p => new { p.TenantCode, p.ID });
            builder.Entity<Role>().HasIndex(p => p.TenantCode);
            builder.Entity<Role>().HasIndex(p => new { p.TenantCode, p.RoleCode }).IsUnique(true);

            builder.Entity<RolePermission>().HasKey(p => new { p.TenantCode, p.ID });
            builder.Entity<RolePermission>().HasIndex(p => p.TenantCode);
            builder.Entity<RolePermission>().HasOne<Resource>(p => p.Resource).WithMany(p => p.RolePermissions)
                .HasForeignKey(s => new { s.TenantCode, s.ResourceID }).HasPrincipalKey(p => new { p.TenantCode, p.ID });
            builder.Entity<RolePermission>().HasOne<Role>(p => p.Role).WithMany(p => p.RolePermissions)
                .HasForeignKey(s => new { s.TenantCode, s.RoleID }).HasPrincipalKey(p => new { p.TenantCode, p.ID });

            builder.Entity<Principal>().HasKey(p => new { p.TenantCode, p.ID });
            builder.Entity<Principal>().HasIndex(p => p.TenantCode);
            builder.Entity<Principal>().HasIndex(p => new { p.TenantCode, p.PrincipalCode }).IsUnique(true);

            builder.Entity<Scope>().HasKey(p => new { p.TenantCode, p.ID });
            builder.Entity<Scope>().HasIndex(p => p.TenantCode);
            builder.Entity<Scope>().HasIndex(p => new { p.TenantCode, p.ScopeCode }).IsUnique(true);
            builder.Entity<Scope>().HasOne<Scope>(p => p.ParentScope).WithMany(p => p.ChildrenScopes)
              .HasForeignKey(s => new { s.TenantCode, s.ParentScopeID }).HasPrincipalKey(p => new { p.TenantCode, p.ID });

            builder.Entity<RoleAssignment>().HasKey(p => new { p.TenantCode, p.ID });
            builder.Entity<RoleAssignment>().HasIndex(p => p.TenantCode);
            builder.Entity<RoleAssignment>().HasOne<Principal>(p => p.Principal).WithMany(p => p.RoleAssignments)
           .HasForeignKey(s => new { s.TenantCode, s.PrincipalID }).HasPrincipalKey(p => new { p.TenantCode, p.ID });
            builder.Entity<RoleAssignment>().HasOne<Role>(p => p.Role).WithMany(p => p.RoleAssignments)
                .HasForeignKey(s => new { s.TenantCode, s.RoleID }).HasPrincipalKey(p => new { p.TenantCode, p.ID });
            builder.Entity<RoleAssignment>().HasOne<Scope>(p => p.Scope).WithMany(p => p.RoleAssignments)
             .HasForeignKey(s => new { s.TenantCode, s.ScopeID }).HasPrincipalKey(p => new { p.TenantCode, p.ID });


            builder.Entity<Recycle>().HasKey(p => new { p.TenantCode, p.ID });
            builder.Entity<Recycle>().HasIndex(p => p.TenantCode);


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
