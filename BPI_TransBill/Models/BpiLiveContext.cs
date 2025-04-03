using System;
using System.Collections.Generic;
using BPI_TransBill.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace BPI_TransBill.Models;

public partial class BpiLiveContext : DbContext
{
    public BpiLiveContext()
    {
    }

    public BpiLiveContext(DbContextOptions<BpiLiveContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ud100> Ud100s { get; set; }
    public virtual DbSet<Ud27> Ud27s { get; set; }
    public virtual DbSet<EmpBasic> EmpBasics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:BpiLiveConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ud100>(entity =>
        {
            entity.HasKey(e => new { e.Company, e.Key1, e.Key2, e.Key3, e.Key4, e.Key5 });

            entity.ToTable("UD100", "Ice", tb => tb.HasTrigger("TR_UD100_ChangeCapture"));

            entity.HasIndex(e => e.SysRowId, "IX_UD100_SysIndex").IsUnique();

            entity.Property(e => e.Company)
                .HasMaxLength(8)
                .HasDefaultValue("");
            entity.Property(e => e.Key1)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.Key2)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.Key3)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.Key4)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.Key5)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.Character01).HasDefaultValue("");
            entity.Property(e => e.Character02).HasDefaultValue("");
            entity.Property(e => e.Character03).HasDefaultValue("");
            entity.Property(e => e.Character04).HasDefaultValue("");
            entity.Property(e => e.Character05).HasDefaultValue("");
            entity.Property(e => e.Character06).HasDefaultValue("");
            entity.Property(e => e.Character07).HasDefaultValue("");
            entity.Property(e => e.Character08).HasDefaultValue("");
            entity.Property(e => e.Character09).HasDefaultValue("");
            entity.Property(e => e.Character10).HasDefaultValue("");
            entity.Property(e => e.GlobalUd100).HasColumnName("GlobalUD100");
            entity.Property(e => e.Number01).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number02).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number03).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number04).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number05).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number06).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number07).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number08).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number09).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number10).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number11).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number12).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number13).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number14).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number15).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number16).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number17).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number18).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number19).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number20).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.ShortChar01)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ShortChar02)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ShortChar03)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ShortChar04)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ShortChar05)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ShortChar06)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ShortChar07)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ShortChar08)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ShortChar09)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ShortChar10)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.SysRevId)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SysRevID");
            entity.Property(e => e.SysRowId)
                .HasDefaultValueSql("(CONVERT([uniqueidentifier],CONVERT([binary](10),newid())+CONVERT([binary](6),getutcdate())))")
                .HasColumnName("SysRowID");
        });

        modelBuilder.Entity<Ud27>(entity =>
        {
            entity.HasKey(e => new { e.Company, e.Key1, e.Key2, e.Key3, e.Key4, e.Key5 });

            entity.ToTable("UD27", "Ice", tb =>
            {
                tb.HasTrigger("BPI_UD27_WriteLog");
                tb.HasTrigger("TR_UD27_ChangeCapture");
            });

            entity.HasIndex(e => e.SysRowId, "IX_UD27_SysIndex").IsUnique();

            entity.Property(e => e.Company)
                .HasMaxLength(8)
                .HasDefaultValue("");
            entity.Property(e => e.Key1)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.Key2)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.Key3)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.Key4)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.Key5)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.Character01).HasDefaultValue("");
            entity.Property(e => e.Character02).HasDefaultValue("");
            entity.Property(e => e.Character03).HasDefaultValue("");
            entity.Property(e => e.Character04).HasDefaultValue("");
            entity.Property(e => e.Character05).HasDefaultValue("");
            entity.Property(e => e.Character06).HasDefaultValue("");
            entity.Property(e => e.Character07).HasDefaultValue("");
            entity.Property(e => e.Character08).HasDefaultValue("");
            entity.Property(e => e.Character09).HasDefaultValue("");
            entity.Property(e => e.Character10).HasDefaultValue("");
            entity.Property(e => e.GlobalUd27).HasColumnName("GlobalUD27");
            entity.Property(e => e.Number01).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number02).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number03).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number04).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number05).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number06).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number07).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number08).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number09).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number10).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number11).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number12).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number13).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number14).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number15).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number16).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number17).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number18).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number19).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number20).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.ShortChar01)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ShortChar02)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ShortChar03)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ShortChar04)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ShortChar05)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ShortChar06)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ShortChar07)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ShortChar08)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ShortChar09)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ShortChar10)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ShortChar11)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ShortChar12)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ShortChar13)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ShortChar14)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ShortChar15)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ShortChar16)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ShortChar17)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ShortChar18)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ShortChar19)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ShortChar20)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.SysRevId)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SysRevID");
            entity.Property(e => e.SysRowId)
                .HasDefaultValueSql("(CONVERT([uniqueidentifier],CONVERT([binary](10),newid())+CONVERT([binary](6),getutcdate())))")
                .HasColumnName("SysRowID");
        });

        modelBuilder.Entity<EmpBasic>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("EmpBasic");

            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Address2).HasMaxLength(35);
            entity.Property(e => e.BpiUserFileNameC)
                .HasMaxLength(100)
                .HasColumnName("BPI_UserFileName_c");
            entity.Property(e => e.BpiUserIdC)
                .HasMaxLength(75)
                .HasColumnName("BPI_UserId_c");
            entity.Property(e => e.CanReportNcqty).HasColumnName("CanReportNCQty");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.CnvEmpId)
                .HasMaxLength(8)
                .HasColumnName("CnvEmpID");
            entity.Property(e => e.Company).HasMaxLength(8);
            entity.Property(e => e.Country).HasMaxLength(35);
            entity.Property(e => e.DcdUserId)
                .HasMaxLength(75)
                .HasColumnName("DcdUserID");
            entity.Property(e => e.DefaultClaimCurrencyCode).HasMaxLength(4);
            entity.Property(e => e.DefaultExpCurrencyCode).HasMaxLength(4);
            entity.Property(e => e.DefaultExpenseCode).HasMaxLength(16);
            entity.Property(e => e.DefaultIndirectCode).HasMaxLength(4);
            entity.Property(e => e.DefaultLaborHrs).HasColumnType("decimal(11, 5)");
            entity.Property(e => e.DefaultLaborTypePseudo).HasMaxLength(2);
            entity.Property(e => e.DefaultPmuid).HasColumnName("DefaultPMUID");
            entity.Property(e => e.DefaultResourceGrpId)
                .HasMaxLength(8)
                .HasColumnName("DefaultResourceGrpID");
            entity.Property(e => e.DefaultResourceId)
                .HasMaxLength(12)
                .HasColumnName("DefaultResourceID");
            entity.Property(e => e.DefaultTaxRegionCode).HasMaxLength(4);
            entity.Property(e => e.DefaultTimeTypCd).HasMaxLength(10);
            entity.Property(e => e.Department).HasMaxLength(50);
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .HasColumnName("EMailAddress");
            entity.Property(e => e.EmgContact).HasMaxLength(30);
            entity.Property(e => e.EmgPhone).HasMaxLength(20);
            entity.Property(e => e.EmpId)
                .HasMaxLength(8)
                .HasColumnName("EmpID");
            entity.Property(e => e.EmpStatus).HasMaxLength(2);
            entity.Property(e => e.ExpenseAdvReqWfgroupId)
                .HasMaxLength(8)
                .HasColumnName("ExpenseAdvReqWFGroupID");
            entity.Property(e => e.ExpenseCode).HasMaxLength(16);
            entity.Property(e => e.ExpenseWfgroupId)
                .HasMaxLength(8)
                .HasColumnName("ExpenseWFGroupID");
            entity.Property(e => e.ExternalMes).HasColumnName("ExternalMES");
            entity.Property(e => e.ExternalMeslastSync)
                .HasColumnType("datetime")
                .HasColumnName("ExternalMESLastSync");
            entity.Property(e => e.ExternalMessyncRequired).HasColumnName("ExternalMESSyncRequired");
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.ForeignSysRowId).HasColumnName("ForeignSysRowID");
            entity.Property(e => e.Iddocument)
                .HasMaxLength(50)
                .HasColumnName("IDDocument");
            entity.Property(e => e.ImageId)
                .HasMaxLength(256)
                .HasColumnName("ImageID");
            entity.Property(e => e.Jcdept)
                .HasMaxLength(8)
                .HasColumnName("JCDept");
            entity.Property(e => e.LaborRate).HasColumnType("decimal(14, 4)");
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.MiddleInitial).HasMaxLength(30);
            entity.Property(e => e.MobileResourceId)
                .HasMaxLength(12)
                .HasColumnName("MobileResourceID");
            entity.Property(e => e.MobileUserPassword).HasMaxLength(30);
            entity.Property(e => e.Name).HasMaxLength(35);
            entity.Property(e => e.PayrollValuesForHcm)
                .HasMaxLength(3)
                .HasColumnName("PayrollValuesForHCM");
            entity.Property(e => e.PerConId).HasColumnName("PerConID");
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.PhotoFile).HasMaxLength(8);
            entity.Property(e => e.PrsetupReq).HasColumnName("PRSetupReq");
            entity.Property(e => e.ResourceGrpId)
                .HasMaxLength(8)
                .HasColumnName("ResourceGrpID");
            entity.Property(e => e.ResourceId)
                .HasMaxLength(12)
                .HasColumnName("ResourceID");
            entity.Property(e => e.SendToFsa).HasColumnName("SendToFSA");
            entity.Property(e => e.Sex).HasMaxLength(1);
            entity.Property(e => e.ShortChar09).HasMaxLength(50);
            entity.Property(e => e.ShortChar10).HasMaxLength(50);
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.SupervisorId)
                .HasMaxLength(8)
                .HasColumnName("SupervisorID");
            entity.Property(e => e.SysRevId)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SysRevID");
            entity.Property(e => e.SysRowId).HasColumnName("SysRowID");
            entity.Property(e => e.TimeWfgroupId)
                .HasMaxLength(8)
                .HasColumnName("TimeWFGroupID");
            entity.Property(e => e.UdSysRevId)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("UD_SysRevID");
            entity.Property(e => e.UserNameInJdf)
                .HasMaxLength(50)
                .HasColumnName("UserNameInJDF");
            entity.Property(e => e.Zip)
                .HasMaxLength(10)
                .HasColumnName("ZIP");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
