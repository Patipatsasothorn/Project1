using System;
using System.Collections.Generic;

namespace BPI_TransBill.Models.Data.UAT2;

public partial class EmpBasic
{
    public string Company { get; set; } = null!;

    public string EmpId { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string MiddleInitial { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Address2 { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Zip { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string EmgPhone { get; set; } = null!;

    public int Shift { get; set; }

    public decimal LaborRate { get; set; }

    public bool Payroll { get; set; }

    public bool PrsetupReq { get; set; }

    public string EmpStatus { get; set; } = null!;

    public string ExpenseCode { get; set; } = null!;

    public string PhotoFile { get; set; } = null!;

    public string Jcdept { get; set; } = null!;

    public string EmgContact { get; set; } = null!;

    public string SupervisorId { get; set; } = null!;

    public int CountryNum { get; set; }

    public bool ServTech { get; set; }

    public string EmailAddress { get; set; } = null!;

    public string DcdUserId { get; set; } = null!;

    public bool ProductionWorker { get; set; }

    public bool MaterialHandler { get; set; }

    public bool ShopSupervisor { get; set; }

    public bool CanReportQty { get; set; }

    public bool CanOverrideJob { get; set; }

    public bool CanRequestMaterial { get; set; }

    public bool CanReportScrapQty { get; set; }

    public bool CanReportNcqty { get; set; }

    public bool ShipRecv { get; set; }

    public string CnvEmpId { get; set; } = null!;

    public bool WarehouseManager { get; set; }

    public bool CanOverrideAllocations { get; set; }

    public bool AllowDirLbr { get; set; }

    public bool ContractEmp { get; set; }

    public string ResourceGrpId { get; set; } = null!;

    public string ResourceId { get; set; } = null!;

    public string TimeWfgroupId { get; set; } = null!;

    public bool ExpenseEntryAllowed { get; set; }

    public string ExpenseWfgroupId { get; set; } = null!;

    public int ExpenseVendorNum { get; set; }

    public int PerConId { get; set; }

    public bool SyncNameToPerCon { get; set; }

    public bool SyncAddressToPerCon { get; set; }

    public bool SyncPhoneToPerCon { get; set; }

    public bool SyncEmailToPerCon { get; set; }

    public bool CanEnterIndirectTime { get; set; }

    public bool CanEnterProductionTime { get; set; }

    public bool CanEnterProjectTime { get; set; }

    public bool CanEnterServiceTime { get; set; }

    public bool CanEnterSetupTime { get; set; }

    public bool TimeAutoApprove { get; set; }

    public bool ExpenseAutoApprove { get; set; }

    public string MobileUserPassword { get; set; } = null!;

    public bool AllowIndirect { get; set; }

    public bool AllowProduction { get; set; }

    public bool AllowProject { get; set; }

    public bool AllowService { get; set; }

    public bool AllowSetup { get; set; }

    public string DefaultLaborTypePseudo { get; set; } = null!;

    public string DefaultTimeTypCd { get; set; } = null!;

    public string DefaultIndirectCode { get; set; } = null!;

    public string DefaultExpenseCode { get; set; } = null!;

    public string DefaultResourceGrpId { get; set; } = null!;

    public string DefaultResourceId { get; set; } = null!;

    public decimal DefaultLaborHrs { get; set; }

    public string DefaultExpCurrencyCode { get; set; } = null!;

    public string DefaultClaimCurrencyCode { get; set; } = null!;

    public int DefaultPmuid { get; set; }

    public string DefaultTaxRegionCode { get; set; } = null!;

    public bool DefaultTaxIncluded { get; set; }

    public bool ExpenseAdvReqAllowed { get; set; }

    public string ExpenseAdvReqWfgroupId { get; set; } = null!;

    public bool ExpenseAdvReqAutoApprove { get; set; }

    public string MobileResourceId { get; set; } = null!;

    public bool AllowAsAltRemitTo { get; set; }

    public string UserNameInJdf { get; set; } = null!;

    public byte[]? EmployeePhoto { get; set; }

    public bool ExternalMes { get; set; }

    public bool PermitScrap { get; set; }

    public bool PermitDown { get; set; }

    public bool PermitHelp { get; set; }

    public bool PermitJobControl { get; set; }

    public bool PermitNextJobControl { get; set; }

    public bool PermitManualSqc { get; set; }

    public bool PermitVariableSqc { get; set; }

    public bool PermitAttributeSqc { get; set; }

    public bool PermitMaterialLot { get; set; }

    public bool PermitSetupMaterial { get; set; }

    public bool PermitCavities { get; set; }

    public bool PermitPercentRegrind { get; set; }

    public bool PermitSaveProfile { get; set; }

    public bool PermitCalibration { get; set; }

    public bool PermitMachinePm { get; set; }

    public bool PermitToolPm { get; set; }

    public bool PermitLanguage { get; set; }

    public bool PermitPreferences { get; set; }

    public byte[] SysRevId { get; set; } = null!;

    public Guid SysRowId { get; set; }

    public bool DisallowTimeEntry { get; set; }

    public bool PkgInboundAllowed { get; set; }

    public bool PkgOutboundAllowed { get; set; }

    public bool PkgInventoryAllowed { get; set; }

    public bool PkgManufacturingAllowed { get; set; }

    public bool PkgQualityAllowed { get; set; }

    public string ImageId { get; set; } = null!;

    public bool PkgMasterMixedPrint { get; set; }

    public bool PkgSuppressPrintMessages { get; set; }

    public string PayrollValuesForHcm { get; set; } = null!;

    public bool SendToFsa { get; set; }

    public bool ExternalMessyncRequired { get; set; }

    public DateTime? ExternalMeslastSync { get; set; }

    public string Iddocument { get; set; } = null!;

    public DateOnly? BirthDate { get; set; }

    public string Sex { get; set; } = null!;

    public string Department { get; set; } = null!;

    public DateOnly? EnrollmentDate { get; set; }

    public DateOnly? DepartureDate { get; set; }

    public Guid? ForeignSysRowId { get; set; }

    public byte[]? UdSysRevId { get; set; }

    public string? ShortChar09 { get; set; }

    public string? ShortChar10 { get; set; }

    public string? BpiUserIdC { get; set; }

    public string? BpiUserFileNameC { get; set; }
}
