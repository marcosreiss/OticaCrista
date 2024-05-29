using Microsoft.EntityFrameworkCore;
using OticaCrista.communication.Requests.Client;
using SistOtica.Models.Client;

namespace OticaCrista.Infra.DataBase.Repository.Client
{
    public class ClientRepository : IClientRepository
    {
        private readonly IDbContextFactory<OticaCristaContext> _contextFactory;
        public ClientRepository(IDbContextFactory<OticaCristaContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }


        public async Task<ClientModel> AddClient(RequestClientJson request)
        {
            using var context = _contextFactory.CreateDbContext();
            throw new NotImplementedException();
        }

        public async Task<List<ClientModel>> GetAllClients()
        {
            using var context = _contextFactory.CreateDbContext();
            var clients = await context.Clients.ToListAsync();
            return clients;
        }

        public async Task<ClientModel> GetClientById(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var client = await context.Clients.FirstOrDefaultAsync(x => x.Id == id);
            return client;
        }

        public async Task<ClientModel> UpdateClient(RequestClientJson request, int id)
        {
            using var context = _contextFactory.CreateDbContext();

            throw new NotImplementedException();
        }

        public async Task<bool> DeleteClient(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var client = GetClientById(id).Result;

            if (client == null) throw new InvalidOperationException($"client with {id} dont found");
            
            context.Clients.Remove(client);
            await context.SaveChangesAsync();
            return true;

        }



        public async Task<bool> AddContact(ContactJson number, int clientId)
        {
            using var context = _contextFactory.CreateDbContext();
            var contact = new ClientContact
            {
                PhoneNumber = number.PhoneNumber,
                ClientId = clientId
            };
            await context.Contacts.AddAsync(contact);
            return true;
            
        }

        public async Task<bool> AddReference(ReferenceJson contact)
        {
            using var context = _contextFactory.CreateDbContext();

            throw new NotImplementedException();
        }


        public async Task<bool> UpdateContact(ContactJson contact, int id)
        {
            using var context = _contextFactory.CreateDbContext();

            throw new NotImplementedException();
        }

        public async Task<bool> UpdateReference(ReferenceJson contact, int id)
        {
            using var context = _contextFactory.CreateDbContext();

            throw new NotImplementedException();
        }


        public async Task<bool> DeleteContact(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            throw new NotImplementedException();
        }

        public async Task<bool> DeleteReference(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            throw new NotImplementedException();
        }
    }
}
