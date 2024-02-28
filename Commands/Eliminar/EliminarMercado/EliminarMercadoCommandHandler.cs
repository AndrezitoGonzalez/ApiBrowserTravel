using MediatR;
using BrowserTravelApi.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BrowserTravelApi.Commands.Eliminar.EliminarMercado
{
    public class EliminarMercadoCommandHandler : IRequestHandler<EliminarMercadoCommand>
    {
        private readonly ApplicationDbContext _context;

        public EliminarMercadoCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(EliminarMercadoCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    var mercado = await _context.Mercados.FindAsync(request.id);

                    if (mercado == null)
                    {
                        // Manejar el caso en el que el mercado no se encuentra
                        // throw new NotFoundException(nameof(mercado), request.id);
                    }

                    _context.Mercados.Remove(mercado);
                    await _context.SaveChangesAsync(cancellationToken);

                    // Commit de la transacción si todo es exitoso
                    await transaction.CommitAsync(cancellationToken);

                    return Unit.Value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al eliminar mercado: {ex}");

                    // Rollback en caso de excepción
                    await transaction.RollbackAsync(cancellationToken);
                    throw; // Relanza la excepción para que se maneje en un nivel superior si es necesario
                }
            }
        }
    }
}
