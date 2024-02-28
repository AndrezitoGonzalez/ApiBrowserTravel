using MediatR;
using BrowserTravelApi.Models;
using System.Threading;
using System.Threading.Tasks;

namespace BrowserTravelApi.Commands.Obtener.ObtenerMercado
{
    public class ObtenerMercadoQueryHandler : IRequestHandler<ObtenerMercadoQuery, ObtenerMercadoQueryResponse>
    {
        private readonly ApplicationDbContext _context;

        public ObtenerMercadoQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ObtenerMercadoQueryResponse> Handle(ObtenerMercadoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var mercado = await _context.Mercados.FindAsync(request.id);
                var mercadoDto = new ObtenerMercadoQueryResponse();
                if (mercado == null)
                {
                    // Manejar el caso en el que el vehículo no se encuentra
                    return null;
                }
                else
                {
                    // Mapea los campos necesarios a tu objeto de transferencia de datos (DTO)
                    mercadoDto = new ObtenerMercadoQueryResponse
                    {
                        id = mercado.id,
                        nombre = mercado.nombre,
                        estado = Convert.ToInt32(mercado.estado),
                    };
                }

                return mercadoDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al manejar la consulta ObtenerQuery: {ex.Message}");
                throw;
            }
        }
    }
}
