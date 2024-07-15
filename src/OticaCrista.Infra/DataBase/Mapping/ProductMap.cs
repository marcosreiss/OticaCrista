using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistOtica.Models.Product;

namespace SistOtica.Data.Mapping
{
    public class ProductMap
    {
        public ProductMap(EntityTypeBuilder<ProductModel> tb)
        {
            tb.HasKey(x => x.Id);
            tb.HasOne(x => x.Brand).WithMany(x => x.Products).HasForeignKey(x => x.BrandId);
            tb.Property(x => x.Name).IsRequired().HasMaxLength(255);
        }
    }
}
