using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OticaCrista.Application.UseCases.Product.Create;
using OticaCrista.Application.UseCases.Product.Get;
using OticaCrista.communication.Requests.Product;
using SistOtica.Models.Product;

namespace OticaCrista.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        public async Task<ProductModel> Post([FromBody] ProductRequestJson request,
            [FromServices] CreateProductUseCase useCase)
        {
            var product = await useCase.Execute(request);
            return product;
        }

        [HttpGet]
        public async Task<List<ProductModel>> GetAll([FromServices] GetProductUseCase useCase)
        {
            var products = await useCase.GetAll();

            return products;
        }
        [HttpGet("{id}")]
        public async Task<ProductModel> GetById(int id ,
            [FromServices] GetProductUseCase useCase)
        {
            var product = await useCase.GetById(id);
            return product;
        }
    }
}
