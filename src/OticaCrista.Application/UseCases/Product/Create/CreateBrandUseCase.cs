using OticaCrista.communication.Requests.Product;
using OticaCrista.Infra.DataBase.Repository;
using SistOtica.Models.Product;

namespace OticaCrista.Application.UseCases.Product.Create
{
    public class CreateBrandUseCase : BrandUseCases
    {
        private readonly IBrandRepository _repository;

        public CreateBrandUseCase(IBrandRepository repository)
            : base(repository)
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
            var brands = _repository.GetAll().Result;
            foreach ( var brand in brands )
            {
                if(brand.Name == request.Name)
                {
                    throw new InvalidOperationException("This Brand Already exists");
                }
            }
        }
    }
}
