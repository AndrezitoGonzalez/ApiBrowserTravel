using BrowserTravelApi.Commands.Agregar.AgregarVehiculo;
using BrowserTravelApi.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BrowserTravelApi.Commands.Agregar.AgregarMercado
{
    public class AgregarMercadoCommandHandler : IRequestHandler<AgregarMercadoCommand, Guid>
    {
        private readonly ApplicationDbContext _context;

        public AgregarMercadoCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(AgregarMercadoCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    var nuevoMercado = new Mercado
                    {
                        id = Guid.NewGuid(),
                        nombre = request.nombre,
                        estado = 1,
                    };

                    _context.Mercados.Add(nuevoMercado);
                    await _context.SaveChangesAsync(cancellationToken);

                    // Commit de la transacción si todo es exitoso
                    await transaction.CommitAsync(cancellationToken);

                    return nuevoMercado.id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al agregar mercado: {ex}");

                    // Rollback en caso de excepción
                    await transaction.RollbackAsync(cancellationToken);
                    throw; // Relanza la excepción para que se maneje en un nivel superior si es necesario
                }
            }
        }
    }
}
