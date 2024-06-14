using OticaCrista.communication.Requests.Product;
using OticaCrista.Infra.DataBase.Repository.Product;
using SistOtica.Models.Product;

namespace OticaCrista.Application.UseCases.Product
{
    public class UpdateProductUseCase
    {
        private readonly IProductRepository _repository;
        public UpdateProductUseCase(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        public async Task<ProductModel> Execute(ProductRequest request, int id)
        {
            var product = await _repository.Update(request, id);
            return product;
        }
    }
}
