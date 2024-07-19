using Microsoft.Extensions.Logging;
using OticaCrista.communication.Responses;
using OticaCrista.Infra.DataBase.Repository.Service;
using SistOtica.Models.Service;

namespace OticaCrista.Application.UseCases.Service
{
    public class CreateServiceUseCase(
        IServiceRepository _repository,
        ILogger<CreateServiceUseCase> _logger)
    {
        public async Task<Response<ServiceModel>> Execute(ServiceModel request)
        {
            var service = await _repository.CreateServiceAsync(request);
            if (service != null)
            {
                return new Response<ServiceModel>(service, 201, "Serviço cadastrado com sucesso");
            }
            return new Response<ServiceModel>(null, 500, "Erro no repositório ao tentar cadastrar serviço, verifique os logs da aplicação");
        }
    }
}
