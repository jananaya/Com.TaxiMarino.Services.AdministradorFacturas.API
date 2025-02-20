namespace Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Dtos;

public class DetalleFacturaDto : CreateDetalleFacturaDto
{
    public int Id { get; set; }
    public decimal Subtotal { get; set; }
}