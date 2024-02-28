using MediatR;
using BrowserTravelApi.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BrowserTravelApi.Commands.Actualizar.ActualizarCliente
{
    public class ActualizarClienteCommandHandler : IRequestHandler<ActualizarClienteCommand>
    {
        private readonly ApplicationDbContext _context;

        public ActualizarClienteCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ActualizarClienteCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    var cliente = await _context.Clientes.FindAsync(request.id);

                    if (cliente == null)
                    {
                        // Manejar el caso en el que el país no se encuentra
                        //throw new NotFoundException(nameof(Pais), request.id);
                    }

                    // Actualizar las propiedades necesarias
                    cliente.nombre = request.nombre;

                    await _context.SaveChangesAsync(cancellationToken);

                    // Commit si todo fue exitoso
                    await transaction.CommitAsync(cancellationToken);

                    return Unit.Value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al actualizar cliente: {ex}");

                    // Rollback en caso de error
                    await transaction.RollbackAsync(cancellationToken);

                    return Unit.Value;
                }
            }
        }
    }
}
