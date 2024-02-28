using MediatR;
using BrowserTravelApi.Models;
using System.Threading;
using System.Threading.Tasks;

namespace BrowserTravelApi.Commands.Obtener.ObtenerVehiculo
{
    public class ObtenerVehiculoQueryHandler : IRequestHandler<ObtenerVehiculoQuery, ObtenerVehiculoQueryResponse>
    {
        private readonly ApplicationDbContext _context;

        public ObtenerVehiculoQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ObtenerVehiculoQueryResponse> Handle(ObtenerVehiculoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var vehiculo = await _context.Vehiculos.FindAsync(request.id);
                var vehiculoDto = new ObtenerVehiculoQueryResponse();
                if (vehiculo == null)
                {
                    // Manejar el caso en el que el vehículo no se encuentra
                    return null;
                }
                else
                {
                    // Mapea los campos necesarios a tu objeto de transferencia de datos (DTO)
                    vehiculoDto = new ObtenerVehiculoQueryResponse
                    {
                        id = vehiculo.id,
                        modelo = Convert.ToInt32(vehiculo.modelo),
                        marca = vehiculo.marca,
                        fechaFabricacion = Convert.ToDateTime(vehiculo.fechaFabricacion),
                        estado = Convert.ToInt32(vehiculo.estado),
                        localidad = vehiculo.localidad
                    };
                }

                return vehiculoDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al manejar la consulta ObtenerVehiculoQuery: {ex.Message}");
                throw;
            }
        }
    }
}
