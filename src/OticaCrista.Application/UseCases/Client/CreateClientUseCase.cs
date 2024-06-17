using FluentValidation;
using Microsoft.Extensions.Logging;
using OticaCrista.Application.UseCases.Client.Validators;
using OticaCrista.communication.Requests.Client;
using OticaCrista.communication.Responses;
using OticaCrista.Infra.DataBase.Repository.Client;
using SistOtica.Models.Client;

namespace OticaCrista.Application.UseCases.Client
{
    public class CreateClientUseCase(
        IClientRepository _repository,
        ILogger<CreateClientUseCase> _logger)
    {
        public async Task<Response<ClientModel>> Execute(ClientRequest request)
        {
            try
            {
                await Validate(request);
            }
            catch (ValidationException ex)
            {
                return new Response<ClientModel>(null, 400, ex.Message);
            }
            var client = await _repository.CreateClientAsync(request);
            if (client != null)
            {
                return new Response<ClientModel>(client, 201, "Cliente cadastrado com sucesso!");
            }
            return new Response<ClientModel>(null, 500, "Erro no repositório ao tentar cadastrar cliente, verifique os logs da aplicação");
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
                _logger.LogError("Erro em CreateClientUseCase.Validate:\n" + errorMessages);
                throw new ValidationException(errorMessages);
            }
        }
    }
}
