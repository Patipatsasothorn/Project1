namespace BPI_TransBill.Models.AddInv
{
    public class BillingNoteDViewModel
    {
        // ข้อมูลการขนส่ง
        public string ShipDate { get; set; }
        public string ShipNum { get; set; }
        public string ProjectDesc { get; set; }
        public string PartDescription { get; set; }
        public string ShipToName { get; set; }
        public string ExtCompany { get; set; }
        public string CarNo { get; set; }
        public string DriverName { get; set; }
        public int ShipQty { get; set; }
        public string StaffID { get; set; }
        public string StaffGen { get; set; }
        public double Fuel { get; set; }
        public long BillID { get; set; }
        public double NetWeight { get; set; }
        public double StaffAmt { get; set; }
    }

}
