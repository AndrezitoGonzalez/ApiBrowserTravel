using BrowserTravelApi.Commands.Agregar.AgregarVehiculo;
using BrowserTravelApi.Commands.Eliminar.EliminarVehiculo;
using BrowserTravelApi.Commands.Actualizar.ActualizarVehiculo;
using BrowserTravelApi.Commands.Obtener.ObtenerVehiculo;
using BrowserTravelApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BrowserTravelApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehiculoController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPut("agregarVehiculo")]
        public async Task<IActionResult> agregarVehiculo(int modelo, string marca, DateTime fechaFabricacion,
            int estado, string localidad)
        {
            AgregarVehiculoCommand objetoVehiculo = new AgregarVehiculoCommand();
            objetoVehiculo.modelo = modelo;
            objetoVehiculo.marca = marca;
            objetoVehiculo.fechaFabricacion = fechaFabricacion;
            objetoVehiculo.estado = estado;
            objetoVehiculo.localidad = localidad;

            var vehiculoId = await _mediator.Send(objetoVehiculo);
            return CreatedAtAction(nameof(Obtenervehiculo), new { id = vehiculoId }, null);
        }

        [HttpGet("obtenerVehiculo")]
        public async Task<ActionResult<Vehiculo>> Obtenervehiculo(Guid id)
        {
            var query = new ObtenerVehiculoQuery { id = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("eliminarVehiculo")]
        public async Task<IActionResult> EliminarVehiculo(Guid id)
        {
            var command = new EliminarVehiculoCommand { id = id };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("actualizarVehiculo")]
        public async Task<IActionResult> ActualizarVehiculo([FromBody] ActualizarVehiculoCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
