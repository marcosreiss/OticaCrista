using OticaCrista.Infra.DataBase.Repository.Product;
using SistOtica.Models.Product;

namespace OticaCrista.Application.UseCases.Product.Get
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
            var brandList = await _brandRepository.GetAll();
            return brandList;
        }

        public async Task<BrandModel> GetById(int id)
        {
            var brand = await _brandRepository.GetById(id);
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
