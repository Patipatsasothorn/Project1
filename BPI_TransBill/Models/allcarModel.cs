using Microsoft.AspNetCore.Mvc;

namespace BPI_TransBill.Models;

public class allcarModel
{
    public string ShipNum { get; set; } = null!;  // เลขที่ใบเบิก
    public string PartDescription { get; set; } = null!;
    public int ShipQty { get; set; }
    public string Cname { get; set; } = null!;
    public string Sname { get; set; } = null!;
    public double NetWeight { get; set; }
    public double ShipRate { get; set; }
    public DateTime? ShipDate { get; set; }

    public string CarNo { get; set; } = null!;
    public string ShipViaCode { get; set; } = null!;
    public string ShipSet { get; set; } = null!;
    public double bath { get; set; }
    public double distance { get; set; }
    public bool compensate { get; set; }
    public bool HasAPInvDetail { get; set; }
    public decimal diesel { get; set; }
    public double compensateValue { get; set; }
    public string extcompany { get; set; } = null!;
    public string Remark { get; set; } = null!;
    public Int64 DetailID { get; set; }
    public byte? DeliveryNo { get; set; }
    public byte? RateType { get; set; }

}
