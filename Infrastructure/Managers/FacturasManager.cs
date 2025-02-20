using Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Dtos;
using Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Entities;
using Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Managers.Interfaces;
using Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Repositories.Interfaces;
using Com.TaxiMarino.Services.AdministradorFacturas.API.Utils;
using Com.TaxiMarino.Services.AdministradorFacturas.API.Utils.Constants;

namespace Com.TaxiMarino.Services.AdministradorFacturas.API.Infrastructure.Managers;

public class FacturasManager : IFacturasManager
{
    private readonly IFacturasRepository _facturasRepository;

    public FacturasManager(IFacturasRepository facturasRepository)
    {
        _facturasRepository = facturasRepository;
    }

    public async Task<IReadOnlyCollection<FacturaDto>> GetFacturasAsync()
    {
        var facturas = await _facturasRepository.GetAllAsync();
        return facturas.Select(MapFacturaToDto).OrderBy(dto => dto.Cliente).ToList();
    }

    public async Task<FacturaDto> CreateFacturaAsync(CreateFacturaDto facturaDto)
    {
        var factura = new Factura
        {
            Fecha = facturaDto.Fecha.ParseDate(),
            Cliente = facturaDto.Cliente,
            Total = facturaDto.Total
        };

        _facturasRepository.Add(factura);
        await _facturasRepository.SaveAsync();

        return MapFacturaToDto(factura);
    }

    public async Task DeleteFacturaAsync(int id)
    {
        var factura = await _facturasRepository.GetAsync(id);

        if (factura is null)
        {
            throw new KeyNotFoundException(ValidationMessages.FacturaNotFound);
        }

        _facturasRepository.Remove(factura);
        await _facturasRepository.SaveAsync();
    }

    public async Task UpdateFacturaAsync(int id, CreateFacturaDto facturaDto)
    {
        var factura = await _facturasRepository.GetAsync(id);

        if (factura is null)
        {
            throw new KeyNotFoundException(ValidationMessages.FacturaNotFound);
        }

        factura.Fecha = facturaDto.Fecha.ParseDate();
        factura.Cliente = facturaDto.Cliente;
        factura.Total = facturaDto.Total;

        _facturasRepository.Update(factura);
        await _facturasRepository.SaveAsync();
    }

    private static FacturaDto MapFacturaToDto(Factura factura)
    {
        return new FacturaDto
        {
            Id = factura.Id,
            Fecha = factura.Fecha.ToFormattedString(),
            Cliente = factura.Cliente,
            Total = factura.Total
        };
    }
}