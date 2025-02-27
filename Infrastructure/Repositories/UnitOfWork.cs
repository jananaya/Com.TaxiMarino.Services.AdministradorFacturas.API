using Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Repositories.Interfaces;

namespace Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appDbContext;

    public UnitOfWork(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task SaveAsync()
    {
        await _appDbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _appDbContext.Dispose();
    }
}