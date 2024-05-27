using OticaCrista.communication.Requests.Product;
using OticaCrista.Infra.DataBase.Repository;
using SistOtica.Models.Product;

namespace OticaCrista.Application.UseCases.Product.Update
{
    public class UpdateBrandUseCase
    {
        private readonly IBrandRepository _brandRepository;
        public UpdateBrandUseCase(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }


        public async Task<BrandModel> Execute(BrandRequestJson update, int id)
        {
           var newBrand =  await _brandRepository.Update(update, id);

            return newBrand;
        }
    }
}
