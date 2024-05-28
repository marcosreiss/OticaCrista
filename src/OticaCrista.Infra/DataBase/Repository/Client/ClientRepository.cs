using OticaCrista.communication.Requests.Client;
using SistOtica.Models.Client;

namespace OticaCrista.Infra.DataBase.Repository.Client
{
    public class ClientRepository : IClientRepository
    {
        public async Task<ClientModel> AddClient(RequestClientJson request)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ClientModel>> GetAllClients()
        {
            throw new NotImplementedException();
        }

        public async Task<ClientModel> GetClientById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ClientModel> UpdateClient(RequestClientJson request, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteClient(int id)
        {
            throw new NotImplementedException();
        }



        public async Task<bool> AddContact(ContactJson contact)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddReference(ReferenceJson contact)
        {
            throw new NotImplementedException();
        }


        public async Task<bool> UpdateContact(ContactJson contact, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateReference(ReferenceJson contact, int id)
        {
            throw new NotImplementedException();
        }


        public async Task<bool> DeleteContact(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteReference(int id)
        {
            throw new NotImplementedException();
        }
    }
}
