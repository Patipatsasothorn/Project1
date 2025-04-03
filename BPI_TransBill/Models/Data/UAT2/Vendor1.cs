using System;
using System.Collections.Generic;

namespace BPI_TransBill.Models.Data.UAT2;

public partial class Vendor1
{
    public bool Inactive { get; set; }

    public string Company { get; set; } = null!;

    public string VendorId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int VendorNum { get; set; }

    public string Address1 { get; set; } = null!;

    public string Address2 { get; set; } = null!;

    public string Address3 { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Zip { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string TaxPayerId { get; set; } = null!;

    public string PurPoint { get; set; } = null!;

    public string TermsCode { get; set; } = null!;

    public string GroupCode { get; set; } = null!;

    public bool Print1099 { get; set; }

    public bool OneCheck { get; set; }

    public bool PrintLabels { get; set; }

    public string FaxNum { get; set; } = null!;

    public string PhoneNum { get; set; } = null!;

    public string Comment { get; set; } = null!;

    public bool PayHold { get; set; }

    public int PrimPcon { get; set; }

    public string AccountRef { get; set; } = null!;

    public string DefaultFob { get; set; } = null!;

    public bool RcvInspectionReq { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public string TaxRegionCode { get; set; } = null!;

    public int CountryNum { get; set; }

    public string LangNameId { get; set; } = null!;

    public string BorderCrossing { get; set; } = null!;

    public string FormatStr { get; set; } = null!;

    public bool ElecPayment { get; set; }

    public string PrimaryBankId { get; set; } = null!;

    public bool Approved { get; set; }

    public bool Icvend { get; set; }

    public string EmailAddress { get; set; } = null!;

    public bool WebVendor { get; set; }

    public string VendUrl { get; set; } = null!;

    public int EarlyBuffer { get; set; }

    public int LateBuffer { get; set; }

    public string OnTimeRating { get; set; } = null!;

    public string QualityRating { get; set; } = null!;

    public string PriceRating { get; set; } = null!;

    public string ServiceRating { get; set; } = null!;

    public string ExternalId { get; set; } = null!;

    public int VendPilimit { get; set; }

    public bool GlobalVendor { get; set; }

    public bool Ictrader { get; set; }

    public string TaxAuthorityCode { get; set; } = null!;

    public bool GlobalLock { get; set; }

    public decimal MinOrderValue { get; set; }

    public string CalendarId { get; set; } = null!;

    public string Edicode { get; set; } = null!;

    public bool ConsolidatedPurchasing { get; set; }

    public bool LocalPurchasing { get; set; }

    public bool ResDelivery { get; set; }

    public bool SatDelivery { get; set; }

    public bool SatPickup { get; set; }

    public bool Hazmat { get; set; }

    public bool DocOnly { get; set; }

    public string RefNotes { get; set; } = null!;

    public bool ApplyChrg { get; set; }

    public decimal ChrgAmount { get; set; }

    public bool Cod { get; set; }

    public bool Codfreight { get; set; }

    public bool Codcheck { get; set; }

    public decimal Codamount { get; set; }

    public string GroundType { get; set; } = null!;

    public bool NotifyFlag { get; set; }

    public string NotifyEmail { get; set; } = null!;

    public bool DeclaredIns { get; set; }

    public decimal DeclaredAmt { get; set; }

    public bool ServSignature { get; set; }

    public bool ServAlert { get; set; }

    public bool ServHomeDel { get; set; }

    public string DeliveryType { get; set; } = null!;

    public DateOnly? ServDeliveryDate { get; set; }

    public string ServPhone { get; set; } = null!;

    public string ServInstruct { get; set; } = null!;

    public bool ServRelease { get; set; }

    public string ServAuthNum { get; set; } = null!;

    public string ServRef1 { get; set; } = null!;

    public string ServRef2 { get; set; } = null!;

    public string ServRef3 { get; set; } = null!;

    public string ServRef4 { get; set; } = null!;

    public string ServRef5 { get; set; } = null!;

    public bool Cpay { get; set; }

    public bool IndividualPackIds { get; set; }

    public bool IntrntlShip { get; set; }

    public bool CertOfOrigin { get; set; }

    public bool CommercialInvoice { get; set; }

    public bool ShipExprtDeclartn { get; set; }

    public bool LetterOfInstr { get; set; }

    public string Ffid { get; set; } = null!;

    public string FfcompName { get; set; } = null!;

    public string Ffcontact { get; set; } = null!;

    public string Ffaddress1 { get; set; } = null!;

    public string Ffaddress2 { get; set; } = null!;

    public string Ffaddress3 { get; set; } = null!;

    public string Ffcity { get; set; } = null!;

    public string Ffstate { get; set; } = null!;

    public string Ffzip { get; set; } = null!;

    public string Ffcountry { get; set; } = null!;

    public bool NonStdPkg { get; set; }

    public int DeliveryConf { get; set; }

    public bool AddlHdlgFlag { get; set; }

    public bool UpsquantumView { get; set; }

    public string UpsqvshipFromName { get; set; } = null!;

    public string Upsqvmemo { get; set; } = null!;

    public string FfphoneNum { get; set; } = null!;

    public int FfcountryNum { get; set; }

    public string RevChargeMethod { get; set; } = null!;

    public bool ManagedCust { get; set; }

    public string ManagedCustId { get; set; } = null!;

    public int ManagedCustNum { get; set; }

    public int Pmuid { get; set; }

    public bool HasBank { get; set; }

    public string PmtAcctRef { get; set; } = null!;

    public string LegalName { get; set; } = null!;

    public string TaxRegReason { get; set; } = null!;

    public string OrgRegCode { get; set; } = null!;

    public bool AdvTaxInv { get; set; }

    public bool AllowAsAltRemitTo { get; set; }

    public byte[] SysRevId { get; set; } = null!;

    public Guid SysRowId { get; set; }

    public string ThbranchId { get; set; } = null!;

    public string ParamCode { get; set; } = null!;

    public string AgafipresponsibilityCode { get; set; } = null!;

    public string AggrossIncomeTaxId { get; set; } = null!;

    public string AgiddocumentTypeCode { get; set; } = null!;

    public string AgprovinceCode { get; set; } = null!;

    public bool AguseGoodDefaultMark { get; set; }

    public string Agapartment { get; set; } = null!;

    public string AgextraStreetNumber { get; set; } = null!;

    public string Agfloor { get; set; } = null!;

    public string AglocationCode { get; set; } = null!;

    public string Agneighborhood { get; set; } = null!;

    public string Agstreet { get; set; } = null!;

    public string AgstreetNumber { get; set; } = null!;

    public string CooneTimeId { get; set; } = null!;

    public bool NoBankingReference { get; set; }

    public bool PegoodsContributor { get; set; }

    public bool PewithholdAgent { get; set; }

    public bool PecollectionAgent { get; set; }

    public bool PenotFound { get; set; }

    public bool PenoAddress { get; set; }

    public string PeidentityDocType { get; set; } = null!;

    public bool CoisOneTimeVend { get; set; }

    public string PedocumentId { get; set; } = null!;

    public int MaxLateDaysPorel { get; set; }

    public string Code1099Id { get; set; } = null!;

    public string Tin { get; set; } = null!;

    public string Tintype { get; set; } = null!;

    public bool SecondTinnotice { get; set; }

    public string NameControl { get; set; } = null!;

    public string ShipViaCode { get; set; } = null!;

    public bool NonUs { get; set; }

    public string FormTypeId { get; set; } = null!;

    public string InsupplierType { get; set; } = null!;

    public string Incstnumber { get; set; } = null!;

    public string Inpannumber { get; set; } = null!;

    public string DeorgType { get; set; } = null!;

    public bool PaymentReporting { get; set; }

    public bool ExternalPurchasing { get; set; }

    public string MxretentionCode { get; set; } = null!;

    public string Reporting1099Name { get; set; } = null!;

    public string Reporting1099Name2 { get; set; } = null!;

    public bool Fatca { get; set; }

    public string AccountNum { get; set; } = null!;

    public string TwguiregNum { get; set; } = null!;

    public string Mxtarcode { get; set; } = null!;

    public string PeaddressId { get; set; } = null!;

    public string PeretentionRegime { get; set; } = null!;

    public string TaxEntityType { get; set; } = null!;

    public int IngstcomplianceRate { get; set; }

    public string IntaxRegistrationId { get; set; } = null!;

    public int TinvalidationStatus { get; set; }

    public bool ImporterOfRecord { get; set; }

    public bool PlautomaticApinvoiceNum { get; set; }

    public string Sec { get; set; } = null!;

    public string MxdiottranType { get; set; } = null!;

    public string Us1099kmerchCatCode { get; set; } = null!;

    public string MxtaxpayerType { get; set; } = null!;

    public string MxlegalRepRfc { get; set; } = null!;

    public string MxlegalRepCurp { get; set; } = null!;

    public string MxlegalRepName { get; set; } = null!;

    public string MxlegalRepTaxpayerType { get; set; } = null!;

    public string Us1099state { get; set; } = null!;

    public int TaxValidationStatus { get; set; }

    public DateTime? TaxValidationDate { get; set; }

    public string HmrctaxValidationLog { get; set; } = null!;

    public string ExternalSchemeId { get; set; } = null!;

    public string Mxmunicipio { get; set; } = null!;

    public bool Einvoice { get; set; }

    public Guid? ForeignSysRowId { get; set; }

    public byte[]? UdSysRevId { get; set; }

    public decimal? Uddecimal1C { get; set; }

    public decimal? Uddecimal2C { get; set; }

    public string? Udstring1C { get; set; }

    public string? Udstring2C { get; set; }

    public string? NameC { get; set; }

    public decimal? Number01 { get; set; }

    public bool? CertapprovedC { get; set; }

    public DateOnly? CertadateC { get; set; }

    public DateOnly? CertedateC { get; set; }

    public string? Character01 { get; set; }

    public string? Character02 { get; set; }

    public string? Character03 { get; set; }

    public string? Character04 { get; set; }

    public string? Character05 { get; set; }

    public bool? CheckBox01 { get; set; }

    public bool? CheckBox02 { get; set; }

    public bool? CheckBox03 { get; set; }

    public bool? CheckBox04 { get; set; }

    public bool? CheckBox05 { get; set; }

    public DateTime? Date01 { get; set; }

    public DateTime? Date02 { get; set; }

    public DateTime? Date03 { get; set; }

    public DateTime? Date04 { get; set; }

    public DateTime? Date05 { get; set; }

    public decimal? Number02 { get; set; }

    public decimal? Number03 { get; set; }

    public decimal? Number04 { get; set; }

    public decimal? Number05 { get; set; }

    public string? AdtSupNameC { get; set; }
}
