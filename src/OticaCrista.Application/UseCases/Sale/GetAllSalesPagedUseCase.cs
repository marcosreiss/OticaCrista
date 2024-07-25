using OticaCrista.communication.Responses;
using OticaCrista.Infra.DataBase.Repository.Sale;
using SistOtica.Models.Sale;

namespace OticaCrista.Application.UseCases.Sale
{
    public class GetAllSalesPagedUseCase(ISaleRepository _repository)
    {
        public async Task<Response<IEnumerable<SaleModel>>> Execute(int skip, int take)
        {
            try
            {
                var sales = await _repository.GetAllSalesPagedAsync(skip, take);

                return new Response<IEnumerable<SaleModel>>(sales, 200, "Vendas recuperadas com sucesso");
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<SaleModel>>(null, 500, "Erro ao recuperar vendas: " + ex.Message);
            }
        }
    }
}
