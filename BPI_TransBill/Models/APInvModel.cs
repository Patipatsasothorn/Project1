using Microsoft.AspNetCore.Mvc;

namespace APInv.Models;

public class APInvModel
{
    public long BillID { get; set; }   // เลขที่ใบเบิก
    public string Company { get; set; } = null!;
    public string BillNo { get; set; } = null!;
    public DateTime BillDate { get; set; }

    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public byte CarType { get; set; }   // เลขที่ใบเบิก
    public string? VendorCode { get; set; } = null!;
    public string? PaidCode { get; set; } = null!;
    public string? DriverName { get; set; }
    public string? EmpID { get; set; }
    public string? StaffGen { get; set; }
    public string? StaffID { get; set; }

    public byte DocStatus { get; set; }   // เลขที่ใบเบิก

    public DateTime? CreateDate { get; set; }
    public string CreateBy { get; set; } = null!;
    public DateTime? UpdateDate { get; set; }
    public string? UpdateBy { get; set; }
    public string? addres { get; set; }

    public string? name { get; set; }

    public string? namet { get; set; }
    public double? Fuel { get; set; }


}
