using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Entities;
using ServiceCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService.Domain.Entities
{
    public static class ModelBuilderExtensions
    {
        public static void InitializeEntities(this ModelBuilder builder)
        {
            builder.Entity<Category>().HasKey(p => new { p.TenantCode, p.ID });
            builder.Entity<Category>().HasIndex(p => p.TenantCode);
            builder.Entity<Category>().HasIndex(p => new { p.TenantCode, p.CategoryCode }).IsUnique(true);
            Guid cateID = Guid.NewGuid();
            builder.Entity<Category>().HasData(
            new Category()
            {
                TenantCode = "SYSTEM",
                ID = cateID,
                CategoryCode = "cate1",
                CategoryName = "商品类别1"
            });

            builder.Entity<Product>().HasKey(p => new { p.TenantCode, p.ID });
            builder.Entity<Product>().HasIndex(p => p.TenantCode);
            builder.Entity<Product>().HasIndex(p => new { p.TenantCode, p.ProductCode }).IsUnique(true);
            builder.Entity<Product>().HasOne<Category>(p => p.Category).WithMany(p => p.Products)
                .HasForeignKey(s => new { s.TenantCode, s.CategoryId }).HasPrincipalKey(p => new { p.TenantCode, p.ID });
            builder.Entity<Product>().Property(d => d.ProductProfile).HasColumnType("json");
            builder.Entity<Product>().HasData(
            new Product()
            {
                TenantCode = "SYSTEM",
                ID = Guid.NewGuid(),
                ProductCode = "product1",
                ProductName = "商品1",
                ProductAmount = 100,
                ProductPrice = 60,
                CategoryId = cateID
            });

            builder.Entity<Recycle>().HasKey(p => new { p.TenantCode, p.ID });
            builder.Entity<Recycle>().HasIndex(p => p.TenantCode);
        }
    }
}
