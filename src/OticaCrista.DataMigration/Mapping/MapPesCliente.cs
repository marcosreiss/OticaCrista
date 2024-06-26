using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using OticaCrista.DataMigration.MigrationObjects;

namespace OticaCrista.DataMigration.Mapping
{
    public class MapPesCliente : ClassMap<PesCliente>
    {
        public MapPesCliente()
        {
            Map(p => p.ClientId).Name("cliPessoa");
            Map(p => p.Spouse).Name("cliConjuge");
            Map(p => p.Parents).Name("cliFiliacao");
            Map(p => p.RefName1).Name("cliRefNome1");
            Map(p => p.RefPhoneNumber1).Name("cliRefContato1");
            Map(p => p.RefName2).Name("cliRefNome2");
            Map(p => p.RefPhoneNumber2).Name("cliRefContato2");
            Map(p => p.RefName3).Name("cliRefNome3");
            Map(p => p.RefPhoneNumber3).Name("cliRefContato3");
            Map(p => p.Spc).Convert(c => c.Row.GetField<string>("cliSpc") == "Sim");
            Map(p => p.Rg).Name("cliRg");
            Map(p => p.Ocupation).Name("cliProfissao");
            Map(p => p.Company).Name("cliEmpresa");
            Map(p => p.PreciusSales).Name("cliAtendimentos");
            
            

        }
    }
}
