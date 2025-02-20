using Microsoft.EntityFrameworkCore;
using Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Managers;
using Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Managers.Interfaces;
using Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Repositories;
using Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Repositories.Interfaces;

namespace Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure;

public static class Extensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IFacturasRepository, FacturasRepository>();
        services.AddScoped<IDetallesFacturaRepository, DetallesFacturaRepository>();

        services.AddScoped<IFacturasManager, FacturasManager>();

        services.AddTransient<DbContext, AppDbContext>();
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("AppDbContext") ?? throw new ArgumentNullException("AppDbContext"))
                .LogTo(Console.WriteLine, LogLevel.Information);
            options.UseLazyLoadingProxies();
        });
    }
}
