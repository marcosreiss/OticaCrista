using Microsoft.EntityFrameworkCore;
using OticaCrista.communication.Requests.Product;
using SistOtica.Models.Product;

namespace OticaCrista.Infra.DataBase.Repository.Product
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
            return await context.Brands
                .ToListAsync();
        }

        public async Task<BrandModel> GetById(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var brand = await context.Brands.FirstOrDefaultAsync(x => x.Id == id);
            if (brand == null)
            {
                throw new ArgumentNullException("Brand not Found");
            }
            return brand;
        }

        public async Task<BrandModel> Add(BrandModel brand)
        {
            using var context = _contextFactory.CreateDbContext();
            await context.Brands.AddAsync(brand);
            await context.SaveChangesAsync();
            return brand;
        }

        public async Task<BrandModel> Update(BrandRequestJson brand, int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var updateBrand = await GetById(id);
            

            updateBrand.Name = brand.Name;
            context.Brands.Update(updateBrand);
            await context.SaveChangesAsync();

            return updateBrand;

        }

        public async Task<bool> Delete(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var deleteBrand = await GetById(id);
           

            context.Brands.Remove(deleteBrand);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
