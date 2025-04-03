using System;
using System.Collections.Generic;

namespace BPI_TransBill.Models;

public partial class ApinvDetail
{
    public long ApinvDetailId { get; set; }

    public string? Company { get; set; }

    public long? ApinvId { get; set; }

    public long? DetailId { get; set; }

    public double? NeetWeight { get; set; }

    public byte? RateType { get; set; }

    public double? Rate { get; set; }

    public string? TransAmt { get; set; }

    public double? Distance { get; set; }

    public bool? Compensate { get; set; }

    public string? ShipViaCode { get; set; }

    public double? OilPrice { get; set; }

    public double? DiffOilPrice { get; set; }

    public double? DriverRate { get; set; }

    public double? StaffRate { get; set; }

    public double? FuelAmt { get; set; }

    public byte? DetailStatus { get; set; }

    public string? Remark { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? CreateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? UpdateBy { get; set; }
}
