using System;
using System.Collections.Generic;

namespace BPI_TransBill.Models.Data;

public partial class BillingNoteD
{
    public long DetailId { get; set; }

    public long BillId { get; set; }

    public string ShipNum { get; set; }

    public DateTime? ShipDate { get; set; }

    public string CarNo { get; set; }

    public string ShipViaCode { get; set; }

    public string Partnum { get; set; }

    public string ProjectId { get; set; }

    public int ShipQty { get; set; }

    public string CustNum { get; set; }

    public string ShipToNum { get; set; }

    public double NetWeight { get; set; }

    public string ExtCompany { get; set; }

    public double Fuel { get; set; }

    public byte DetailStatus { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? CreateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? UpdateBy { get; set; }

    public string? StaffId { get; set; }

    public string? StaffGen { get; set; }

    public double? StaffAmt { get; set; }

    public string? DeliveryRoudNo { get; set; }

    public byte? DeliveryNo { get; set; }
    public string? ShipSet { get; set; }
}
