using MediatR;
using System.Collections.Generic;

namespace BrowserTravelApi.Commands.Obtener.ObtenerReserva
{
    public class ObtenerReservaQueryResponse : IRequest<List<ObtenerReservaQueryResponse>>
    {
        public string? cliente { get; set; }
        public string? vehiculo { get; set; }
        public string? mercado { get; set; }
        public string? localidadRecogida { get; set; }
        public string? localidadDevolucion { get; set; }
    }
}
