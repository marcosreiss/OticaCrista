using FluentValidation;
using OticaCrista.Application.UseCases.Client.Validators;
using OticaCrista.communication.Requests.Client;
using OticaCrista.Infra.DataBase.Repository.Client;
using SistOtica.Models.Client;

namespace OticaCrista.Application.UseCases.Client
{
    public class CreateClientUseCase
    {
        private readonly IClientRepository _repository;
        public CreateClientUseCase(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<ClientModel> Execute(RequestClientJson requestClientJson)
        {
            Validate(requestClientJson);

            return await _repository.AddClient(requestClientJson);
        }

        private void Validate(RequestClientJson request)
        {
            var validator = new CreateClientValidator(_repository);
            var result = validator.Validate(request);
            if(!result.IsValid)
            {
                throw new ValidationException(result.Errors.ToArray());
            }
        }
    }
}
