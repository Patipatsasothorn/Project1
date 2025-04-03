namespace BPI_TransBill.Models.AddInv
{
    public class DeliveryInfo
    {
        //public bool SelectRow { get; set; }   // สำหรับ checkbox
        public string InvDate { get; set; }  // วันที่
        public string InvNum { get; set; }     // เลขที่ใบส่งของ
        public string CarNum { get; set; }     // ทะเบียนรถ
        public string PartNum { get; set; }    // รหัสสินค้า
        public int ShipQty { get; set; }       // จำนวนท่อน
        public string DriverName { get; set; } // คนขับ
        public string InvSend { get; set; }    // สถานที่ส่ง
        public decimal NetWeight { get; set; } // น้ำหนักรวม (ตัน)
        public string InvLocation { get; set; } // สถานที่ขึ้นของ
        public string StaffId { get; set; }    // ชื่อเด็กรถ
        public string Gender { get; set; }     // เพศ
        public string ShipCost { get; set; }  // ค่าบรรทุก
        public string FuelPrice { get; set; } // น้ำมัน
        public string ShipViaCode { get; set; } // น้ำมัน
        public string ProjectId { get; set; } // น้ำมัน
        public string CustNum { get; set; } // น้ำมัน
        public string ShipToNum { get; set; } // น้ำมัน
        public string ExtCompany { get; set; } // น้ำมัน
        public string DeliveryRoundNo { get; set; } // น้ำมัน
        public byte DeliveryNo { get; set; } // น้ำมัน
        public bool ShipSet { get; set; } // น้ำมัน
    }
}
