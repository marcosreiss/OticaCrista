using Microsoft.Extensions.Logging;
using OticaCrista.communication.Responses;
using OticaCrista.Infra.DataBase.Repository.Sale;
using SistOtica.Models.Sale;

namespace OticaCrista.Application.UseCases.Sale
{
    public class CreateSaleUseCase(
        ISaleRepository _repository,
        ILogger<CreateSaleUseCase> _logger)
    {
        public async Task<Response<SaleModel>> Execute()
        {

        }
    }
}
