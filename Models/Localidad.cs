using System.ComponentModel.DataAnnotations;

namespace BrowserTravelApi.Models
{
    public class Localidad
    {
        [Key]
        public Guid id { get; set; }
        public string? nombre { get; set; }
        public string? mercado { get; set; }
        public int? estado { get; set; }
    }
}
