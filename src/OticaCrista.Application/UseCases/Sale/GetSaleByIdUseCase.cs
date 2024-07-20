using OticaCrista.communication.Responses;
using OticaCrista.Infra.DataBase.Repository.Sale;
using SistOtica.Models.Sale;

namespace OticaCrista.Application.UseCases.Sale
{
    public class GetSaleByIdUseCase(ISaleRepository _repository)
    {
        public async Task<Response<SaleModel>> Execute(int id)
        {
            var sale = await _repository.GetSaleByIdAsync(id);
            if (sale != null)
            {
                return new Response<SaleModel>(sale, 200, "Venda recuperada com sucesso!");
            }
            return new Response<SaleModel>(null, 500, "Erro ao buscar venda por id. Verifique os logs da aplicação.");
        }

    }
}
