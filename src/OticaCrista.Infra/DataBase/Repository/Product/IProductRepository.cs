using OticaCrista.communication.Requests.Product;
using SistOtica.Models.Product;

namespace OticaCrista.Infra.DataBase.Repository.Product
{
    public interface IProductRepository
    {
        Task<ProductModel?> CreateProductAsync(ProductModel product);
        Task<ProductModel?> UpdateProductAsync(ProductRequest model, int id);
        Task<ProductModel?> DeleteProductAsync(int id);
        Task<ProductModel?> GetProductByIdAsync(int id);
        Task<List<ProductModel>?> GetAllProductsPaginadedAsync(int skip, int take);
        Task<int> GetProductsCountAsync();
        
         
    }
}
