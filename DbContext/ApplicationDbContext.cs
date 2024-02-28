// Data/ApplicationDbContext.cs
using BrowserTravelApi.Models;
using Microsoft.EntityFrameworkCore;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Vehiculo> Vehiculos { get; set; }
    public DbSet<Localidad> Localidades { get; set; }
    public DbSet<Mercado> Mercados { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Reserva> Reservas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vehiculo>().ToTable("Vehiculo", "BT").HasKey(v => v.id);
        modelBuilder.Entity<Localidad>().ToTable("Localidad", "BT").HasKey(l => l.id);
        modelBuilder.Entity<Mercado>().ToTable("Mercado", "BT").HasKey(m => m.id);
        modelBuilder.Entity<Cliente>().ToTable("Cliente", "BT").HasKey(c => c.id);
        modelBuilder.Entity<Reserva>().ToTable("Reserva", "BT").HasKey(r => r.id);

        base.OnModelCreating(modelBuilder);

    }
}
