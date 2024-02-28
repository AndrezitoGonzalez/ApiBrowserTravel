using MediatR;
using BrowserTravelApi.Models;
using System;

namespace BrowserTravelApi.Commands.Obtener.ObtenerLocalidad
{
    public class ObtenerLocalidadQuery : IRequest<ObtenerLocalidadQueryResponse>
    {
        public Guid id { get; set; }
    }
}
