using System;
using System.Collections.Generic;
using BPI_TransBill.Models.Data;
using BPI_TransBill.Models.Data.Store;
using Microsoft.EntityFrameworkCore;

namespace BPI_TransBill.Models;

public partial class BpigContext : DbContext
{
    public BpigContext()
    {
    }

    public BpigContext(DbContextOptions<BpigContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserRight> UserRights { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:BpigConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRight>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UserRight");

            entity.HasIndex(e => e.UserId, "IX_UserRight");

            entity.HasIndex(e => e.UserName, "IX_UserRight_1").IsUnique();

            entity.Property(e => e.Line)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Remark)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UserId)
                .ValueGeneratedOnAdd()
                .HasColumnName("UserID");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UserPassword)
                .HasMaxLength(64)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
