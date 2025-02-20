namespace Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Dtos;

public class FacturaDto : CreateFacturaDto
{
    public int Id { get; set; }
    public decimal Total { get; set; }
}