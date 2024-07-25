﻿using Microsoft.AspNetCore.Mvc;
using OticaCrista.Application.UseCases.Brand;
using OticaCrista.communication.Requests.Product;

namespace OticaCrista.Api.Controllers
{
    [Route("product/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAll(
            [FromServices] GetAllBrandsPaginadedUseCase useCase, 
            [FromQuery] int currentPage)
        {

            var take = 100;
            var skip = (currentPage - 1) * take;
            var result = await useCase.Execute(skip, take);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(
            int id, 
            [FromServices] GetBrandByIdUseCase useCase)
        {
            var brand =  await useCase.Execute(id);
            return Ok(brand);
        }

        [HttpPost]
        public async Task<ActionResult> Post(
            [FromBody] BrandRequest request,
            [FromServices] CreateBrandUseCase useCase)
        {
            var response = await useCase.Execute(request);

            return Created($"/product/brand/{response.Data.Id}", response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(
            [FromBody] BrandRequest request, int id,
            [FromServices] UpdateBrandUseCase useCase)
        {
            var updated = await useCase.Execute(request, id);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(
            int id,
            [FromServices] DeleteBrandUseCase useCase)
        {
            var response = useCase.Execute(id).Result;
            return Ok(response);
        }
    }
}
