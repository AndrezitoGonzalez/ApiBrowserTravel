using BrowserTravelApi.Commands.Agregar.AgregarLocalidad;
using BrowserTravelApi.Commands.Eliminar.EliminarLocalidad;
using BrowserTravelApi.Commands.Actualizar.ActualizarLocalidad;
using BrowserTravelApi.Commands.Obtener.ObtenerLocalidad;
using BrowserTravelApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BrowserTravelApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocalidadController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocalidadController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPut("agregarLocalidad")]
        public async Task<IActionResult> agregarLocalidad(string nombre, string mercado,int estado)
        {
            AgregarLocalidadCommand objetoLocalidad = new AgregarLocalidadCommand();
            objetoLocalidad.nombre = nombre;
            objetoLocalidad.mercado = mercado;
            objetoLocalidad.estado = estado;

            var localidadId = await _mediator.Send(objetoLocalidad);
            return CreatedAtAction(nameof(ObtenerLocalidad), new { id = localidadId }, null);
        }

        [HttpGet("obtenerLocalidad")]
        public async Task<ActionResult<Vehiculo>> ObtenerLocalidad(Guid id)
        {
            var query = new ObtenerLocalidadQuery { id = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("eliminarLocalidad")]
        public async Task<IActionResult> EliminarLocalidad(Guid id)
        {
            var command = new EliminarLocalidadCommand { id = id };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("actualizarLocalidad")]
        public async Task<IActionResult> ActualizarLocalidad([FromBody] ActualizarLocalidadCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
