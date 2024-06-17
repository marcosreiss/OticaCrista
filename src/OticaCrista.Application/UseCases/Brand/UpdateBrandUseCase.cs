using OticaCrista.communication.Requests.Product;
using OticaCrista.Infra.DataBase.Repository.Brand;
using SistOtica.Models.Product;

namespace OticaCrista.Application.UseCases.Brand
{
    public class UpdateBrandUseCase
    {
        private readonly IBrandRepository _brandRepository;
        public UpdateBrandUseCase(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }


        public async Task<BrandModel> Execute(BrandRequest update, int id)
        {
            var newBrand = await _brandRepository.UpdateBrandAsync(update, id);

            return newBrand;
        }
    }
}
