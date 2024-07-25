using OticaCrista.communication.Responses;
using OticaCrista.Infra.DataBase.Repository.Sale;
using SistOtica.Models.Sale;

namespace OticaCrista.Application.UseCases.Sale
{
    public class DeleteSaleUseCase(ISaleRepository _repository)
    {
        public async Task<Response<SaleModel>> Execute(int id)
        {
            try
            {
                var sale = await _repository.GetSaleByIdAsync(id);
                if (sale == null)
                {
                    return new Response<SaleModel>(null, 404, "Venda não encontrada");
                }

                await _repository.DeleteSaleAsync(id);

                return new Response<SaleModel>(null, 200, "Venda deletada com sucesso");
            }
            catch (Exception ex)
            {
                return new Response<SaleModel>(null, 500, "Erro ao deletar venda: " + ex.Message);
            }
        }
    }
}
