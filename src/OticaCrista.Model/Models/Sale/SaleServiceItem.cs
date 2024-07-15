using SistOtica.Models.Product;
using SistOtica.Models.Sale;
using SistOtica.Models.Service;

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

        public List<SaleModel>? Sales { get; set; }

    }
}
