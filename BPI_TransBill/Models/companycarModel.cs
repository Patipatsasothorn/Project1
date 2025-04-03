namespace BPI_TransBill.Models
{
    public class companycarModel
    {
        public string ShipNum { get; set; } = null!;  // เลขที่ใบเบิก
        public string PartDescription { get; set; } = null!;
        public int ShipQty { get; set; }
        public string Cname { get; set; } = null!;
        public string Sname { get; set; } = null!;
        public double NetWeight { get; set; }
        public string ShipRate { get; set; }
        public DateTime ShipDate { get; set; }

        public string CarNo { get; set; } = null!;
        public string ShipViaCode { get; set; } = null!;
        public double bath { get; set; }
        public double distance { get; set; }
        public bool compensate { get; set; }
        public decimal diesel { get; set; }
        public double compensateValue { get; set; }
        public string extcompany { get; set; } = null!;
        public Int64 DetailID { get; set; }
        public double DriverRate { get; set; }
        public double Fuel { get; set; }
        public byte? RateType { get; set; }
    }
}
