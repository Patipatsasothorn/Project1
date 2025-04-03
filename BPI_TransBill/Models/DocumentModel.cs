using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BPI_TransBill.Models
{
    public class DocumentModel
    {
        public string Company { get; set; } // เลขที่ใบตั้งหนี้

        public string ContractorDebtNo { get; set; } // เลขที่ใบตั้งหนี้
        public DateTime ContractorBillingDate { get; set; } // วันที่ตั้งหนี้
        public string ContractorBillNo { get; set; } // เลขที่ใบวางบิล
        public DateTime? BillDate { get; set; } // วันที่วางบิล
        public DateTime? StartDateCarAll { get; set; } // จากวันที่
        public DateTime? StopDateCarAll { get; set; } // ถึงวันที่
        public string ContractorCreditor { get; set; } // เจ้าหนี้
        public string ContractorPayName { get; set; } // จ่ายในนาม
        public string ContractorAddress { get; set; } // ที่อยู่
        public string ContractorStatus { get; set; } // สถานะการตั้งหนี้
        public string CustID { get; set; } // สถานะการตั้งหนี้
        public string CustIDdmg { get; set; } // สถานะการตั้งหนี้
        public DateTime? ContractorPayDate { get; set; } // วันที่กำหนดจ่าย
        public double? Input6 { get; set; } // ค่าที่ 6
        public double? Oildebt { get; set; } // ค่าที่ 6
        public double? Lossdebtor { get; set; } // ค่าที่ 6
        public decimal? Input7 { get; set; } // ภงด.3/ภงด.53 (-1%)
        public decimal? Input8 { get; set; } // ค่าน้ำมัน
        public decimal? Input9 { get; set; } // ค่าเสียหาย
        public decimal? Input10 { get; set; } // คงเหลือ (Input6 - Input7 - Input8 - Input9)
        public long? BillID { get; set; } // คงเหลือ (Input6 - Input7 - Input8 - Input9)
        public byte? Cartype { get; set; } // คงเหลือ (Input6 - Input7 - Input8 - Input9)
        public List<DebtDetailsModel> DebtDetails { get; set; }


    }
}
