using OticaCrista.Infra.DataBase.Repository.Product;
using SistOtica.Models.Product;

namespace OticaCrista.Application.UseCases.Product.Get
{
    public class GetProductUseCase
    {
        private readonly IProductRepository _repository;
        public GetProductUseCase(IProductRepository productRepository) { 
            _repository = productRepository;
        }


        public async Task<List<ProductModel>> GetAll()
        {
           return await _repository.GetAll();
        }

        public async Task<ProductModel> GetById(int id)
        {
            return await _repository.GetById(id);
        }
    }
}
