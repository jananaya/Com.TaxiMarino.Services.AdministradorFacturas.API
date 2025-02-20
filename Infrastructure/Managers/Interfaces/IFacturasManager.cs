using Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Dtos;

namespace Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Managers.Interfaces;

public interface IFacturasManager
{
    Task<IReadOnlyCollection<FacturaDto>> GetFacturasAsync();
    Task<FacturaDto> CreateFacturaAsync(CreateFacturaDto facturaDto);
    Task UpdateFacturaAsync(int id, CreateFacturaDto facturaDto);
    Task DeleteFacturaAsync(int id);
}