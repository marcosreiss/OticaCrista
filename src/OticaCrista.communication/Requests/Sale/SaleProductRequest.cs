namespace OticaCrista.communication.Requests.Sale
{
    public class SaleProductRequest
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public double Discount { get; set; }
        public double FinalPrice { get; set; }
        public string? Observation { get; set; }
    }
}
