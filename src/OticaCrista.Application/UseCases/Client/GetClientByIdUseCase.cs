using OticaCrista.communication.Responses;
using OticaCrista.Infra.DataBase.Repository.Client;
using SistOtica.Models.Client;

namespace OticaCrista.Application.UseCases.Client
{
    public class GetClientByIdUseCase(IClientRepository _repository)
    {
        public async Task<Response<ClientModel>> Execute(int id)
        {
            var client = await _repository.GetClientByIdAsync(id);
            if (client != null)
            {
                return new Response<ClientModel>(client, 200, "Cliente recuperado com sucesso!");
            }
            return new Response<ClientModel>(null, 500, "erro ao buscar client por id. verifique os logs da aplicação");
        }
    }
}
