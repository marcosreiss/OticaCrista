using OticaCrista.communication.Requests.Product;
using OticaCrista.Infra.DataBase.Repository;
using SistOtica.Models.Product;

namespace OticaCrista.Application.UseCases.Product.Create
{
    public class CreateBrandUseCase
    {
        private readonly BrandRepository _repository;

        public CreateBrandUseCase(BrandRepository repository)
        {
            _repository = repository;
        }
        public async Task<BrandModel> Execute(BrandRequestJson request) 
        {
            Validate(request);
            var newBrand = new BrandModel
            {
                Name = request.Name,
                Products = null
            };
            await _repository.Add(newBrand);
            return newBrand;
        }

        private void Validate(BrandRequestJson request)
        {
            if (request.Name == null)
            {
                throw new ArgumentNullException(nameof(request));
            }


        }
    }
}
