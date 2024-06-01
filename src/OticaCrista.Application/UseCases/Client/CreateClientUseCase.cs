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
            await Validate(requestClientJson);

            return await _repository.AddClient(requestClientJson);
        }

        private async Task Validate(RequestClientJson request)
        {
            var validator = new CreateClientValidator(_repository);
            var result = await validator.ValidateAsync(request);
            if(!result.IsValid)
            {
                var errorMessages = "\n";
                foreach (var failure in result.Errors)
                {
                    var error = $"Property {failure.PropertyName} failed validation. Error was: {failure.ErrorMessage}\n";
                    errorMessages += error;
                }
                throw new ValidationException(errorMessages);
            }
        }
    }
}
