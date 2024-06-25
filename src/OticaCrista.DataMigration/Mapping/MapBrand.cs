using CsvHelper.Configuration;
using SistOtica.Models.Product;

namespace OticaCrista.DataMigration.Mapping
{
    public class MapBrand : ClassMap<BrandModel>
    {
        public MapBrand() 
        {
            Map(b => b.Id).Name("marcaId");
            Map(b => b.Name).Name("marcaNome");
        }
    }
}
