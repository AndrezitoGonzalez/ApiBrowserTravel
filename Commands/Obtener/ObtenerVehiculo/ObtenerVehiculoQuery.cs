using MediatR;
using BrowserTravelApi.Models;
using System;

namespace BrowserTravelApi.Commands.Obtener.ObtenerVehiculo
{
    public class ObtenerVehiculoQuery : IRequest<ObtenerVehiculoQueryResponse>
    {
        public Guid id { get; set; }
    }
}
