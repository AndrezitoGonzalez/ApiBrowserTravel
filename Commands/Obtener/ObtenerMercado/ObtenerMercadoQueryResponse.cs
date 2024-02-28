using System;

namespace BrowserTravelApi.Commands.Obtener.ObtenerMercado
{
    public class ObtenerMercadoQueryResponse
    {
        public Guid id { get; set; }
        public string nombre { get; set; }
        public int estado { get; set; }
    }
}
