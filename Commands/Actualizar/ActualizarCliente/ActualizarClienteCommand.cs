using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BrowserTravelApi.Commands.Actualizar.ActualizarCliente
{
    public class ActualizarClienteCommand : IRequest
    {
        [Required(ErrorMessage = "El ID es obligatorio.")]
        public Guid id { get; set; }

        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string? nombre { get; set; }
    }
}

