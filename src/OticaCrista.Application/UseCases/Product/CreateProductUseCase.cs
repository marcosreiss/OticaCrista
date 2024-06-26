using OticaCrista.communication.Requests.Product;
using OticaCrista.communication.Responses;
using OticaCrista.Infra.DataBase.Repository.Product;
using SistOtica.Models.Product;

namespace OticaCrista.Application.UseCases.Product
{
    public class CreateProductUseCase(IProductRepository _repository)
    {

        public async Task<Response<ProductModel>> Execute(ProductRequest request)
        {
            //Validate(request);
            try
            {
                var product = new ProductModel
                {
                    Name = request.Name,
                    BuyPrice = request.BuyPrice,
                    Addition = request.Additon,
                    SalePrice = request.SalePrice,
                    Quantity = request.Quantity,
                    BrandId = request.BrandId,
                };
                var response = await _repository.CreateProductAsync(product);
                if (response != null)
                    return new Response<ProductModel>(response, 200, "Produto cadastrado com sucesso!");
                else
                    return new Response<ProductModel>(null, 500, "Erro ao Cadastrar Produto");
            }
            catch (Exception ex)
            {
                return new Response<ProductModel>(null, 500, "Erro ao Cadastras Produto: " + ex.Message);
            }
        }

        //private void Validate(ProductRequest requestJson)
        //{
        //    var products = _repository.GetAll().Result;
        //    foreach (var product in products)
        //    {
        //        if (product.Name == requestJson.Name)
        //        {
        //            throw new ArgumentException($"Product {requestJson.Name} already exists");
        //        }
        //    }
        //}
    }
}
