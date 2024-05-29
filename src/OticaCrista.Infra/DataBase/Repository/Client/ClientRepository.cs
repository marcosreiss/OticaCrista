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

        public async Task<bool> AddReference(ReferenceJson reference, int clientId)
        {
            using var context = _contextFactory.CreateDbContext();

            var newReference = new ClientReferences
            {
                Name = reference.Name,
                PhoneNumber = reference.PhoneNumber,
                ClientId = clientId
            };
            await context.References.AddAsync(newReference);
            return true;
        }


        public async Task<bool> UpdateContact(ContactJson contact, int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var newContact = context.Contacts.FirstOrDefaultAsync(x => x.Id == id).Result;

            if (newContact == null) throw new InvalidOperationException("Contact doesnt exist");

            newContact.PhoneNumber = contact.PhoneNumber;
            context.Contacts.Update(newContact);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateReference(ReferenceJson reference, int id)
        {
            using var context = _contextFactory.CreateDbContext();

            var newReference = context.References.FirstOrDefaultAsync(x=>x.Id == id).Result;

            if (newReference == null) throw new InvalidOperationException("Reference doesnt exist");

            newReference.Name = reference.Name;
            newReference.PhoneNumber = reference.PhoneNumber;

            context.References.Update(newReference);
            await context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteContact(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            
            var contact = context.Contacts.FirstOrDefault(x => x.Id == id);

            if (contact == null) throw new InvalidOperationException("contact doesnt exist");

            context.Contacts.Remove(contact);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteReference(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var reference = context.References.FirstOrDefault(x => x.Id == id);

            if (reference == null) throw new InvalidOperationException("Reference doesnt exist");

            context.References.Remove(reference);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
