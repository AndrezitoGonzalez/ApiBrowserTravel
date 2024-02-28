using MediatR;
using BrowserTravelApi.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BrowserTravelApi.Commands.Actualizar.ActualizarVehiculo
{
    public class ActualizarVehiculoCommandHandler : IRequestHandler<ActualizarVehiculoCommand>
    {
        private readonly ApplicationDbContext _context;

        public ActualizarVehiculoCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ActualizarVehiculoCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    var vehiculo = await _context.Vehiculos.FindAsync(request.id);

                    if (vehiculo == null)
                    {
                        // Manejar el caso en el que el país no se encuentra
                        //throw new NotFoundException(nameof(Pais), request.id);
                    }

                    // Actualizar las propiedades necesarias
                    vehiculo.modelo = request.modelo;
                    vehiculo.marca = request.marca;
                    vehiculo.fechaFabricacion = request.fechaFabricacion;
                    vehiculo.estado = request.estado;
                    vehiculo.localidad = request.localidad;

                    await _context.SaveChangesAsync(cancellationToken);

                    // Commit si todo fue exitoso
                    await transaction.CommitAsync(cancellationToken);

                    return Unit.Value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al actualizar vehículo: {ex}");

                    // Rollback en caso de error
                    await transaction.RollbackAsync(cancellationToken);

                    return Unit.Value;
                }
            }
        }
    }
}
