using CommonLibrary.Enities;
using CommonLibrary.Utilities;
using Microsoft.EntityFrameworkCore;
using ProductService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Infrastructure
{
    /// <summary>
    /// Add-Migration 20190929 -Context ProductDBContext
    /// Update-Database -Context ProductDBContext
    /// </summary>
    public class ProductDBContext : DbContext
    {
        private readonly CurrentUserInfo currentUserInfo;
        public ProductDBContext(DbContextOptions<ProductDBContext> options, ICurrentUserInfoProvider currentUserInfoProvider) : base(options)
        {
            currentUserInfo = currentUserInfoProvider.GetCurrentUserInfo();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Recycle> Recycles { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>().HasIndex(p => new { p.TenantCode, p.CategoryCode }).IsUnique(true);

            builder.Entity<Product>().HasIndex(p => new { p.TenantCode, p.ProductCode }).IsUnique(true);
            builder.Entity<Product>().HasOne<Category>(p => p.Category).WithMany(p => p.Products)
                .HasForeignKey(s => new { s.TenantCode, s.CategoryId }).HasPrincipalKey(p => new { p.TenantCode, p.ID });
            builder.Entity<Product>().Property(d => d.ProductProfile).HasColumnType("json");

            foreach (var entityType in GetBaseEntityTypes(builder))
            {
                builder.Entity<Product>().HasKey(p => new { p.TenantCode, p.ID });
                builder.Entity<Product>().HasIndex(p => p.TenantCode);

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
        static readonly MethodInfo GlobalTenantQueryMethodInfo = typeof(ProductDBContext).GetMethods(BindingFlags.Public | BindingFlags.Instance)
                                                       .Single(t => t.IsGenericMethod && t.Name == "SetGlobalTenantQuery");
        public void SetGlobalTenantQuery<T>(ModelBuilder builder) where T : BaseEntity
        {
            builder.Entity<T>().HasQueryFilter(e => e.TenantCode == currentUserInfo.TenantCode);
        }
        #endregion
    }
}
