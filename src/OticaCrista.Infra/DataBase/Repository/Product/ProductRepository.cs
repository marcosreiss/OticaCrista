using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SistOtica.Models.Product;

namespace OticaCrista.Infra.DataBase.Repository.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbContextFactory<OticaCristaContext> _dbContextFactory;
        public ProductRepository(IDbContextFactory<OticaCristaContext> context)
        {
            _dbContextFactory = context;
        }

        public async Task<ProductModel> Add(ProductModel product)
        {
            using var context = _dbContextFactory.CreateDbContext();
            await context.Products.AddAsync(product);
            context.SaveChanges();
            return product;
           
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
