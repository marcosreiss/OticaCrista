using OticaCrista.communication.Requests.Product;
using OticaCrista.Infra.DataBase.Repository.Product;
using SistOtica.Models.Product;

namespace OticaCrista.Application.UseCases.Product
{
    public class CreateProductUseCase
    {
        private readonly IProductRepository _productRepository;
        public CreateProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductModel> Execute(ProductRequest request)
        {
            Validate(request);
            var product = new ProductModel
            {
                Name = request.Name,
                BuyPrice = request.BuyPrice,
                Addition = request.Additon,
                SalePrice = request.SalePrice,
                Quantity = request.Quantity,
                BrandId = request.BrandId,
            };
            await _productRepository.CreateProductAsync(product);
            return product;
        }

        private void Validate(ProductRequest requestJson)
        {
            var products = _productRepository.GetAll().Result;
            foreach (var product in products)
            {
                if (product.Name == requestJson.Name)
                {
                    throw new ArgumentException($"Product {requestJson.Name} already exists");
                }
            }
        }
    }
}
