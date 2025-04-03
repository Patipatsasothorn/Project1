using System;
using System.Collections.Generic;

namespace BPI_TransBill.Models.Data;

public partial class BillingNoteH
{
    public long BillId { get; set; }

    public string Company { get; set; }

    public string BillNo { get; set; }

    public DateTime? BillDate { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public byte CarType { get; set; }

    public string? VendorCode { get; set; }

    public string? PaidCode { get; set; }

    public string? PaidName { get; set; }

    public string? DriverName { get; set; }

    public string? EmpId { get; set; }

    public string? StaffGen { get; set; }

    public string? StaffId { get; set; }

    public byte DocStatus { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? CreateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? UpdateBy { get; set; }
}
