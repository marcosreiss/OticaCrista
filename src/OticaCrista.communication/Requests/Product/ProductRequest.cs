namespace OticaCrista.communication.Requests.Product
{
    public class ProductRequest
    {
        public string Name { get; set; } = string.Empty;
        public decimal BuyPrice { get; set; }
        public decimal Additon { get; set; }
        public decimal SalePrice { get; set; }
        public int Quantity { get; set; }
        public int BrandId { get; set; }
    }
}
