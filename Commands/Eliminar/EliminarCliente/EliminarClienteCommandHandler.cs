using MediatR;
using BrowserTravelApi.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BrowserTravelApi.Commands.Eliminar.EliminarCliente
{
    public class EliminarClienteCommandHandler : IRequestHandler<EliminarClienteCommand>
    {
        private readonly ApplicationDbContext _context;

        public EliminarClienteCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(EliminarClienteCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    var cliente = await _context.Clientes.FindAsync(request.id);

                    if (cliente == null)
                    {
                        // Manejar el caso en el que el mercado no se encuentra
                        // throw new NotFoundException(nameof(mercado), request.id);
                    }

                    _context.Clientes.Remove(cliente);
                    await _context.SaveChangesAsync(cancellationToken);

                    // Commit de la transacción si todo es exitoso
                    await transaction.CommitAsync(cancellationToken);

                    return Unit.Value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al eliminar cliente: {ex}");

                    // Rollback en caso de excepción
                    await transaction.RollbackAsync(cancellationToken);
                    throw; // Relanza la excepción para que se maneje en un nivel superior si es necesario
                }
            }
        }
    }
}
