using SistOtica.Models.Product;

namespace OticaCrista.Infra.DataBase.Repository.Product
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetAll();
        Task<ProductModel> GetById(int id);
        Task<ProductModel> Add();
        Task<ProductModel> Update(ProductModel model, int id);
        Task<ProductModel> Delete(int id);
         
    }
}
