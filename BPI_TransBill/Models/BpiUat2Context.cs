using System;
using System.Collections.Generic;
using BPI_TransBill.Models.Data.UAT2;
using Microsoft.EntityFrameworkCore;

namespace BPI_TransBill.Models.Data;

public partial class BpiUat2Context : DbContext
{
    public BpiUat2Context()
    {
    }

    public BpiUat2Context(DbContextOptions<BpiUat2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Ud27> Ud27s { get; set; }
    public virtual DbSet<Vendor> Vendors { get; set; }
    public virtual DbSet<Vendor1> Vendors1 { get; set; }
    public virtual DbSet<Vendor2> Vendors2 { get; set; }
    public virtual DbSet<Part> Parts { get; set; }
    public virtual DbSet<EmpBasic> EmpBasics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:UAT2Connection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => new { e.Company, e.VendorNum });

            entity.ToTable("Vendor", "Csfth");

            entity.Property(e => e.Company)
                .HasMaxLength(8)
                .HasDefaultValue("");
            entity.Property(e => e.OrgType)
                .HasMaxLength(6)
                .HasDefaultValue("");
            entity.Property(e => e.SysRevId)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SysRevID");
            entity.Property(e => e.SysRowId)
                .HasDefaultValueSql("(CONVERT([uniqueidentifier],CONVERT([binary](10),newid(),(0))+CONVERT([binary](6),getutcdate(),(0)),(0)))")
                .HasColumnName("SysRowID");

            entity.HasOne(d => d.Vendor2).WithOne(p => p.Vendor)
                .HasForeignKey<Vendor>(d => new { d.Company, d.VendorNum })
                .HasConstraintName("FK_Csfth_Vendor_Erp_Vendor");
        });

        modelBuilder.Entity<Vendor1>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Vendor");

            entity.Property(e => e.AccountNum).HasMaxLength(20);
            entity.Property(e => e.AccountRef).HasMaxLength(20);
            entity.Property(e => e.Address1).HasMaxLength(50);
            entity.Property(e => e.Address2).HasMaxLength(50);
            entity.Property(e => e.Address3).HasMaxLength(50);
            entity.Property(e => e.AdtSupNameC)
                .HasMaxLength(150)
                .HasColumnName("ADT_SupName_c");
            entity.Property(e => e.AgafipresponsibilityCode)
                .HasMaxLength(4)
                .HasColumnName("AGAFIPResponsibilityCode");
            entity.Property(e => e.Agapartment)
                .HasMaxLength(3)
                .HasColumnName("AGApartment");
            entity.Property(e => e.AgextraStreetNumber)
                .HasMaxLength(1)
                .HasColumnName("AGExtraStreetNumber");
            entity.Property(e => e.Agfloor)
                .HasMaxLength(3)
                .HasColumnName("AGFloor");
            entity.Property(e => e.AggrossIncomeTaxId)
                .HasMaxLength(20)
                .HasColumnName("AGGrossIncomeTaxID");
            entity.Property(e => e.AgiddocumentTypeCode)
                .HasMaxLength(4)
                .HasColumnName("AGIDDocumentTypeCode");
            entity.Property(e => e.AglocationCode)
                .HasMaxLength(5)
                .HasColumnName("AGLocationCode");
            entity.Property(e => e.Agneighborhood)
                .HasMaxLength(40)
                .HasColumnName("AGNeighborhood");
            entity.Property(e => e.AgprovinceCode)
                .HasMaxLength(4)
                .HasColumnName("AGProvinceCode");
            entity.Property(e => e.Agstreet)
                .HasMaxLength(40)
                .HasColumnName("AGStreet");
            entity.Property(e => e.AgstreetNumber)
                .HasMaxLength(8)
                .HasColumnName("AGStreetNumber");
            entity.Property(e => e.AguseGoodDefaultMark).HasColumnName("AGUseGoodDefaultMark");
            entity.Property(e => e.BorderCrossing).HasMaxLength(4);
            entity.Property(e => e.CalendarId)
                .HasMaxLength(8)
                .HasColumnName("CalendarID");
            entity.Property(e => e.CertadateC).HasColumnName("CERTADATE_c");
            entity.Property(e => e.CertapprovedC).HasColumnName("CERTApproved_c");
            entity.Property(e => e.CertedateC).HasColumnName("CERTEDATE_c");
            entity.Property(e => e.ChrgAmount).HasColumnType("decimal(17, 3)");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Cod).HasColumnName("COD");
            entity.Property(e => e.Codamount)
                .HasColumnType("decimal(17, 3)")
                .HasColumnName("CODAmount");
            entity.Property(e => e.Codcheck).HasColumnName("CODCheck");
            entity.Property(e => e.Code1099Id)
                .HasMaxLength(15)
                .HasColumnName("Code1099ID");
            entity.Property(e => e.Codfreight).HasColumnName("CODFreight");
            entity.Property(e => e.CoisOneTimeVend).HasColumnName("COIsOneTimeVend");
            entity.Property(e => e.Company).HasMaxLength(8);
            entity.Property(e => e.CooneTimeId)
                .HasMaxLength(20)
                .HasColumnName("COOneTimeID");
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.Cpay).HasColumnName("CPay");
            entity.Property(e => e.CurrencyCode).HasMaxLength(4);
            entity.Property(e => e.Date01).HasColumnType("datetime");
            entity.Property(e => e.Date02).HasColumnType("datetime");
            entity.Property(e => e.Date03).HasColumnType("datetime");
            entity.Property(e => e.Date04).HasColumnType("datetime");
            entity.Property(e => e.Date05).HasColumnType("datetime");
            entity.Property(e => e.DeclaredAmt).HasColumnType("decimal(17, 3)");
            entity.Property(e => e.DefaultFob)
                .HasMaxLength(15)
                .HasColumnName("DefaultFOB");
            entity.Property(e => e.DeliveryType).HasMaxLength(8);
            entity.Property(e => e.DeorgType)
                .HasMaxLength(1)
                .HasColumnName("DEOrgType");
            entity.Property(e => e.Edicode)
                .HasMaxLength(15)
                .HasColumnName("EDICode");
            entity.Property(e => e.Einvoice).HasColumnName("EInvoice");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .HasColumnName("EMailAddress");
            entity.Property(e => e.ExternalId).HasMaxLength(40);
            entity.Property(e => e.ExternalSchemeId)
                .HasMaxLength(10)
                .HasColumnName("ExternalSchemeID");
            entity.Property(e => e.Fatca).HasColumnName("FATCA");
            entity.Property(e => e.FaxNum).HasMaxLength(20);
            entity.Property(e => e.Ffaddress1)
                .HasMaxLength(50)
                .HasColumnName("FFAddress1");
            entity.Property(e => e.Ffaddress2)
                .HasMaxLength(50)
                .HasColumnName("FFAddress2");
            entity.Property(e => e.Ffaddress3)
                .HasMaxLength(50)
                .HasColumnName("FFAddress3");
            entity.Property(e => e.Ffcity)
                .HasMaxLength(50)
                .HasColumnName("FFCity");
            entity.Property(e => e.FfcompName)
                .HasMaxLength(50)
                .HasColumnName("FFCompName");
            entity.Property(e => e.Ffcontact)
                .HasMaxLength(50)
                .HasColumnName("FFContact");
            entity.Property(e => e.Ffcountry)
                .HasMaxLength(50)
                .HasColumnName("FFCountry");
            entity.Property(e => e.FfcountryNum).HasColumnName("FFCountryNum");
            entity.Property(e => e.Ffid)
                .HasMaxLength(8)
                .HasColumnName("FFID");
            entity.Property(e => e.FfphoneNum)
                .HasMaxLength(20)
                .HasColumnName("FFPhoneNum");
            entity.Property(e => e.Ffstate)
                .HasMaxLength(50)
                .HasColumnName("FFState");
            entity.Property(e => e.Ffzip)
                .HasMaxLength(10)
                .HasColumnName("FFZip");
            entity.Property(e => e.ForeignSysRowId).HasColumnName("ForeignSysRowID");
            entity.Property(e => e.FormTypeId)
                .HasMaxLength(12)
                .HasColumnName("FormTypeID");
            entity.Property(e => e.FormatStr).HasMaxLength(50);
            entity.Property(e => e.GroundType).HasMaxLength(8);
            entity.Property(e => e.GroupCode).HasMaxLength(4);
            entity.Property(e => e.HmrctaxValidationLog).HasColumnName("HMRCTaxValidationLog");
            entity.Property(e => e.Ictrader).HasColumnName("ICTrader");
            entity.Property(e => e.Icvend).HasColumnName("ICVend");
            entity.Property(e => e.Incstnumber)
                .HasMaxLength(25)
                .HasColumnName("INCSTNumber");
            entity.Property(e => e.IndividualPackIds).HasColumnName("IndividualPackIDs");
            entity.Property(e => e.IngstcomplianceRate).HasColumnName("INGSTComplianceRate");
            entity.Property(e => e.Inpannumber)
                .HasMaxLength(12)
                .HasColumnName("INPANNumber");
            entity.Property(e => e.InsupplierType)
                .HasMaxLength(30)
                .HasColumnName("INSupplierType");
            entity.Property(e => e.IntaxRegistrationId)
                .HasMaxLength(15)
                .HasColumnName("INTaxRegistrationID");
            entity.Property(e => e.LangNameId)
                .HasMaxLength(8)
                .HasColumnName("LangNameID");
            entity.Property(e => e.LegalName).HasMaxLength(200);
            entity.Property(e => e.ManagedCustId)
                .HasMaxLength(10)
                .HasColumnName("ManagedCustID");
            entity.Property(e => e.MaxLateDaysPorel).HasColumnName("MaxLateDaysPORel");
            entity.Property(e => e.MinOrderValue).HasColumnType("decimal(17, 3)");
            entity.Property(e => e.MxdiottranType)
                .HasMaxLength(10)
                .HasColumnName("MXDIOTTranType");
            entity.Property(e => e.MxlegalRepCurp)
                .HasMaxLength(18)
                .HasColumnName("MXLegalRepCURP");
            entity.Property(e => e.MxlegalRepName)
                .HasMaxLength(300)
                .HasColumnName("MXLegalRepName");
            entity.Property(e => e.MxlegalRepRfc)
                .HasMaxLength(13)
                .HasColumnName("MXLegalRepRFC");
            entity.Property(e => e.MxlegalRepTaxpayerType)
                .HasMaxLength(2)
                .HasColumnName("MXLegalRepTaxpayerType");
            entity.Property(e => e.Mxmunicipio)
                .HasMaxLength(50)
                .HasColumnName("MXMunicipio");
            entity.Property(e => e.MxretentionCode)
                .HasMaxLength(10)
                .HasColumnName("MXRetentionCode");
            entity.Property(e => e.Mxtarcode)
                .HasMaxLength(10)
                .HasColumnName("MXTARCode");
            entity.Property(e => e.MxtaxpayerType)
                .HasMaxLength(2)
                .HasColumnName("MXTaxpayerType");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.NameC)
                .HasMaxLength(500)
                .HasColumnName("Name_c");
            entity.Property(e => e.NameControl).HasMaxLength(4);
            entity.Property(e => e.NonUs).HasColumnName("NonUS");
            entity.Property(e => e.NotifyEmail)
                .HasMaxLength(500)
                .HasColumnName("NotifyEMail");
            entity.Property(e => e.Number01).HasColumnType("decimal(20, 9)");
            entity.Property(e => e.Number02).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Number03).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Number04).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Number05).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.OnTimeRating).HasMaxLength(4);
            entity.Property(e => e.OrgRegCode).HasMaxLength(12);
            entity.Property(e => e.ParamCode).HasMaxLength(20);
            entity.Property(e => e.PeaddressId)
                .HasMaxLength(10)
                .HasColumnName("PEAddressID");
            entity.Property(e => e.PecollectionAgent).HasColumnName("PECollectionAgent");
            entity.Property(e => e.PedocumentId)
                .HasMaxLength(60)
                .HasColumnName("PEDocumentID");
            entity.Property(e => e.PegoodsContributor).HasColumnName("PEGoodsContributor");
            entity.Property(e => e.PeidentityDocType)
                .HasMaxLength(1)
                .HasColumnName("PEIdentityDocType");
            entity.Property(e => e.PenoAddress).HasColumnName("PENoAddress");
            entity.Property(e => e.PenotFound).HasColumnName("PENotFound");
            entity.Property(e => e.PeretentionRegime)
                .HasMaxLength(8)
                .HasColumnName("PERetentionRegime");
            entity.Property(e => e.PewithholdAgent).HasColumnName("PEWithholdAgent");
            entity.Property(e => e.PhoneNum).HasMaxLength(20);
            entity.Property(e => e.PlautomaticApinvoiceNum).HasColumnName("PLAutomaticAPInvoiceNum");
            entity.Property(e => e.PmtAcctRef).HasMaxLength(25);
            entity.Property(e => e.Pmuid).HasColumnName("PMUID");
            entity.Property(e => e.PriceRating).HasMaxLength(4);
            entity.Property(e => e.PrimPcon).HasColumnName("PrimPCon");
            entity.Property(e => e.PrimaryBankId)
                .HasMaxLength(9)
                .HasColumnName("PrimaryBankID");
            entity.Property(e => e.PurPoint).HasMaxLength(4);
            entity.Property(e => e.QualityRating).HasMaxLength(4);
            entity.Property(e => e.RefNotes).HasMaxLength(500);
            entity.Property(e => e.Reporting1099Name).HasMaxLength(50);
            entity.Property(e => e.Reporting1099Name2).HasMaxLength(50);
            entity.Property(e => e.RevChargeMethod).HasMaxLength(8);
            entity.Property(e => e.Sec)
                .HasMaxLength(8)
                .HasColumnName("SEC");
            entity.Property(e => e.SecondTinnotice).HasColumnName("SecondTINNotice");
            entity.Property(e => e.ServAuthNum).HasMaxLength(50);
            entity.Property(e => e.ServInstruct).HasMaxLength(100);
            entity.Property(e => e.ServPhone).HasMaxLength(20);
            entity.Property(e => e.ServRef1).HasMaxLength(50);
            entity.Property(e => e.ServRef2).HasMaxLength(50);
            entity.Property(e => e.ServRef3).HasMaxLength(50);
            entity.Property(e => e.ServRef4).HasMaxLength(50);
            entity.Property(e => e.ServRef5).HasMaxLength(50);
            entity.Property(e => e.ServiceRating).HasMaxLength(4);
            entity.Property(e => e.ShipViaCode).HasMaxLength(4);
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.SysRevId)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SysRevID");
            entity.Property(e => e.SysRowId).HasColumnName("SysRowID");
            entity.Property(e => e.TaxAuthorityCode).HasMaxLength(8);
            entity.Property(e => e.TaxEntityType).HasMaxLength(3);
            entity.Property(e => e.TaxPayerId)
                .HasMaxLength(20)
                .HasColumnName("TaxPayerID");
            entity.Property(e => e.TaxRegReason).HasMaxLength(12);
            entity.Property(e => e.TaxRegionCode).HasMaxLength(4);
            entity.Property(e => e.TaxValidationDate).HasColumnType("datetime");
            entity.Property(e => e.TermsCode).HasMaxLength(4);
            entity.Property(e => e.ThbranchId)
                .HasMaxLength(8)
                .HasColumnName("THBranchID");
            entity.Property(e => e.Tin)
                .HasMaxLength(50)
                .HasColumnName("TIN");
            entity.Property(e => e.Tintype)
                .HasMaxLength(2)
                .HasColumnName("TINType");
            entity.Property(e => e.TinvalidationStatus).HasColumnName("TINValidationStatus");
            entity.Property(e => e.TwguiregNum)
                .HasMaxLength(8)
                .HasColumnName("TWGUIRegNum");
            entity.Property(e => e.UdSysRevId)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("UD_SysRevID");
            entity.Property(e => e.Uddecimal1C)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("UDDecimal1_c");
            entity.Property(e => e.Uddecimal2C)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("UDDecimal2_c");
            entity.Property(e => e.Udstring1C)
                .HasMaxLength(100)
                .HasColumnName("UDString1_c");
            entity.Property(e => e.Udstring2C)
                .HasMaxLength(100)
                .HasColumnName("UDString2_c");
            entity.Property(e => e.UpsquantumView).HasColumnName("UPSQuantumView");
            entity.Property(e => e.Upsqvmemo).HasColumnName("UPSQVMemo");
            entity.Property(e => e.UpsqvshipFromName)
                .HasMaxLength(50)
                .HasColumnName("UPSQVShipFromName");
            entity.Property(e => e.Us1099kmerchCatCode)
                .HasMaxLength(4)
                .HasColumnName("US1099KMerchCatCode");
            entity.Property(e => e.Us1099state)
                .HasMaxLength(50)
                .HasColumnName("US1099State");
            entity.Property(e => e.VendPilimit).HasColumnName("VendPILimit");
            entity.Property(e => e.VendUrl).HasColumnName("VendURL");
            entity.Property(e => e.VendorId)
                .HasMaxLength(8)
                .HasColumnName("VendorID");
            entity.Property(e => e.Zip)
                .HasMaxLength(10)
                .HasColumnName("ZIP");
        });

        modelBuilder.Entity<Vendor2>(entity =>
        {
            entity.HasKey(e => new { e.Company, e.VendorNum });

            entity.ToTable("Vendor", "Erp", tb => tb.HasTrigger("TR_Vendor_ChangeCapture"));

            entity.HasIndex(e => new { e.Company, e.Country }, "IX_Vendor_Country");

            entity.HasIndex(e => new { e.Company, e.CountryNum }, "IX_Vendor_CountryNum");

            entity.HasIndex(e => new { e.Company, e.CurrencyCode }, "IX_Vendor_CurrencyCode");

            entity.HasIndex(e => new { e.Inactive, e.ExternalId }, "IX_Vendor_ExternalID");

            entity.HasIndex(e => new { e.Company, e.Inactive, e.Ictrader, e.VendorId }, "IX_Vendor_ICTraderId");

            entity.HasIndex(e => new { e.Company, e.Inactive, e.Ictrader, e.Name }, "IX_Vendor_ICTraderName");

            entity.HasIndex(e => new { e.Company, e.Name, e.VendorId }, "IX_Vendor_Name").IsUnique();

            entity.HasIndex(e => new { e.Company, e.VendorNum, e.PrimPcon }, "IX_Vendor_PrimPcon");

            entity.HasIndex(e => e.SysRowId, "IX_Vendor_SysIndex").IsUnique();

            entity.HasIndex(e => new { e.Company, e.TaxRegionCode, e.Name }, "IX_Vendor_TaxRgnName");

            entity.HasIndex(e => new { e.Company, e.VendorId }, "IX_Vendor_VendorID").IsUnique();

            entity.HasIndex(e => new { e.Company, e.VendorNum, e.PurPoint }, "IX_Vendor_VendorPoint");

            entity.HasIndex(e => new { e.Company, e.WebVendor, e.VendorId }, "IX_Vendor_WebVendor");

            entity.Property(e => e.Company)
                .HasMaxLength(8)
                .HasDefaultValue("");
            entity.Property(e => e.AccountNum)
                .HasMaxLength(20)
                .HasDefaultValue("");
            entity.Property(e => e.AccountRef)
                .HasMaxLength(20)
                .HasDefaultValue("");
            entity.Property(e => e.Address1)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.Address3)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.AgafipresponsibilityCode)
                .HasMaxLength(4)
                .HasDefaultValue("")
                .HasColumnName("AGAFIPResponsibilityCode");
            entity.Property(e => e.Agapartment)
                .HasMaxLength(3)
                .HasDefaultValue("")
                .HasColumnName("AGApartment");
            entity.Property(e => e.AgextraStreetNumber)
                .HasMaxLength(1)
                .HasDefaultValue("")
                .HasColumnName("AGExtraStreetNumber");
            entity.Property(e => e.Agfloor)
                .HasMaxLength(3)
                .HasDefaultValue("")
                .HasColumnName("AGFloor");
            entity.Property(e => e.AggrossIncomeTaxId)
                .HasMaxLength(20)
                .HasDefaultValue("")
                .HasColumnName("AGGrossIncomeTaxID");
            entity.Property(e => e.AgiddocumentTypeCode)
                .HasMaxLength(4)
                .HasDefaultValue("")
                .HasColumnName("AGIDDocumentTypeCode");
            entity.Property(e => e.AglocationCode)
                .HasMaxLength(5)
                .HasDefaultValue("")
                .HasColumnName("AGLocationCode");
            entity.Property(e => e.Agneighborhood)
                .HasMaxLength(40)
                .HasDefaultValue("")
                .HasColumnName("AGNeighborhood");
            entity.Property(e => e.AgprovinceCode)
                .HasMaxLength(4)
                .HasDefaultValue("")
                .HasColumnName("AGProvinceCode");
            entity.Property(e => e.Agstreet)
                .HasMaxLength(40)
                .HasDefaultValue("")
                .HasColumnName("AGStreet");
            entity.Property(e => e.AgstreetNumber)
                .HasMaxLength(8)
                .HasDefaultValue("")
                .HasColumnName("AGStreetNumber");
            entity.Property(e => e.AguseGoodDefaultMark).HasColumnName("AGUseGoodDefaultMark");
            entity.Property(e => e.Approved).HasDefaultValue(true);
            entity.Property(e => e.BorderCrossing)
                .HasMaxLength(4)
                .HasDefaultValue("");
            entity.Property(e => e.CalendarId)
                .HasMaxLength(8)
                .HasDefaultValue("")
                .HasColumnName("CalendarID");
            entity.Property(e => e.ChrgAmount).HasColumnType("decimal(17, 3)");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.Cod).HasColumnName("COD");
            entity.Property(e => e.Codamount)
                .HasColumnType("decimal(17, 3)")
                .HasColumnName("CODAmount");
            entity.Property(e => e.Codcheck).HasColumnName("CODCheck");
            entity.Property(e => e.Code1099Id)
                .HasMaxLength(15)
                .HasDefaultValue("")
                .HasColumnName("Code1099ID");
            entity.Property(e => e.Codfreight).HasColumnName("CODFreight");
            entity.Property(e => e.CoisOneTimeVend).HasColumnName("COIsOneTimeVend");
            entity.Property(e => e.Comment).HasDefaultValue("");
            entity.Property(e => e.CooneTimeId)
                .HasMaxLength(20)
                .HasDefaultValue("")
                .HasColumnName("COOneTimeID");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.Cpay).HasColumnName("CPay");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(4)
                .HasDefaultValue("");
            entity.Property(e => e.DeclaredAmt).HasColumnType("decimal(17, 3)");
            entity.Property(e => e.DefaultFob)
                .HasMaxLength(15)
                .HasDefaultValue("")
                .HasColumnName("DefaultFOB");
            entity.Property(e => e.DeliveryConf).HasDefaultValue(1);
            entity.Property(e => e.DeliveryType)
                .HasMaxLength(8)
                .HasDefaultValue("");
            entity.Property(e => e.DeorgType)
                .HasMaxLength(1)
                .HasDefaultValue("N")
                .HasColumnName("DEOrgType");
            entity.Property(e => e.Edicode)
                .HasMaxLength(15)
                .HasDefaultValue("")
                .HasColumnName("EDICode");
            entity.Property(e => e.Einvoice).HasColumnName("EInvoice");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("EMailAddress");
            entity.Property(e => e.ExternalId)
                .HasMaxLength(40)
                .HasDefaultValue("");
            entity.Property(e => e.ExternalSchemeId)
                .HasMaxLength(10)
                .HasDefaultValue("")
                .HasColumnName("ExternalSchemeID");
            entity.Property(e => e.Fatca).HasColumnName("FATCA");
            entity.Property(e => e.FaxNum)
                .HasMaxLength(20)
                .HasDefaultValue("");
            entity.Property(e => e.Ffaddress1)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("FFAddress1");
            entity.Property(e => e.Ffaddress2)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("FFAddress2");
            entity.Property(e => e.Ffaddress3)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("FFAddress3");
            entity.Property(e => e.Ffcity)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("FFCity");
            entity.Property(e => e.FfcompName)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("FFCompName");
            entity.Property(e => e.Ffcontact)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("FFContact");
            entity.Property(e => e.Ffcountry)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("FFCountry");
            entity.Property(e => e.FfcountryNum).HasColumnName("FFCountryNum");
            entity.Property(e => e.Ffid)
                .HasMaxLength(8)
                .HasDefaultValue("")
                .HasColumnName("FFID");
            entity.Property(e => e.FfphoneNum)
                .HasMaxLength(20)
                .HasDefaultValue("")
                .HasColumnName("FFPhoneNum");
            entity.Property(e => e.Ffstate)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("FFState");
            entity.Property(e => e.Ffzip)
                .HasMaxLength(10)
                .HasDefaultValue("")
                .HasColumnName("FFZip");
            entity.Property(e => e.FormTypeId)
                .HasMaxLength(12)
                .HasDefaultValue("")
                .HasColumnName("FormTypeID");
            entity.Property(e => e.FormatStr)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.GroundType)
                .HasMaxLength(8)
                .HasDefaultValue("");
            entity.Property(e => e.GroupCode)
                .HasMaxLength(4)
                .HasDefaultValue("");
            entity.Property(e => e.HmrctaxValidationLog)
                .HasDefaultValue("")
                .HasColumnName("HMRCTaxValidationLog");
            entity.Property(e => e.Ictrader).HasColumnName("ICTrader");
            entity.Property(e => e.Icvend).HasColumnName("ICVend");
            entity.Property(e => e.Incstnumber)
                .HasMaxLength(25)
                .HasDefaultValue("")
                .HasColumnName("INCSTNumber");
            entity.Property(e => e.IndividualPackIds).HasColumnName("IndividualPackIDs");
            entity.Property(e => e.IngstcomplianceRate).HasColumnName("INGSTComplianceRate");
            entity.Property(e => e.Inpannumber)
                .HasMaxLength(12)
                .HasDefaultValue("")
                .HasColumnName("INPANNumber");
            entity.Property(e => e.InsupplierType)
                .HasMaxLength(30)
                .HasDefaultValue("")
                .HasColumnName("INSupplierType");
            entity.Property(e => e.IntaxRegistrationId)
                .HasMaxLength(15)
                .HasDefaultValue("")
                .HasColumnName("INTaxRegistrationID");
            entity.Property(e => e.LangNameId)
                .HasMaxLength(8)
                .HasDefaultValue("")
                .HasColumnName("LangNameID");
            entity.Property(e => e.LegalName)
                .HasMaxLength(200)
                .HasDefaultValue("");
            entity.Property(e => e.ManagedCustId)
                .HasMaxLength(10)
                .HasDefaultValue("")
                .HasColumnName("ManagedCustID");
            entity.Property(e => e.MaxLateDaysPorel).HasColumnName("MaxLateDaysPORel");
            entity.Property(e => e.MinOrderValue).HasColumnType("decimal(17, 3)");
            entity.Property(e => e.MxdiottranType)
                .HasMaxLength(10)
                .HasDefaultValue("")
                .HasColumnName("MXDIOTTranType");
            entity.Property(e => e.MxlegalRepCurp)
                .HasMaxLength(18)
                .HasDefaultValue("")
                .HasColumnName("MXLegalRepCURP");
            entity.Property(e => e.MxlegalRepName)
                .HasMaxLength(300)
                .HasDefaultValue("")
                .HasColumnName("MXLegalRepName");
            entity.Property(e => e.MxlegalRepRfc)
                .HasMaxLength(13)
                .HasDefaultValue("")
                .HasColumnName("MXLegalRepRFC");
            entity.Property(e => e.MxlegalRepTaxpayerType)
                .HasMaxLength(2)
                .HasDefaultValue("")
                .HasColumnName("MXLegalRepTaxpayerType");
            entity.Property(e => e.Mxmunicipio)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("MXMunicipio");
            entity.Property(e => e.MxretentionCode)
                .HasMaxLength(10)
                .HasDefaultValue("")
                .HasColumnName("MXRetentionCode");
            entity.Property(e => e.Mxtarcode)
                .HasMaxLength(10)
                .HasDefaultValue("")
                .HasColumnName("MXTARCode");
            entity.Property(e => e.MxtaxpayerType)
                .HasMaxLength(2)
                .HasDefaultValue("")
                .HasColumnName("MXTaxpayerType");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.NameControl)
                .HasMaxLength(4)
                .HasDefaultValue("");
            entity.Property(e => e.NonUs).HasColumnName("NonUS");
            entity.Property(e => e.NotifyEmail)
                .HasMaxLength(500)
                .HasDefaultValue("")
                .HasColumnName("NotifyEMail");
            entity.Property(e => e.OnTimeRating)
                .HasMaxLength(4)
                .HasDefaultValue("");
            entity.Property(e => e.OrgRegCode)
                .HasMaxLength(12)
                .HasDefaultValue("");
            entity.Property(e => e.ParamCode)
                .HasMaxLength(20)
                .HasDefaultValue("");
            entity.Property(e => e.PeaddressId)
                .HasMaxLength(10)
                .HasDefaultValue("")
                .HasColumnName("PEAddressID");
            entity.Property(e => e.PecollectionAgent).HasColumnName("PECollectionAgent");
            entity.Property(e => e.PedocumentId)
                .HasMaxLength(60)
                .HasDefaultValue("")
                .HasColumnName("PEDocumentID");
            entity.Property(e => e.PegoodsContributor).HasColumnName("PEGoodsContributor");
            entity.Property(e => e.PeidentityDocType)
                .HasMaxLength(1)
                .HasDefaultValue("6")
                .HasColumnName("PEIdentityDocType");
            entity.Property(e => e.PenoAddress).HasColumnName("PENoAddress");
            entity.Property(e => e.PenotFound).HasColumnName("PENotFound");
            entity.Property(e => e.PeretentionRegime)
                .HasMaxLength(8)
                .HasDefaultValue("")
                .HasColumnName("PERetentionRegime");
            entity.Property(e => e.PewithholdAgent).HasColumnName("PEWithholdAgent");
            entity.Property(e => e.PhoneNum)
                .HasMaxLength(20)
                .HasDefaultValue("");
            entity.Property(e => e.PlautomaticApinvoiceNum).HasColumnName("PLAutomaticAPInvoiceNum");
            entity.Property(e => e.PmtAcctRef)
                .HasMaxLength(25)
                .HasDefaultValue("");
            entity.Property(e => e.Pmuid).HasColumnName("PMUID");
            entity.Property(e => e.PriceRating)
                .HasMaxLength(4)
                .HasDefaultValue("");
            entity.Property(e => e.PrimPcon).HasColumnName("PrimPCon");
            entity.Property(e => e.PrimaryBankId)
                .HasMaxLength(9)
                .HasDefaultValue("")
                .HasColumnName("PrimaryBankID");
            entity.Property(e => e.PrintLabels).HasDefaultValue(true);
            entity.Property(e => e.PurPoint)
                .HasMaxLength(4)
                .HasDefaultValue("");
            entity.Property(e => e.QualityRating)
                .HasMaxLength(4)
                .HasDefaultValue("");
            entity.Property(e => e.RefNotes)
                .HasMaxLength(500)
                .HasDefaultValue("");
            entity.Property(e => e.Reporting1099Name)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.Reporting1099Name2)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.RevChargeMethod)
                .HasMaxLength(8)
                .HasDefaultValue("");
            entity.Property(e => e.Sec)
                .HasMaxLength(8)
                .HasDefaultValue("")
                .HasColumnName("SEC");
            entity.Property(e => e.SecondTinnotice).HasColumnName("SecondTINNotice");
            entity.Property(e => e.ServAuthNum)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ServInstruct)
                .HasMaxLength(100)
                .HasDefaultValue("");
            entity.Property(e => e.ServPhone)
                .HasMaxLength(20)
                .HasDefaultValue("");
            entity.Property(e => e.ServRef1)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ServRef2)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ServRef3)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ServRef4)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ServRef5)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ServiceRating)
                .HasMaxLength(4)
                .HasDefaultValue("");
            entity.Property(e => e.ShipViaCode)
                .HasMaxLength(4)
                .HasDefaultValue("");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.SysRevId)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SysRevID");
            entity.Property(e => e.SysRowId)
                .HasDefaultValueSql("(CONVERT([uniqueidentifier],CONVERT([binary](10),newid())+CONVERT([binary](6),getutcdate())))")
                .HasColumnName("SysRowID");
            entity.Property(e => e.TaxAuthorityCode)
                .HasMaxLength(8)
                .HasDefaultValue("");
            entity.Property(e => e.TaxEntityType)
                .HasMaxLength(3)
                .HasDefaultValue("");
            entity.Property(e => e.TaxPayerId)
                .HasMaxLength(20)
                .HasDefaultValue("")
                .HasColumnName("TaxPayerID");
            entity.Property(e => e.TaxRegReason)
                .HasMaxLength(12)
                .HasDefaultValue("");
            entity.Property(e => e.TaxRegionCode)
                .HasMaxLength(4)
                .HasDefaultValue("");
            entity.Property(e => e.TaxValidationDate).HasColumnType("datetime");
            entity.Property(e => e.TermsCode)
                .HasMaxLength(4)
                .HasDefaultValue("");
            entity.Property(e => e.ThbranchId)
                .HasMaxLength(8)
                .HasDefaultValue("")
                .HasColumnName("THBranchID");
            entity.Property(e => e.Tin)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("TIN");
            entity.Property(e => e.Tintype)
                .HasMaxLength(2)
                .HasDefaultValue("")
                .HasColumnName("TINType");
            entity.Property(e => e.TinvalidationStatus).HasColumnName("TINValidationStatus");
            entity.Property(e => e.TwguiregNum)
                .HasMaxLength(8)
                .HasDefaultValue("")
                .HasColumnName("TWGUIRegNum");
            entity.Property(e => e.UpsquantumView).HasColumnName("UPSQuantumView");
            entity.Property(e => e.Upsqvmemo)
                .HasDefaultValue("")
                .HasColumnName("UPSQVMemo");
            entity.Property(e => e.UpsqvshipFromName)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("UPSQVShipFromName");
            entity.Property(e => e.Us1099kmerchCatCode)
                .HasMaxLength(4)
                .HasDefaultValue("")
                .HasColumnName("US1099KMerchCatCode");
            entity.Property(e => e.Us1099state)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("US1099State");
            entity.Property(e => e.VendPilimit).HasColumnName("VendPILimit");
            entity.Property(e => e.VendUrl)
                .HasDefaultValue("")
                .HasColumnName("VendURL");
            entity.Property(e => e.VendorId)
                .HasMaxLength(8)
                .HasDefaultValue("")
                .HasColumnName("VendorID");
            entity.Property(e => e.Zip)
                .HasMaxLength(10)
                .HasDefaultValue("")
                .HasColumnName("ZIP");
        });

        modelBuilder.Entity<Part>(entity =>
        {
            entity.HasKey(e => new { e.Company, e.PartNum });

            entity.ToTable("Part", "Erp", tb => tb.HasTrigger("TR_Part_ChangeCapture"));

            entity.HasIndex(e => new { e.Company, e.Snmask }, "IX_Part_CompSNMask");

            entity.HasIndex(e => new { e.Company, e.SysRevId }, "IX_Part_CompanySysRevID");

            entity.HasIndex(e => new { e.Company, e.InActive, e.PartNum }, "IX_Part_InactivePartNum");

            entity.HasIndex(e => new { e.Company, e.TrackLots, e.TypeCode, e.PartNum }, "IX_Part_LotTypePart");

            entity.HasIndex(e => new { e.Company, e.TrackLots, e.TypeCode, e.SearchWord, e.PartNum }, "IX_Part_LotTypeWord");

            entity.HasIndex(e => new { e.Company, e.Method, e.LowLevelCode }, "IX_Part_MethodLowLevel");

            entity.HasIndex(e => new { e.Company, e.Method, e.PartNum }, "IX_Part_MethodPart");

            entity.HasIndex(e => new { e.Company, e.Method, e.SearchWord, e.PartNum }, "IX_Part_MethodWord");

            entity.HasIndex(e => new { e.Company, e.ClassId }, "IX_Part_PartClass");

            entity.HasIndex(e => new { e.Company, e.ProdCode, e.PartNum }, "IX_Part_ProdCode");

            entity.HasIndex(e => new { e.Company, e.SearchWord, e.PartNum }, "IX_Part_SearchWord");

            entity.HasIndex(e => e.SysRowId, "IX_Part_SysIndex").IsUnique();

            entity.HasIndex(e => new { e.Company, e.TrackSerialNum, e.TypeCode, e.PartNum }, "IX_Part_TrackSerialNumPart");

            entity.HasIndex(e => new { e.Company, e.TrackSerialNum, e.TypeCode, e.SearchWord }, "IX_Part_TrackSerialNumWord");

            entity.HasIndex(e => new { e.Company, e.TypeCode, e.PartNum }, "IX_Part_TypePart");

            entity.HasIndex(e => new { e.Company, e.TypeCode, e.SearchWord, e.PartNum }, "IX_Part_TypeSearch");

            entity.HasIndex(e => new { e.Company, e.UomclassId, e.PartNum }, "IX_Part_UOMClass");

            entity.HasIndex(e => new { e.Company, e.Upccode1 }, "IX_Part_UPCCode1");

            entity.HasIndex(e => new { e.Company, e.Upccode2 }, "IX_Part_UPCCode2");

            entity.HasIndex(e => new { e.Company, e.Upccode3 }, "IX_Part_UPCCode3");

            entity.Property(e => e.Company)
                .HasMaxLength(8)
                .HasDefaultValue("");
            entity.Property(e => e.PartNum)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.Aesexp)
                .HasMaxLength(8)
                .HasDefaultValue("")
                .HasColumnName("AESExp");
            entity.Property(e => e.AgproductMark).HasColumnName("AGProductMark");
            entity.Property(e => e.AguseGoodMark).HasColumnName("AGUseGoodMark");
            entity.Property(e => e.AnalysisCode)
                .HasMaxLength(8)
                .HasDefaultValue("");
            entity.Property(e => e.AttBatch)
                .HasMaxLength(3)
                .HasDefaultValue("N");
            entity.Property(e => e.AttBeforeDt)
                .HasMaxLength(3)
                .HasDefaultValue("N");
            entity.Property(e => e.AttCureDt)
                .HasMaxLength(3)
                .HasDefaultValue("N");
            entity.Property(e => e.AttExpDt)
                .HasMaxLength(3)
                .HasDefaultValue("N");
            entity.Property(e => e.AttFirmware)
                .HasMaxLength(3)
                .HasDefaultValue("N");
            entity.Property(e => e.AttHeat)
                .HasMaxLength(3)
                .HasDefaultValue("N");
            entity.Property(e => e.AttIsorigCountry)
                .HasMaxLength(3)
                .HasDefaultValue("N")
                .HasColumnName("AttISOrigCountry");
            entity.Property(e => e.AttMfgBatch)
                .HasMaxLength(3)
                .HasDefaultValue("N");
            entity.Property(e => e.AttMfgDt)
                .HasMaxLength(3)
                .HasDefaultValue("N");
            entity.Property(e => e.AttMfgLot)
                .HasMaxLength(3)
                .HasDefaultValue("N");
            entity.Property(e => e.AttrClassId)
                .HasMaxLength(30)
                .HasDefaultValue("")
                .HasColumnName("AttrClassID");
            entity.Property(e => e.BasePartNum)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.Bolclass)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("BOLClass");
            entity.Property(e => e.ChangedOn).HasColumnType("datetime");
            entity.Property(e => e.ClassId)
                .HasMaxLength(4)
                .HasDefaultValue("")
                .HasColumnName("ClassID");
            entity.Property(e => e.Cnbonded).HasColumnName("CNBonded");
            entity.Property(e => e.CncodeVersion)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("CNCodeVersion");
            entity.Property(e => e.CnhasPreferentialTreatment).HasColumnName("CNHasPreferentialTreatment");
            entity.Property(e => e.CnpreferentialTreatmentContent)
                .HasMaxLength(100)
                .HasDefaultValue("")
                .HasColumnName("CNPreferentialTreatmentContent");
            entity.Property(e => e.CnproductName)
                .HasMaxLength(100)
                .HasDefaultValue("")
                .HasColumnName("CNProductName");
            entity.Property(e => e.Cnspecification)
                .HasMaxLength(30)
                .HasDefaultValue("")
                .HasColumnName("CNSpecification");
            entity.Property(e => e.CntaxCategoryCode)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("CNTaxCategoryCode");
            entity.Property(e => e.Cnweight)
                .HasColumnType("decimal(17, 5)")
                .HasColumnName("CNWeight");
            entity.Property(e => e.CnweightUom)
                .HasMaxLength(6)
                .HasDefaultValue("")
                .HasColumnName("CNWeightUOM");
            entity.Property(e => e.CnzeroTaxRateMark)
                .HasMaxLength(1)
                .HasDefaultValue("")
                .HasColumnName("CNZeroTaxRateMark");
            entity.Property(e => e.CommentText).HasDefaultValue("");
            entity.Property(e => e.CommercialBrand)
                .HasMaxLength(30)
                .HasDefaultValue("");
            entity.Property(e => e.CommercialCategory)
                .HasMaxLength(30)
                .HasDefaultValue("");
            entity.Property(e => e.CommercialColor)
                .HasMaxLength(30)
                .HasDefaultValue("");
            entity.Property(e => e.CommercialSize1)
                .HasMaxLength(30)
                .HasDefaultValue("");
            entity.Property(e => e.CommercialSize2)
                .HasMaxLength(30)
                .HasDefaultValue("");
            entity.Property(e => e.CommercialStyle)
                .HasMaxLength(30)
                .HasDefaultValue("");
            entity.Property(e => e.CommercialSubBrand)
                .HasMaxLength(30)
                .HasDefaultValue("");
            entity.Property(e => e.CommercialSubCategory)
                .HasMaxLength(30)
                .HasDefaultValue("");
            entity.Property(e => e.CommodityCode)
                .HasMaxLength(15)
                .HasDefaultValue("");
            entity.Property(e => e.CommoditySchemeId)
                .HasMaxLength(10)
                .HasDefaultValue("")
                .HasColumnName("CommoditySchemeID");
            entity.Property(e => e.CommoditySchemeVersion)
                .HasMaxLength(40)
                .HasDefaultValue("");
            entity.Property(e => e.Condition)
                .HasMaxLength(30)
                .HasDefaultValue("");
            entity.Property(e => e.CostMethod)
                .HasMaxLength(2)
                .HasDefaultValue("A");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(75)
                .HasDefaultValue("");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Csfcj5).HasColumnName("CSFCJ5");
            entity.Property(e => e.Csflmw).HasColumnName("CSFLMW");
            entity.Property(e => e.Dedenomination)
                .HasMaxLength(3)
                .HasDefaultValue("")
                .HasColumnName("DEDenomination");
            entity.Property(e => e.DefaultAttributeSetId).HasColumnName("DefaultAttributeSetID");
            entity.Property(e => e.DefaultDim)
                .HasMaxLength(6)
                .HasDefaultValue("");
            entity.Property(e => e.DeinternationalSecuritiesId)
                .HasMaxLength(12)
                .HasDefaultValue("")
                .HasColumnName("DEInternationalSecuritiesID");
            entity.Property(e => e.DeisInvestment).HasColumnName("DEIsInvestment");
            entity.Property(e => e.DeisSecurityFinancialDerivative).HasColumnName("DEIsSecurityFinancialDerivative");
            entity.Property(e => e.DeisServices).HasColumnName("DEIsServices");
            entity.Property(e => e.DepayStatCode)
                .HasMaxLength(3)
                .HasDefaultValue("")
                .HasColumnName("DEPayStatCode");
            entity.Property(e => e.Diameter).HasColumnType("decimal(15, 5)");
            entity.Property(e => e.DiameterInside).HasColumnType("decimal(15, 5)");
            entity.Property(e => e.DiameterOutside).HasColumnType("decimal(15, 5)");
            entity.Property(e => e.DiameterUm)
                .HasMaxLength(6)
                .HasDefaultValue("")
                .HasColumnName("DiameterUM");
            entity.Property(e => e.DiffPrc2PrchUom).HasColumnName("DiffPrc2PrchUOM");
            entity.Property(e => e.DualUomclassId)
                .HasMaxLength(12)
                .HasDefaultValue("")
                .HasColumnName("DualUOMClassID");
            entity.Property(e => e.Durometer)
                .HasMaxLength(30)
                .HasDefaultValue("");
            entity.Property(e => e.Eccnnumber)
                .HasMaxLength(25)
                .HasDefaultValue("")
                .HasColumnName("ECCNNumber");
            entity.Property(e => e.Edicode)
                .HasMaxLength(15)
                .HasDefaultValue("")
                .HasColumnName("EDICode");
            entity.Property(e => e.EngineeringAlert)
                .HasMaxLength(30)
                .HasDefaultValue("");
            entity.Property(e => e.EstimateId)
                .HasMaxLength(256)
                .HasDefaultValue("")
                .HasColumnName("EstimateID");
            entity.Property(e => e.EstimateOrPlan)
                .HasMaxLength(20)
                .HasDefaultValue("");
            entity.Property(e => e.ExpLicNumber)
                .HasMaxLength(25)
                .HasDefaultValue("");
            entity.Property(e => e.ExpLicType)
                .HasMaxLength(8)
                .HasDefaultValue("");
            entity.Property(e => e.ExternalCrmlastSync)
                .HasColumnType("datetime")
                .HasColumnName("ExternalCRMLastSync");
            entity.Property(e => e.ExternalCrmpartId)
                .HasMaxLength(200)
                .HasDefaultValue("")
                .HasColumnName("ExternalCRMPartID");
            entity.Property(e => e.ExternalCrmsyncRequired).HasColumnName("ExternalCRMSyncRequired");
            entity.Property(e => e.ExternalId)
                .HasMaxLength(40)
                .HasDefaultValue("")
                .HasColumnName("ExternalID");
            entity.Property(e => e.ExternalMeslastSync)
                .HasColumnType("datetime")
                .HasColumnName("ExternalMESLastSync");
            entity.Property(e => e.ExternalMessyncRequired).HasColumnName("ExternalMESSyncRequired");
            entity.Property(e => e.ExternalSchemeId)
                .HasMaxLength(10)
                .HasDefaultValue("")
                .HasColumnName("ExternalSchemeID");
            entity.Property(e => e.FairMarketValue).HasColumnType("decimal(18, 5)");
            entity.Property(e => e.Fsaequipment).HasColumnName("FSAEquipment");
            entity.Property(e => e.Fsaitem).HasColumnName("FSAItem");
            entity.Property(e => e.FsassetClassCode)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("FSAssetClassCode");
            entity.Property(e => e.FspricePerCode)
                .HasMaxLength(2)
                .HasDefaultValue("E")
                .HasColumnName("FSPricePerCode");
            entity.Property(e => e.FssalesUnitPrice)
                .HasColumnType("decimal(17, 5)")
                .HasColumnName("FSSalesUnitPrice");
            entity.Property(e => e.Gravity).HasColumnType("decimal(15, 5)");
            entity.Property(e => e.GrossWeight).HasColumnType("decimal(15, 5)");
            entity.Property(e => e.GrossWeightUom)
                .HasMaxLength(6)
                .HasDefaultValue("")
                .HasColumnName("GrossWeightUOM");
            entity.Property(e => e.HazClass)
                .HasMaxLength(8)
                .HasDefaultValue("");
            entity.Property(e => e.HazGvrnmtId)
                .HasMaxLength(8)
                .HasDefaultValue("")
                .HasColumnName("HazGvrnmtID");
            entity.Property(e => e.HazPackInstr).HasDefaultValue("");
            entity.Property(e => e.HazSub)
                .HasMaxLength(8)
                .HasDefaultValue("");
            entity.Property(e => e.HazTechName)
                .HasMaxLength(40)
                .HasDefaultValue("");
            entity.Property(e => e.Hts)
                .HasMaxLength(10)
                .HasDefaultValue("")
                .HasColumnName("HTS");
            entity.Property(e => e.ImageFileName)
                .HasMaxLength(256)
                .HasDefaultValue("");
            entity.Property(e => e.ImageId)
                .HasMaxLength(256)
                .HasDefaultValue("")
                .HasColumnName("ImageID");
            entity.Property(e => e.InchapterId)
                .HasMaxLength(12)
                .HasDefaultValue("")
                .HasColumnName("INChapterID");
            entity.Property(e => e.InternalPricePerCode)
                .HasMaxLength(2)
                .HasDefaultValue("E");
            entity.Property(e => e.InternalUnitPrice).HasColumnType("decimal(17, 5)");
            entity.Property(e => e.IsorigCountry)
                .HasMaxLength(6)
                .HasDefaultValue("")
                .HasColumnName("ISOrigCountry");
            entity.Property(e => e.Isregion)
                .HasMaxLength(3)
                .HasDefaultValue("")
                .HasColumnName("ISRegion");
            entity.Property(e => e.IssuppUnitsFactor)
                .HasDefaultValue(1m)
                .HasColumnType("decimal(18, 8)")
                .HasColumnName("ISSuppUnitsFactor");
            entity.Property(e => e.Ium)
                .HasMaxLength(6)
                .HasDefaultValue("")
                .HasColumnName("IUM");
            entity.Property(e => e.LcnrvestimatedUnitPrice)
                .HasColumnType("decimal(17, 3)")
                .HasColumnName("LCNRVEstimatedUnitPrice");
            entity.Property(e => e.Lcnrvreporting).HasColumnName("LCNRVReporting");
            entity.Property(e => e.LocationFormatId)
                .HasMaxLength(12)
                .HasDefaultValue("")
                .HasColumnName("LocationFormatID");
            entity.Property(e => e.LocationIdnumReq).HasColumnName("LocationIDNumReq");
            entity.Property(e => e.LotAppendDate)
                .HasMaxLength(10)
                .HasDefaultValue("");
            entity.Property(e => e.LotNxtNum).HasDefaultValue(1);
            entity.Property(e => e.LotPrefix)
                .HasMaxLength(20)
                .HasDefaultValue("");
            entity.Property(e => e.LotSeqId)
                .HasMaxLength(12)
                .HasDefaultValue("")
                .HasColumnName("LotSeqID");
            entity.Property(e => e.Mdpv).HasColumnName("MDPV");
            entity.Property(e => e.MfgComment).HasDefaultValue("");
            entity.Property(e => e.MobilePart).HasDefaultValue(true);
            entity.Property(e => e.MtlAnalysisCode)
                .HasMaxLength(8)
                .HasDefaultValue("");
            entity.Property(e => e.MtlBurRate).HasColumnType("decimal(10, 5)");
            entity.Property(e => e.MxcustomsDuty)
                .HasMaxLength(10)
                .HasDefaultValue("")
                .HasColumnName("MXCustomsDuty");
            entity.Property(e => e.MxcustomsUmfrom)
                .HasMaxLength(1)
                .HasDefaultValue("")
                .HasColumnName("MXCustomsUMFrom");
            entity.Property(e => e.MxprodServCode)
                .HasMaxLength(8)
                .HasDefaultValue("")
                .HasColumnName("MXProdServCode");
            entity.Property(e => e.NaftaorigCountry)
                .HasMaxLength(6)
                .HasDefaultValue("")
                .HasColumnName("NAFTAOrigCountry");
            entity.Property(e => e.Naftapref)
                .HasMaxLength(8)
                .HasDefaultValue("")
                .HasColumnName("NAFTAPref");
            entity.Property(e => e.Naftaprod)
                .HasMaxLength(8)
                .HasDefaultValue("")
                .HasColumnName("NAFTAProd");
            entity.Property(e => e.NetVolume).HasColumnType("decimal(15, 5)");
            entity.Property(e => e.NetVolumeUom)
                .HasMaxLength(6)
                .HasDefaultValue("")
                .HasColumnName("NetVolumeUOM");
            entity.Property(e => e.NetWeight).HasColumnType("decimal(15, 5)");
            entity.Property(e => e.NetWeightUom)
                .HasMaxLength(6)
                .HasDefaultValue("")
                .HasColumnName("NetWeightUOM");
            entity.Property(e => e.OnHoldReasonCode)
                .HasMaxLength(8)
                .HasDefaultValue("");
            entity.Property(e => e.OwnershipStatus)
                .HasMaxLength(8)
                .HasDefaultValue("");
            entity.Property(e => e.PartDescription).HasDefaultValue("");
            entity.Property(e => e.PartHeight).HasColumnType("decimal(15, 5)");
            entity.Property(e => e.PartLength).HasColumnType("decimal(15, 5)");
            entity.Property(e => e.PartLengthWidthHeightUm)
                .HasMaxLength(6)
                .HasDefaultValue("")
                .HasColumnName("PartLengthWidthHeightUM");
            entity.Property(e => e.PartSpecificPackingUom).HasColumnName("PartSpecificPackingUOM");
            entity.Property(e => e.PartWidth).HasColumnType("decimal(15, 5)");
            entity.Property(e => e.PdmobjId)
                .HasMaxLength(8)
                .HasDefaultValue("")
                .HasColumnName("PDMObjID");
            entity.Property(e => e.PedetrGoodServiceCode)
                .HasMaxLength(10)
                .HasDefaultValue("")
                .HasColumnName("PEDetrGoodServiceCode");
            entity.Property(e => e.PeproductServiceCode)
                .HasMaxLength(10)
                .HasDefaultValue("")
                .HasColumnName("PEProductServiceCode");
            entity.Property(e => e.Pesunattype)
                .HasMaxLength(100)
                .HasDefaultValue("")
                .HasColumnName("PESUNATType");
            entity.Property(e => e.PesunattypeCode)
                .HasMaxLength(2)
                .HasDefaultValue("")
                .HasColumnName("PESUNATTypeCode");
            entity.Property(e => e.Pesunatuom)
                .HasMaxLength(100)
                .HasDefaultValue("")
                .HasColumnName("PESUNATUOM");
            entity.Property(e => e.Pesunatuomcode)
                .HasMaxLength(3)
                .HasDefaultValue("")
                .HasColumnName("PESUNATUOMCode");
            entity.Property(e => e.PhantomBom).HasColumnName("PhantomBOM");
            entity.Property(e => e.PhotoFile)
                .HasMaxLength(8)
                .HasDefaultValue("");
            entity.Property(e => e.PricePerCode)
                .HasMaxLength(2)
                .HasDefaultValue("E");
            entity.Property(e => e.PricingFactor).HasColumnType("decimal(14, 5)");
            entity.Property(e => e.PricingUom)
                .HasMaxLength(6)
                .HasDefaultValue("")
                .HasColumnName("PricingUOM");
            entity.Property(e => e.ProdCode)
                .HasMaxLength(8)
                .HasDefaultValue("");
            entity.Property(e => e.Pum)
                .HasMaxLength(6)
                .HasDefaultValue("")
                .HasColumnName("PUM");
            entity.Property(e => e.PurComment).HasDefaultValue("");
            entity.Property(e => e.PurchasingFactor)
                .HasDefaultValue(1m)
                .HasColumnType("decimal(14, 4)");
            entity.Property(e => e.PurchasingFactorDirection)
                .HasMaxLength(1)
                .HasDefaultValue("D");
            entity.Property(e => e.QtyBearing).HasDefaultValue(true);
            entity.Property(e => e.RcoverThreshold)
                .HasColumnType("decimal(17, 3)")
                .HasColumnName("RCOverThreshold");
            entity.Property(e => e.RcunderThreshold)
                .HasColumnType("decimal(17, 3)")
                .HasColumnName("RCUnderThreshold");
            entity.Property(e => e.RefCategory)
                .HasMaxLength(8)
                .HasDefaultValue("");
            entity.Property(e => e.ReturnableContainer)
                .HasMaxLength(30)
                .HasDefaultValue("");
            entity.Property(e => e.RevChargeMethod)
                .HasMaxLength(8)
                .HasDefaultValue("");
            entity.Property(e => e.SaftprodCategory)
                .HasMaxLength(10)
                .HasDefaultValue("")
                .HasColumnName("SAFTProdCategory");
            entity.Property(e => e.SalesUm)
                .HasMaxLength(6)
                .HasDefaultValue("")
                .HasColumnName("SalesUM");
            entity.Property(e => e.SchedBcode)
                .HasMaxLength(12)
                .HasDefaultValue("");
            entity.Property(e => e.SearchWord)
                .HasMaxLength(8)
                .HasDefaultValue("");
            entity.Property(e => e.SellingFactor)
                .HasDefaultValue(1m)
                .HasColumnType("decimal(18, 8)");
            entity.Property(e => e.SellingFactorDirection)
                .HasMaxLength(1)
                .HasDefaultValue("D");
            entity.Property(e => e.SendToFsa).HasColumnName("SendToFSA");
            entity.Property(e => e.SnbaseDataType)
                .HasMaxLength(10)
                .HasDefaultValue("")
                .HasColumnName("SNBaseDataType");
            entity.Property(e => e.Snformat)
                .HasMaxLength(80)
                .HasDefaultValue("")
                .HasColumnName("SNFormat");
            entity.Property(e => e.SnlastUsedSeq)
                .HasMaxLength(40)
                .HasDefaultValue("")
                .HasColumnName("SNLastUsedSeq");
            entity.Property(e => e.Snmask)
                .HasMaxLength(20)
                .HasDefaultValue("")
                .HasColumnName("SNMask");
            entity.Property(e => e.SnmaskExample)
                .HasMaxLength(80)
                .HasDefaultValue("")
                .HasColumnName("SNMaskExample");
            entity.Property(e => e.SnmaskPrefix)
                .HasMaxLength(10)
                .HasDefaultValue("")
                .HasColumnName("SNMaskPrefix");
            entity.Property(e => e.SnmaskSuffix)
                .HasMaxLength(10)
                .HasDefaultValue("")
                .HasColumnName("SNMaskSuffix");
            entity.Property(e => e.Snprefix)
                .HasMaxLength(30)
                .HasDefaultValue("")
                .HasColumnName("SNPrefix");
            entity.Property(e => e.Specification)
                .HasMaxLength(30)
                .HasDefaultValue("");
            entity.Property(e => e.SubPart)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.SyncToExternalCrm).HasColumnName("SyncToExternalCRM");
            entity.Property(e => e.SysRevId)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("SysRevID");
            entity.Property(e => e.SysRowId)
                .HasDefaultValueSql("(CONVERT([uniqueidentifier],CONVERT([binary](10),newid())+CONVERT([binary](6),getutcdate())))")
                .HasColumnName("SysRowID");
            entity.Property(e => e.TaxCatId)
                .HasMaxLength(10)
                .HasDefaultValue("")
                .HasColumnName("TaxCatID");
            entity.Property(e => e.Thickness).HasColumnType("decimal(15, 5)");
            entity.Property(e => e.ThicknessMax).HasColumnType("decimal(15, 5)");
            entity.Property(e => e.ThicknessUm)
                .HasMaxLength(6)
                .HasDefaultValue("")
                .HasColumnName("ThicknessUM");
            entity.Property(e => e.TypeCode)
                .HasMaxLength(2)
                .HasDefaultValue("P");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(17, 5)");
            entity.Property(e => e.UomclassId)
                .HasMaxLength(12)
                .HasDefaultValue("")
                .HasColumnName("UOMClassID");
            entity.Property(e => e.Upccode1)
                .HasMaxLength(20)
                .HasDefaultValue("")
                .HasColumnName("UPCCode1");
            entity.Property(e => e.Upccode2)
                .HasMaxLength(20)
                .HasDefaultValue("")
                .HasColumnName("UPCCode2");
            entity.Property(e => e.Upccode3)
                .HasMaxLength(20)
                .HasDefaultValue("")
                .HasColumnName("UPCCode3");
            entity.Property(e => e.UseHtsdesc).HasColumnName("UseHTSDesc");
            entity.Property(e => e.UsePartRev).HasDefaultValue(true);
            entity.Property(e => e.UserChar1)
                .HasMaxLength(30)
                .HasDefaultValue("");
            entity.Property(e => e.UserChar2)
                .HasMaxLength(30)
                .HasDefaultValue("");
            entity.Property(e => e.UserChar3)
                .HasMaxLength(30)
                .HasDefaultValue("");
            entity.Property(e => e.UserChar4)
                .HasMaxLength(30)
                .HasDefaultValue("");
            entity.Property(e => e.UserDate1).HasColumnType("datetime");
            entity.Property(e => e.UserDate2).HasColumnType("datetime");
            entity.Property(e => e.UserDate3).HasColumnType("datetime");
            entity.Property(e => e.UserDate4).HasColumnType("datetime");
            entity.Property(e => e.UserDecimal1).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.UserDecimal2).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.UserDecimal3).HasColumnType("decimal(15, 5)");
            entity.Property(e => e.UserDecimal4).HasColumnType("decimal(15, 5)");
            entity.Property(e => e.WarrantyCode)
                .HasMaxLength(8)
                .HasDefaultValue("");
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
