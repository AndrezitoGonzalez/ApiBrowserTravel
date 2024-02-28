using MediatR;
using BrowserTravelApi.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BrowserTravelApi.Commands.Eliminar.EliminarVehiculo
{
    public class EliminarVehiculoCommandHandler : IRequestHandler<EliminarVehiculoCommand>
    {
        private readonly ApplicationDbContext _context;

        public EliminarVehiculoCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(EliminarVehiculoCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    var vehiculo = await _context.Vehiculos.FindAsync(request.id);

                    if (vehiculo == null)
                    {
                        // Manejar el caso en el que el vehículo no se encuentra
                        // throw new NotFoundException(nameof(vehiculo), request.id);
                    }

                    _context.Vehiculos.Remove(vehiculo);
                    await _context.SaveChangesAsync(cancellationToken);

                    // Commit de la transacción si todo es exitoso
                    await transaction.CommitAsync(cancellationToken);

                    return Unit.Value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al eliminar vehículo: {ex}");

                    // Rollback en caso de excepción
                    await transaction.RollbackAsync(cancellationToken);
                    throw; // Relanza la excepción para que se maneje en un nivel superior si es necesario
                }
            }
        }
    }
}
