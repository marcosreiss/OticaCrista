using System.Text.Json.Serialization;

namespace SistOtica.Models.Product
{
    public class BrandModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<ProductModel>? Products { get; set; } = new List<ProductModel>();
    }
}
