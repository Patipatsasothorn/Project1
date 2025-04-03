using System;
using System.Collections.Generic;

namespace BPI_TransBill.Models;

public partial class ApinvHeadVendor
{
    public long ApinvId { get; set; }

    public string? Company { get; set; }

    public string? ApinvNo { get; set; }

    public DateTime? ApinvDate { get; set; }

    public long? BillId { get; set; }

    public double? ApinvAmt { get; set; }

    public double? Whtamt { get; set; }

    public string? CustIdfuel { get; set; }

    public double? CustIdfuelBal { get; set; }

    public int? FiscalYear { get; set; }

    public byte? FiscalPeriod { get; set; }

    public double? FuelAmt { get; set; }

    public string? CustIddamage { get; set; }

    public double? CustIddamageBal { get; set; }

    public double? DamageAmt { get; set; }

    public DateTime? PayDay { get; set; }

    public byte? ApinvStatus { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? UpdateBy { get; set; }
}
