namespace Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Entities;

public class Factura
{
    public int Id { get; set; }
    public string Cliente { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }

    public virtual List<DetalleFactura> Detalles { get; set; } = new();
}
