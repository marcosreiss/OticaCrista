using OticaCrista.communication.Responses;
using OticaCrista.Infra.DataBase.Repository.Client;
using SistOtica.Models.Client;

namespace OticaCrista.Application.UseCases.Client
{
    public class GetAllClientsPaginadedUseCase(IClientRepository _repository)
    {
        public async Task<PagedResponse<List<ClientModel>>> Execute(int skip = 0, int take = 3)
        {
            try
            {
                var clients = await _repository.GetAllClientsPaginadedAsync(skip, take);
                var count = await _repository.GetClientCountAsync();
                var currentPage = (int)(skip / (double)take) + 1;
                return new PagedResponse<List<ClientModel>>(
                    clients, 
                    count, 
                    currentPage, 
                    take, 
                    200, 
                    "Clientes recuperados com sucesso!");
            }
            catch (Exception ex)
            {
                return new PagedResponse<List<ClientModel>>(null, 0, 0, 0, 500, ex.Message);
            }

        }
    }
}
