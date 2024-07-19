using Microsoft.AspNetCore.Mvc;
using OticaCrista.Application.UseCases.Service;
using SistOtica.Models.Service;

namespace OticaCrista.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(
            ServiceModel request, 
            [FromServices] CreateServiceUseCase useCase)
        {
            var response = await useCase.Execute(request);
            if (response.StatusCode is >= 200 and <= 299)
            {
                return Created("", response);
            }
            return BadRequest(response);
        }
    }
}
