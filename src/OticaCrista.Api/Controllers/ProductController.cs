﻿using Microsoft.AspNetCore.Mvc;
using OticaCrista.Application.UseCases.Product;
using OticaCrista.communication.Requests.Product;
using SistOtica.Models.Product;

namespace OticaCrista.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //[HttpPost]
        //public async Task<ProductModel> Post([FromBody] ProductRequest input,
        //    [FromServices] CreateProductUseCase useCase)
        //{
        //    var product = await useCase.Execute(input);
        //    return product;
        //}

        //[HttpGet]
        //public async Task<List<ProductModel>> GetAll([FromServices] GetProductUseCase useCase)
        //{
        //    var products = await useCase.GetAll();

        //    return products;
        //}
        //[HttpGet("{id}")]
        //public async Task<ProductModel> GetById(int id ,
        //    [FromServices] GetProductUseCase useCase)
        //{
        //    var product = await useCase.GetById(id);
        //    return product;
        //}

        //[HttpPut("{id}")]
        //public async Task<ProductModel> Update(ProductRequest input, int id,
        //    [FromServices] UpdateProductUseCase useCase)
        //{
        //    var product = await useCase.Execute(input, id);
        //    return product;
        //}

        //[HttpDelete("{id}")]
        //public async Task<bool> Delete(int id,
        //    [FromServices] DeleteProductUseCase useCase)
        //{
        //    await useCase.Execute(id);
        //    return true;
        //}
    }
}
