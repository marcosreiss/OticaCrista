using OticaCrista.communication.Responses;
using OticaCrista.Infra.DataBase.Repository.Service;
using SistOtica.Models.Service;

namespace OticaCrista.Application.UseCases.Service
{
    public class DeleteServiceUseCase(IServiceRepository _repository)
    {
        public async Task<Response<ServiceModel>> Execute(int id)
        {
            try
            {
                var service = await _repository.DeleteServiceAsync(id);
                if (service != null)
                    return new Response<ServiceModel>(service, 200, "Serviço Deletado com Sucesso!");
                else
                    return new Response<ServiceModel>(null, 500, "Erro ao Deletar Serviço");
            }
            catch (Exception ex)
            {
                return new Response<ServiceModel>(null, 500, "Erro ao Deletar Serviço: " + ex.Message);
            }
        }
    }
}
