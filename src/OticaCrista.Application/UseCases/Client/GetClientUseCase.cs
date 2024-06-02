using AutoMapper;
using OticaCrista.communication.Requests.Client;
using OticaCrista.communication.Responses.Client;
using OticaCrista.Infra.DataBase.Repository.Client;

namespace OticaCrista.Application.UseCases.Client
{
    public class GetClientUseCase
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;
        public GetClientUseCase(IClientRepository clientRepository, IMapper mapper)
        {
            _repository = clientRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseClientJson?>> GetAll()
        {
            var clients = await _repository.GetAllClients();
            if (clients.Count != 0)
            {
                var response = new List<ResponseClientJson>();
                foreach (var client in clients)
                {
                    var mapping = _mapper.Map<ResponseClientJson>(client);
                    response.Add(mapping);
                }
                return response;
            }
            else  return null; 
        }

        public async Task<ResponseClientJson?> GetById(int id)
        {
            var client = await _repository.GetClientById(id);
            if (client == null) return null;
            var response = _mapper.Map<ResponseClientJson>(client);
            return response;
        }
    }
}
