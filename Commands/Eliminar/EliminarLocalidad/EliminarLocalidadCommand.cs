using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using MediatR;

namespace BrowserTravelApi.Commands.Eliminar.EliminarLocalidad
{
    public class EliminarLocalidadCommand : IRequest
    {
        [Required(ErrorMessage = "El ID es obligatorio.")]
        public Guid id { get; set; }
    }
}
