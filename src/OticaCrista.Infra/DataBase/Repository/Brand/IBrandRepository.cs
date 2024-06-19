using OticaCrista.communication.Requests.Product;
using SistOtica.Models.Product;

namespace OticaCrista.Infra.DataBase.Repository.Brand
{
    public interface IBrandRepository
    {
        Task<BrandModel?> CreateBrandAsync(BrandModel model);
        Task<BrandModel?> UpdateBrandAsync(BrandRequest brand, int id);
        Task<BrandModel?> DeleteBrandAsync(int id);
        Task<List<BrandModel>?> GetAllBrandsPaginadedAsync(int skip, int take);
        Task<BrandModel?> GetBrandByIdAsync(int id);
        Task<int> CountBrandsAsync();
        Task<bool> UniqueNameAsync(string name, CancellationToken token);
    }
}
