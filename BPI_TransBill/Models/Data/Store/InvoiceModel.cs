namespace BPI_TransBill.Models.Data.Store
{
    public class InvoiceModel
    {
        public string InvDate { get; set; }  // วันที่
        public string InvNum { get; set; }   // เลขที่ใบส่งของ
        public string CarNum { get; set; }   // ทะเบียนรถ
        public string PartNum { get; set; }  // รหัสสินค้า
        public string PartDesc { get; set; }  // รหัสสินค้า
        public int ShipQty { get; set; }     // จำนวนท่อน
        public string DriverName { get; set; } // คนขับ
        public string InvSend { get; set; }  // สถานที่ส่ง
        public decimal TotalWeight { get; set; } // น้ำหนักรวม (NetWeight / 1000 * ShipQty)
        public string InvLocation { get; set; } // สถานที่ขึ้นของ
        public string ShipViaCode { get; set; } // ประเภทรถ
        public string CustNum { get; set; }   // CustNum
        public string ShipToNum { get; set; } // ShipToNum
        public string ExtCompany { get; set; } // ExtCompany
        public string ProjectId { get; set; } // ProjectId
        public string DeliveryRoundNo { get; set; } // ProjectId
        public decimal DeliveryNo { get; set; } // ProjectId

    }
}
