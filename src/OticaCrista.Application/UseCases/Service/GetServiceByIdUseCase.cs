using OticaCrista.communication.Responses;
using OticaCrista.Infra.DataBase.Repository.Service;
using SistOtica.Models.Service;

namespace OticaCrista.Application.UseCases.Service
{
    public class GetServiceByIdUseCase(IServiceRepository _repository)
    {
        public async Task<Response<ServiceModel>> Execute(int id)
        {
            try
            {
                var response = await _repository.GetServiceByIdAsync(id);
                if (response != null)
                {
                    return new Response<ServiceModel>(response, 200, "Serviço Recuperado com Sucesso");
                }
                else
                {
                    return new Response<ServiceModel>(null, 500, "Serviço não encontrado");
                }
            }
            catch (Exception ex)
            {
                return new Response<ServiceModel>(null, 500, "Erro ao Recuperar Serviço: " + ex.Message);
            }
        }

    }
}
