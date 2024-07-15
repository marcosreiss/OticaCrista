using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OticaCrista.communication.Requests.Product;
using SistOtica.Models.Product;

namespace OticaCrista.Infra.DataBase.Repository.Brand
{
    public class BrandRepository(
        IDbContextFactory<OticaCristaContext> _factory,
        ILogger<BrandRepository> _logger) 
        : IBrandRepository
    {
        private readonly OticaCristaContext _context = _factory.CreateDbContext();
        
        public async Task<BrandModel?> CreateBrandAsync(BrandModel model)
        {
            try
            {
                await _context.Brands.AddAsync(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em BrandRepository.CreateBrandAsync:\n" + ex.Message);
            }
            return null;
        }

        public async Task<BrandModel?> UpdateBrandAsync(BrandRequest model, int id)
        {
            try
            {
                var brand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);
                if (brand == null)
                {
                    _logger
                        .LogInformation
                        ("brand null in BrandRepository.UpdateBrandAsync (Invalid Id)");
                    return null;
                }

                brand.Name = model.Name;
                _context.Brands.Update(brand);
                await _context.SaveChangesAsync();

                return brand;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em BrandRepository.UpdateBrandAsync:\n" + ex.Message);
            }
            return null;

        }

        public async Task<BrandModel?> DeleteBrandAsync(int id)
        {
            try
            {
                var brand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);
                if (brand == null)
                {
                    _logger
                        .LogInformation
                        ("brand null in BrandRepository.DeleteBrandAsync (Invalid Id)");
                    return null;
                }

                _context.Brands.Remove(brand);
                await _context.SaveChangesAsync();

                return brand;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em BrandRepository.DeleteBrandAsync:\n" + ex.Message);
            }
            return null;
        }

        public async Task<BrandModel?> GetBrandByIdAsync(int id)
        {
            try
            {
                var brand = await _context.Brands
                    .AsNoTracking()
                    .FirstOrDefaultAsync(b => b.Id == id);
                if (brand == null)
                {
                    _logger
                        .LogInformation
                        ("brand null in BrandRepository.GetBrandByIdAsync (Invalid Id)");
                    return null;
                }

                return brand;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em BrandRepository.GetBrandByIdAsync:\n" + ex.Message);
            }
            return null;
        }

        public async Task<List<BrandModel>?> GetAllBrandsPaginadedAsync(int skip, int take)
        {
            try
            {
                var brands = await _context.Brands
                    .Skip(skip)
                    .Take(take)
                    .AsNoTracking()
                    .ToListAsync();
                return brands;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em BrandRepository.GetAllBrandsPaginadedAsync:\n" + ex.Message);
            }
            return null;
        }

        public async Task<int> CountBrandsAsync()
        {
            return await _context.Brands.CountAsync();
        }

        public async Task<bool> UniqueNameAsync(string name, CancellationToken token)
        {
            return await _context.Brands
                .AsNoTracking()
                .AllAsync(b => b.Name != name, token);
        }
    }
}
