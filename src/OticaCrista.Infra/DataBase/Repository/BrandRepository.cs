using Microsoft.EntityFrameworkCore;
using OticaCrista.communication.Requests.Product;
using SistOtica.Models.Product;

namespace OticaCrista.Infra.DataBase.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly OticaCristaContext _context;
        public BrandRepository(OticaCristaContext context)
        {
            _context = context;

        }
        public async Task<List<BrandModel>> GetAll()
        {
            return await _context.Brands.ToListAsync();
        }

        public async Task<BrandModel> GetById(int id)
        {
            return await _context.Brands.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BrandModel> Add(BrandModel brand)
        {
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
            return brand;
        }

        public async Task<BrandModel> Update(BrandModel brand, int id)
        {
            var updateBrand = await GetById(id);
            if (updateBrand == null)
            {
                throw new Exception($"usuário de id {id} não encontrado");
            }

            updateBrand.Name = brand.Name;
            await _context.Brands.AddAsync(updateBrand);
            await _context.SaveChangesAsync();

            return updateBrand;
            
        }

        public async Task<bool> Delete(int id)
        {
            var deleteBrand = await GetById(id);
            if (deleteBrand == null)
            {
                throw new Exception($"usuário de id {id} não encontrado");
            }

            _context.Brands.Remove(deleteBrand);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
