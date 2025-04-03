namespace BPI_TransBill.Models
{
    public class ContractorDebtDetailModel
    {
        public int Order { get; set; } // ลำดับ
        public DateTime? DeliveryDate { get; set; } // วันที่ส่งของ
        public string InvoiceNo { get; set; } // เลขที่ใบเบิก
        public string LicensePlate { get; set; } // ทะเบียนรถ
        public string Product { get; set; } // รายการสินค้า
        public decimal? Quantity { get; set; } // จำนวน (ตัน)
        public string OrderedBy { get; set; } // นามสั่งสินค้า
        public string DeliveryLocation { get; set; } // สถานที่ส่ง
        public decimal? NetWeight { get; set; } // น้ำหนักสุทธิ
        public decimal? FreightRate { get; set; } // อัตราค่าบรรทุก
        public decimal? TotalAmount { get; set; } // จำนวนเงิน (บาท)
        public decimal? Distance { get; set; } // ระยะทาง
        public decimal? Compensation { get; set; } // ชดเชย
        public decimal? OilPrice { get; set; } // ราคาน้ำมัน
        public decimal? Difference { get; set; } // ส่วนต่าง
        public string Note { get; set; } // หมายเหตุ
        public string PickupLocation { get; set; } // สถานที่ขึ้นของ
        public bool IsSelected { get; set; } // เลือก
    }

}
