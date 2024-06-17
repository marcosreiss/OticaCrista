using Microsoft.AspNetCore.Mvc;
using OticaCrista.Application.UseCases.Brand;
using OticaCrista.communication.Requests.Product;
using OticaCrista.Infra.DataBase.Repository;
using SistOtica.Models.Product;

namespace OticaCrista.Api.Controllers
{
    [Route("product/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        //[HttpGet]
        //public async Task<ActionResult<List<BrandModel>>> GetAll([FromServices] GetBrandUseCase useCase)
        //{
        //    return await useCase.GetAll();
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<BrandModel>> Get(int id, [FromServices]GetBrandUseCase useCase)
        //{
        //   return await useCase.GetById(id);
        //}

        //[HttpPost]
        //public async Task<ActionResult<BrandModel>> Post(
        //    [FromBody] BrandRequest request,
        //    [FromServices]CreateBrandUseCase useCase)
        //{
        //    var newBrand = await useCase.Execute(request);
            
        //    return Created(string.Empty, newBrand);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult<BrandModel>> Update(
        //    [FromBody] BrandRequest request, int id,
        //    [FromServices] UpdateBrandUseCase useCase)
        //{
        //    var updated = await useCase.Execute(request, id);
        //    return Ok(updated);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<BrandModel>> Delete(int id,
        //    [FromServices] DeleteBrandUseCase useCase)
        //{
        //    bool apagado = useCase.Execute(id).Result;
        //    return Ok(apagado);
        //}
    }
}
