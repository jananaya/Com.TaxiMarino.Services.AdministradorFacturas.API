namespace Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Entities;

public class DetalleFactura
{
    public int Id { get; set; }
    public int FacturaId { get; set; }
    public string Producto { get; set; } = string.Empty;
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Subtotal { get; set; }

    public virtual Factura Factura { get; set; } = null!;
}
