using System.ComponentModel.DataAnnotations;

namespace BrowserTravelApi.Models
{
    public class Reserva
    {
        [Key]
        public int id { get; set; }
        public string? cliente { get; set; }
        public string? vehiculo { get; set; }
        public string? mercado { get; set; }
        public int? estado { get; set; }
        public string? localidadRecogida { get; set; }
        public string? localidadDevolucion { get; set; }

    }
}
