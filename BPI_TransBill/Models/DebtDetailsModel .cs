namespace BPI_TransBill.Models
{
    public class DebtDetailsModel
    {
        public string Order { get; set; }
        public string DeliveryDate { get; set; }
        public string InvoiceNo { get; set; }
        public string CarRegNo { get; set; }
        public string Product { get; set; }
        public string Quantity { get; set; }
        public string Customer { get; set; }
        public string DeliveryLocation { get; set; }
        public string NetWeight { get; set; }
        public string TransportRate { get; set; }
        public string TotalAmount { get; set; }
        public string Distance { get; set; }
        public string Compensation { get; set; }
        public string FuelPrice { get; set; }
        public string Difference { get; set; }
        public string Remark { get; set; }
        public string DetailID { get; set; }
        public string LoadingLocation { get; set; }
        public string ShipViaCode { get; set; }
        public byte RateType { get; set; }
    }

}
