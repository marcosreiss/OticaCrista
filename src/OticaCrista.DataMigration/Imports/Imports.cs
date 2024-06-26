using CsvHelper;
using CsvHelper.Configuration;
using MySql.Data.MySqlClient;
using OticaCrista.DataMigration.Mapping;
using OticaCrista.DataMigration.MigrationObjects;
using SistOtica.Models.Client;
using SistOtica.Models.Product;
using System.Globalization;
using System.Text.Json;

namespace OticaCrista.DataMigration.Imports
{
    public static class Imports
    {
        private static string DefaultPath = @"C:\Users\mvini\Documents\2024.1\otica\csv\";

        private static CsvConfiguration config 
            = new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = true, };

        private static string connectionString = "Server=roundhouse.proxy.rlwy.net; User=root; Password=GTwHDxUKycANtQvesIKsytxrlRVDGFCY;Port=51555; Database=oticacristadb";


        public static void ImportBrand()
        {
            var path = DefaultPath + "marca.csv";
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
                    connection.Close();
                    Console.WriteLine("dados importados com sucesso");
                }
            }
        }

        public static void ImportClient()
        {
            #region Lendo Dados do CSV

            var pathPessoa = DefaultPath + "pessoa.csv";
            var pessoa = new List<Pessoa>();

            var pathPesCliente = DefaultPath + "pesCliente.csv";
            var pesCliente = new List<PesCliente>();

            using(var  reader = new StreamReader(pathPessoa))
            using(var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<MapPessoa>();
                pessoa = csv.GetRecords<Pessoa>().ToList();
            }
            Console.WriteLine("Dados Lidos do aquivo pessoa.csv ...");
            Console.ReadLine();

            using (var reader = new StreamReader(pathPesCliente))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<MapPesCliente>();
                pesCliente = csv.GetRecords<PesCliente>().ToList();
            }
            Console.WriteLine("Dados Lidos do aquivo pesCliente.csv ...");
            Console.ReadLine();

            #endregion

            #region Populando Dados no Modelo

            var clients = new List<ClientModel>();
            var contacts = new List<ClientContact>();
            var references = new List<ClientReferences>();
            foreach (var p in pessoa)
            {
                #region Client

                var pCliente =  pesCliente.FirstOrDefault(c => c.ClientId == p.Id);
                var newClient = new ClientModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Cpf = p.Cpf,
                    Rg = pCliente?.Rg ?? "",
                    BornDate = DateOnly.FromDateTime(p.BornDate),
                    Gender = p.Gender,
                    //nome do pai
                    //nome da mae
                    SpouseName = pCliente?.Spouse ?? "",
                    //email
                    Company = pCliente?.Company ?? "",
                    Ocupation = pCliente?.Ocupation ?? "",
                    Street = p.Street ?? "",
                    Neighborhood = p.Neighborhood ?? "",
                    City = p.City ?? "",
                    Uf = p.Uf ?? "",
                    Cep = p.Cep ?? "",
                    AddressComplement = p.AddressComplement ?? "",
                    Negativated = (pCliente?.Spc == null) ? false : (bool)pCliente?.Spc,
                    Observation = p.Email ?? ""
                };

                var parents = pCliente?.Parents.Split(" E ");
                newClient.MotherName = parents?[0];
                if(parents?.Length > 1) newClient.FatherName = parents?[1];

                clients.Add(newClient);

                #endregion

                #region Contact
                if(p.PhoneNumber != null)
                {
                    var newContact = new ClientContact
                    {
                        PhoneNumber = p.PhoneNumber,
                        ClientId = p.Id,
                    };
                    contacts.Add(newContact);
                }
                if(p.PhoneNumber2 != null)
                {
                    var newContact = new ClientContact
                    {
                         ClientId = p.Id,
                         PhoneNumber = p.PhoneNumber2,
                    };
                    contacts.Add(newContact);
                }
                #endregion

                #region References

                if(pCliente?.RefName1 != null)
                {
                    var reference = new ClientReferences
                    {
                        ClientId = p.Id,
                        Name = pCliente.RefName1,
                        PhoneNumber = pCliente.RefPhoneNumber1
                    };
                    references.Add(reference);
                }

                if (pCliente?.RefName2 != null)
                {
                    var reference = new ClientReferences
                    {
                        ClientId = p.Id,
                        Name = pCliente.RefName2,
                        PhoneNumber = pCliente.RefPhoneNumber2
                    };
                    references.Add(reference);
                }

                if (pCliente?.RefName3 != null)
                {
                    var reference = new ClientReferences
                    {
                        ClientId = p.Id,
                        Name = pCliente.RefName3,
                        PhoneNumber = pCliente.RefPhoneNumber3
                    };
                    references.Add(reference);
                }

                #endregion
            }
            Console.WriteLine("Dados Populados no modelo (ClientModel, ClientContact, ClientReference) ...");
            Console.ReadLine();

            #endregion

            #region Persistindo Dados no Banco
            Console.Clear();
            Console.WriteLine("Iniciando Processo de Popular os dados no Banco. \nenter para continuar...");
            Console.ReadLine();
            Console.Clear();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                foreach (var client in clients)
                {
                    string query
                        = "use oticacristadb; " +
                        "INSERT INTO Clients " +
                        "( Id, Name, Cpf, Rg, BornDate, FatherName, MotherName, SpouseName, " +
                        "EmailAddress, Company, Ocupation, Street, Neighborhood, City, Uf, Cep, " +
                        "AddressComplement, Negativated, Observation, Gender ) " +
                        "VALUES ( @id, @name, @cpf, @rg, @bornDate, @fatherName, @motherName, @spouseName, " +
                        "@emailAddress, @company, @ocupation, @street, @neighborhood, @city, @uf, @cep, " +
                        "@addressComplement, @negativated, @observation, @gender );";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", client.Id);
                        command.Parameters.AddWithValue("@name", client.Name);
                        command.Parameters.AddWithValue("@cpf", client.Cpf);
                        command.Parameters.AddWithValue("@rg", client.Rg);
                        command.Parameters.AddWithValue("@bornDate", DateTime.Parse(client.BornDate.ToString()));
                        command.Parameters.AddWithValue("@fatherName", client.FatherName);
                        command.Parameters.AddWithValue("@motherName", client.MotherName);
                        command.Parameters.AddWithValue("@spouseName", client.SpouseName);
                        command.Parameters.AddWithValue("@emailAddress", client.EmailAddress);
                        command.Parameters.AddWithValue("@company", client.Company);
                        command.Parameters.AddWithValue("@ocupation", client.Ocupation);
                        command.Parameters.AddWithValue("@street", client.Street);
                        command.Parameters.AddWithValue("@neighborhood", client.Neighborhood);
                        command.Parameters.AddWithValue("@city", client.City);
                        command.Parameters.AddWithValue("@uf", client.Uf);
                        command.Parameters.AddWithValue("@cep", client.Cep);
                        command.Parameters.AddWithValue("@addressComplement", client.AddressComplement);
                        command.Parameters.AddWithValue("@negativated", client.Negativated);
                        command.Parameters.AddWithValue("@observation", client.Observation);
                        command.Parameters.AddWithValue("@gender", client.Gender);

                        command.ExecuteNonQuery();
                    }

                }
                Console.WriteLine("Lista de Clientes Persistida no banco com sucesso ...");
                Console.ReadLine();

                foreach (var contact in contacts)
                {
                    string query
                        = "INSERT INTO Contacts ( PhoneNumber, ClientId ) " +
                        "VALUES ( @phoneNumber, @clientId );";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@phoneNumber", contact.PhoneNumber);
                        command.Parameters.AddWithValue("@clientId", contact.ClientId);

                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Lista de Contatos Persistida no banco com sucesso ...");
                Console.ReadLine();


                //var referenceCount = references.Count();
                //var currentRef = 1;
                foreach (var reference in references)
                {
                    
                    string query
                        = "INSERT INTO `References` ( Name, PhoneNumber, ClientId ) " +
                        "VALUES ( @name, @phoneNumber, @clientId );";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", reference.Name);
                        command.Parameters.AddWithValue("@phoneNumber", reference.PhoneNumber);
                        command.Parameters.AddWithValue("@clientId", reference.ClientId);

                        command.ExecuteNonQuery();
                    }
                    //Console.Clear();
                    //Console.WriteLine("Cadastrando Referências");
                    //Console.WriteLine($"progresso: {currentRef}/{referenceCount}");
                    //currentRef++;
                }
                Console.WriteLine("Lista de Referencias Persistida no banco com sucesso ...");
                Console.ReadLine();

                connection.Close();
            }
            Console.WriteLine("\n\n\nSucesso na Imporação!");

            #endregion
        }
    }
}
