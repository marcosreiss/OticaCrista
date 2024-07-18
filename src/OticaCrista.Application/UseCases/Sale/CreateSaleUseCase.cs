using Microsoft.Extensions.Logging;
using OticaCrista.communication.Requests.Sale;
using OticaCrista.communication.Responses;
using OticaCrista.Infra.DataBase.Repository.Sale;
using SistOtica.Models.Sale;

namespace OticaCrista.Application.UseCases.Sale
{
    public class CreateSaleUseCase(
        ISaleRepository _repository,
        ILogger<CreateSaleUseCase> _logger)
    {
        public async Task<Response<SaleModel>> Execute(SaleRequest request)
        {
            var sale = await _repository.CreateSaleAsync(request);
            if (sale != null)
            {
                return new Response<SaleModel>(sale, 201, "Atendimento Cadastrado com sucesso!");
            }
            return new Response<SaleModel>(null, 500, "Erro no repositório ao tentar cadastrar atendimento, verifique os logs da aplicação");
        }
    }
}
