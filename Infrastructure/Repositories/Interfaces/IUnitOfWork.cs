namespace Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task SaveAsync();
}