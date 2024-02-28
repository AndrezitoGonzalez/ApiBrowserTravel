using System.ComponentModel.DataAnnotations;

namespace BrowserTravelApi.Models
{
    public class Mercado
    {
        [Key]
        public Guid id { get; set; }
        public string? nombre { get; set; }
        public int? estado { get; set; }
    }
}
