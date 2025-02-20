using Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Entities;
using Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Repositories;

public class DetallesFacturaRepository : BaseRepository<DetalleFactura>, IDetallesFacturaRepository
{
    public DetallesFacturaRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<IReadOnlyCollection<DetalleFactura>> GetDetallesFacturaByFacturaIdAsync(int facturaId)
    {
        return await _appDbContext.DetallesFactura
            .Where(df => df.FacturaId == facturaId)
            .ToListAsync();
    }
}