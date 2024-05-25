using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistOtica.Models.Sale;

namespace SistOtica.Data.Mapping
{
    public class SaleMap
    {
        public SaleMap(EntityTypeBuilder<SaleModel> tb)
        {
            tb.HasKey(x => x.Id);
            tb.HasMany(x => x.Products).WithMany(x => x.Sales);
            tb.HasMany(x => x.Services).WithMany(x => x.Sales);
            tb.HasOne(x => x.Client).WithMany(x => x.Sales);
            tb.HasOne(x => x.Payment).WithOne(x => x.Sale);
            tb.HasOne(x => x.Protocol).WithOne(x => x.Sale);
        }
    }
}
