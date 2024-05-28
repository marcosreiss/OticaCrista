using SistOtica.Models.Sale;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistOtica.Models.Product
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public required decimal BuyPrice { get; set; }

        public decimal Addition { get; set; } = 100; 

        public decimal SalePrice { get; set; }

        public int Quantity  { get; set; }


        [ForeignKey("BrandId")]
        [InverseProperty("Products")]
        public required int BrandId { get; set; }

        public required virtual BrandModel brand { get; set; }


        public ICollection<SaleModel>? Sales { get; set; }

    }
}
