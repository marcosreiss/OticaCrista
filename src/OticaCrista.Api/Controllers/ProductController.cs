using Microsoft.AspNetCore.Mvc;
using OticaCrista.Application.UseCases.Product;
using OticaCrista.communication.Requests.Product;
using OticaCrista.communication.Responses;
using SistOtica.Models.Product;

namespace OticaCrista.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        public async Task<Response<ProductModel>> Post([FromBody] ProductRequest input,
            [FromServices] CreateProductUseCase useCase)
        {
            var response = await useCase.Execute(input);
            return response;
        }

        [HttpPut("{id}")]
        public async Task<Response<ProductModel>> Update(ProductRequest input, int id,
            [FromServices] UpdateProductUseCase useCase)
        {
            var response = await useCase.Execute(input, id);
            return response;
        }

        [HttpDelete("{id}")]
        public async Task<Response<ProductModel>> Delete(int id,
            [FromServices] DeleteProductUseCase useCase)
        {
            var response = await useCase.Execute(id);
            return response;
        }

        [HttpGet("{id}")]
        public async Task<Response<ProductModel>> GetById(int id,
            [FromServices] GetProductByIdUseCase useCase)
        {
            var response = await useCase.Execute(id);
            return response;
        }

        [HttpGet]
        public async Task<PagedResponse<List<ProductModel>>> GetAll(
            [FromServices] GetAllProductsPagedUseCase useCase,
            [FromQuery]int currentPage)
        {
            var take = 100;
            var skip = (currentPage - 1) * take;

            var result = await useCase.Execute(skip, take);

            return result;
        }





    }
}
