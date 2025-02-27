using Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<Factura> Facturas { get; set; }
    public DbSet<DetalleFactura> DetallesFactura { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DetalleFactura>()
            .HasOne(d => d.Factura)
            .WithMany(f => f.Detalles)
            .HasForeignKey(d => d.FacturaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
