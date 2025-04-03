using System.ComponentModel.DataAnnotations;

namespace BPI_TransBill.Models
{
    public class BillingNoteViewModel
    {
        public string BillDate { get; set; }
        [Key]
        public string BillNo { get; set; }
        public string? VendorCode { get; set; }
        public string? VendorName { get; set; }
        public string? DriverName { get; set; }
        public string CarType { get; set; }
        public string DocStatus { get; set; }
    }
}
