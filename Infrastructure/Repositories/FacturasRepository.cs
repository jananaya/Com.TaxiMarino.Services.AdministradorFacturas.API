using Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Entities;
using Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Repositories.Interfaces;

namespace Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Repositories;

public class FacturasRepository : BaseRepository<Factura>, IFacturasRepository
{
    public FacturasRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}