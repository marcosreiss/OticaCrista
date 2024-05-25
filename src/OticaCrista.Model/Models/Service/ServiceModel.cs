using SistOtica.Models.Sale;

namespace SistOtica.Models.Service
{
    public class ServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public ICollection<SaleModel> Sales { get; set; } = new List<SaleModel>();
    }
}
