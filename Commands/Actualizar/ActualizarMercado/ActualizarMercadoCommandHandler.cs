using MediatR;
using BrowserTravelApi.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BrowserTravelApi.Commands.Actualizar.ActualizarMercado
{
    public class ActualizarMercadoCommandHandler : IRequestHandler<ActualizarMercadoCommand>
    {
        private readonly ApplicationDbContext _context;

        public ActualizarMercadoCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ActualizarMercadoCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    var mercado = await _context.Mercados.FindAsync(request.id);

                    if (mercado == null)
                    {
                        // Manejar el caso en el que el país no se encuentra
                        //throw new NotFoundException(nameof(Pais), request.id);
                    }

                    // Actualizar las propiedades necesarias
                    mercado.nombre = request.nombre;
                    mercado.estado = request.estado;

                    await _context.SaveChangesAsync(cancellationToken);

                    // Commit si todo fue exitoso
                    await transaction.CommitAsync(cancellationToken);

                    return Unit.Value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al actualizar mercado: {ex}");

                    // Rollback en caso de error
                    await transaction.RollbackAsync(cancellationToken);

                    return Unit.Value;
                }
            }
        }
    }
}
