using System;
using System.Collections.Generic;
using BPI_TransBill.Models.AddInv;
using BPI_TransBill.Models.Data;
using BPI_TransBill.Models.Data.Store;
using Microsoft.EntityFrameworkCore;

namespace BPI_TransBill.Models;

public partial class BpiTrpaymentContext : DbContext
{
    public BpiTrpaymentContext()
    {
    }

    public BpiTrpaymentContext(DbContextOptions<BpiTrpaymentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BillingNoteH> BillingNoteHs { get; set; }
    public virtual DbSet<BillingNoteD> BillingNoteDs { get; set; }
    public virtual DbSet<InvoiceModel> Invoices { get; set; }
    public virtual DbSet<BillingNoteViewModel> BillingNoteViewModels { get; set; }
    public virtual DbSet<BillingNoteDViewModel> BillingNoteDViewModels { get; set; }
    public virtual DbSet<ApinvHead> ApinvHeads { get; set; }
    public virtual DbSet<ApinvDetail> ApinvDetails { get; set; }
    public virtual DbSet<ApinvHeadVendor> ApinvHeadVendors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:BpiTRConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BillingNoteH>(entity =>
        {
            entity.ToTable("BillingNoteH");

            entity.HasKey(e => e.BillId); // กำหนด Primary Key

            entity.Property(e => e.BillId)
                .HasColumnName("BillID");

            entity.Property(e => e.BillNo)
                .HasMaxLength(12)
                .IsUnicode(false);

            entity.Property(e => e.Company)
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.Property(e => e.BillDate)
            .HasColumnType("datetime");

            entity.Property(e => e.FromDate)
            .HasColumnType("datetime");

            entity.Property(e => e.ToDate)
            .HasColumnType("datetime");

            entity.Property(e => e.CreateDate)
            .HasColumnType("datetime");

            entity.Property(e => e.UpdateDate)
            .HasColumnType("datetime");

            entity.Property(e => e.CreateBy)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.UpdateBy)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.DriverName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.EmpId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EmpID");

            entity.Property(e => e.PaidCode)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.PaidName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.StaffGen)
                .HasMaxLength(1)
                .IsUnicode(false);

            entity.Property(e => e.StaffId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("StaffID");

            entity.Property(e => e.VendorCode)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BillingNoteD>(entity =>
        {
            entity.HasKey(e => e.DetailId);  // กำหนดให้ DetailId เป็น Primary Key

            entity.ToTable("BillingNoteD");

            entity.Property(e => e.DetailId).HasColumnName("DetailID");

            entity.Property(e => e.BillId).HasColumnName("BillID");

            entity.Property(e => e.CarNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreateBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CustNum)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DeliveryRoudNo)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.DetailId)
                .ValueGeneratedOnAdd()
                .HasColumnName("DetailID");
            entity.Property(e => e.ExtCompany)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Partnum)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProjectId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ProjectID");
            entity.Property(e => e.ShipDate).HasColumnType("datetime");
            entity.Property(e => e.ShipNum)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ShipSet)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ShipToNum)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ShipViaCode)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.StaffGen)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.StaffId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("StaffID");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<InvoiceModel>().HasNoKey().ToView("BPI_TransBill_GetUD27");

        modelBuilder.Entity<InvoiceModel>().HasNoKey().ToView("BPI_TransBill_GetData");

        modelBuilder.Entity<BillingNoteDViewModel>().HasNoKey().ToView("BPI_TransBill_GetBillingNoteD");

        modelBuilder.Entity<ApinvHead>(entity =>
        {
            entity.ToTable("APInvHead");

            entity.HasKey(e => e.ApinvId);
            entity.Property(e => e.ApinvId)
                .ValueGeneratedOnAdd()
                .HasColumnName("APInvID");

            entity.Property(e => e.ApinvAmt).HasColumnName("APInvAmt");
            entity.Property(e => e.ApinvDate)
                .HasColumnType("datetime")
                .HasColumnName("APInvDate");
            entity.Property(e => e.ApinvId)
                .ValueGeneratedOnAdd()
                .HasColumnName("APInvID");
            entity.Property(e => e.ApinvNo)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("APInvNo");
            entity.Property(e => e.ApinvStatus).HasColumnName("APInvStatus");
            entity.Property(e => e.BillId).HasColumnName("BillID");
            entity.Property(e => e.Company)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.CreateBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.PayDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Whtamt).HasColumnName("WHTAmt");
        });

        modelBuilder.Entity<ApinvDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("APInvDetail");

            entity.Property(e => e.ApinvDetailId)
                .ValueGeneratedOnAdd()
                .HasColumnName("APInvDetailID");
            entity.Property(e => e.ApinvId).HasColumnName("APInvID");
            entity.Property(e => e.Company)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.CreateBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.DetailId).HasColumnName("DetailID");
            entity.Property(e => e.Remark)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ShipViaCode)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.TransAmt)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ApinvHeadVendor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("APInvHeadVendor");

            entity.Property(e => e.ApinvAmt).HasColumnName("APInvAmt");
            entity.Property(e => e.ApinvDate)
                .HasColumnType("datetime")
                .HasColumnName("APInvDate");
            entity.Property(e => e.ApinvId)
                .ValueGeneratedOnAdd()
                .HasColumnName("APInvID");
            entity.Property(e => e.ApinvNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("APInvNo");
            entity.Property(e => e.ApinvStatus).HasColumnName("APInvStatus");
            entity.Property(e => e.BillId).HasColumnName("BillID");
            entity.Property(e => e.Company)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.CreateBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CustIddamage)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CustIDDamage");
            entity.Property(e => e.CustIddamageBal).HasColumnName("CustIDDamageBal");
            entity.Property(e => e.CustIdfuel)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CustIDFuel");
            entity.Property(e => e.CustIdfuelBal).HasColumnName("CustIDFuelBal");
            entity.Property(e => e.PayDay).HasColumnType("datetime");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Whtamt).HasColumnName("WHTAmt");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
