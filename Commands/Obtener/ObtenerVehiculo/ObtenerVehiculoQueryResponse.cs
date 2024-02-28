using System;

namespace BrowserTravelApi.Commands.Obtener.ObtenerVehiculo
{
    public class ObtenerVehiculoQueryResponse
    {
        public Guid id { get; set; }
        public int modelo { get; set; }
        public string marca { get; set; }
        public DateTime fechaFabricacion { get; set; }
        public int estado { get; set; }
        public string localidad { get; set; }
    }
}
