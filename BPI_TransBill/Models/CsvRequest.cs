namespace BPI_TransBill.Models
{
    public class CsvRequest
    {
        public string CsvData { get; set; } // เนื้อหาของไฟล์ CSV
        public string FileName { get; set; } // ชื่อไฟล์ที่ต้องการบันทึก
    }

}
