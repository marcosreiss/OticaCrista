using OticaCrista.communication.Requests.Client;
using SistOtica.Models.Client;

namespace OticaCrista.Infra.DataBase.Repository.Client
{
    public interface IClientRepository
    {
        Task<ClientModel?> CreateClientAsync(ClientRequest request);
        Task<ClientModel?> UpdateClientAsync(ClientRequest request, int id);
        Task<ClientModel?> DeleteClientAsync(int id);
        Task<ClientModel?> GetClientByIdAsync(int id);
        Task<List<ClientModel>?> GetAllClientsPaginadedAsync(int skip, int take);

        Task<bool> CreateContactAsync(ContactJson number, int clientId);
        Task<bool> UpdateContactAsync(ContactJson contact, int id);
        Task<bool> DeleteContactAsync(int id);

        Task<bool> CreateReferenceAsync(ReferenceJson reference, int clientId);
        Task<bool> UpdateReferenceAsync(ReferenceJson contact, int id);
        Task<bool> DeleteReferenceAsync(int id);

        Task<bool> UniqueName(string name, CancellationToken cancellationToken);
        Task<bool> UniqueCpf(string cpf, CancellationToken cancellationToken);
    }
}
