namespace Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Repositories.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetAsync(int id);
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
    Task SaveAsync();
}