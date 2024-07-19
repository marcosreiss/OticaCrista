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
    }
}
