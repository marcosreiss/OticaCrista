using OticaCrista.Infra.DataBase.Repository.Brand;
using SistOtica.Models.Product;

namespace OticaCrista.Application.UseCases.Brand
{
    public class GetBrandUseCase
    {
        private readonly IBrandRepository _brandRepository;
        public GetBrandUseCase(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<List<BrandModel>> GetAll()
        {
            var brandList = await _brandRepository.GetAllBrandsPaginaded();
            return brandList;
        }

        public async Task<BrandModel> GetById(int id)
        {
            var brand = await _brandRepository.GetBrandByIdAsync(id);
            Validate(brand);

            return brand;
        }

        private void Validate(BrandModel brand)
        {
            if (brand == null)
            {
                throw new ArgumentNullException("This brand dont exists: ", nameof(brand));
            }
        }
    }
}
