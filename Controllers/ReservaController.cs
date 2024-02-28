using BrowserTravelApi.Commands.Agregar.AgregarMercado;
using BrowserTravelApi.Commands.Eliminar.EliminarMercado;
using BrowserTravelApi.Commands.Actualizar.ActualizarMercado;
using BrowserTravelApi.Commands.Obtener.ObtenerReserva;
using BrowserTravelApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BrowserTravelApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservaController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("obtenerReserva")]
        public async Task<ActionResult<Vehiculo>> Obtenermercado(string cliente,string mercado, string localidadRecogida, string localidadDevolucion)
        {
            var query = new ObtenerReservaQuery { 
                cliente = cliente,
                mercado = mercado, 
                localidadRecogida = localidadRecogida, 
                localidadDevolucion = localidadDevolucion 
            };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
