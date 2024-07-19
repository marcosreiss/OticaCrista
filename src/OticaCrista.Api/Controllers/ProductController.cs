using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
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
        public async Task<IActionResult> Create([FromBody] ProductRequest request,
            [FromServices] CreateProductUseCase useCase)
        {
            var response = await useCase.Execute(request);
            if (response.StatusCode is >= 200 and <= 299)
            {
                return Created("", response);
            }
            return BadRequest(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(ProductRequest request, int id,
            [FromServices] UpdateProductUseCase useCase)
        {
            var response = await useCase.Execute(request, id);
            if (response.StatusCode is >= 200 and <= 299)
            {
                return Created("", response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id,
            [FromServices] DeleteProductUseCase useCase)
        {
            var response = await useCase.Execute(id);
            if (response.StatusCode is >= 200 and <= 299)
            {
                return Created("", response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id,
            [FromServices] GetProductByIdUseCase useCase)
        {
            var response = await useCase.Execute(id);
            if (response.StatusCode is >= 200 and <= 299)
            {
                return Created("", response);
            }
            return BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromServices] GetAllProductsPagedUseCase useCase,
            [FromQuery]int currentPage)
        {
            var take = 100;
            var skip = (currentPage - 1) * take;

            var response = await useCase.Execute(skip, take);
            if (response.StatusCode is >= 200 and <= 299)
            {
                return Created("", response);
            }
            return BadRequest(response);
        }
    }
}
