using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BrowserTravelApi.Commands.Actualizar.ActualizarVehiculo
{
    public class ActualizarVehiculoCommand : IRequest
    {
        [Required(ErrorMessage = "El ID es obligatorio.")]
        public Guid id { get; set; }
        [Range(1000, 9999, ErrorMessage = "El modelo debe ser un número de 4 dígitos.")]
        public int? modelo { get; set; }

        [StringLength(100, ErrorMessage = "La marca no puede tener más de 100 caracteres.")]
        public string? marca { get; set; }

        [DataType(DataType.Date, ErrorMessage = "La fecha de fabricación debe ser una fecha válida.")]
        public DateTime? fechaFabricacion { get; set; }

        [Range(0, 9, ErrorMessage = "El estado debe estar en el rango de 0 a 9.")]
        public int? estado { get; set; }

        [StringLength(100, ErrorMessage = "La localidad no puede tener más de 100 caracteres.")]
        public string? localidad { get; set; }
    }
}

