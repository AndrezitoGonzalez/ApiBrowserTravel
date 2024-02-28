using System.ComponentModel.DataAnnotations;

namespace BrowserTravelApi.Models
{
    public class Cliente
    {
        [Key]
        public Guid id { get; set; }
        public string? nombre { get; set; }
    }
}
