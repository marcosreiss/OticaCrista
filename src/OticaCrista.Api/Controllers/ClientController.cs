﻿using Microsoft.AspNetCore.Mvc;
using OticaCrista.Application.UseCases.Client;
using OticaCrista.communication.Requests.Client;
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
        public async Task<IActionResult> GetAll([FromServices] GetClientUseCase useCase)
        {
            var clients = await useCase.GetAll();
            if (clients != null) return Ok(clients);
            var response = new
            {
                Status = StatusCodes.Status204NoContent,
                Ok = true,
                Message = "No Client Found"
            };
            return Ok(response);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromServices] GetClientUseCase useCase, int id)
        {
            var client = await useCase.GetById(id);
            if (client != null) return Ok(client);
            var response = new
            {
                Status = StatusCodes.Status204NoContent,
                Ok = true,
                Message = "No Client Found whit This Id"
            };
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(RequestClientJson requestClientJson, int id,
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
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
