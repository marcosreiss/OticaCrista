using SistOtica.Models.Sale;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistOtica.Models.Product
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string BuyPrice { get; set; }

        public double Addition { get; set; } = 100; //lucro

        public string SalePrice { get; set; }

        public int Quantity  { get; set; }


        [ForeignKey("BrandId")]
        [InverseProperty("Products")]
        public int BrandId { get; set; }

        public virtual BrandModel brand { get; set; }


        public ICollection<SaleModel> Sales { get; set; } = new List<SaleModel>();

    }
}
