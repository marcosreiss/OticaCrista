using Microsoft.EntityFrameworkCore;
using OticaCrista.communication.Requests.Product;
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


        public async Task<List<ProductModel>> GetAll()
        {
            using var context = _dbContextFactory.CreateDbContext();
            return await context.Products.ToListAsync();
        }

        public async Task<ProductModel> GetById(int id)
        {
            using var context = _dbContextFactory.CreateDbContext();
          
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                throw new ArgumentNullException("Product not Found");
            }
            return product;
        }

        public async Task<ProductModel> Add(ProductModel product)
        {
            using var context = _dbContextFactory.CreateDbContext();
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            return product;
        }

        public async Task<ProductModel> Update(ProductRequestJson model, int id)
        {
            using var context = _dbContextFactory.CreateDbContext();
            var product = GetById(id).Result;

            product.Name = model.Name;
            product.BuyPrice = model.BuyPrice;
            product.Addition = model.Additon;
            product.SalePrice = model.SalePrice;
            product.Quantity = model.Quantity;
            product.BrandId = model.BrandId;

            context.Products.Update(product);
            await context.SaveChangesAsync();

            return product;
        }

        public async Task<bool> Delete(int id)
        {
            using var context = _dbContextFactory.CreateDbContext();
            var product = GetById(id).Result;

            context.Products.Remove(product);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
