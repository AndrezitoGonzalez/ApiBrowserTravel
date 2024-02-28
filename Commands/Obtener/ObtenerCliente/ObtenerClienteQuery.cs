using MediatR;
using BrowserTravelApi.Models;
using System;

namespace BrowserTravelApi.Commands.Obtener.ObtenerCliente
{
    public class ObtenerClienteQuery : IRequest<ObtenerClienteQueryResponse>
    {
        public Guid id { get; set; }
    }
}
