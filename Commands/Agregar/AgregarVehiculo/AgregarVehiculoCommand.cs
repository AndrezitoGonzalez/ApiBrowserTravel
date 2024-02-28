using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BrowserTravelApi.Commands.Agregar.AgregarVehiculo
{
    public class AgregarVehiculoCommand : IRequest<Guid>
    {
        [Required(ErrorMessage = "El modelo es obligatorio.")]
        [Range(1000, 9999, ErrorMessage = "El modelo debe ser un número de 4 dígitos.")]
        public int? modelo { get; set; }

        [Required(ErrorMessage = "La marca es obligatoria.")]
        [StringLength(100, ErrorMessage = "La marca no puede tener más de 100 caracteres.")]
        public string? marca { get; set; }

        [Required(ErrorMessage = "La fecha de fabricación es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "La fecha de fabricación debe ser una fecha válida.")]
        public DateTime? fechaFabricacion { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [Range(0, 9, ErrorMessage = "El estado debe estar en el rango de 0 a 9.")]
        public int? estado { get; set; }

        [Required(ErrorMessage = "La localidad es obligatoria.")]
        [StringLength(100, ErrorMessage = "La localidad no puede tener más de 100 caracteres.")]
        public string? localidad { get; set; }
    }
}
