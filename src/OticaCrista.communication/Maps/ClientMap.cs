using OticaCrista.communication.Requests.Client;
using SistOtica.Models.Client;

namespace OticaCrista.communication.Maps
{
    public class ClientMap
    {
        public ClientRequest ClientToRequest(ClientModel client)
        {
            var request = new ClientRequest 
            {
                Name = client.Name,
                Cpf = client.Cpf,
                Rg = client.Rg,
                BornDate = client.BornDate,
                FatherName = client.FatherName,
                MotherName = client.MotherName,
                SpouseName = client.SpouseName,
                EmailAddress = client.EmailAddress,
                Company = client.Company,
                Ocupation = client.Ocupation,
                Street = client.Street,
                Neighborhood = client.Neighborhood,
                City = client.City,
                Uf = client.Uf,
                Cep = client.Cep,
                AddressComplement = client.AddressComplement,
                Negativated = client.Negativated,
                Observation = client.Observation,
            };

            var contacts = new List<ContactJson>();
            var references = new List<ReferenceJson>();
            if (client.Contacts != null)
            {
                foreach (var contact in client.Contacts)
                {
                    var contactJson = new ContactJson { PhoneNumber = contact.PhoneNumber };
                    contacts.Add(contactJson);
                }
                request.Contacts = contacts;
            }
            if (client.References != null)
            {
                foreach (var reference in client.References)
                {
                    var referenceJson = new ReferenceJson
                    {
                        Name = reference.Name,
                        PhoneNumber = reference.PhoneNumber
                    };
                    references.Add(referenceJson);
                }
                request.References = references;
            }

            return request;
        }

        public ClientModel RequestToClient(ClientRequest request)
        {
            var client = new ClientModel
            {
                Name = request.Name,
                Cpf = request.Cpf,
                Rg = request.Rg,
                BornDate = request.BornDate,
                FatherName = request.FatherName,
                MotherName = request.MotherName,
                SpouseName = request.SpouseName,
                EmailAddress = request.EmailAddress,
                Company = request.Company,
                Ocupation = request.Ocupation,
                Street = request.Street,
                Neighborhood = request.Neighborhood,
                City = request.City,
                Uf = request.Uf,
                Cep = request.Cep,
                AddressComplement = request.AddressComplement,
                Negativated = request.Negativated,
                Observation = request.Observation,
            };
            var contacts = new List<ClientContact>();
            var references = new List<ClientReferences>();

            if (request.Contacts != null)
            {
                foreach (var contact in request.Contacts)
                {
                    var clientContact = new ClientContact { PhoneNumber = contact.PhoneNumber };
                    contacts.Add(clientContact);
                }
                client.Contacts = contacts;
            }
            if (request.References != null)
            {
                foreach (var reference in request.References)
                {
                    var referenceJson = new ClientReferences
                    {
                        Name = reference.Name,
                        PhoneNumber = reference.PhoneNumber
                    };
                    references.Add(referenceJson);
                }
                client.References = references;
            }

            return client;
        }
    }
}
