using SistOtica.Models.Sale;

namespace OticaCrista.Infra.DataBase.Repository.Sale
{
    public interface ISaleRepository
    {
        Task<SaleModel?> CreateSaleAsync(SaleModel model);
        Task<SaleModel?> UpdateSaleAsync(int id, SaleModel model);
        Task<SaleModel?> DeleteSaleAsync(int id);
        Task<SaleModel?> GetSaleByIdAsync(int id);
        Task<List<SaleModel>?> GetAllSalesPaginadedAsync(int skip, int take);
    }
}
