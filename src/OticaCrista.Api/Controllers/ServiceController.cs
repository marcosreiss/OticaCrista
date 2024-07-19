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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(ServiceModel request, int id,
            [FromServices] UpdateServiceUseCase useCase)
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
            [FromServices] DeleteServiceUseCase useCase)
        {
            var response = await useCase.Execute(id);
            if (response.StatusCode is >= 200 and <= 299)
            {
                return Created("", response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, [FromServices] GetServiceByIdUseCase useCase)
        {
            var response = await useCase.Execute(id);
            if (response.StatusCode is >= 200 and <= 299)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromServices] GetAllServicesPagedUseCase useCase,
            [FromQuery] int currentPage)
        {
            var take = 100;
            var skip = (currentPage - 1) * take;

            var response = await useCase.Execute(skip, take);
            if (response.StatusCode is >= 200 and <= 299)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }



    }
}
