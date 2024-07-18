using OticaCrista.communication.Requests.Sale;
using SistOtica.Models.Sale;

namespace OticaCrista.Infra.DataBase.Repository.Sale
{
    public interface ISaleRepository
    {
        Task<SaleModel?> CreateSaleAsync(SaleRequest model);
        Task<SaleModel?> UpdateSaleAsync(int id, SaleModel model);
        Task<SaleModel?> DeleteSaleAsync(int id);
        Task<SaleModel?> GetSaleByIdAsync(int id);
        Task<List<SaleModel>?> GetAllSalesPagedAsync(int skip, int take);
        Task<int> GetSaleCountAsync();
    }
}
