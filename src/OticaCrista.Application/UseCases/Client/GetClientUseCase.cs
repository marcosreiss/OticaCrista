using AutoMapper;
using OticaCrista.Application.Mapping;
using OticaCrista.communication.Requests.Client;
using OticaCrista.communication.Responses.Client;
using OticaCrista.Infra.DataBase.Repository.Client;
using SistOtica.Models.Client;

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

        public async Task<List<ResponseClientJson>> GetAll()
        {
            var clients = await _repository.GetAllClients();
            var response = new List<ResponseClientJson>();
            foreach (var client in clients)
            {
                var mapping = _mapper.Map<ResponseClientJson>(client);

                mapping.Contacts = new List<ContactJson>();
                foreach(var contact in client.PhoneNumber)
                {
                    var contactJson = new ContactJson();
                    contactJson.PhoneNumber = contact.PhoneNumber;
                    mapping.Contacts.Add(contactJson);
                }
                response.Add(mapping);
            }
            return response;
        }

        public async Task<ResponseClientJson> GetById(int id)
        {
            var client = await _repository.GetClientById(id);
            var response = _mapper.Map<ResponseClientJson>(client);

            response.Contacts = new List<ContactJson>();
            foreach(var contact in client.PhoneNumber) 
            { 
                var contactJson = new ContactJson();
                contactJson.PhoneNumber = contact.PhoneNumber;
                response.Contacts.Add(contactJson);
            }
            return response;
        }
    }
}
