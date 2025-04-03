using BPI_TransBill.Models.AddInv;
using BPI_TransBill.Models.Data.Store;

namespace BPI_TransBill.Models
{
    public class AddInvoiceModel
    {
        public string Company { get; set; } // Primary Key
        public string InvNo { get; set; } // Primary Key
        public string BillId { get; set; } // Primary Key
        public string BillDate { get; set; } // วันที่ใบส่งของ
        public string FromDate { get; set; } // วันที่ใบส่งของ
        public string ToDate { get; set; } // วันที่ใบส่งของ
        public byte CarType { get; set; } // วันที่ใบส่งของ
        public string DocStatus { get; set; } // วันที่ใบส่งของ
        public string VendorCode { get; set; } // วันที่ใบส่งของ
        public string PaidName { get; set; } // วันที่ใบส่งของ
        public string DriverName { get; set; } // วันที่ใบส่งของ
        public string EmpId { get; set; } // วันที่ใบส่งของ
        public string StaffId { get; set; } // วันที่ใบส่งของ
        public string StaffGen { get; set; } // วันที่ใบส่งของ
        public string FuelPrice { get; set; } // วันที่ใบส่งของ
        public List<DeliveryInfo> deliveryInfos { get; set; }
    }
}
