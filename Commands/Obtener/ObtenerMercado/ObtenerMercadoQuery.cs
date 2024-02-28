using MediatR;
using BrowserTravelApi.Models;
using System;

namespace BrowserTravelApi.Commands.Obtener.ObtenerMercado
{
    public class ObtenerMercadoQuery : IRequest<ObtenerMercadoQueryResponse>
    {
        public Guid id { get; set; }
    }
}
