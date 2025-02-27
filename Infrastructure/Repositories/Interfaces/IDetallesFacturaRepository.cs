using Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Entities;

namespace Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Repositories.Interfaces;

public interface IDetallesFacturaRepository : IBaseRepository<DetalleFactura>
{
    Task<IReadOnlyCollection<DetalleFactura>> GetDetallesFacturaByFacturaIdAsync(int facturaId);
}