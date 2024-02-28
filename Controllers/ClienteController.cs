using BrowserTravelApi.Commands.Agregar.AgregarCliente;
using BrowserTravelApi.Commands.Eliminar.EliminarCliente;
using BrowserTravelApi.Commands.Actualizar.ActualizarCliente;
using BrowserTravelApi.Commands.Obtener.ObtenerCliente;
using BrowserTravelApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BrowserTravelApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPut("agregarCliente")]
        public async Task<IActionResult> agregarCliente(string nombre)
        {
            AgregarClienteCommand objetoCliente = new AgregarClienteCommand();
            objetoCliente.nombre = nombre;

            var ClienteId = await _mediator.Send(objetoCliente);
            return CreatedAtAction(nameof(ObtenerCliente), new { id = ClienteId }, null);
        }

        [HttpGet("obtenerCliente")]
        public async Task<ActionResult<Vehiculo>> ObtenerCliente(Guid id)
        {
            var query = new ObtenerClienteQuery { id = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("eliminarCliente")]
        public async Task<IActionResult> EliminarCliente(Guid id)
        {
            var command = new EliminarClienteCommand { id = id };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("actualizarCliente")]
        public async Task<IActionResult> ActualizarCliente([FromBody] ActualizarClienteCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
