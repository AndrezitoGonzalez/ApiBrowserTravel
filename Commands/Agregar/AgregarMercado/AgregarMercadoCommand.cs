using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BrowserTravelApi.Commands.Agregar.AgregarMercado
{
    public class AgregarMercadoCommand : IRequest<Guid>
    {

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string? nombre { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [Range(0, 9, ErrorMessage = "El estado debe estar en el rango de 0 a 9.")]
        public int? estado { get; set; }

    }
}
