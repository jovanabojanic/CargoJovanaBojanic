using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Core.Models;
using Core.DTOs;

namespace Models.DbContexts
{
    public class ProductCategoryDbContext : DbContext
    {
        public ProductCategoryDbContext()

        {
        }

        public ProductCategoryDbContext(DbContextOptions<ProductCategoryDbContext> options) : base(options)

        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-M8U2QP5;Database=ProductDB;Integrated Security=True;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>(entity =>
            {
                entity.ToTable("_FC_Products");
            });

            builder.Entity<Category>(entity =>
            {
                entity.ToTable("_FC_Categories");
            });

            builder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("_FC_ProductCategories");
            });

            builder.Entity<ProductCategory>()
          .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            builder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.ProductId);

            builder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(pc => pc.CategoryId);
        }
    }
}


