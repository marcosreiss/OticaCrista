using OticaCrista.Application.UseCases.Client.Validators;
using OticaCrista.communication.Requests.Client;
using OticaCrista.Infra.DataBase.Repository.Client;
using SistOtica.Models.Client;
using System.ComponentModel.DataAnnotations;

namespace OticaCrista.Application.UseCases.Client
{
    public class UpdateClientUseCase
    {
        private readonly IClientRepository _repository;
        public UpdateClientUseCase(IClientRepository clientRepository)
        {
            _repository = clientRepository;
        }

        public async Task<ClientModel> Execute(ClientRequest requestClientJson, int id)
        {
            await Validate(requestClientJson, id);

            return await _repository.UpdateClientAsync(requestClientJson, id);
        }

        private async Task Validate(ClientRequest request, int id)
        {
            var validator = new UpdateClientValidator();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                var errorMessages = "\n";
                foreach (var failure in result.Errors)
                {
                    var error = $"Property {failure.PropertyName} failed validation. Error was: {failure.ErrorMessage}\n";
                    errorMessages += error;
                }
                throw new ValidationException(errorMessages);
            }
            var client = _repository.GetClientByIdAsync(id);
            if (client == null)
            {
                throw new ArgumentException("No Client found with this id");
            }
        }
    }
}
