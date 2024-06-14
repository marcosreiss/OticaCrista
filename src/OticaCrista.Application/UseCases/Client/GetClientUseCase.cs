using AutoMapper;
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

    }
}
