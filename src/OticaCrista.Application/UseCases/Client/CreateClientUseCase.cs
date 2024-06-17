using FluentValidation;
using OticaCrista.Application.UseCases.Client.Validators;
using OticaCrista.communication.Requests.Client;
using OticaCrista.Infra.DataBase.Repository.Client;
using SistOtica.Models.Client;

namespace OticaCrista.Application.UseCases.Client
{
    public class CreateClientUseCase(IClientRepository _repository)
    {
        public async Task<ClientModel> Execute(ClientRequest request)
        {
            await Validate(request);
            var client = await _repository.CreateClientAsync(request);
            if (client != null)
            {
                return client;
            }
            return null;
        }

        private async Task Validate(ClientRequest request)
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
