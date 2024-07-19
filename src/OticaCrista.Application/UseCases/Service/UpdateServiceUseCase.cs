using Microsoft.Extensions.Logging;
using OticaCrista.communication.Responses;
using OticaCrista.Infra.DataBase.Repository.Service;
using SistOtica.Models.Client;
using SistOtica.Models.Service;

namespace OticaCrista.Application.UseCases.Service
{
    public class UpdateServiceUseCase(
        IServiceRepository _repository,
        ILogger<UpdateServiceUseCase> _logger)
    {
        public async Task<Response<ServiceModel>> Execute(ServiceModel request, int id)
        {
            var service = await _repository.UpdateServiceAsync(id, request);
            if (service != null)
            {
                return new Response<ServiceModel>(service, 200, "Serviço editado com sucesso!");
            }
            return new Response<ServiceModel>(null, 500,
                "Erro ao editar serviçio em repository. Verifique os logs da aplicação");
        }
    }
}
