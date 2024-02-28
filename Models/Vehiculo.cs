using System.ComponentModel.DataAnnotations;


namespace BrowserTravelApi.Models
{
    public class Vehiculo
    {
        [Key]
        public Guid id { get; set; }
        public int? modelo { get; set; }
        public string? marca { get; set; }
        public DateTime? fechaFabricacion { get; set; }
        public int? estado { get; set; }
        public string? localidad { get; set; }

    }
}
