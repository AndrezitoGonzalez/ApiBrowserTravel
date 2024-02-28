using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BrowserTravelApi.Commands.Agregar.AgregarCliente
{
    public class AgregarClienteCommand : IRequest<Guid>
    {

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string? nombre { get; set; }

    }
}
