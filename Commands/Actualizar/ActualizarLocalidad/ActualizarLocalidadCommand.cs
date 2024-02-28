using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BrowserTravelApi.Commands.Actualizar.ActualizarLocalidad
{
    public class ActualizarLocalidadCommand : IRequest
    {
        [Required(ErrorMessage = "El ID es obligatorio.")]
        public Guid id { get; set; }

        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string? nombre { get; set; }

        [StringLength(100, ErrorMessage = "El mercado no puede tener más de 100 caracteres.")]
        public string? mercado { get; set; }

        [Range(0, 9, ErrorMessage = "El estado debe estar en el rango de 0 a 9.")]
        public int? estado { get; set; }

    }
}

