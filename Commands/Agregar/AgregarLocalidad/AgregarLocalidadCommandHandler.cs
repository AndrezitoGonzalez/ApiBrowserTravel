using BrowserTravelApi.Commands.Agregar.AgregarLocalidad;
using BrowserTravelApi.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BrowserTravelApi.Commands.Agregar.AgregarLocalidad
{
    public class AgregarLocalidadCommandHandler : IRequestHandler<AgregarLocalidadCommand, Guid>
    {
        private readonly ApplicationDbContext _context;

        public AgregarLocalidadCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(AgregarLocalidadCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    // Intenta convertir el string a un Guid
                    if (!Guid.TryParse(request.mercado, out Guid mercadoId))
                    {
                        throw new Exception("El formato del Id del mercado no es válido.");
                    }

                    var mercado = await _context.Mercados.FindAsync(mercadoId);

                    if (mercado == null)
                    {
                        // Lanza una excepción indicando que el mercado no se encuentra
                        throw new Exception("El mercado especificado no existe.");
                    }

                    var nuevaLocalidad = new Localidad
                    {
                        id = Guid.NewGuid(),
                        nombre = request.nombre,
                        mercado = mercadoId.ToString(),
                        estado = 1,
                    };

                    _context.Localidades.Add(nuevaLocalidad);
                    await _context.SaveChangesAsync(cancellationToken);

                    // Commit de la transacción si todo es exitoso
                    await transaction.CommitAsync(cancellationToken);

                    return nuevaLocalidad.id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al agregar localidad: {ex}");

                    // Rollback en caso de excepción
                    await transaction.RollbackAsync(cancellationToken);
                    throw; // Relanza la excepción para que se maneje en un nivel superior si es necesario
                }
            }
        }
    }
}
