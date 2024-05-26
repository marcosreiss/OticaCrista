using Microsoft.EntityFrameworkCore;
using SistOtica.Models.Product;

namespace OticaCrista.Infra.DataBase.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IDbContextFactory<OticaCristaContext> _contextFactory;
        public BrandRepository(IDbContextFactory<OticaCristaContext> context)
        {
            _contextFactory = context;

        }
        public async Task<List<BrandModel>> GetAll()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Brands.ToListAsync();
        }

        public async Task<BrandModel> GetById(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Brands.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BrandModel> Add(BrandModel brand)
        {
            using var context = _contextFactory.CreateDbContext();
            await context.Brands.AddAsync(brand);
            await context.SaveChangesAsync();
            return brand;
        }

        public async Task<BrandModel> Update(BrandModel brand, int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var updateBrand = await GetById(id);
            if (updateBrand == null)
            {
                throw new Exception($"usuário de id {id} não encontrado");
            }

            updateBrand.Name = brand.Name;
            await context.Brands.AddAsync(updateBrand);
            await context.SaveChangesAsync();

            return updateBrand;
            
        }

        public async Task<bool> Delete(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var deleteBrand = await GetById(id);
            if (deleteBrand == null)
            {
                throw new Exception($"usuário de id {id} não encontrado");
            }

            context.Brands.Remove(deleteBrand);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
