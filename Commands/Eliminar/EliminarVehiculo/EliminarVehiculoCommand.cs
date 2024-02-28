using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using MediatR;

namespace BrowserTravelApi.Commands.Eliminar.EliminarVehiculo
{
    public class EliminarVehiculoCommand : IRequest
    {
        [Required(ErrorMessage = "El ID es obligatorio.")]
        public Guid id { get; set; }
    }
}
