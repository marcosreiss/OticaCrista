using CsvHelper;
using CsvHelper.Configuration;
using MySql.Data.MySqlClient;
using OticaCrista.DataMigration.Mapping;
using SistOtica.Models.Product;
using System.Globalization;

namespace OticaCrista.DataMigration.Imports
{
    public static class Imports
    {
        private static string DefaultPaht = @"C:\Users\mvini\Documents\2024.1\otica\csv\";

        private static CsvConfiguration config 
            = new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = true, };

        private static string connectionString = "Server=roundhouse.proxy.rlwy.net; User=root; Password=GTwHDxUKycANtQvesIKsytxrlRVDGFCY;Port=51555; Database=oticacristadb";


        public static void ImportBrand()
        {
            var path = DefaultPaht + "marca.csv";
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<MapBrand>();
                var records = csv.GetRecords<BrandModel>().ToList();

                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (var record in records)
                    {
                        string query = "use oticacristadb; insert into Brands (Id, Name) values (@id, @name)";

                        using (var command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@id", record.Id);
                            command.Parameters.AddWithValue("@Name", record.Name);

                            command.ExecuteNonQuery();
                        }
                    }
                    Console.WriteLine("dados importados com sucesso");
                }
            }
        }
    }
}
