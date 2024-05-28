using OticaCrista.communication.Requests.Client;
using SistOtica.Models.Client;

namespace OticaCrista.Infra.DataBase.Repository.Client
{
    public interface IClientRepository
    {
        Task<List<ClientModel>> GetAllClients();
        Task<ClientModel> GetClientById(int id);
        Task<ClientModel> AddClient(RequestClientJson request);
        Task<ClientModel> UpdateClient(RequestClientJson request, int id);
        Task<bool> DeleteClient(int id);

        Task<bool> AddContact(ContactJson contact);
        Task<bool> DeleteContact(int id);
        Task<bool> UpdateContact(ContactJson contact, int id);

        Task<bool> AddReference(ReferenceJson contact);
        Task<bool> DeleteReference(int id);
        Task<bool> UpdateReference(ReferenceJson contact, int id);
    }
}
