using MediatR;
using BrowserTravelApi.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BrowserTravelApi.Commands.Actualizar.ActualizarLocalidad
{
    public class ActualizarLocalidadCommandHandler : IRequestHandler<ActualizarLocalidadCommand>
    {
        private readonly ApplicationDbContext _context;

        public ActualizarLocalidadCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ActualizarLocalidadCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    var localidad = await _context.Localidades.FindAsync(request.id);

                    if (localidad == null)
                    {
                        // Manejar el caso en el que el país no se encuentra
                        //throw new NotFoundException(nameof(Pais), request.id);
                    }

                    // Actualizar las propiedades necesarias
                    localidad.nombre = request.nombre;
                    localidad.mercado = request.mercado;
                    localidad.estado = request.estado;

                    await _context.SaveChangesAsync(cancellationToken);

                    // Commit si todo fue exitoso
                    await transaction.CommitAsync(cancellationToken);

                    return Unit.Value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al actualizar localidad: {ex}");

                    // Rollback en caso de error
                    await transaction.RollbackAsync(cancellationToken);

                    return Unit.Value;
                }
            }
        }
    }
}
