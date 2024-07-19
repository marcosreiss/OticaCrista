using SistOtica.Models.Product;
using SistOtica.Models.Sale;
using SistOtica.Models.Service;
using System.Text.Json.Serialization;

namespace OticaCrista.Model.Models.Sale
{
    public class SaleServiceItem
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public ServiceModel Service { get; set; }
        public int Amount { get; set; }
        public double Discount { get; set; }
        public double FinalPrice { get; set; }
        public string? Observation { get; set; }

        [JsonIgnore]
        public SaleModel Sale { get; set; }
        public int SaleId { get; set; }


    }
}
