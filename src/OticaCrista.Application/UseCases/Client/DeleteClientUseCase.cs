using OticaCrista.communication.Responses;
using OticaCrista.Infra.DataBase.Repository.Client;
using SistOtica.Models.Client;

namespace OticaCrista.Application.UseCases.Client
{
    public class DeleteClientUseCase(IClientRepository repository)
    {
        public async Task<Response<ClientModel>> Execute(int id)
        {
            var client = await repository.DeleteClientAsync(id);
            if (client != null)
            {
                return new Response<ClientModel>(client, 200, "Cliente deletado com Sucesso!");
            }
            return new Response<ClientModel>(null, 500, "Erro ao deletar client no repository. Verifique os logs da aplicação");
        }
    }
}
