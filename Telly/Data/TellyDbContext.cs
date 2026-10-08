using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Telly.Models;

namespace Telly.Data;

public partial class TellyDbContext : DbContext
{
    public TellyDbContext()
    {
    }

    public TellyDbContext(DbContextOptions<TellyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Dimension> Dimensions { get; set; }

    public virtual DbSet<Tv> Tvs { get; set; }

    public virtual DbSet<Tvaccessory> Tvaccessories { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PK__Brands__DAD4F3BE6E0144BD");

            entity.Property(e => e.BrandId).HasColumnName("BrandID");
            entity.Property(e => e.BrandLogo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BrandName)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Dimension>(entity =>
        {
            entity.HasKey(e => e.DimensionId).HasName("PK__dimensio__B812A50BE0105D28");

            entity.ToTable("dimensions");

            entity.Property(e => e.DimensionId).HasColumnName("dimensionID");
            entity.Property(e => e.Size).HasColumnName("size");
        });

        modelBuilder.Entity<Tv>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TV__3214EC278E980D66");

            entity.ToTable("TV");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BrandId).HasColumnName("BrandID");
            entity.Property(e => e.DimensionId).HasColumnName("dimensionID");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Stars)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TvUrl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TvURL");
            entity.Property(e => e.TvimageQuality)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TVImageQuality");
            entity.Property(e => e.Tvname)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TVName");
            entity.Property(e => e.Tvtype)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TVType");

            entity.HasOne(d => d.Brand).WithMany(p => p.Tvs)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK__TV__BrandID__5070F446");

            entity.HasOne(d => d.Dimension).WithMany(p => p.Tvs)
                .HasForeignKey(d => d.DimensionId)
                .HasConstraintName("FK__TV__dimensionID__5165187F");
        });

        modelBuilder.Entity<Tvaccessory>(entity =>
        {
            entity.HasKey(e => e.AccessoryId);

            entity.ToTable("TVAccessories");

            entity.Property(e => e.AccessoryId).HasColumnName("accessoryID");
            entity.Property(e => e.AccessoryImage)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("accessoryImage");
            entity.Property(e => e.AccessoryLength).HasColumnName("accessoryLength");
            entity.Property(e => e.AccessoryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("accessoryName");
            entity.Property(e => e.BatteryType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("batteryType");
            entity.Property(e => e.BrandId).HasColumnName("BrandID");

            entity.HasOne(d => d.Brand).WithMany(p => p.Tvaccessories)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK_Brands");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
