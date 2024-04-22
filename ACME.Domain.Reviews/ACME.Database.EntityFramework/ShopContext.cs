﻿using ACME.Database.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;


// Scaffold - DbContext "Server=.\SqlExpress;Database=ProductCatalog;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Models - Context ShopContext
namespace ACME.Database.EntityFramework;

public partial class ShopContext : DbContext
{
    public ShopContext()
    {
    }

    public ShopContext(DbContextOptions<ShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<PriceHistory> PriceHistories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductGroup> ProductGroups { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Reviewer> Reviewers { get; set; }

    public virtual DbSet<Specification> Specifications { get; set; }

    public virtual DbSet<SpecificationDefinition> SpecificationDefinitions { get; set; }

     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.ToTable("Brands", "Core");

            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Website).HasMaxLength(1024);
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity.ToTable("Prices", "Core");

            entity.HasIndex(e => e.ProductId, "IX_Prices_ProductId");

            entity.Property(e => e.ShopName).HasMaxLength(255);
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Product).WithMany(p => p.Prices).HasForeignKey(d => d.ProductId);
        });

        modelBuilder.Entity<PriceHistory>(entity =>
        {
            entity.ToTable("PriceHistory", "Core");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ShopName).HasMaxLength(255);
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Products", "Core");

            entity.HasIndex(e => e.BrandId, "IX_Products_BrandId");

            entity.HasIndex(e => e.ProductGroupId, "IX_Products_ProductGroupId");

            entity.Property(e => e.Image).HasMaxLength(1024);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Brand).WithMany(p => p.Products).HasForeignKey(d => d.BrandId);

            entity.HasOne(d => d.ProductGroup).WithMany(p => p.Products).HasForeignKey(d => d.ProductGroupId);
        });

        modelBuilder.Entity<ProductGroup>(entity =>
        {
            entity.ToTable("ProductGroups", "Core");

            entity.Property(e => e.Image).HasMaxLength(1024);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.ToTable("Reviews", "Core");

            entity.HasIndex(e => e.ProductId, "IX_Reviews_ProductId");

            entity.HasIndex(e => e.ReviewerId, "IX_Reviews_ReviewerId");

            entity.Property(e => e.Organization).HasMaxLength(512);
            entity.Property(e => e.ReviewUrl).HasMaxLength(1024);
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews).HasForeignKey(d => d.ProductId);

            entity.HasOne(d => d.Reviewer).WithMany(p => p.Reviews).HasForeignKey(d => d.ReviewerId);
        });

        modelBuilder.Entity<Reviewer>(entity =>
        {
            entity.ToTable("Reviewers", "Core");

            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.UserName).HasMaxLength(255);
        });

        modelBuilder.Entity<Specification>(entity =>
        {
            entity.ToTable("Specifications", "Core");

            entity.HasIndex(e => e.ProductId, "IX_Specifications_ProductId");

            entity.Property(e => e.Key).HasMaxLength(255);
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Product).WithMany(p => p.Specifications).HasForeignKey(d => d.ProductId);
        });

        modelBuilder.Entity<SpecificationDefinition>(entity =>
        {
            entity.ToTable("SpecificationDefinitions", "Core");

            entity.HasIndex(e => e.ProductGroupId, "IX_SpecificationDefinitions_ProductGroupId");

            entity.Property(e => e.Key).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Unit).HasMaxLength(127);

            entity.HasOne(d => d.ProductGroup).WithMany(p => p.SpecificationDefinitions).HasForeignKey(d => d.ProductGroupId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
