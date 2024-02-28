using System;

namespace BrowserTravelApi.Commands.Obtener.ObtenerLocalidad
{
    public class ObtenerLocalidadQueryResponse
    {
        public Guid id { get; set; }
        public string nombre { get; set; }
        public string mercado { get; set; }
        public int estado { get; set; }
    }
}
