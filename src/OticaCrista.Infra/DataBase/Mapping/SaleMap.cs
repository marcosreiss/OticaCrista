using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistOtica.Models.Sale;

namespace SistOtica.Data.Mapping
{
    public class SaleMap
    {
        public SaleMap(EntityTypeBuilder<SaleModel> tb)
        {
            tb.HasKey(x => x.Id);
            tb.HasMany(x => x.Products).WithOne(x => x.Sale).OnDelete(DeleteBehavior.Cascade);
            tb.HasMany(x => x.Services).WithOne(x => x.Sale).OnDelete(DeleteBehavior.Cascade);
            tb.HasOne(x => x.Client).WithMany(x => x.Sales);
            tb.HasOne(x => x.Payment).WithOne(x => x.Sale).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
