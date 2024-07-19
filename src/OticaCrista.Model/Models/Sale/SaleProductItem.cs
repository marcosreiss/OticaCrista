using SistOtica.Models.Product;
using SistOtica.Models.Sale;
using System.Text.Json.Serialization;

namespace OticaCrista.Model.Models.Sale
{
    public class SaleProductItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
        public int Amount { get; set; }
        public double Discount { get; set; }
        public double FinalPrice { get; set; }
        public string? Observation { get; set; }

        [JsonIgnore]
        public SaleModel Sale { get; set; }
        public int SaleId { get; set; }
    }
}
