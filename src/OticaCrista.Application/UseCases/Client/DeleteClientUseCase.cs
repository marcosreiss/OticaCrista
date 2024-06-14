using OticaCrista.Infra.DataBase.Repository.Client;

namespace OticaCrista.Application.UseCases.Client
{
    public class DeleteClientUseCase
    {
        private readonly IClientRepository _clientRepository;
        public DeleteClientUseCase(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<bool> Execute(int id)
        {
            if(await _clientRepository.DeleteClient(id)) return true;
            return false;
        }
    }
}
