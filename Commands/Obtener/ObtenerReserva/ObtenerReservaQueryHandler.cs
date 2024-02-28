using MediatR;
using BrowserTravelApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BrowserTravelApi.Commands.Obtener.ObtenerReserva
{
    public class ObtenerReservaQueryHandler : IRequestHandler<ObtenerReservaQuery, List<ObtenerReservaQueryResponse>>
    {
        private readonly ApplicationDbContext _context;

        public ObtenerReservaQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ObtenerReservaQueryResponse>> Handle(ObtenerReservaQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var reservas = from v in _context.Vehiculos
                               join lr in _context.Localidades on v.localidad equals lr.id.ToString()
                               join m in _context.Mercados on lr.mercado equals m.id.ToString()
                               join ld in _context.Localidades on m.id.ToString() equals ld.mercado
                               where m.id.ToString() == request.mercado
                               && lr.id.ToString() == request.localidadRecogida
                               && ld.id.ToString() == request.localidadDevolucion
                               select new ObtenerReservaQueryResponse
                               {
                                   cliente = request.cliente,
                                   vehiculo = v.id.ToString(),
                                   mercado = m.id.ToString(),
                                   localidadRecogida = lr.id.ToString(),
                                   localidadDevolucion = ld.id.ToString()
                               };

                var reservasList = await reservas.ToListAsync(cancellationToken);

                if (reservasList == null)
                {
                    // Manejar el caso en el que no se encuentran reservas
                    return new List<ObtenerReservaQueryResponse>();
                }

                return reservasList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al manejar la consulta ObtenerReservaQuery: {ex.Message}");
                throw;
            }
        }
    }
}
