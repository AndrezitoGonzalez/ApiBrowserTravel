using BrowserTravelApi.Commands.Agregar.AgregarMercado;
using BrowserTravelApi.Commands.Eliminar.EliminarMercado;
using BrowserTravelApi.Commands.Actualizar.ActualizarMercado;
using BrowserTravelApi.Commands.Obtener.ObtenerMercado;
using BrowserTravelApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BrowserTravelApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MercadoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MercadoController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPut("agregarMercado")]
        public async Task<IActionResult> agregarMercado(string nombre,int estado)
        {
            AgregarMercadoCommand objetoMercado = new AgregarMercadoCommand();
            objetoMercado.nombre = nombre;
            objetoMercado.estado = estado;

            var mercadoId = await _mediator.Send(objetoMercado);
            return CreatedAtAction(nameof(Obtenermercado), new { id = mercadoId }, null);
        }

        [HttpGet("obtenerMercado")]
        public async Task<ActionResult<Vehiculo>> Obtenermercado(Guid id)
        {
            var query = new ObtenerMercadoQuery { id = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("eliminarMercado")]
        public async Task<IActionResult> EliminarMercado(Guid id)
        {
            var command = new EliminarMercadoCommand { id = id };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("actualizarMercado")]
        public async Task<IActionResult> ActualizarMercado([FromBody] ActualizarMercadoCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
