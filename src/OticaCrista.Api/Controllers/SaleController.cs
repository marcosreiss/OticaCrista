using Microsoft.AspNetCore.Mvc;
using OticaCrista.Application.UseCases.Sale;
using OticaCrista.communication.Requests.Sale;

namespace OticaCrista.Api.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(
            SaleRequest request, 
            [FromServices] CreateSaleUseCase useCase)
        {
            var response = await useCase.Execute(request);
            if(response.StatusCode is >= 200 and <= 299)
            {
                return Created("", response);
            }
            return BadRequest(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            SaleRequest request, 
            int id,
            [FromServices] UpdateSaleUseCase useCase)
        {
            var response = await useCase.Execute(request, id);
            if (response.StatusCode is >= 200 and <= 299)
            {
                return Created("", response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(
            int id,
            [FromServices] DeleteSaleUseCase useCase)
        {
            var response = await useCase.Execute(id);
            if (response.StatusCode is >= 200 and <= 299)
            {
                return Created("", response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, [FromServices] GetSaleByIdUseCase useCase)
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
            [FromServices] GetAllSalesPagedUseCase useCase,
            [FromQuery] int currentPage)
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
