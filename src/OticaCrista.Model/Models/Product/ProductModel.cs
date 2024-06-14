using SistOtica.Models.Sale;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SistOtica.Models.Product
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public required decimal BuyPrice { get; set; }

        public decimal Addition { get; set; } = 100; 

        public decimal SalePrice { get; set; }

        public int Quantity  { get; set; }


        [ForeignKey("BrandId")]
        [InverseProperty("Products")]
        public required int BrandId { get; set; }

        public virtual BrandModel brand { get; set; }

        [JsonIgnore]
        public ICollection<SaleModel>? Sales { get; set; }

    }
}
