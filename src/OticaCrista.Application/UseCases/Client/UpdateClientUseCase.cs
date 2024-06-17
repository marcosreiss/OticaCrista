using Microsoft.Extensions.Logging;
using OticaCrista.Application.UseCases.Client.Validators;
using OticaCrista.communication.Requests.Client;
using OticaCrista.communication.Responses;
using OticaCrista.Infra.DataBase.Repository.Client;
using SistOtica.Models.Client;
using System.ComponentModel.DataAnnotations;

namespace OticaCrista.Application.UseCases.Client
{
    public class UpdateClientUseCase(
        IClientRepository _repository,
        ILogger<UpdateClientUseCase> _logger)
    {
        public async Task<Response<ClientModel>> Execute(ClientRequest requestClientJson, int id)
        {
            try
            {
                await Validate(requestClientJson, id);
            }
            catch (ValidationException ex)
            {
                return new Response<ClientModel>(null, 400, ex.Message);
            }
            catch(ArgumentException ex)
            {
                return new Response<ClientModel>(null, 400, ex.Message);
            }

            var client = await _repository.UpdateClientAsync(requestClientJson, id);
            if (client != null)
            {
                return new Response<ClientModel>(client, 201, "Cliente editado com sucesso!");
            }

            return new Response<ClientModel>(null, 500,
                "Erro ao cadastrar cliente em repository. Verifique os logs da aplicação");
        }

        private async Task Validate(ClientRequest request, int id)
        {
            var validator = new UpdateClientValidator(_repository);
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                var errorMessages = "\n";
                foreach (var failure in result.Errors)
                {
                    var error = $"Property {failure.PropertyName} failed validation. Error was: {failure.ErrorMessage}\n";
                    errorMessages += error;
                }
                _logger.LogError("Erro em UpdateClientUseCase.Validate" + errorMessages);
                throw new ValidationException(errorMessages);
            }
            var client = await _repository.GetClientByIdAsync(id);
            if (client == null)
            {
                throw new ArgumentException("No Client found with this id");
            }
        }
    }
}
