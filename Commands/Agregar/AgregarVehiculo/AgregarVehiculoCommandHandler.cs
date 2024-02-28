using BrowserTravelApi.Commands.Agregar.AgregarVehiculo;
using BrowserTravelApi.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BrowserTravelApi.Commands.Agregar.AgregarVehiculo
{
    public class AgregarVehiculoCommandHandler : IRequestHandler<AgregarVehiculoCommand, Guid>
    {
        private readonly ApplicationDbContext _context;

        public AgregarVehiculoCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(AgregarVehiculoCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    // Intenta convertir el string a un Guid
                    if (!Guid.TryParse(request.localidad, out Guid localidadId))
                    {
                        throw new Exception("El formato del Id de la localidad no es válido.");
                    }

                    var localidad = await _context.Localidades.FindAsync(localidadId);

                    if (localidad == null)
                    {
                        // Lanza una excepción indicando que la localidad no se encuentra
                        throw new Exception("La localidad especificada no existe.");
                    }

                    var nuevoVehiculo = new Vehiculo
                    {
                        id = Guid.NewGuid(),
                        modelo = request.modelo,
                        marca = request.marca,
                        fechaFabricacion = request.fechaFabricacion,
                        estado = 1,
                        localidad = localidadId.ToString(),
                    };

                    _context.Vehiculos.Add(nuevoVehiculo);
                    await _context.SaveChangesAsync(cancellationToken);

                    // Commit de la transacción si todo es exitoso
                    await transaction.CommitAsync(cancellationToken);

                    return nuevoVehiculo.id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al agregar vehículo: {ex}");

                    // Rollback en caso de excepción
                    await transaction.RollbackAsync(cancellationToken);
                    throw; // Relanza la excepción para que se maneje en un nivel superior si es necesario
                }
            }
        }
    }
}
