using OticaCrista.communication.Requests.Sale;
using OticaCrista.communication.Responses;
using OticaCrista.Infra.DataBase.Repository.Sale;
using SistOtica.Models.Sale;

namespace OticaCrista.Application.UseCases.Sale
{
    public class UpdateSaleUseCase(ISaleRepository _repository)
    {
        public async Task<Response<SaleModel>> Execute(SaleRequest request, int id)
        {
            try
            {
                var response = await _repository.UpdateSaleAsync(id, request);
                if (response != null)
                {
                    return new Response<SaleModel>(response, 200, "Venda atualizada com sucesso");
                }
                else
                {
                    return new Response<SaleModel>(null, 500, "Erro ao atualizar venda");
                }
            }
            catch (Exception ex)
            {
                return new Response<SaleModel>(null, 500, "Erro ao atualizar venda: " + ex.Message);
            }
        }

    }
}
