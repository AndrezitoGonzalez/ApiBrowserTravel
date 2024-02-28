using MediatR;

namespace BrowserTravelApi.Commands.Obtener.ObtenerReserva
{
    public class ObtenerReservaQuery : IRequest<List<ObtenerReservaQueryResponse>>
    {
        public string? cliente { get; set; }
        public string? mercado { get; set; }
        public string? localidadRecogida { get; set; }
        public string? localidadDevolucion { get; set; }
    }
}
