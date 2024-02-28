using MediatR;
using BrowserTravelApi.Models;
using System.Threading;
using System.Threading.Tasks;

namespace BrowserTravelApi.Commands.Obtener.ObtenerCliente
{
    public class ObtenerClienteQueryHandler : IRequestHandler<ObtenerClienteQuery, ObtenerClienteQueryResponse>
    {
        private readonly ApplicationDbContext _context;

        public ObtenerClienteQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ObtenerClienteQueryResponse> Handle(ObtenerClienteQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cliente = await _context.Clientes.FindAsync(request.id);
                var clienteDto = new ObtenerClienteQueryResponse();
                if (cliente == null)
                {
                    // Manejar el caso en el que el vehículo no se encuentra
                    return null;
                }
                else
                {
                    // Mapea los campos necesarios a tu objeto de transferencia de datos (DTO)
                    clienteDto = new ObtenerClienteQueryResponse
                    {
                        id = cliente.id,
                        nombre = cliente.nombre,
                    };
                }

                return clienteDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al manejar la consulta ObtenerClienteQuery: {ex.Message}");
                throw;
            }
        }
    }
}
