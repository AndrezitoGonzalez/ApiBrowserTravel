using BrowserTravelApi.Commands.Agregar.AgregarVehiculo;
using BrowserTravelApi.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BrowserTravelApi.Commands.Agregar.AgregarCliente
{
    public class AgregarClienteCommandHandler : IRequestHandler<AgregarClienteCommand, Guid>
    {
        private readonly ApplicationDbContext _context;

        public AgregarClienteCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(AgregarClienteCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    var nuevoCliente = new Cliente
                    {
                        id = Guid.NewGuid(),
                        nombre = request.nombre,
                    };

                    _context.Clientes.Add(nuevoCliente);
                    await _context.SaveChangesAsync(cancellationToken);

                    // Commit de la transacción si todo es exitoso
                    await transaction.CommitAsync(cancellationToken);

                    return nuevoCliente.id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al agregar Cliente: {ex}");

                    // Rollback en caso de excepción
                    await transaction.RollbackAsync(cancellationToken);
                    throw; // Relanza la excepción para que se maneje en un nivel superior si es necesario
                }
            }
        }
    }
}
