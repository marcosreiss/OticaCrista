using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Asn1.Ocsp;
using OticaCrista.communication.Requests.Product;
using SistOtica.Models.Product;

namespace OticaCrista.Infra.DataBase.Repository.Product
{
    public class ProductRepository(
        IDbContextFactory<OticaCristaContext> factory,
        ILogger<ProductRepository> _logger) 
        : IProductRepository
    {
        private readonly OticaCristaContext _context = factory.CreateDbContext();

        private static ProductModel MapProduct(ProductRequest request)
        {
            var product = new ProductModel
            {
                Name = request.Name,
                BuyPrice = request.BuyPrice,
                Addition = request.Additon,
                SalePrice = request.SalePrice,
                Quantity = request.Quantity,
                BrandId = request.BrandId,
            };
            return product;
        }


        public async Task<ProductModel?> CreateProductAsync(ProductRequest request)
        {
            var product = MapProduct(request);
            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();

                return product;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em ProductRepository.CreateProductAsync:\n" + ex.Message);
            }
            return null;
        }

        public async Task<ProductModel?> UpdateProductAsync(ProductRequest request, int id)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (product == null)
                {
                    _logger.LogError("(ProductRepository.UpdateProductAsync): id pasado inválido, product não encontrada");
                    return null;
                }

                product.Name = request.Name;
                product.BuyPrice = request.BuyPrice;
                product.Addition = request.Additon;
                product.SalePrice = request.SalePrice;
                product.Quantity = request.Quantity;
                product.BrandId = request.BrandId;

                _context.Products.Update(product);
                await _context.SaveChangesAsync();

                return product;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em ProductRepository.UpdateProductAsync:\n" + ex.Message);
            }
            return null;
        }

        public async Task<ProductModel?> DeleteProductAsync(int id)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (product == null)
                {
                    _logger.LogError("(ProductRepository.DeleteProductAsync): id pasado inválido, product não encontrada");
                    return null;
                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                return product;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em ProductRepository.DeleteProductAsync:\n" + ex.Message);
            }
            return null;
        }

        public async Task<ProductModel?> GetProductByIdAsync(int id)
        {

            try
            {
                var product = await _context.Products
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
                if (product == null)
                {
                    _logger.LogError("(ProductRepository.DeleteProductAsync): id pasado inválido, product não encontrada");
                    return null;
                }
                return product;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em ProductRepository.GetProductByIdAsync:\n" + ex.Message);
            }
            return null;
        }

        public async Task<List<ProductModel>?> GetAllProductsPaginadedAsync(int skip, int take)
        {
            try
            {
                var products = await _context.Products
                    .Skip(skip)
                    .Take(take)
                    .AsNoTracking()
                    .ToListAsync();
                return products;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em ProductRepository.GetAllProductsPaginadedAsync:\n" + ex.Message);
            }
            return null;
        }

        public async Task<int> GetProductsCountAsync()
        {
            return _context.Products.Count();
        }
    }
}
