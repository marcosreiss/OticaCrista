using CsvHelper.Configuration;
using OticaCrista.DataMigration.MigrationObjects;
using OticaCrista.Model.Models.Enums;
using System.Globalization;

namespace OticaCrista.DataMigration.Mapping
{
    public class MapPessoa : ClassMap<Pessoa>
    {
        public MapPessoa()
        {
            Map(p => p.Id).Name("pesId");
            Map(p => p.Name).Name("pesNome");
            Map(p => p.PhoneNumber).Name("pesCel");
            Map(p => p.PhoneNumber2).Name("pesTel");
            Map(p => p.Street).Name("pesRua");
            Map(p => p.Neighborhood).Name("pesBairro");
            Map(p => p.City).Name("pesCidade");
            Map(p => p.Uf).Name("pesUf");
            Map(p => p.Cep).Name("pesCep");
            Map(p => p.AddressComplement).Name("pesComp");
            Map(p => p.Email).Name("pesEmail");
            Map(p => p.Cpf).Name("pesDoc");

            Map(p => p.BornDate).Convert(c =>
            {
                var date = c.Row.GetField<string>("pesDataNasc") ?? "16/8/2001";
                if (date == "") date = "16/8/2001";
                var retorno = DateTime.ParseExact(date, "d/M/yyyy", CultureInfo.InvariantCulture);
                return retorno;
            });

            Map(p => p.Gender).Convert(c =>
            {
                var gender = c.Row.GetField<string>("pesSexo");
                return gender == "Masculino" ? Gender.Male : Gender.Female;
            });

        }
    }
}
