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
using SystemService.Domain;
using SystemService.Domain.Entities;

namespace SystemService.Domain
{
    /// <summary>
    /// Add-Migration 20191023 -Context SystemDBContext
    /// Update-Database -Context SystemDBContext
    /// </summary>
    public class SystemDBContext : DbContext
    {
        public SystemDBContext(DbContextOptions<SystemDBContext> options) : base(options)
        {
        }

        public DbSet<Resource> Resources { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        public DbSet<Recycle> Recycles { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.InitializeEntities();
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

            foreach (var entry in this.ChangeTracker.Entries<BaseEntityWithNoTenant>().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified))
            {
                var entity = entry.Entity;
                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.CreateIn = nowTime;
                        entity.CreatedBy = "system";
                        break;
                    case EntityState.Modified:
                        entity.UpdateIn = nowTime;
                        entity.UpdatedBy = "system";
                        break;
                    case EntityState.Deleted:
                        Recycle recycle = new Recycle()
                        {
                            TenantCode = "SYSTEM",
                            ID = Guid.NewGuid(),
                            CreateIn = nowTime,
                            CreatedBy = "system",
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

     
    }
}
