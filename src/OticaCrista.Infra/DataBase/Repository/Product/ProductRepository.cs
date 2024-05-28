using SistOtica.Models.Product;

namespace OticaCrista.Infra.DataBase.Repository.Product
{
    public class ProductRepository : IProductRepository
    {
        public Task<ProductModel> Add()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> Update(ProductModel model, int id)
        {
            throw new NotImplementedException();
        }
    }
}
