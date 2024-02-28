using MediatR;
using BrowserTravelApi.Models;
using System.Threading;
using System.Threading.Tasks;

namespace BrowserTravelApi.Commands.Obtener.ObtenerLocalidad
{
    public class ObtenerLocalidadQueryHandler : IRequestHandler<ObtenerLocalidadQuery, ObtenerLocalidadQueryResponse>
    {
        private readonly ApplicationDbContext _context;

        public ObtenerLocalidadQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ObtenerLocalidadQueryResponse> Handle(ObtenerLocalidadQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var localidad = await _context.Localidades.FindAsync(request.id);
                var localidadDto = new ObtenerLocalidadQueryResponse();
                if (localidad == null)
                {
                    // Manejar el caso en el que el vehículo no se encuentra
                    return null;
                }
                else
                {
                    // Mapea los campos necesarios a tu objeto de transferencia de datos (DTO)
                    localidadDto = new ObtenerLocalidadQueryResponse
                    {
                        id = localidad.id,
                        nombre = localidad.nombre,
                        mercado = localidad.mercado,
                        estado = Convert.ToInt32(localidad.estado),
                    };
                }

                return localidadDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al manejar la consulta ObtenerLocalidadQuery: {ex.Message}");
                throw;
            }
        }
    }
}
