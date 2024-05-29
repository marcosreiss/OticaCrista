using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using OticaCrista.Application.UseCases.Client;
using OticaCrista.communication.Requests.Client;
using SistOtica.Models.Client;

namespace OticaCrista.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RequestClientJson requestClientJson,
            [FromServices] CreateClientUseCase useCase)
        {
            var client = await useCase.Execute(requestClientJson);
            return Created(string.Empty, client);
        }
    }
}
