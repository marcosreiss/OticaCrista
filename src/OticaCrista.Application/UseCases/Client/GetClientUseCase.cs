using OticaCrista.Infra.DataBase.Repository.Client;
using SistOtica.Models.Client;

namespace OticaCrista.Application.UseCases.Client
{
    public class GetClientUseCase
    {
        private readonly IClientRepository _repository;
        public GetClientUseCase(IClientRepository clientRepository)
        {
            _repository = clientRepository;
        }

        public async Task<List<ClientModel>> GetAll()
        {
            var clients = _repository.GetAllClients();
            return null;
        }
    }
}
