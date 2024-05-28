using OticaCrista.communication.Requests.Product;
using SistOtica.Models.Product;

namespace OticaCrista.Infra.DataBase.Repository.Product
{
    public interface IBrandRepository
    {
        Task<List<BrandModel>> GetAll();
        Task<BrandModel> GetById(int id);
        Task<BrandModel> Add(BrandModel brand);
        Task<BrandModel> Update(BrandRequestJson brand, int id);
        Task<bool> Delete(int id);
    }
}
