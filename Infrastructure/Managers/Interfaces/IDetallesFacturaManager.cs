using Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Dtos;

namespace Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Managers.Interfaces;

public interface IDetallesFacturaManager
{
    Task<IReadOnlyCollection<DetalleFacturaDto>> GetDetallesFacturaByFacturaIdAsync(int facturaId);
    Task<DetalleFacturaDto> CreateDetalleFacturaAsync(CreateDetalleFacturaDto createDetalleFacturaDto);
    Task UpdateDetalleFacturaAsync(int id, UpdateDetalleFacturaDto updateDetalleFacturaDto);
    Task DeleteDetalleFacturaAsync(int id);
}