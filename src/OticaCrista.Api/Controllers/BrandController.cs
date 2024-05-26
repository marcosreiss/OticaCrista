using Microsoft.AspNetCore.Mvc;
using OticaCrista.Application.UseCases.Product.Create;
using OticaCrista.communication.Requests.Product;
using OticaCrista.Infra.DataBase.Repository;
using SistOtica.Models.Product;

namespace OticaCrista.Api.Controllers
{
    [Route("product/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;
        private readonly CreateBrandUseCase _createBrandUseCase;
        public BrandController(IBrandRepository brandRepository, CreateBrandUseCase createBrandUseCase) 
        { 
            _brandRepository = brandRepository;
            _createBrandUseCase = createBrandUseCase;
        }

        [HttpGet]
        public async Task<ActionResult<List<BrandModel>>> GetAll()
        {
            var brandList = await _brandRepository.GetAll();
            return Ok(brandList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BrandModel>> Get(int id)
        {
            var brandList = await _brandRepository.GetById(id);
            return Ok(brandList);
        }

        [HttpPost]
        public async Task<ActionResult<BrandModel>> Post(BrandRequestJson request)
        {
            var newBrand = await _createBrandUseCase.Execute(request);
            
            return Created("", newBrand);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BrandModel>> Update([FromBody] BrandModel brandModel, int id)
        {
            var brand = await _brandRepository.Update(brandModel, id);

            return Ok(brand);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BrandModel>> Delete(int id)
        {
            bool apagado = await _brandRepository.Delete(id);
            return Ok(apagado);
        }
    }
}
