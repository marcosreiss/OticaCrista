using Microsoft.AspNetCore.Mvc;
using OticaCrista.Application.UseCases.Client;
using OticaCrista.communication.Requests.Client;
using System.ComponentModel.DataAnnotations;

namespace OticaCrista.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpPost(Order = 1)]
        public async Task<IActionResult> Create(ClientRequest requestClientJson,
            [FromServices] CreateClientUseCase useCase)
        {
            var response = await useCase.Execute(requestClientJson);
            if(response.StatusCode is >= 200 and <= 299)
            {
                return Created("", response);
            }
            return BadRequest(response);
        }

        [HttpPut("{id}", Order = 2)]
        public async Task<IActionResult> Update(ClientRequest requestClientJson, int id,
            [FromServices] UpdateClientUseCase useCase)
        {
            try
            {
                var client = await useCase.Execute(requestClientJson, id);
                return Ok(client);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}", Order = 3)]
        public async Task<IActionResult> Delete([FromServices] DeleteClientUseCase useCase, int id)
        {

            var response = await useCase.Execute(id);
            if (response.StatusCode is >= 200 and <= 2999)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("{id}", Order = 4)]
        public async Task<IActionResult> GetById(
            [FromServices] GetClientByIdUseCase useCase, 
            int id)
        {
            var result = await useCase.Execute(id);
            return Ok(result);
        }

        [HttpGet(Order = 5)]
        public async Task<IActionResult> GetAllBrandsPaginadedAsync(
            [FromServices] GetAllClientsPaginadedUseCase useCase,
            [FromQuery] int currentPage)
        {
            var take = 100;
            var skip = (currentPage - 1) * take;

            var clients = await useCase.Execute(skip, take);
            return Ok(clients);
            
        }

    }
}
