using OticaCrista.communication.Requests.Client;
using SistOtica.Models.Client;

namespace OticaCrista.Infra.DataBase.Repository.Client
{
    public interface IClientRepository
    {
        Task<List<ClientModel>> GetAllClients();
        Task<ClientModel> GetClientById(int id);
        Task<ClientModel> AddClient(ClientRequest request);
        Task<ClientModel> UpdateClient(ClientRequest request, int id);
        Task<bool> DeleteClient(int id);

        Task<bool> AddContact(ContactJson number, int clientId);
        Task<bool> DeleteContact(int id);
        Task<bool> UpdateContact(ContactJson contact, int id);

        Task<bool> AddReference(ReferenceJson reference, int clientId);
        Task<bool> DeleteReference(int id);
        Task<bool> UpdateReference(ReferenceJson contact, int id);

        Task<bool> UniqueName(string name, CancellationToken cancellationToken);
    }
}
