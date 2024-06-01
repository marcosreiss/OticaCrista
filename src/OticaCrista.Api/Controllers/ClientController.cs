using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using OticaCrista.Application.UseCases.Client;
using OticaCrista.communication.Requests.Client;
using OticaCrista.communication.Responses.Client;
using SistOtica.Models.Client;
using System.ComponentModel.DataAnnotations;

namespace OticaCrista.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(RequestClientJson requestClientJson,
            [FromServices] CreateClientUseCase useCase)
        {
            try
            {
                var client = await useCase.Execute(requestClientJson);
                return Created(string.Empty, client);
            }catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<List<ResponseClientJson>> GetAll([FromServices] GetClientUseCase useCase)
        {
            return await useCase.GetAll();

        }

        [HttpGet("{id}")]
        public async Task<ResponseClientJson?> GetById([FromServices] GetClientUseCase useCase, int id)
        {
            return await useCase.GetById(id);
        }
    }
}
